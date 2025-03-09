using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public iscllose bool_script;

    public GameObject ant;
    public Slider slid;
    public Gradient gradient;
    public Image fill; 

    public Text ordersCompletedText;
    public Text reactionRateText;
    public Text batteryText; // temporary. probably display this in world?
    public Text coolantText;
    public Text fuelRodText;

    public int ordersCompleted = 0; // number of full batteries delivered.
    public float reactionRate = 0; // from 0 to 100%
    public int controlRodState = 1; // 0 = up, 1 = middle, 2 = down
    // control rod controls whether reaction rate increases or decreases
    public float batteryBar = 0; // amount of energy produced from 0 to 100%
    public float coolantTemp = 10; // coolant temperature
    public float fuelRodPercent = 100; // fuel rod percentage left

    public float energyProduction = 0;
    // To produce energy, fuel must not be empty and coolant must be cool enough.
    // Amount of energy produced is higher if reaction rate is higher.

    public float fuelRodUsePerSec = 3; // Use 3% per second, runs out in ~30 seconds
    public float coolantResetTemp = 10; // temperature when coolant is reset
    public float coolantHighTemp = 60; // temperature when coolant is too hot
    public float coolantTempIncreasePerSec = 1;
    public float reactionChangeControlRodUp = 4;
    public float reactionChangeControlRodMiddle = 1;
    public float reactionChangeControlRodDown = -4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update fuel
        fuelRodPercent -= fuelRodUsePerSec * Time.deltaTime;
        if (fuelRodPercent <= 0) {
            fuelRodPercent = 0;
        }
        updateFuelWarning();

        // update coolant temperature
        coolantTemp += coolantTempIncreasePerSec * Time.deltaTime;
        updateCoolantWarning();

        // update reaction rate
        if (controlRodState == 0) {
            reactionRate += 3 * Time.deltaTime;
        } else if (controlRodState == 1) {
            reactionRate += 0.5f * Time.deltaTime;
        } else {
            reactionRate += -3 * Time.deltaTime;
        }
        if (reactionRate < 0) reactionRate = 0;
        if (reactionRate > 100) reactionRate = 100;

        // update energy production rate
        if (fuelRodPercent > 0 && coolantTemp < coolantHighTemp) {
            // produce energy based on reaction rate
            energyProduction = getEnergyProductionFromReactionRate(reactionRate);
        } else {
            // don't produce energy
            energyProduction = 0;
        }

        reactionRateText.text = "Reaction rate: " + ((int)reactionRate) + "%  (" + (10*energyProduction) + " MJ)";

        // update battery based on energy production
        batteryBar += energyProduction * Time.deltaTime;
        if (batteryBar > 100) {
            batteryBar = 100;
        }
        

        if ((batteryBar > 90) && (Input.GetKeyDown("space"))){
            bool_script = ant.GetComponent<iscllose>();
            if (bool_script.isclose == true)
            {
                ordersCompleted++;

                batteryBar = 0;
            }


        }
        batteryText.text = "Battery: " + (int)batteryBar + "%";

        ordersCompletedText.text = "Orders completed: " + ordersCompleted;
        slid.value = coolantTemp;
        fill.color = gradient.Evaluate(slid.normalizedValue);
    }

    float getEnergyProductionFromReactionRate(float rate) {
        if (rate < 10) {
            return 0;
        } else if (rate < 50) {
            return 1;
        } else if (rate < 70) {
            return 2;
        } else if (rate < 80) {
            return 3;
        } else {
            return 5;
        }
    }

    void updateFuelWarning() {
        if (fuelRodPercent <= 0) {
            fuelRodText.text = "Warning: Fuel empty";
        } else {
            fuelRodText.text = "";
        }

    }
    void updateCoolantWarning() {
        if (coolantTemp >= coolantHighTemp) {
            coolantText.text = "Warning: Coolant temperature too high";
        } else {
            coolantText.text = "";
        }

    }
    
}

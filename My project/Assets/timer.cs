using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timwecontrol;
    float currentTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timwecontrol.text = "00";
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timwecontrol.text = currentTime.ToString("#.00");
    }
}

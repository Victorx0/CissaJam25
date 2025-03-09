using UnityEngine;

public class ControlRodUpScript : MonoBehaviour, IInteractable
{
    public GameLogicScript gamelogic;

    public void Interact()
    {
        gamelogic.controlRodState = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using TMPro;

public class changeTempText : MonoBehaviour
{
    public TextMeshPro temperatureText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        temperatureText.text = "100/ 100";  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.UI;
public class reacter : MonoBehaviour
{
    public Slider slid;

    public float currentTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;

        slid.value = currentTime;

    }
}

using UnityEngine;

public class isfixedd : MonoBehaviour
{
    public bool isfixed = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isfixed = true;

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            isfixed = false;

        }

    }
}

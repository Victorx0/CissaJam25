using UnityEngine;

public class iscllose : MonoBehaviour
{
    public bool isclose = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") {
            isclose = true;

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            isclose = false;

        }

    }
}

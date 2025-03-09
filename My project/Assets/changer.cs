using UnityEngine;
using UnityEngine.SceneManagement;


public class changer : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

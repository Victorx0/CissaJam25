using UnityEngine;
using UnityEngine.SceneManagement;


public class movmentoftext3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timeLeft = 0;

    private Animation anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim.Play();

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft >= 33)
        {
            SceneManager.LoadScene(0);
        }



    }
}

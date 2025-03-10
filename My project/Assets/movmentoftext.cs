using UnityEngine;
using UnityEngine.SceneManagement;


public class movmentoftext : MonoBehaviour
{
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
        if (timeLeft >= 20)
        {
            SceneManager.LoadScene(2);
        }



    }
}

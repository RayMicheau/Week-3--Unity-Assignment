using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    [Header("Reference to Player HP")]
    public PlayerHealth playerHealth;
    Animator anim;

    //Floats for timer and reset timer
    float restartTimer;
    float timeToRestart = 5f;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentHP <= 0)
        {
 
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;
            if(restartTimer >= timeToRestart)
            {
                Application.LoadLevel(Application.loadedLevel);
            }

        }
    }
}

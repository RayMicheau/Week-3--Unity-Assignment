using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {
    public float health = 100f;
    public float resetAfterDeathTimer = 5f;
    public AudioClip deathClip;

    private float timer;
    private bool playerDead;
    private FirstPersonController firstPersonController;

    void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if(health <= 0f)
        {
            if (!playerDead)
            {
                PlayerDeath();
            }
            else
            {
               PlayerDead();
            }
        }
    }
    void PlayerDeath()
    {
        playerDead = true;

        AudioSource.PlayClipAtPoint(deathClip, transform.position);
    }

    void PlayerDead()
    {
        firstPersonController.enabled = false;
        
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log(health);
    }
}

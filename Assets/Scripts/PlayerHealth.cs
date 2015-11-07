using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {
    public float health = 100f;
    public float resetAfterDeathTimer = 5f;
    public AudioClip deathClip;
    public Text textfield;
    private float timer;
    private bool playerDead;
    private FirstPersonController firstPersonController;
    public Camera playerCam;
    public Camera deathCam;

    

    void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        UpdateHealth();
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
        
        //AudioSource.PlayClipAtPoint(deathClip, transform.position);
    }

    void UpdateHealth()
    {
        textfield.text = "Health: " + health.ToString();
    }

    void PlayerDead()
    {
        playerCam.enabled = false;
        deathCam.enabled = true;
        firstPersonController.enabled = false;
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log(health);
        UpdateHealth();
    }
}

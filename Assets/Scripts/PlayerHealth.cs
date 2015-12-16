using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {
    public float health = 100;
    public float currentHP;
    public float resetAfterDeathTimer = 5f;

    public Slider healthSlider;
    public AudioClip deathClip;
    public Image damageImage;
    public Image HPImage;

    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    private float timer;
    private bool isDead;
    private bool damaged;

    private FirstPersonController firstPersonController;
    AudioSource playerAudio;

    public Shooting playerShooting;

    public Camera playerCam;
    public Camera deathCam;



    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        firstPersonController = GetComponent<FirstPersonController>();

       // damageImage = GetComponent<Image>();
        currentHP = health;
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
            damaged = false;
    }

    void PlayerDead()
    {
        isDead = true;

        AudioSource.PlayClipAtPoint(deathClip, transform.position);

        //Disabling player things
        playerCam.enabled = false;
        deathCam.enabled = true;

        firstPersonController.enabled = false;
        playerShooting.enabled = false;
        healthSlider.enabled = false;

        HPImage.enabled = false;
        damageImage.enabled = false;
        playerAudio.enabled = false;
    }

    public void TakeDamage(float dmg)
    {
        damaged = true;
        currentHP -= dmg;
        healthSlider.value = currentHP;

        if(currentHP <= 0 && !isDead)
        {
            PlayerDead();
        }

        Debug.Log(health);
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public float startHP = 100;
    public float currHP;
    public float hpStat;
    public float sinkSpd = 3.0f;
    private float kills = 0;
    public AudioClip deathClip;

    //References
    Animator anim;
    CapsuleCollider capsuleColl;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    private EnemyAI enAI;

    public Image HPBar;

    //bools
    bool isDead;
    bool isSinking;

    void Awake()
    {
        //Prep references
        enAI = GetComponent<EnemyAI>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleColl = GetComponent<CapsuleCollider>();
        hitParticles = GetComponentInChildren<ParticleSystem>();

        //set currHP to startHP when enemy spawns in
        currHP = startHP;
    }

    void Update()
    {
        //If the enemy should sink
        if (isSinking)
        {
            capsuleColl.enabled = false;
            //Move them down by the sinkspeed
            transform.Translate(-Vector3.up * sinkSpd * Time.deltaTime);
        }
    }

    //Can be used for raycasting, when/if implemented
    //TODO: raycast weapon
    public void TakeDamage(float dmg, Vector3 hitPoint)
    {
        //if dead already
        if (isDead)
            //exit, damage isnt needed
            return;

        currHP -= dmg;
        hitParticles.transform.position = hitPoint;

        UpdateUI();

        hitParticles.Play();

        if (currHP <= 0)
        {
            Dead();
        }
    }

    public void TakeDamage(float dmg)
    {
        //if dead already
        if (isDead)
            //exit, damage isnt needed
            return;

        currHP -= dmg;

        UpdateUI();

        hitParticles.Play();

        if (currHP <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
        enAI.enabled = false;
        capsuleColl.isTrigger = true;

        StartSinking();

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }


    public void UpdateUI()
    {
        //Should be updating and shrinking the HP Image
        hpStat = currHP / startHP;
        HPBar.rectTransform.localScale = new Vector3(hpStat, HPBar.rectTransform.localScale.y, HPBar.rectTransform.localScale.z);
    }

    public void StartSinking()
    {
        isSinking = true;

        Destroy(gameObject, 2f);
    }

}
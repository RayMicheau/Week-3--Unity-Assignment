using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public enum AIType
    {
        CHASER,
        SHOOTER
    }

    Animator anim;
    AIType aiType;
    GameObject player;
    Transform playerTrans;
    PlayerHealth playerHP;
    EnemyHealth enemyHP;
    NavMeshAgent agent;

    public Transform shootPoint;
    public Rigidbody projectile;


    //Floats
    public float dmg = 5f;
    public float playerDistance;
    public float rotationDamping;
    public float moveSpeed;
    public float bulletSpeed;
    public float BulletTime;


    public float timeBetweenAttack = 0.5f;
    float timer;

    public bool startMovement;
    bool playerInRange;

    public int rand;

    private bool shooting;

    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.transform;
        playerHP = player.GetComponent<PlayerHealth>();
        enemyHP = GetComponent<EnemyHealth>();

        rand = Random.Range(0, 2);
        if(rand < 1)
        {
            aiType = AIType.SHOOTER;
        }
        else
        {
            aiType = AIType.CHASER;
        }

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if( enemyHP.currHP > 0 && playerHP.currentHP > 0)
        {
            agent.SetDestination(playerTrans.position);
            agent.stoppingDistance = 3;
            playerDistance = Vector3.Distance(playerTrans.position, transform.position);
            
            if(playerDistance < 7.0f && enemyHP.currHP > 0 && aiType == AIType.SHOOTER)
            {
                agent.Stop();
                if (!shooting)
                {
                    InvokeRepeating("Shoot", 0, 1);
                    shooting = true;
                }
            }
            else
            {
                CancelInvoke("Shoot");
                shooting = false;
                agent.Resume();
            }

            if (playerDistance < 3.0f && enemyHP.currHP > 0 && aiType == AIType.CHASER)
            {
                agent.Stop();
                if(timer > timeBetweenAttack)
                {
                    Attack();
                }
            }
            else
            {
                agent.Resume();
            }
        }
        else
        {
            agent.enabled = false;
        }
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(playerTrans.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    void chasePlayer()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (enemyHP.currHP <= 0)
            return;

        Rigidbody enemyProj = Instantiate(projectile, shootPoint.position, shootPoint.rotation) as Rigidbody;
        enemyProj.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        Destroy(enemyProj.gameObject, 1.0f);
    }

    void Attack()
    {
        timer = 0f;
        if(playerHP.currentHP > 0)
        {
            playerHP.TakeDamage(dmg);
        }
    }
}

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Transform player;
    public Transform shootPoint;
    public float playerDistance;
    public float rotationDamping;
    public float moveSpeed;
    public Rigidbody projectile;
    public float bulletSpeed;
    public float BulletTime;
    public bool startMovement;

    private bool shooting;
	// Use this for initialization
	void Start ()
    {
        shooting = false;
        startMovement = true;
    }
	
	// Update is called once per frame
	void Update () {
        playerDistance = Vector3.Distance(player.position, transform.position);
        if(playerDistance < 15.0f) {
            LookAtPlayer();
        }
        if (playerDistance < 12.0f  && startMovement && playerDistance > 4.0f) {
            chasePlayer();
        }
        if (playerDistance < 7.0) {
            if (!shooting) { 
                InvokeRepeating("Shoot", 0, 1);
                shooting = true;
            }

        }
        else {
            CancelInvoke("Shoot");
            shooting = false;
        }

	}

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    void chasePlayer()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Rigidbody enemyProj = Instantiate(projectile, shootPoint.position, shootPoint.rotation) as Rigidbody;
        enemyProj.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        Destroy(enemyProj.gameObject, 1.0f);
    }
}

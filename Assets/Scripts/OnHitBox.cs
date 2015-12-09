using UnityEngine;
using System.Collections;

public class OnHitBox : MonoBehaviour {

    private GameObject player;
    private GameObject enemy;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    public float damageNum = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemies");
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Box(Clone)")
        {
            //Uncomment to destroy boxes on collision
            //Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damageNum);
            Debug.Log("Hit Player");
        }
        else if(col.gameObject.tag == "Enemies")
        {
            enemyHealth.TakeDamage((damageNum));
            Debug.Log(damageNum);
        }
    }

    void OnCollisionStay(Collision col)
    {
        //Debug.Log("Staying");
    }

    void OnCollisionExit(Collision col)
    {
        //Debug.Log("Exiting");
    }
    
}

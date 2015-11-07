using UnityEngine;
using System.Collections;

public class OnHitBox : MonoBehaviour {
    private GameObject player;
    private PlayerHealth playerHealth;
    float damageNum = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
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
    }

    void OnCollisionStay(Collision col)
    {
        Debug.Log("Staying");
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("Exiting");
    }
    
}

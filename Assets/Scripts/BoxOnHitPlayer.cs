using UnityEngine;
using System.Collections;

public class BoxOnHitPlayer : MonoBehaviour {

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
        if (col.gameObject.tag == "Player"  ) {
            float damage = damageNum * col.relativeVelocity.magnitude;
            playerHealth.TakeDamage(damage);
            Debug.Log("Hit Player");
        }
    }
}

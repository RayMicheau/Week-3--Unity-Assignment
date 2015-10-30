using UnityEngine;
using System.Collections;

public class BoxOnHitPlayer : MonoBehaviour {

    private PlayerHealth playerHealth;
    float damageNum = 2f;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            float damage = damageNum * col.relativeVelocity.magnitude;
            playerHealth.TakeDamage(damage);
        }
    }
}

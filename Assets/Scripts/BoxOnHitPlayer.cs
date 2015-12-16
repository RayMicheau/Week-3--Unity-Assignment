using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BoxOnHitPlayer : MonoBehaviour {

    private GameObject player;
    private PlayerHealth playerHealth;
    public Text scoreText;



    int damageNum = 5;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player") {
            int damage = (int)(damageNum * col.relativeVelocity.magnitude);
            playerHealth.TakeDamage(damage);
            Debug.Log("Hit Player");
        }
    }
}

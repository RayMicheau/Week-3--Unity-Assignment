using UnityEngine;
using System.Collections;

public class OnHitBox : MonoBehaviour {
    //Damage number variables
    public float damageNum;
    public float enemyDam;

    //Only for damage dealing based on what's hit
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Box(Clone)")
        {
            //Uncomment to destroy boxes on collision
            //Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDam);
            Debug.Log("Hit Player");
        }
        else if(col.gameObject.tag == "Enemies")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageNum);
            Destroy(this.gameObject);
            Debug.Log("Hit Enemy");
        }
    }
}

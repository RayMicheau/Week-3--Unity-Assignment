using UnityEngine;
using System.Collections;

public class BoxOnHit : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Box(Clone)")
        {
            //Uncomment to destroy boxes on collision
            //Destroy(col.gameObject);
        }
    }

}

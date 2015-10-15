using UnityEngine;
using System.Collections;

public class OnHitBox : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Box(Clone)")
        {
            //Uncomment to destroy boxes on collision
            //Destroy(col.gameObject);
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

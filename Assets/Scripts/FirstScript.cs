using UnityEngine;
using System.Collections;

public class FirstScript : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody projectile;
    public Vector3 bulletCount;
    public Light flashlight;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        FlickLights();
        //modify x, y, z numbers in editor to change how many bullets are fired in a grid pattern
        if (Input.GetButtonDown("Fire1"))
        {
            for (int x = 0; x < bulletCount.x; x++)
            {
                for (int y = 0; y < bulletCount.y; y++)
                {
                    for (int z = 0; z < bulletCount.z; z++)
                    {
                        Rigidbody instantiateProj = Instantiate(projectile, transform.position + transform.TransformDirection(x, y, z), transform.rotation) as Rigidbody;
                        instantiateProj.position = transform.position + new Vector3(x * 1.1f, y * 1.1f, z * 1.1f);
                        instantiateProj.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                        Debug.Log("Pew!");
                        Destroy(instantiateProj.gameObject, 1.0f);
                    }
                }
            }
        }
    }

    void FlickLights(){
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashlight.enabled)
            {
                flashlight.enabled = true;
            }
            else if (flashlight.enabled) {
                 flashlight.enabled = false;
            }
        }
    }
}
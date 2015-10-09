using UnityEngine;
using System.Collections;

public class FirstScript : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody projectile;
    public Rigidbody cubeBits;
    public Vector3 wallCount;
    public Vector3 bulletCount;
    // Use this for initialization
    void Start()
    {
    /*
        //Loops through X, Y, Z instantiating and moving the positions of each to make a cube or wall
        for (int x = 0; x < wallCount.x; x++)
        {
            for (int y = 0; y < wallCount.y; y++)
            {
                for (int z = 0; z < wallCount.z; z++)
                {
                    Rigidbody instantiateCubes = Instantiate(cubeBits, transform.position + new Vector3(x * 1.1F, y * 1.1f, z * 1.1f), transform.rotation) as Rigidbody;
                }
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
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
}
using UnityEngine;
using System.Collections;

public class FirstScript : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody projectile;
    public Rigidbody cubeBits;
    public Vector3 wallCount;
    public Vector3 bulletCount;

    private int count;
    // Use this for initialization
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Cube(Clone)"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
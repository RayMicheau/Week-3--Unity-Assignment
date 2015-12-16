using UnityEngine;
using System.Collections;

public class CubeWall : MonoBehaviour
{
    [SerializeField]
    Rigidbody cubeBits;
    [SerializeField]
    Vector3 pos;

    Rigidbody instantiateCubes;
    // Use this for initialization
    void Start()
    {
        //Loops through X, Y, Z instantiating and moving the positions of each to make a cube or wall
        for (int x = 0; x < pos.x; x++)
        {
            for (int y = 0; y < pos.y; y++)
            {
                for (int z = 0; z < pos.z; z++)
                {
                    instantiateCubes = Instantiate(cubeBits, transform.position + new Vector3(x, y, z), transform.rotation) as Rigidbody;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnBoxes();
    }


}

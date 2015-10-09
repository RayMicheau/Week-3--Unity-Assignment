using UnityEngine;
using System.Collections;

public class CubeWall : MonoBehaviour {
    public Rigidbody cubeBits;
    public Vector3 pos;
	// Use this for initialization
	void Start () {
        //Loops through X, Y, Z instantiating and moving the positions of each to make a cube or wall
        for (int x = 0; x < pos.x; x++){
            for (int y = 0; y < pos.y; y++) {
                for(int z = 0; z < pos.z; z++) { 
                    Rigidbody instantiateCubes = Instantiate(cubeBits, transform.position + new Vector3(x * 1.11f, y * 1.1f, z * 1.11f), transform.rotation) as Rigidbody;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

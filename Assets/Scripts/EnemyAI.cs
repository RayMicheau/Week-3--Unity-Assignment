using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public Transform player;
    public float playerDistance;
    public float rotationDamping;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerDistance = Vector3.Distance(player.position, transform.position);
	}
}

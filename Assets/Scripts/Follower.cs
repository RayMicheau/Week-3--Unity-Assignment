using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour
{
    [SerializeField]
    Transform leader;
    [SerializeField]
    Transform follower;


    [SerializeField]
    float speed;
    [SerializeField]
    float chaseRange;

    private float range;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(follower.position, leader.position);

        if (range <= chaseRange)
        {
            LookAtPlayer();
        }

    }
    void LookAtPlayer()
    {
        follower.LookAt(leader);
        follower.Translate(speed * Vector3.forward * Time.deltaTime);
    }
}
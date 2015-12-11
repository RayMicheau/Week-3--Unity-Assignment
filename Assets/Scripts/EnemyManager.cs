using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{


    public PlayerHealth playerHealth;
    public GameObject enemy;

    [Range(0.0f, 10.0f)]
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHP <= 0f)
            return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

    }
}

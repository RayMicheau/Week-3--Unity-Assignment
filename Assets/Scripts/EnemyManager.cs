using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class EnemyManager : MonoBehaviour
{


    public PlayerHealth playerHealth;
    public GameObject enemy;

    List<GameObject> enemies;

    [Range(0.0f, 10.0f)]
    public float spawnTime = 5f;
    public float spawnTimeDelta = 1f;
    private float timer = 0;
    public Transform[] spawnPoints;

    
    // Use this for initialization
    void Update()
    {
        timer += Time.deltaTime;

        if (playerHealth.currentHP <= 0f)
            return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        spawnTimeDelta = spawnTime + Mathf.PingPong(Time.time, .5f);

        if (timer >= spawnTimeDelta)
        {
            timer = 0;
            Instantiate(enemy, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            spawnTime = Mathf.Lerp(0.1f, spawnTime, 0.95f);
        }
    }
}

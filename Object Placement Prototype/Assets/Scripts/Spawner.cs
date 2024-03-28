using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;

    public float spawnRate;
    private float timeTillSpawn;
    public float spawnRateIncreaseRate;
    public float maxSpawnRate;

    void Start()
    {
        timeTillSpawn = spawnRate;
    }

    void Update()
    {
        if(timeTillSpawn <= 0)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            timeTillSpawn = spawnRate;
            spawnRate -= spawnRateIncreaseRate;
        }
        timeTillSpawn -= Time.deltaTime;

        if (spawnRate <= maxSpawnRate)
        {
            spawnRate = maxSpawnRate;
        }
    }
}

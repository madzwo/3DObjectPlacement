using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    public GameObject enemy5Prefab;
    public GameObject enemy6Prefab;
    public GameObject enemy7Prefab;



    public int spawnCount;


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
            Debug.Log(spawnCount);
            if (spawnCount % 128 == 0)
            {
                Instantiate(enemy7Prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else if (spawnCount % 64 == 0)
            {
                Instantiate(enemy6Prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else if (spawnCount % 32 == 0)
            {
                Instantiate(enemy5Prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else if (spawnCount % 16 == 0)
            {
                Instantiate(enemy4Prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else if (spawnCount % 8 == 0)
            {
                Instantiate(enemy3Prefab, spawnPoint.position, spawnPoint.rotation);
            }
            else if(spawnCount % 4 == 0)
            {   
                Instantiate(enemy2Prefab, spawnPoint.position, spawnPoint.rotation);
            } 
            else
            {
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            timeTillSpawn = spawnRate;
            spawnRate -= spawnRateIncreaseRate;
            spawnCount++;
        }
        timeTillSpawn -= Time.deltaTime;

        if (spawnRate <= maxSpawnRate)
        {
            spawnRate = maxSpawnRate;
        }

    }
}

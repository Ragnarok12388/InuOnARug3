using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBitcoinBoss : MonoBehaviour
{
    public GameObject bitcoin;
    public float minTime;
    public float maxTime;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public float spawnTime;
    public float delay;

    void Start()
    {
        spawnTime = delay;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > spawnTime)
        {
            timeBetweenSpawn = Random.Range(minTime, maxTime);
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }

    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        GameObject newBitcoin = Instantiate(bitcoin, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        Destroy(newBitcoin, 10f);
    }
}

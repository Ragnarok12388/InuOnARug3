using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBitcoin : MonoBehaviour
{
    public GameObject bitcoin;
    public GameObject Monero;
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
        // Calculate random spawn position relative to Monero
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = Monero.transform.position + new Vector3(randomX, randomY, 0);

        // Instantiate Litecoin object at the calculated spawn position
        GameObject newBitcoin = Instantiate(bitcoin, spawnPosition, Quaternion.identity);
        Destroy(newBitcoin, 10f);
    }

}

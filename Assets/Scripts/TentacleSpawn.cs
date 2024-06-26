using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSpawn : MonoBehaviour
{
    public GameObject obstacle;
    public float minTime;
    public float maxTime;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public float spawnTime;
    private float randomX;
    private float randomY;
    public TextTMP score;

    public void Start()
    {
        spawnTime = 6.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > spawnTime)
        {
            timeBetweenSpawn = Random.Range(minTime, maxTime);
            Spawn();
            //spawnTime = Time.time + timeBetweenSpawn;
            spawnTime = Time.timeSinceLevelLoad + timeBetweenSpawn;
        }

    }
    void Spawn()
    {
        if (score.spawnenemies == false)
        {
            return;
        }
        if (score.score < 10)
        {
            return;
        }
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        Destroy(newObstacle, 30); // Destroy the spawned obstacle after 20 seconds
    }
}

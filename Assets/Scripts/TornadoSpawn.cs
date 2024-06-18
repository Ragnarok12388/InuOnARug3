using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpawn : MonoBehaviour
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
    public bool active;
    private float activeend;
    private float randomX;
    private float randomY;
    private float LastX;
    public TextTMP score;
    public AudioManager Sounds;

    public void Start()
    {
        active = false;
        LastX = -1000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > activeend)
        {
            return;
        }
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
        int i = 0;
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);
        while ((randomX<(LastX + 2.5f) || randomX>(LastX - 2.5f)) && i <20)
        {
            i ++;
            randomX = Random.Range(minX, maxX);
            randomY = Random.Range(minY, maxY);
        }
        LastX = randomX;
        GameObject newObstacle;
        newObstacle = Instantiate(obstacle, new Vector3(randomX, randomY, 0), transform.rotation);
        Destroy(newObstacle, 30); // Destroy the spawned obstacle after 20 seconds
    }
    public void activate()
    {
        activeend = Time.timeSinceLevelLoad + 30.0f;
    }
}
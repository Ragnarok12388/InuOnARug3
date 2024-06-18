using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawn : MonoBehaviour
{
    public Shark obstacle;
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
    public TextTMP score;
    public AudioManager Sounds;

    public void Start()
    {
        active = false;
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
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);
        Shark newObstacle;
        newObstacle = Instantiate(obstacle, new Vector3(randomX, randomY, 0), transform.rotation);
        newObstacle.realshark=false;
        Destroy(newObstacle, 30); // Destroy the spawned obstacle after 20 seconds
    }
    public void activate(float sharktime)
    {
        activeend = Time.timeSinceLevelLoad + sharktime;
    }
}
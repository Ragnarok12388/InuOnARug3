using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeg : MonoBehaviour
{
    public PegasusBehaviorScript obstacle;
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
    public TextTMP score;
    public bool PoseidonSpawn;
    public void Start()
    {
        activeend = Time.timeSinceLevelLoad;
        spawnTime = 6.0f;
        PoseidonSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < activeend)
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
        if (score.spawnenemies == false)
        {
            return;
        }
        
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        PegasusBehaviorScript newObstacle = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        Rigidbody2D Pegasus = newObstacle.GetComponent<Rigidbody2D>();
        Pegasus.constraints = RigidbodyConstraints2D.None;
        Destroy(newObstacle, 20); // Destroy the spawned obstacle after 20 seconds
    }
    public void activate(float pegtime)
    {
        activeend = Time.timeSinceLevelLoad + pegtime;
    }
}

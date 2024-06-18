using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CthulhuSpawn : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject laserbeam;
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
    public AudioManager Sounds;

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
        if (score.score<4500)
        {
            return;
        }
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(0.0f, 2.0f);
        GameObject newObstacle;
        if (randomZ<=1.0f)
        {
            newObstacle = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            newObstacle.tag = "Cthulhu";
        }
        else
        {
            newObstacle = Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            newObstacle.tag = "Cthulhu";
            Vector3 CurrentScale = newObstacle.transform.localScale;
            CurrentScale.y *= -1.0f;
            newObstacle.transform.localScale = CurrentScale;
            Vector3 CurrentRot = newObstacle.transform.rotation.eulerAngles;
            CurrentRot.z = 40.0f;
            newObstacle.transform.rotation = Quaternion.Euler(CurrentRot);
        }
        Destroy(newObstacle, 30); // Destroy the spawned obstacle after 20 seconds
        StartCoroutine(Makealaser(4.0f, randomX, randomY, randomZ, newObstacle));
    }
    IEnumerator Makealaser(float delay, float x, float y, float randomZ, GameObject Cthulhu)
    {
        yield return new WaitForSeconds(delay);
        if(Cthulhu == null)
        {
            yield break;
        }
        GameObject LaserInstance;
        if (randomZ <= 1.0f)
        {
            LaserInstance = Instantiate(laserbeam, transform.position + new Vector3(x + 2.65f, y - 10.25f, 0.0f), transform.rotation);
            LaserInstance.tag = "Laser";
        }
        else
        {
            LaserInstance = Instantiate(laserbeam, transform.position + new Vector3(x - 2.65f, y - 10.25f, 0.0f), transform.rotation);
            LaserInstance.tag = "Laser";
            Vector3 CurrentRot = LaserInstance.transform.rotation.eulerAngles;
            CurrentRot.z = -20.0f;
            LaserInstance.transform.rotation = Quaternion.Euler(CurrentRot);
        }
        Sounds.PlayLaser();
        Destroy(LaserInstance, 2.0f);
    }
    public void Pup(float delay)
    {
        {
            GameObject[] AllObject = GameObject.FindObjectsOfType<GameObject>();
            foreach (GameObject OBJ in AllObject)
            {
                if (OBJ.CompareTag("Laser"))
                {
                    CapsuleCollider2D COL = OBJ.GetComponent<CapsuleCollider2D>();
                    COL.isTrigger = false;
                }
                if (OBJ.CompareTag("Cthulhu"))
                {
                    Rigidbody2D COL = OBJ.GetComponent<Rigidbody2D>();
                    COL.bodyType = RigidbodyType2D.Dynamic;
                }
                if (OBJ.CompareTag("LaserFake"))
                {
                    CapsuleCollider2D COL = OBJ.GetComponent<CapsuleCollider2D>();
                    COL.isTrigger = false;
                }
                if (OBJ.CompareTag("CthulhuFake"))
                {
                    Rigidbody2D COL = OBJ.GetComponent<Rigidbody2D>();
                    COL.bodyType = RigidbodyType2D.Dynamic;
                }
            }
            StartCoroutine(turnoffPower(7.5f));
        }
    }
    private IEnumerator turnoffPower(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject[] AllObject = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject OBJ in AllObject)
        {
            if (OBJ.CompareTag("Laser"))
            {
                Destroy(OBJ);
            }
            if (OBJ.CompareTag("Cthulhu"))
            {
                Destroy(OBJ);
            }
            if (OBJ.CompareTag("LaserFake"))
            {
                CapsuleCollider2D COL = OBJ.GetComponent<CapsuleCollider2D>();
                COL.isTrigger = true;
            }
            if (OBJ.CompareTag("CthulhuFake"))
            {
                Rigidbody2D COL = OBJ.GetComponent<Rigidbody2D>();
                COL.bodyType = RigidbodyType2D.Static;
            }
        }
    }

}

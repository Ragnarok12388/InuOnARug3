using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wingedcoin : MonoBehaviour
{
    public GameObject genericcoin;
    public float minTime;
    public float maxTime;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public float spawnTime;
    public float delay;
    public GameObject Backwing;
    public GameObject Forwardwing;
    public Sprite Litecoin;
    public Sprite Bitcoin;
    public Sprite Dogecoin;
    public Sprite IOARToken;

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
        float randomcoin = Random.Range(0.0f, 4.0f);
        GameObject Genericcoin = Instantiate(genericcoin, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        SpriteRenderer Coinrenderer = Genericcoin.GetComponent<SpriteRenderer>();
        Rigidbody2D rb = Genericcoin.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1.0f, 0);
        GameObject backwing = Instantiate(Backwing, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        backwing.transform.parent = Genericcoin.transform;
        GameObject forwardwing = Instantiate(Forwardwing, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        forwardwing.transform.parent = Genericcoin.transform;
        if (randomcoin <= 1.0f) //this is dogecoin
        {
            Coinrenderer.sprite = Dogecoin;
            Coinrenderer.tag = "wingedDogecoin";
            Genericcoin.transform.localScale = new Vector3(0.08f, 0.08f, 1.0f);
            backwing.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
            forwardwing.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
            backwing.transform.localPosition = new Vector3(-2.7f, 4.3f, 0.0f);
            forwardwing.transform.localPosition = new Vector3(5.6f, 4.6f, 0.0f);
        }
        else if (randomcoin <= 2.0f) // this is litecoin
        {
            Coinrenderer.sprite = Litecoin;
            Coinrenderer.tag = "wingedLitecoin";
            Genericcoin.transform.localScale = new Vector3(0.25f, 0.25f, 0.2f);
            backwing.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            forwardwing.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            backwing.transform.localPosition = new Vector3(-0.67f, 1.38f, 0.0f);
            forwardwing.transform.localPosition = new Vector3(1.88f, 1.26f, 0.0f);
        }
        else if (randomcoin <= 3.0f) //this is bitcoin
        {
            Coinrenderer.sprite = Bitcoin;
            Coinrenderer.tag = "wingedBitcoin";
            Genericcoin.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);
            backwing.transform.localScale = new Vector3(2.7f, 2.7f, 1.0f);
            forwardwing.transform.localScale = new Vector3(2.7f, 2.7f, 1.0f);
            backwing.transform.localPosition = new Vector3(-2.4f, 3.3f, 0.0f);
            forwardwing.transform.localPosition = new Vector3(4.6f,4.6f, 0.0f);
        }
        else //this is ioartoken
        {
            Coinrenderer.sprite = IOARToken;
            Coinrenderer.tag = "wingedIOARToken";
            Genericcoin.transform.localScale = new Vector3(0.1f, 0.1f, 0.2f);
            backwing.transform.localScale = new Vector3(2.7f, 2.7f, 1.0f);
            forwardwing.transform.localScale = new Vector3(2.7f, 2.7f, 1.0f);
            backwing.transform.localPosition = new Vector3(-1.4f, 3.1f, 0.0f);
            forwardwing.transform.localPosition = new Vector3(5.0f, 4.0f, 0.0f);
        }
        Destroy(Genericcoin, 30f);
    }
}


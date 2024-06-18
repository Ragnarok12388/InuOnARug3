using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleExplosion : MonoBehaviour
{
    public GameObject Whale1;
    public GameObject Whale2;
    public GameObject Whale3;
    public GameObject Whale4;
    public float variance;

    public void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Spawn(float X, float Y)
    {
        float randomX = X + variance * Random.Range(-1.0f, 1.0f);
        float randomY = Y + variance * Random.Range(-1.0f, 1.0f);
        GameObject W1 = Instantiate(Whale1, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        randomX = X + variance * Random.Range(-1.0f, 1.0f);
        randomY = Y + variance * Random.Range(-1.0f, 1.0f);
        GameObject W2 = Instantiate(Whale2, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        randomX = X + variance * Random.Range(-1.0f, 1.0f);
        randomY = Y + variance * Random.Range(-1.0f, 1.0f);
        GameObject W3 = Instantiate(Whale3, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        randomX = X + variance * Random.Range(-1.0f, 1.0f);
        randomY = Y + variance * Random.Range(-1.0f, 1.0f);
        GameObject W4 = Instantiate(Whale4, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        Destroy(W1, 20);
        Destroy(W2, 20);
        Destroy(W3, 20);
        Destroy(W4, 20);
        // Destroy the spawned obstacle after 20 seconds
    }
}

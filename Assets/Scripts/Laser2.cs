using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Las : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundrenderer;
    public GameObject player;
    public GameObject gameOverPanel;
    public Player player2;
    public Livestext livesdoge;
    public float creationtime;
    public Rigidbody2D laser;
    public AudioManager yelp;
    float tempy;
    float tempz;

    void Start()
    {
        laser.SetRotation(20.0f);
        creationtime = Time.timeSinceLevelLoad;
        tempy = transform.localScale.y;
        tempz = transform.localScale.z;
        transform.localScale = new Vector3(0.001f, tempy, tempz);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Doge")
        {
            if (player2.poweredUp == false)
            {
                yelp.PlayYelp();
                if (player2.lives > 1)
                {
                    player2.lives -= 1;
                    livesdoge.Awake();
                    return;
                }

                gameOverPanel.SetActive(true);
                Destroy(player.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            if ((Time.timeSinceLevelLoad-creationtime) < 1.0f) 
            {
                transform.localScale = new Vector3(0.01f + 0.7f * ((Time.timeSinceLevelLoad - creationtime) / 1.0f), tempy, (tempz));
            }
            else if ((Time.timeSinceLevelLoad - creationtime) < 2.0f)
            {
                transform.localScale = new Vector3(0.01f + 0.7f * (1.0f - ((Time.timeSinceLevelLoad - 1.0f - creationtime) / 1.0f)), tempy, (tempz));
            }
            backgroundrenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * -0.0f * Time.deltaTime, backgroundSpeed * 0.939626f * Time.deltaTime);
        }
    }
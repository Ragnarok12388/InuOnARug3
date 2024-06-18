using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzz : MonoBehaviour
{
    public Rigidbody2D zzzz;
    public float minheight;
    public float maxheight;
    public float jumptime;
    public float jumpheight;
    public float speed;
    public GameObject player;
    public GameObject gameOverPanel;
    public Player player2;
    public Livestext livesdoge;
    public AudioSource yelp;
    public AudioClip ouch;
    public AudioManager audioManager;
    public WhaleExplosion Explosion;

    // Start is called before the first frame update
    void Start()

    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Doge")
        {
            if (player2.poweredUp == false)
            {
                yelp.PlayOneShot(ouch, 1.0f);
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



    }
}

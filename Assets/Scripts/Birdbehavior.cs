using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviourScript : MonoBehaviour
{
    public Rigidbody2D Bird;
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
        Bird = GetComponent<Rigidbody2D>();
        jumpheight = Random.Range(minheight, maxheight);
        jumptime = 1.0f - (((jumpheight - minheight) / (maxheight - minheight)) * 0.5f);
        Bird.velocity = new Vector2(-4 * (speed * jumptime), 0 * (speed * jumptime));
        Bird.transform.localScale = new Vector3((0.5f + Mathf.Min(((Time.timeSinceLevelLoad / 420.0f) * 1.5f), 2.0f)), (0.5f + Mathf.Min(((Time.timeSinceLevelLoad / 420.0f) * 1.5f), 2.0f)), (1.0f));
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
            else
            {
                Explosion.Spawn(Bird.position.x, Bird.position.y);
                audioManager.PlayOrcacry();
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Bird.SetRotation(10 + (1 * (1.0f - (Bird.velocity.y + ((speed * jumptime) / (2.0f * speed * jumptime))))));
    }
}

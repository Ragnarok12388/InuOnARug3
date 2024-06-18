using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaBehaviourScript : MonoBehaviour
{
    public Rigidbody2D Orca;
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
        Orca = GetComponent<Rigidbody2D>();
        jumpheight = Random.Range(minheight, maxheight);
        jumptime = 1.0f - (((jumpheight - minheight) / (maxheight - minheight))*0.5f);
        Orca.velocity = new Vector2(-1 * (speed *jumptime), 1 * (speed * jumptime));
        Orca.transform.localScale = new Vector3((0.5f + Mathf.Min(((Time.timeSinceLevelLoad/420.0f)*1.5f),2.0f)), (0.5f + Mathf.Min(((Time.timeSinceLevelLoad / 420.0f) * 1.5f), 2.0f)), (1.0f));
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
                Explosion.Spawn(Orca.position.x, Orca.position.y);
                audioManager.PlayOrcacry();
                Destroy(this.gameObject);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        Orca.SetRotation ( -20 + (6 *(1.0f - (Orca.velocity.y+((speed*jumptime)/(2.0f * speed * jumptime))))));
      //  Orca.velocity = new Vector2(0 * speed, 1 * speed);
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegasusBehaviorScript : MonoBehaviour
{
    public Rigidbody2D Pegasus;
    public float minheight;
    public float maxheight;
    public float jumptime;
    public float jumpheight;
    public float speed;
    public GameObject player;
    public GameObject gameOverPanel;
    public Player player2;
    public bool gliding = true;
    public Livestext livesdoge;
    public AudioSource yelp;
    public AudioClip ouch;
    public AudioManager audioManager;
    public WhaleExplosion Explosion;
    public Animator peganimation;
    public int HP;

    // Start is called before the first frame update
    void Start()
    
    {
        HP = 2;
        Pegasus = GetComponent<Rigidbody2D>();
        jumpheight = Random.Range(minheight, maxheight);
        jumptime = 1.0f - (((jumpheight - minheight) / (maxheight - minheight))*0.5f);
        Pegasus.velocity = new Vector2(-1 * (speed *jumptime), 1 * (speed * jumptime));
        Pegasus.transform.localScale = new Vector3((0.5f + Mathf.Min(((Time.timeSinceLevelLoad/420.0f)*0.55f),0.9f)), (0.5f + Mathf.Min(((Time.timeSinceLevelLoad / 420.0f) * 0.55f), 0.9f)), (1.0f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Doge" && HP > 0)
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
        if (collision.tag == "Dogelaser")
        {
            Destroy(collision.gameObject);
            if(HP>1)
            {
                HP -= 1; 
            }
            else if(HP == 1)
            {
                HP -= 1;
                peganimation.SetTrigger("Dead");
                Pegasus.velocity = new Vector2(0.0f, 0.0f);
                Pegasus.gravityScale = 1.0f;
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (gliding == true)
        {
            Vector2 vel = Pegasus.velocity;
            if(vel.y <= -0.1f)
            {
                gliding = false;
                Vector3 newrotation = new Vector3(0.0f, 0.0f, -30f);
                Pegasus.MoveRotation(Quaternion.Euler(newrotation));
                Pegasus.gravityScale = 0f;
                vel.y = -0.5f;
                Pegasus.velocity = vel;
                peganimation.SetTrigger("Glide");
            }
        }
      //  Orca.velocity = new Vector2(0 * speed, 1 * speed);
    
    }
}

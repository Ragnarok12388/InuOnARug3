using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angelbehavior : MonoBehaviour
{
    public bool activated;
    public Rigidbody2D Angel;
    public float minheight;
    public float maxheight;
    public float jumptime;
    public float jumpheight;
    public float speed;
    public Player player2;
    public Livestext livesdoge;
    public AudioSource yelp;
    public AudioClip ouch;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        Angel = GetComponent<Rigidbody2D>();
        jumpheight = Random.Range(minheight, maxheight);
        jumptime = 1.0f - (((jumpheight - minheight) / (maxheight - minheight)) * 0.5f);
        Angel.velocity = new Vector2(-3 * (speed * jumptime), 0 * (speed * jumptime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Doge")
        {
                
                if (activated == false)
                {
                    activated = true;
                    yelp.PlayOneShot(ouch, 1.0f);
                    player2.lives += 1;
                    livesdoge.Awake();
                    return;
                }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

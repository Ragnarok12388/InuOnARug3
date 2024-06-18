using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Transform doge;
    public float speed = 2.0f;
    private Rigidbody2D rb;
    public AudioManager Sounds;
    public GameObject gameOverPanel;
    public Player player2;
    public Livestext livesdoge;
    public GameObject player;
    public float maxspeed = 10.0f;
    public Boss Bossobject;
    public float creationtime;
    public Healthbar Bar;
    // Start is called before the first frame update
    void Start()
    {
        creationtime = Time.time;
        rb = GetComponent<Rigidbody2D>();
        Sounds.PlayFireballWoosh();
    }

    // Update is called once per frame
    void Update()
    {
        if (doge != null)
        {
            Vector3 direction = doge.position - transform.position;
            float distance = Vector3.Distance(doge.position, transform.position);
            direction.Normalize();
            Vector2 velocity = (direction * speed * (distance/10.0f));
            Vector2 velocity2 = (Vector2)rb.velocity + velocity;
            velocity2.x = Mathf.Min(maxspeed, velocity2.x);
            velocity2.y = Mathf.Min(maxspeed, velocity2.y);
            rb.velocity = velocity2;
        }
        if (Bossobject.HP>=200)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Doge")
        {
            if (player2.poweredUp == false)
            {
                Sounds.PlayYelp();
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
        if (collision.tag == "Boss")
        {
            {
                if (Time.time > (creationtime + 2.0f))
                {
                    Sounds.PlayCry2();
                    Destroy(this.gameObject);
                    Bossobject.HP += 5;
                    Bar.Awake();
                }
            }
        }
    }
}

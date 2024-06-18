using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public Rigidbody2D Sharkbody;
    public GameObject player;
    public GameObject gameOverPanel;
    public Player player2;
    public Livestext livesdoge;
    public AudioSource yelp;
    public AudioClip ouch;
    public AudioManager audioManager;
    public float speed;
    public SpriteRenderer SharkSprite;
    public float sharkangle;
    public bool realshark;
    // Start is called before the first frame update
    void Start()
    {

        sharkangle = Random.Range(0.0f, Mathf.PI);
        Sharkbody.velocity = new Vector2(speed * Mathf.Cos(sharkangle), speed * Mathf.Sin(sharkangle));
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
        Vector2 Vel = Sharkbody.velocity;
        float angle = Mathf.Atan2(Vel.y, Vel.x)*Mathf.Rad2Deg;
        if (Vel.x<0.0f && !realshark)
        {
            SharkSprite.flipY = true;
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void Nado()
    {
        realshark = false;
    }
}

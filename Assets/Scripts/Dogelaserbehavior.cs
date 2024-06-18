using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogelaserbehavior : MonoBehaviour
{
    public Rigidbody2D Orca;
    public GameObject player;
    public GameObject gameOverPanel;
    public Player player2;
    public Livestext livesdoge;
    public float creationtime;
    public AudioSource yelp;
    public AudioClip ouch;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()

    {
        audioManager.Laserdoge();
        creationtime = Time.timeSinceLevelLoad;
        Orca = GetComponent<Rigidbody2D>();
        Orca.velocity = new Vector2(15.0f,  0.0f);
        Orca.transform.localScale = new Vector3((0.001f), 1.0f, (1.0f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pegasus")
        {
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        Orca.transform.localScale = new Vector3((0.001f + Mathf.Min((((Time.timeSinceLevelLoad - creationtime) / 0.5f)), 1.0f)), (1.0f), (1.0f));
        //  Orca.velocity = new Vector2(0 * speed, 1 * speed);

    }
}

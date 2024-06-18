using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverPanel;
    public Player player2;
    public Livestext livesdoge;
    public AudioSource yelp;
    public AudioClip ouch;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.CompareTag("Doge"))
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

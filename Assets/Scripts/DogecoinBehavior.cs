using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogecoinBehavior : MonoBehaviour
{
    public TextTMP text3;
    public AudioManager Coinsound2;
    public Livestext livesdoge;
    public Player player2;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
            if (rb == null) // Check if the Rigidbody2D component is not already attached
            {
                rb = gameObject.AddComponent<Rigidbody2D>(); // Add the Rigidbody2D component
                rb.gravityScale = 0; // Disable gravity for the object
            }

            // Set velocity to move left
            rb.velocity = new Vector2(moveSpeed, 0); // Assuming moveSpeed is defined somewhere in your script
        }

    }
    // Update is called once per frame
    
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Doge")
            {
                Coinsound2.PlayCoinsound2();
                Destroy(this.gameObject);
                Coinsound2.PlayYelp();
                if (player2.lives >= 1)
                {
                    player2.lives += 1;
                    livesdoge.Awake();
                    return;
                }
            }
        }
}

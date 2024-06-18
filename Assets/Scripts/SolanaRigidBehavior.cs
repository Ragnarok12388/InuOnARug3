using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolanaRigidBehavior : MonoBehaviour
{
    public TextTMP text3;
    public AudioManager Coinsound2;
    public Rigidbody2D RRB;
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystemCry;
    // Start is called before the first frame update
    private void Start()
    {
        particleSystem.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Doge"))
        {
            particleSystem.Play();
            Coinsound2.PlayCoinsound2();
            Destroy(this.gameObject, 20.0f);
        }
        if (collision.tag == "BoundaryV")
        {
            Coinsound2.PlayPlink();
            Vector3 velocity = RRB.velocity;
            velocity.y = -velocity.y;
            RRB.velocity = velocity;
        }
        if (collision.tag == "BoundaryH")
        {
            Coinsound2.PlayPlink();
            Vector3 velocity = RRB.velocity;
            velocity.x = -velocity.x;
            RRB.velocity = velocity;
        }
        if (collision.tag == "Boss")
        {
            ParticleSystem PInstance = Instantiate(particleSystemCry, transform.position, transform.rotation);
            Destroy(PInstance, 20.2f);
        }
    }
}

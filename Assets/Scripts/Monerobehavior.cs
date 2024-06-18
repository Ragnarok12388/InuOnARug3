using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneroBehavior : MonoBehaviour
{
    public TextTMP text3;
    public Player Doge;
    public AudioManager Coinsound;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Doge")
        {
            Doge.Power(7.5f);
            Coinsound.PlayCoinsound();
            text3.increasescore(1);
            text3.Awake();
            Destroy(this.gameObject);
        }
    }
}


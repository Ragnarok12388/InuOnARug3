using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monerolevel5Behavior : MonoBehaviour
{
    public TextTMP text3;
    public Player Doge;
    public AudioManager Coinsound;
    public CthulhuSpawn Spawner;

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
            if (SceneManager.GetActiveScene().name == "Level 5")
            {
                Spawner.Pup(7.5f);
            }
            Destroy(this.gameObject);
        }
    }
}


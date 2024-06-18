using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBehavior : MonoBehaviour
{
    public float distance;
    public float movespeed;
    private Vector3 initialposition;
    public Animator animation;
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
        initialposition = transform.position;
        StartCoroutine(lower());
        audioManager.PlayWaves();
    }
    IEnumerator lower()
    {
        float elapsedtime = 0;
        Vector3 targetposition = initialposition - new Vector3(0, -distance, 0);
        while (elapsedtime < distance / movespeed)
        {
            transform.position = Vector3.Lerp(initialposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetposition;
        yield return new WaitForSeconds(1.0f);
        elapsedtime = 0;
        targetposition = initialposition;
        initialposition = transform.position;
        while (elapsedtime < distance / movespeed)
        {
            transform.position = Vector3.Lerp(initialposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetposition;
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

    }
}
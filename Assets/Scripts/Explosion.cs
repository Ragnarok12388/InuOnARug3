using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioManager audioManager;
    public float creationtime;
    float randomsize;
    // Start is called before the first frame update
    void Start()
    {
        audioManager.PlayCthulhuExplosion();
        randomsize = Random.Range(0.2f, 0.6f);
        creationtime = Time.timeSinceLevelLoad;
        transform.localScale = new Vector3(0.001f, 0.001f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {    
        if ((Time.timeSinceLevelLoad - creationtime) < 1.0f)
        {
            transform.localScale = new Vector3(0.01f + (randomsize*0.7f) * ((Time.timeSinceLevelLoad - creationtime) / 1.0f), 0.01f + (randomsize * 0.7f) * ((Time.timeSinceLevelLoad - creationtime) / 1.0f), (1.0f));
        }
        else if ((Time.timeSinceLevelLoad - creationtime) < 2.0f)
        {
            transform.localScale = new Vector3(0.01f + (randomsize * 0.7f) * (1.0f - ((Time.timeSinceLevelLoad - 1.0f - creationtime) / 1.0f)), 0.01f + (randomsize * 0.7f) * (1.0f - ((Time.timeSinceLevelLoad - 1.0f - creationtime) / 1.0f)), (1.0f));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdfragment : MonoBehaviour
{
    public Rigidbody2D Fragment;
    // Start is called before the first frame update
    void Start()
    {
        Fragment.transform.localScale = new Vector3((0.5f + Mathf.Min(((Time.timeSinceLevelLoad / 420.0f) * 1.5f), 2.0f)), (0.5f + Mathf.Min(((Time.timeSinceLevelLoad / 420.0f) * 1.5f), 2.0f)), (1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

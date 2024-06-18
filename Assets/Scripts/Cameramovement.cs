using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    public float cameraspeed;
    public Camera cameraobject;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(cameraspeed * Time.deltaTime, 0, 0);
    }
    public void Bosssize(float size)
    {
        StartCoroutine(timeresize(10.0f, 4.0f));
    }
    IEnumerator timeresize (float destination, float time)
    {
        float interval = (destination - cameraobject.orthographicSize)/(time*60.0f);

        while (cameraobject.orthographicSize < 10.0f)
        {
            cameraobject.orthographicSize += interval;
            yield return new WaitForSeconds(1.0f/60.0f);
        }
    }
}

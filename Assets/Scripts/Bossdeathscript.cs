using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossdeathscript : MonoBehaviour
{
    public Boss Cthulhu;
    public Camera cameraobject;
    // Start is called before the first frame update
    void Start()
    {
        cameraobject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Cthulhu!=null && Cthulhu.dead == false)
        {
            transform.position = new Vector3(Cthulhu.transform.position.x, Cthulhu.transform.position.y, -10.0f);
            
        }
    }
}

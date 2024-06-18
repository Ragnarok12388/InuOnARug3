using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : MonoBehaviour
{
    public AudioManager Cthulhu;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Roar2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Roar2()
    {
        yield return new WaitForSeconds(3.5f);
        Cthulhu.PlayCthulhu();
    }
}

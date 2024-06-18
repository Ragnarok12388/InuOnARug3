using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharknado : MonoBehaviour
{
    public Vector3 initialposition;
    public float movespeed;
    public float distance;
    public SharkSpawn sharkSpawn;
    // Start is called before the first frame update
    void Start()
    {
        initialposition = transform.position;
    }
    public IEnumerator movesharknado()
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
        sharkSpawn.activate(20.0f);
        yield return new WaitForSeconds(20.0f);
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
        initialposition = targetposition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

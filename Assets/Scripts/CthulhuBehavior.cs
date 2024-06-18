using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthulhuBehavior : MonoBehaviour
{
    public float movespeed;
    public float distance;
    private Vector3 initialposition;
    public GameObject Laser;
    // Start is called before the first frame update
    void Start()
    {
        initialposition = transform.position;
        StartCoroutine(lower());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator lower()
    {
        float elapsedtime = 0;
        Vector3 targetposition = initialposition - new Vector3(0, distance, 0);
        while (elapsedtime < distance/movespeed)
        {
            transform.position = Vector3.Lerp(initialposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetposition;
        yield return new WaitForSeconds(2.0f);
        //Instantiate(Laser, transform.position + new Vector3(1.0f, -1.0f, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        yield return new WaitForSeconds(4.0f);
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
}

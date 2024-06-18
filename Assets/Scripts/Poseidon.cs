using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poseidon : MonoBehaviour
{
    public float distance;
    public float movespeed;
    private Vector3 initialposition;
    public Animator animation;
    public GameObject Waves;
    public SpawnPeg spawnPeg;
    public TornadoSpawn tornadoSpawn;
    public Sharknado sharknado;

    // Start is called before the first frame update
    void Start()
    {
        initialposition = transform.position;
        StartCoroutine(lower());
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
        yield return new WaitForSeconds(2.0f);
        animation.SetTrigger("Trident");
        spawnPeg.PoseidonSpawn = false;
        float randattack = Random.Range(0.0f, 3.0f);
        if (randattack <= 1.0f)
        {
            StartCoroutine(AttackRaiseWave());
            spawnPeg.activate(9.0f);
        }
        else if (randattack <= 2.0f)
        {
            tornadoSpawn.activate();
            spawnPeg.activate(30.0f);
        }
        else
        {
            StartCoroutine(sharknado.movesharknado());
            spawnPeg.activate(30.0f);
        }
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
    IEnumerator AttackRaiseWave()
    {
        BoxCollider2D col = Waves.GetComponent<BoxCollider2D>();
        col.enabled = true;
        Vector3 iposition = Waves.transform.position;
        float elapsedtime = 0;
        Vector3 targetposition = iposition - new Vector3(0, -distance, 0);
        while (elapsedtime < distance / movespeed)
        {
            Waves.transform.position = Vector3.Lerp(iposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        Waves.transform.position = targetposition;
        yield return new WaitForSeconds(2.0f);
        yield return new WaitForSeconds(4.0f);
        elapsedtime = 0;
        targetposition = iposition;
        iposition = Waves.transform.position;
        while (elapsedtime < distance / movespeed)
        {
            Waves.transform.position = Vector3.Lerp(iposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        Waves.transform.position = targetposition;
        col.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSystem : MonoBehaviour
{
    public GameObject Prefab;
    private GameObject Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = Instantiate(Prefab, transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Instance != null)
        {
            Instance.transform.position = transform.position;
        }
    }
}

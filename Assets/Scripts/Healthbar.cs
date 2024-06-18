using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Boss Cthulhu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Awake()
    {
        Vector3 Scale = transform.localScale;
        Scale.x = Mathf.Max(0.25f - 0.25f * ((Cthulhu.HP / 200.0f)), 0.0f);
        transform.localScale = Scale;
    }
}

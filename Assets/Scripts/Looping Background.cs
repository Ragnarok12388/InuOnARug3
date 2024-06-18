using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundrenderer;

    // Update is called once per frame
    void Update()
    {
        backgroundrenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}

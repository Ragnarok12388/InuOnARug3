using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Livesimage : MonoBehaviour
{
    public Camera maincamera;
    public Image dogecoin;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 topright = maincamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        float MaxX = topright.x;
        float MaxY = topright.y;
        RectTransform Image2 = dogecoin.rectTransform;
        Image2.anchoredPosition = new Vector2(MaxX - 1.0f, MaxY - 1.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1load : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{   public TextTMP texttmp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void next()
    {
        if (SceneManager.GetActiveScene().name == "Level 1 Load Scene")
        {
            SceneManager.LoadScene("Level 1");
        }
        if (SceneManager.GetActiveScene().name == "Level 2 Load Scene")
        {
            SceneManager.LoadScene("Level 2");
        }
        if (SceneManager.GetActiveScene().name == "Level 3 Load Scene")
        {
            SceneManager.LoadScene("Level 3");
        }
        if (SceneManager.GetActiveScene().name == "Level 4 Load Scene")
        {
            SceneManager.LoadScene("Level 4");
        }
        if (SceneManager.GetActiveScene().name == "Level 5 Load Scene")
        {
            SceneManager.LoadScene("Level 5");
        }
        if (SceneManager.GetActiveScene().name == "Boss Fight Load Scene")
        {
            SceneManager.LoadScene("Boss Fight");
        }
        if (SceneManager.GetActiveScene().name == "Endgame Load Scene")
        {
            SceneManager.LoadScene("Level Endgame");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public GameObject gameOverPanel;
    //public SpawnObstacles spawntimer;
    void Start()
    {
        gameOverPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level 1");
        gameOverPanel.SetActive(false);
       // spawntimer.Start();
    }
    public void QuitGame()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main Menu");
        gameOverPanel.SetActive(false);
    }
}

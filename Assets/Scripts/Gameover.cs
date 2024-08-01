using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public TextTMP Score;
    public GameObject gameOverPanel;
    //public SpawnObstacles spawntimer;
    void Start()
    {
        gameOverPanel.SetActive(false);
        Score = GameObject.Find("Coins").GetComponent<TextTMP>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public async void Restart()
    {
        await Score.SubmitScoreToLeaderboard();
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level 1");
        gameOverPanel.SetActive(false);
       // spawntimer.Start();
    }
    public async void QuitGame()
    {
        await Score.SubmitScoreToLeaderboard();
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main Menu");
        gameOverPanel.SetActive(false);
    }
}

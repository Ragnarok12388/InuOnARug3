using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    public void Playgame()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadSceneAsync("Level 1 Load Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void goback()
    {
        SceneManager.LoadSceneAsync("Leaderboard");
    }
}
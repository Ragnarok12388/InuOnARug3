using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Leaderboard : MonoBehaviour
{
    public TextTMP Score;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void goback()
    {

        SceneManager.LoadSceneAsync("Main Menu");
    }
    public async void goforward()
    {
        Score = GameObject.Find("Coins").GetComponent<TextTMP>();
        await Score.SubmitScoreToLeaderboard();
        SceneManager.LoadSceneAsync("Leaderboard");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Livestext : MonoBehaviour
{
    private TMP_Text display;
    public Player Lives;
    public void Awake()
    {
        display = GetComponent<TMP_Text>();
        // Assuming you want to display the initial score when the game starts
        UpdateScoreText();
    }

    // Call this method to update the score text
    public void UpdateScoreText()
    {
        display.text = Lives.lives.ToString();
    }
    public void SaveLives()
    {
        PlayerPrefs.SetInt("Lives", Lives.lives);
        PlayerPrefs.Save();
    }

    // Load lives from PlayerPrefs
    public void LoadLives()
    {
        Lives.lives = PlayerPrefs.GetInt("Lives", Lives.startingLives);
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}

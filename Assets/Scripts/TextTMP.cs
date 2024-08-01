using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Beamable;
using Beamable.Common.Api.Leaderboards;
using Beamable.Common.Content;
using Solana.Unity.Soar.Types;
using System.Threading.Tasks;
using Beamable.Common.Leaderboards;
using Beamable.Common.Api;
using Beamable.Common;


public class TextTMP : MonoBehaviour
{
    private TMP_Text display;
    public AudioManager Levelchange;
    public int score = 0;
    public bool spawnenemies;
    public string leaderboardID = "Leaderboardonarug"; // Replace with your leaderboard ID
    private BeamContext beamContext;
    [SerializeField]
    private LeaderboardRef leaderboardref = null;
    private LeaderboardContent leaderboardcontent = null;
    public void Awake()

    {
        //leaderboardref.SetId(leaderboardID);
        display = GetComponent<TMP_Text>();
        // Assuming you want to display the initial score when the game starts
        UpdateScoreText();
        InitializeBeamable();
    }
    private async void InitializeBeamable()
    {
        beamContext = BeamContext.Default;
        //leaderboardcontent = await leaderboardref.Resolve();
        Debug.Log("Beamable initialized successfully.");
    }

    // Call this method to update the score text
    public void UpdateScoreText()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        display.text = "Coins $" + score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnenemies = true;
    }
    public void increasescore(int x)
    {
        score += x;
        // Save the score to PlayerPrefs whenever it changes
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save(); // Save changes immediately
        if (score >= 1000 && ((SceneManager.GetActiveScene().name) == "Level 1"))

        {
            if (spawnenemies == true)
            {
                Levelchange.PlayLevelchange();
            }
            spawnenemies = false;
            StartCoroutine(Pause(5.0f, "Level 2 Load Scene"));
        }
        if (score >= 1750 && ((SceneManager.GetActiveScene().name) == "Level 2"))

        {
            if (spawnenemies == true)
            {
                Levelchange.PlayLevelchange();
            }
            spawnenemies = false;
            StartCoroutine(Pause(5.0f, "Level 3 Load Scene"));
        }
        if (score >= 2750 && ((SceneManager.GetActiveScene().name) == "Level 3"))
        {
            if (spawnenemies == true)
            {
                Levelchange.PlayLevelchange();
            }
            spawnenemies = false;
            StartCoroutine(Pause(5.0f, "Level 4 Load Scene"));
        }
        if (score >= 3500 && ((SceneManager.GetActiveScene().name) == "Level 4"))
        {
            if (spawnenemies == true)
            {
                Levelchange.PlayLevelchange();
            }
            spawnenemies = false;
            StartCoroutine(Pause(5.0f, "Level 5 Load Scene"));
        }
        if (score >= 5000 && ((SceneManager.GetActiveScene().name) == "Level 5"))
        {
            if (spawnenemies == true)
            {
                Levelchange.PlayLevelchange();
            }
            spawnenemies = false;
            StartCoroutine(Pause(5.0f, "Boss Fight Load Scene"));
        }
        if (score >= 5500 && ((SceneManager.GetActiveScene().name) == "Boss Fight"))
        {
            if (spawnenemies == true)
            {
                Levelchange.PlayLevelchange();
            }
            spawnenemies = false;
            StartCoroutine(Pause(5.0f, "Endgame Load Scene"));
        }
    }
    public async Task SubmitScoreToLeaderboard()
    {
        await beamContext.OnReady;
        if (beamContext == null)
        {
            Debug.LogError("Beamable context is not initialized.");
        }
        try
        {

            await beamContext.Api.LeaderboardService.SetScore(leaderboardref.Id, score);
            Debug.Log("Score submitted to leaderboard successfully.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to submit score to leaderboard: " + ex.Message);
        }
    }
    IEnumerator Pause(float delay, string Level)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(Level);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

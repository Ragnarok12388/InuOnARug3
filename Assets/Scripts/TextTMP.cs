using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Solana.Unity.Wallet;
using Solana.Unity.Rpc;
using Solana.Unity.Rpc.Core.Http;
using Solana.Unity.Rpc.Models;
using Solana.Unity.Rpc.Types;
using Solana.Unity.SDK;
using System.Threading.Tasks;
using System.Text;

public class TextTMP : MonoBehaviour
{
    private TMP_Text display;
    public AudioManager Levelchange;
    public int score = 0;
    public bool spawnenemies;
    private string walletAddress;
    private Leaderboard leaderboard;

    public void Awake()
    {
        display = GetComponent<TMP_Text>();
        leaderboard = new Leaderboard();
        walletAddress = SolanaWalletManager.Instance.GetWalletAddress();
        UpdateScoreText();
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

    public async void increasescore(int x)
    {
        score += x;
        // Save the score to PlayerPrefs whenever it changes
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save(); // Save changes immediately

        // Save the score to the blockchain
        await leaderboard.SubmitScore(walletAddress, score);

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

// Leaderboard class to handle Solana interactions
public class Leaderboard
{
    private static readonly PublicKey leaderboardProgramAddress = new PublicKey("HZqdApimXt7y5yKtbsLr8xknUR4vk5biV1RFVcZYQCbk");

    public async Task SubmitScore(string walletAddress, int score)
    {
        var account = SolanaWalletManager.Instance.GetWallet().Account;
        var rpcClient = SolanaWalletManager.Instance.GetRpcClient();

        // Create transaction instruction to submit the score
        var instruction = new TransactionInstruction
        {
            ProgramId = leaderboardProgramAddress,
            Keys = new List<AccountMeta>
            {
                AccountMeta.Writable(new PublicKey(account.PublicKey), true),
                AccountMeta.ReadOnly(new PublicKey(walletAddress), false)
            },
            Data = Encoding.UTF8.GetBytes(score.ToString())
        };

        var transaction = new Transaction
        {
            FeePayer = account.PublicKey
        };
        transaction.Add(instruction);

        var result = await rpcClient.SendTransactionAsync(transaction.Build(account));

        if (!result.WasSuccessful)
        {
            Debug.LogError("Failed to submit score: " + result.Reason);
        }
    }

    public async Task<List<(string walletAddress, int score)>> GetLeaderboard()
    {
        var rpcClient = SolanaWalletManager.Instance.GetRpcClient();
        var result = await rpcClient.GetAccountInfoAsync(leaderboardProgramAddress);

        if (result.WasSuccessful)
        {
            var leaderboardData = Encoding.UTF8.GetString(result.Result.Value.Data[0]);
            return ParseLeaderboardData(leaderboardData);
        }
        else
        {
            Debug.LogError("Failed to retrieve leaderboard: " + result.Reason);
        }

        return new List<(string walletAddress, int score)>();
    }

    private List<(string walletAddress, int score)> ParseLeaderboardData(string leaderboardData)
    {
        // Assuming leaderboard data is stored in a simple CSV format: walletAddress,score\n
        var lines = leaderboardData.Split('\n');
        var leaderboard = new List<(string walletAddress, int score)>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split(',');
            if (parts.Length == 2 && int.TryParse(parts[1], out var score))
            {
                leaderboard.Add((parts[0], score));
            }
        }

        return leaderboard;
    }
}

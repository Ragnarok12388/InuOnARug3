using UnityEngine;
using Solana.Unity.Wallet;
using Solana.Unity.Rpc;
using Solana.Unity.Rpc.Core.Http;
using Solana.Unity.Rpc.Models;
using Solana.Unity.Rpc.Types;
using Solana.Unity.SDK;

public class SolanaWalletManager : MonoBehaviour
{
    public static SolanaWalletManager Instance { get; private set; }
    private Wallet wallet;
    private IRpcClient rpcClient;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        InitializeWallet();
    }

    private void InitializeWallet()
    {
        // Initialize your wallet here. This could be from a mnemonic, private key, etc.
        string mnemonic = "your mnemonic here"; // Replace with your actual mnemonic or key
        wallet = new Wallet(mnemonic);
        rpcClient = ClientFactory.GetClient(Cluster.MainNet);
    }

    public string GetWalletAddress()
    {
        return wallet.Account.PublicKey;
    }

    public IRpcClient GetRpcClient()
    {
        return rpcClient;
    }

    public Wallet GetWallet()
    {
        return wallet;
    }
}

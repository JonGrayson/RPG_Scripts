using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using UnityEngine.Video;

public class GameManager : MonoBehaviourPun
{
    [Header("Players")]
    public string playerPrefabPath;
    public string playerPrefabPath2;
    public string playerPrefabPath3;
    public Transform[] spawnPoints;
    public float respawnTime;
    private int playersInGame;
    public int playerChar;

    // instance
    public static GameManager instance;

    public GameObject deathScreen;
    public GameObject winningCinematic;

    public PlayerController[] players;

    void Awake()
    {
        instance = this;
    }

    [PunRPC]
    void ImInGame()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            SpawnPlayer();
        }
    }

    void Start()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
    }

    void SpawnPlayer()
    {
            GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabPath, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            // initialize the player
            playerObj.GetComponent<PhotonView>().RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }

    /* 
    void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(CharacterInfo.instance.playerModels[0], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        // initialize the player
        playerObj.GetComponent<PhotonView>().RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
    */
}

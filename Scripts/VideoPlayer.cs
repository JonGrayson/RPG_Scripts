using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class VideoPlayer : MonoBehaviourPun
{
    public Button skipButton;

    public void Start()
    {
        skipButton.interactable = PhotonNetwork.IsMasterClient;
    }

    public void onSkipButton()
    {
        Application.Quit();
    }
}

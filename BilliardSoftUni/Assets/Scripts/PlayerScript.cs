﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int playerNum = 1;
    public string defaultName = "David";
    public int ballType;
    public Text playerName;
    public InputField playerInput;
    public UIPlayers UIPlayer;

    private BallType[] balls;

    // Use this for initialization
    void Start()
    {
        playerInput.placeholder.GetComponent<Text>().text = defaultName;

        ChangeName();
    }

    public void ChangeName()
    {
        playerName.text = playerInput.text != "" ? playerInput.text : defaultName;
    }

    public void SetBallType(int ballType)
    {
        balls = UIPlayer.SetBallType(playerNum, ballType);
    }
}

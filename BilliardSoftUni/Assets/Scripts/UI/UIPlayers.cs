﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class BallType
{
    public string name;
    public int type = 0;
    public int number = 0;
    public Sprite sprite;
}

public class UIPlayers : MonoBehaviour
{
    public static UIPlayers instance;

    public GameObject UICanvas;
    public PlayerScript[] players;
    public BallType[] balls;
    public Image UIBall;

    private ArrayList UIBalls;

    void Start()
    {
        if (instance == null) instance = this;

        UIBalls = new ArrayList();
    }

    public void ChangePlayerName(int playerNum)
    {
        players[playerNum - 1].ChangeName();
    }
    
    public BallType[] SetBallType(int playerNum, int ballType)
    {
        BallType[] currentBallsType = new BallType[7];
        Vector3 position = new Vector3(0.0f, -7.0f, 0.0f);
        int plrNum = playerNum + 1;
        Transform ballPanel = UICanvas.transform.Find("Player " + plrNum + " UI").Find("Balls Panel");
        int count = 0;

        for (int i = 0, l = balls.Length; i < l; i++)
        {
            BallType ball = balls[i];
            if (ball.type == ballType)
            {
                Image img = Instantiate(UIBall) as Image;
                UIBallsType uiBallType = img.GetComponent<UIBallsType>();

                uiBallType.sprite = ball.sprite;
                uiBallType.number = ball.number;
                uiBallType.Name = ball.name;
                img.transform.SetParent(ballPanel, false);
                img.GetComponent<RectTransform>().transform.localPosition = position;

                UIBalls.Add(uiBallType);

                currentBallsType[count] = ball;
                count++;
                position.x += 35;
            }
        }

        return currentBallsType;
    }

    public void SelectBall(string ballName)
    {
        for (int i = 0; i < UIBalls.Count; i++)
        {
            UIBallsType ball = UIBalls[i] as UIBallsType;
            
            if (ball.Name == ballName)
            {
                ball.gameObject.SetActive(false);
            }
        }
    }

    public string GetPlayerName(int playerNum)
    {
        return string.IsNullOrEmpty(players[playerNum].playerName.text) ? players[playerNum].defaultName : players[playerNum].playerName.text;
    }
}

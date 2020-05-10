using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level;
    public int coinScore; //The total money
    // public int totalScore;

    private lifeUI lifeUI;
    private moneyUI scoreUI;
    public int coinValue;
    public int valueDiagonalPlatform;
    public int HorizontalPlatform;
    public int boxKillEnemys;
    private PlayerController playerCont;
    // Start is called before the first frame update
    void Start()
    {
        playerCont = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        scoreUI = GameObject.Find("CoinScore").GetComponent<moneyUI>();
        lifeUI = GameObject.Find("LifeScore").GetComponent<lifeUI>();

        //Score Money
        coinScore = 0; 

        //Giving values
        coinValue = 1;
        valueDiagonalPlatform = 1;
        HorizontalPlatform = 0;
        boxKillEnemys = 0;

       //We update the UI at Start Game
        scoreUI.UpdateScoreUI(coinScore);
        lifeUI.UpdateLifeUI(playerCont.GetLifes());
    }

    //Changes the value of Money, 
    public void SetMoney(int value)
    {
        coinScore += value; //money 
        scoreUI.UpdateScoreUI(coinScore); //update money in UI
    }

    public int GetMoney()
    {
        return coinScore;
    }

}

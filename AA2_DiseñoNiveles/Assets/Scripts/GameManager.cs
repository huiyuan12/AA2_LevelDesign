using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    public int coinScore; //The total money
    // public int totalScore;

    private lifeUI lifeUI;
    private moneyUI scoreUI;
    public int coinValue;
    public int valueDiagonalPlatform;
    public int valueHorizontalPlatform;
    public int valueBoxKiller;
    private PlayerController playerCont;
    public  bool isPaused;
    public static int level;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("PlayerController") != null)
        {
            playerCont = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        }
        if (GameObject.Find("CoinScore") != null)
        {
            scoreUI = GameObject.Find("CoinScore").GetComponent<moneyUI>();
        }
        if (GameObject.Find("LifeScore") != null)
        {
            lifeUI = GameObject.Find("LifeScore").GetComponent<lifeUI>();
        }
        //Score Money
        coinScore = 0; 

        //Giving values
        coinValue = 1;
        valueDiagonalPlatform = 1;
        valueHorizontalPlatform = 0;
        valueBoxKiller = 0;
        isPaused = false;
        
    }
    void Update()
    {
        if (scoreUI != null)
        {
            scoreUI.UpdateScoreUI(coinScore);
        }
        if (lifeUI != null)
        {
            lifeUI.UpdateLifeUI(playerCont.GetLifes());
        }
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

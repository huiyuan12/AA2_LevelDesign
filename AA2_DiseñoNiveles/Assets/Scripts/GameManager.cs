using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public int level;
    public int coinScore;
   // public int totalScore;
   public int life;


    private lifeUI lifeUI;
    private moneyUI scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        coinScore = 0;
        life = 3;
        scoreUI = GameObject.Find("CoinScore").GetComponent<moneyUI>();
        lifeUI = GameObject.Find("LifeScore").GetComponent<lifeUI>();
        scoreUI.UpdateScoreUI(coinScore);
        lifeUI.UpdateLifeUI(life);
    }

    public void AddScore(int value)
    {
        coinScore += value;
        scoreUI.UpdateScoreUI(coinScore);
    }

}

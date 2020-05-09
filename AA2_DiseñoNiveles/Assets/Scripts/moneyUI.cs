using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyUI : MonoBehaviour
{
    public Text scoreText;

    // Use this for initialization
    void Awake()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    public void UpdateScoreUI(int newScore)
    {
        scoreText.text = newScore.ToString("0");
    }
}

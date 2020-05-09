using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lifeUI : MonoBehaviour
{
    public Text scoreText;

    // Use this for initialization
    void Awake()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    public void UpdateLifeUI(int newScore)
    {
        scoreText.text = newScore.ToString("0");
    }
}

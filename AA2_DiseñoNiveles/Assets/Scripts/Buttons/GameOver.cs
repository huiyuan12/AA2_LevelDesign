using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textScore;
    public Text textHighScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.level == 1)
            textScore.text = PlayerPrefs.GetInt("Score").ToString("0");
        if (GameManager.level == 2)
            textScore.text = PlayerPrefs.GetInt("TotalScore").ToString("0");

        textHighScore.text = PlayerPrefs.GetInt("HighScore").ToString("0");
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private GameManager gm;
    public int lifes;
    private int userMoney;
    private bool inmunity;
    public float timeInmunity;
    public float counterInmunity;

    public static bool gotIman;
    public float timeIman;
    public float counterIman;

    public int loseScore;
    public int totalScore;
    public int scorelv1;

    public int highScore;

    AudioSource audio;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
      
        speed = 2;
        timeInmunity = 10f; //10 segundos 
        counterInmunity = 0;
        timeIman = 25f; //10 segundos 
        counterIman = 0;
        gotIman = false;
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //velocidad runner, 
        if (!gm.isPaused) 
        rb.velocity = new Vector3(speed, rb.velocity.y);

        if (inmunity)
        {
         
            counterInmunity += Time.deltaTime;

            if (counterInmunity > timeInmunity)
            {
                counterInmunity = 0;
                inmunity = false;
            }
        }
        if (gotIman)
        {
            counterIman += Time.deltaTime;
            if (counterIman > timeIman)
            {
                counterIman = 0;
                gotIman = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //Collider with money
        if (other.tag == "Coin")
        {
            gm.SetMoney(gm.coinValue); //GiveMoney to GameManager
            Destroy(other.gameObject);   // Destroys the money
            audio.Play();
        }
        if (other.tag == "Iman")
        {
            gotIman = true;
          
            Destroy(other.gameObject);   // Destroys the money
        }
        //Logical between scenes
        //If player collides box, we get total lifes, if we have more than 0 lifes, the current level/scene will be restarted, otherwise we will send the player to the menu
        //This makes sense when are at level 2. 

        if (other.tag == "Box")
        {
            if (inmunity)
            {
                Destroy(other.gameObject);
            }
            else
            {
                lifes = PlayerPrefs.GetInt("lifes");
                lifes -= 1;
                if (lifes >= 1)
                {
                    PlayerPrefs.SetInt("lifes", lifes);
                    Debug.Log("hi");
                    string scene = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(scene);
                }
                else
                {
                    if(GameManager.level == 1)
                    {
                        PlayerPrefs.SetInt("Score", gm.coinScore);
                        if (gm.coinScore >= PlayerPrefs.GetInt("HighScore"))
                        {
                            PlayerPrefs.SetInt("HighScore", gm.coinScore);
                        }

                    }
                    if (GameManager.level == 2)
                    {
                        gm.highScore = PlayerPrefs.GetInt("HighScore");
                        //  totalScore = PlayerPrefs.GetInt("Score");
                        totalScore = gm.coinScore + PlayerPrefs.GetInt("Score");
                        PlayerPrefs.SetInt("TotalScore", totalScore);
                        if (totalScore >= gm.highScore)
                        {
                            PlayerPrefs.SetInt("HighScore", totalScore);
                        }
                    }
                    SceneManager.LoadScene(4);
                }
            }
            }

        //the same for enemy. The enemy can destroy diagonal platform, thats why we need box to kill enemy.
        if (other.tag == "Enemy")
        {
            if (inmunity)
            {
                Destroy(other.gameObject);
            }
            else {
                lifes = PlayerPrefs.GetInt("lifes");
                lifes -= 1;
                if (lifes >= 1)
                {
                    PlayerPrefs.SetInt("lifes", lifes);
                    Debug.Log("hi");
                    string scene = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(scene);
                }
                else
                {
                    if (GameManager.level == 1)
                    {
                        PlayerPrefs.SetInt("Score", gm.coinScore);
                        if (gm.coinScore >= PlayerPrefs.GetInt("HighScore"))
                        {
                            PlayerPrefs.SetInt("HighScore", gm.coinScore);
                        }
                    }
                    if (GameManager.level == 2)
                    {
                        gm.highScore = PlayerPrefs.GetInt("HighScore");
                        //  totalScore = PlayerPrefs.GetInt("Score");
                        totalScore = gm.coinScore + PlayerPrefs.GetInt("Score");
                        PlayerPrefs.SetInt("TotalScore", totalScore);
                        if (totalScore >= gm.highScore)
                        {
                            PlayerPrefs.SetInt("HighScore", totalScore);
                        }
                    }
                    SceneManager.LoadScene(4);
                }
            }
        }
            if (other.tag == "Lose")
            {
                lifes = PlayerPrefs.GetInt("lifes");
                lifes -= 1;
                if (lifes >= 1)
                {
                    PlayerPrefs.SetInt("lifes", lifes);
                    Debug.Log("hi");
                    SceneManager.LoadScene(1);
                }
                else
            {
                if (GameManager.level == 1)
                {
                    PlayerPrefs.SetInt("Score", gm.coinScore);
                    if (gm.coinScore >= PlayerPrefs.GetInt("HighScore"))
                    {
                        PlayerPrefs.SetInt("HighScore", gm.coinScore);
                    }
                }
                if (GameManager.level == 2)
                {
                    gm.highScore = PlayerPrefs.GetInt("HighScore");
                    //totalScore = PlayerPrefs.GetInt("Score");
                    totalScore = gm.coinScore + PlayerPrefs.GetInt("Score");
                    PlayerPrefs.SetInt("TotalScore", totalScore);
                    if (totalScore >= gm.highScore)
                    {
                        PlayerPrefs.SetInt("HighScore", totalScore);
                    }
                }
                SceneManager.LoadScene(4);
                }
            }
            if (other.tag == "BoxKillPlayer")
           {
            if (inmunity)
            {
                Destroy(other.gameObject);
            }
            else
            {
                lifes = PlayerPrefs.GetInt("lifes");
                lifes -= 1;
                if (lifes >= 1)
                {
                    PlayerPrefs.SetInt("lifes", lifes);
                    Debug.Log("hi");
                    string scene = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(scene);
                }
                else
                {
                    if (GameManager.level == 1)
                    {
                        PlayerPrefs.SetInt("Score", gm.coinScore);
                        if (gm.coinScore >= PlayerPrefs.GetInt("HighScore"))
                        {
                            PlayerPrefs.SetInt("HighScore", gm.coinScore);
                        }
                    }
                    if (GameManager.level == 2)
                    {
                        gm.highScore = PlayerPrefs.GetInt("HighScore");
                        //  totalScore = PlayerPrefs.GetInt("Score");
                        totalScore = gm.coinScore + PlayerPrefs.GetInt("Score");
                        PlayerPrefs.SetInt("TotalScore", totalScore);
                        if (totalScore >= gm.highScore)
                        {
                            PlayerPrefs.SetInt("HighScore", totalScore);
                        }
                    }
                    SceneManager.LoadScene(4);
                }
            }
        }
        if (other.tag == "Inmunity")
        {
            inmunity = true;
        }
        if (other.tag == "endLevel")
        {
            StartCoroutine(CompleteLevel());

        }
        if (other.tag == "endLevel2")
        {
            StartCoroutine(CompleteLevel2());
        }
    }
    public int GetMoney()
    {
        return userMoney;
    }
    public void SumMoney(int m)
    {
        userMoney += m;
    }
    public int GetLifes()
    {
       return PlayerPrefs.GetInt("lifes");
    }
    public void SetLifes(int m)
    {
        PlayerPrefs.SetInt("lifes", m);
    }
    IEnumerator CompleteLevel()
    {
        float speed2 = speed;
        speed = 0;
        yield return new WaitForSeconds(2);
        speed = speed2 ;
        SetLifes(3);
        PlayerPrefs.SetInt("Score", gm.coinScore);
        GameManager.level = 2;
        SceneManager.LoadScene(3);

    }
    IEnumerator CompleteLevel2()
    {
        float speed2 = speed;
        speed = 0;
        yield return new WaitForSeconds(2);
        speed = speed2;
        //  totalScore = PlayerPrefs.GetInt("Score");
        totalScore = gm.coinScore + PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("TotalScore", totalScore);
        if (totalScore >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", totalScore);
        }
        SceneManager.LoadScene(5);

    }
}

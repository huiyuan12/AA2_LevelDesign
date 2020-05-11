using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HUDButtons : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject diagPlatf;
    public GameObject HorizontalPlatf;
    public GameObject BoxKiller;
    private GameManager gm;
    public GameObject PausePanel;
    public Button pauseButton;
    private Text pausebuttonText;
    private Button horizontalButton;
    private Button diagButton;
    private Button boxButton;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        PausePanel.gameObject.SetActive(false);
        pausebuttonText = pauseButton.GetComponentInChildren<Text>();
        horizontalButton = GameObject.Find("ButtonCreateHorizontalPlatform").GetComponent<Button>();
        diagButton = GameObject.Find("ButtonCreateDiagonalPlatform").GetComponent<Button>();
        boxButton = GameObject.Find("ButtonCreateBoxKiller").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //Button that creates an diagonal platform if there is enough money
    public void instantiateDiagonalPlaform()
    {
        if (gm.GetMoney() >= gm.valueDiagonalPlatform) //the function ''Returncoins'' is the same thatOriol Created in playercontroller
        {
                GameObject newPlatf = Instantiate(diagPlatf);
            gm.SetMoney(-gm.valueDiagonalPlatform);
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
    public void instantiateHorizontalPlaform()
    {
        if (gm.GetMoney() >= gm.valueHorizontalPlatform) //the function ''Returncoins'' is the same thatOriol Created in playercontroller
        {
            GameObject newPlatf = Instantiate(HorizontalPlatf);
            gm.SetMoney(-gm.valueHorizontalPlatform);
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
    public void instantiateBoxKiller()
    {
        if (gm.GetMoney() >= gm.valueBoxKiller) //the function ''Returncoins'' is the same thatOriol Created in playercontroller
        {
            GameObject newPlatf = Instantiate(BoxKiller);
            gm.SetMoney(-gm.valueBoxKiller);
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
    public void pauseMenu()
    {
        gm.isPaused = true;
        PausePanel.gameObject.SetActive(true);
        pausebuttonText.text = "PAUSED";

        pauseButton.enabled = false;
        boxButton.enabled = false;
        horizontalButton.enabled = false;
        diagButton.enabled = false;
    }
    public void continueGame()
    {
        gm.isPaused = false;
        PausePanel.gameObject.SetActive(false);
        pausebuttonText.text = "PAUSE";
        pauseButton.enabled = true;
        boxButton.enabled = true;
        horizontalButton.enabled = true;
        diagButton.enabled = true;
      
    }
    public void RestartLevel()
    {
        int lifes;
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
            //game over
            SceneManager.LoadScene(0);
        }
    }
    public void GoMenu()
    {
          SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLevel1()
    {
      
        GameManager.level = 1;
        PlayerPrefs.SetInt("lifes", 3);
        SceneManager.LoadScene(1);
    }
    public void StartLevel2()
    {
  
        GameManager.level = 2;
        PlayerPrefs.SetInt("lifes", 3);
        SceneManager.LoadScene(3);
    }
}

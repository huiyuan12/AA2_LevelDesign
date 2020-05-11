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
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("lifes", 3);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("lifes", 3);
    }
}

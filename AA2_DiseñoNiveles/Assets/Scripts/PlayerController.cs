﻿using System.Collections;
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
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
      
        speed = 2;
        timeInmunity = 10f; //10 segundos 
        counterInmunity = 0;
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
                inmunity = false;
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
                    //restar puntos en playerprefs
                    SceneManager.LoadScene(0);
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
                    //game over

                    SceneManager.LoadScene(0);
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
                    //game over

                    SceneManager.LoadScene(0);
                }
            }
            if (other.tag == "BoxKill Player")
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
                    //game over

                    SceneManager.LoadScene(0);
                }
            }
        }
        if (other.tag == "Inmunity")
        {
            inmunity = true;
        }
        if (other.tag == "endLevel")
        {
            gm.endlv1 = true;
            SceneManager.LoadScene(3);
        }
        if (other.tag == "endLevel2")
        {
            gm.endlv2 = true;
            SceneManager.LoadScene(0);
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
}

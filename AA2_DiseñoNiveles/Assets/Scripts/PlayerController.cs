using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private GameManager gm;
    public int lifes;
    private int userMoney;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        speed = 2;
        lifes = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        //velocidad runner, 
        rb.velocity = new Vector3(speed, rb.velocity.y);

    }
    void OnTriggerEnter(Collider other)
    {
        //Collider with money
        if (other.tag == "Coin")
        {
            gm.SetMoney(gm.coinValue); //GiveMoney to GameManager
            Destroy(other.gameObject);   // Destroys the money
        }
        if (other.tag == "Box")
        {
           //Lose game
           //
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
        return lifes;
    }
    public void SetLifes(int m)
    {
        lifes += m;
    }
}

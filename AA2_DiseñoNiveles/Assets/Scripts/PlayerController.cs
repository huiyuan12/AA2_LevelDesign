using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private GameManager gm;
    private int coinValue;
    private int userMoney;

    void Start()
    {
        speed = 2;
        coinValue = 1;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocidad runner, 
        rb.velocity = new Vector3(speed, rb.velocity.y);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            gm.AddScore(coinValue); 
            Destroy(other.gameObject);   // Destruir la moneda.
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
}

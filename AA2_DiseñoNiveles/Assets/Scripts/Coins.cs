using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gotIman)
        {
            if (Vector3.Distance(transform.position, player.position) < 3)
            {
                //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);

            }
        }
    }
}

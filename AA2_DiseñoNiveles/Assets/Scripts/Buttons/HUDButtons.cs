using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDButtons : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject diagPlatf;
    private GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
   
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
}

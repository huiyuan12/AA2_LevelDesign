using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class scriptOnDrag : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private GameObject objPrefab;
    [SerializeField] private GameObject objImage;
    [SerializeField] private int objCost;

    PlayerController playerController;
    private GameObject objectImageInstanciated;
    private RectTransform rectTransform;
    private Vector2 objPos = Vector2.zero;
    public GameObject player;
    
    Collider2D col;
    Image me;
    bool changingRed;
    Text text;

    void Start()
    {
        me = this.GetComponent<Image>();
        playerController = player.GetComponent<PlayerController>();
        changingRed = false;
        text = transform.GetComponentInChildren<Text>();
        
    }

    void Update()
    {
        if (!changingRed && playerController.GetMoney() > objCost)
        {
            me.color = new Color32(255, 255, 255, 255); // a blanc
            text.color = new Color32(255, 255, 255, 255); // a blanc
        }
        if (!changingRed && playerController.GetMoney() < objCost)
        {
            me.color = new Color32(150, 150, 150, 255); // a gris
            text.color = new Color32(150, 150, 150, 255);
        }
    }

    // Start is called before the first frame update
    public void AddImageOnHUD()
    {
        GameObject player;
        if (tag == "AllyTroop") player = GameObject.Find("AllyEconomy");
        else player = GameObject.Find("EnemyEconomy");
        playerController = player.GetComponent<PlayerController>();
        if (playerController.GetMoney() > objCost)
            Instantiate(objImage, new Vector3(0, 1, -19), Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(objectImageInstanciated != null)
        {
            objPos = Input.mousePosition;
            objectImageInstanciated.transform.position = objPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         
        Collider2D[] cols = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.1f);
        foreach (Collider2D collision in cols)
        {
            if (collision.tag == "Respawn" && playerController.GetMoney() > objCost)
            {
                Instantiate(objPrefab, objPos, Quaternion.Euler(-90, 0, 0));
                playerController.SumMoney(-objCost);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (playerController.GetMoney() >= objCost)
        {
            objPos = (Vector2)Input.mousePosition;
            objectImageInstanciated = Instantiate(objImage, objPos, Quaternion.identity);
        }
        if (playerController.GetMoney() <= objCost)
        {
            ChangeColor();
        }
        rectTransform = objImage.GetComponent<RectTransform>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Destroy(objectImageInstanciated);
    }

    public void ChangeColor()
    {
        StartCoroutine("ChangingRed");
    }

  IEnumerator ChangingRed()
    {
        changingRed = true;
        for (float i=0f; i<= 0.3f; i += 0.02f)
        {
            me.color = new Color32(255, 57, 57, 255); ; // a red
            yield return new WaitForEndOfFrame();
            //yield  return new WaitForSeconds(0.01f);
        }
        changingRed = false;
        StopCoroutine("ChangingRed");
        //StartCoroutine("ChangingBlue");
    }

    IEnumerator ChangingBlue()
    {
        me.color = new Color32(255, 255, 255, 255); ; // a blan
       // me.color = new Color32(96, 96, 96, 255); ;
        yield return new WaitForEndOfFrame();
        //yield return new WaitForSeconds(0.01f);

        StopCoroutine("ChangingBlue");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public bool isPuttedOnScene;
    BoxCollider coliders; //colliders we will disable when we are dragging object
    void Start()
    {
        isPuttedOnScene = false;
        coliders = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the object has not been put on the scene, the object will follow the mouse and we disable de colliders
        if (isPuttedOnScene == false)
        {
            var pos = Input.mousePosition;
            pos.z = 1;
            pos = Camera.main.ScreenToWorldPoint(pos);
            transform.position = pos;
            coliders.enabled = false;
        }
        //when the player press mouse button, the object will have the position on last click of mouse, and we active colliders with the world. 

        if (Input.GetMouseButton(0) && isPuttedOnScene == false)
        {
            var pos = Input.mousePosition;
            pos.z = 1;
            pos = Camera.main.ScreenToWorldPoint(pos);
            transform.position = pos;
            coliders.enabled = true;
            isPuttedOnScene = true;

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestroyObject" && isPuttedOnScene == true)
        {
            Destroy(gameObject);
        }
    }
}

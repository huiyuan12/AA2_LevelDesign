using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float posX;
    public bool followX;
    private float velocityX = 0;
    public float smoothTimeX;
    public float offsetX;

    private float posY;
    public bool followY;
    private float velocityY = 0;
    public float smoothTimeY;
    public float offsetY;

    public float minY, maxY;

    public Transform targetTransform;

    // Use this for initialization
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;

        if (followX)
        {
            posX = targetTransform.position.x + offsetX;
        }
        if (followY)
        {
            posY = targetTransform.position.y + offsetY;
        }
        transform.position = new Vector3(posX, Mathf.Clamp(posY, minY, maxY), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (followX)
        {
            posX = Mathf.SmoothDamp(posX, targetTransform.position.x + offsetX, ref velocityX, smoothTimeX);
        }
        else
        {
            posX = transform.position.x;
        }

        if (followY)
        {
            posY = Mathf.SmoothDamp(posY, targetTransform.position.y + offsetY, ref velocityY, smoothTimeY);
        }
        else
        {
            posY = transform.position.y;
        }

        transform.position = new Vector3(posX, Mathf.Clamp(posY, minY, maxY), transform.position.z);

    }
}

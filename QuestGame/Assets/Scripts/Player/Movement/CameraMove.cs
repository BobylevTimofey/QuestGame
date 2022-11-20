using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform pointToFollow;
    [SerializeField]
    private float sensitivity = 20f;
    [SerializeField]
    private float smoothTime = 0.1f;
    [SerializeField]
    private float maxRotDown = 60f;
    [SerializeField]
    private float maxRotUp = -60f;

    private float xRotate;
    private float yRotate;
    private float xRotCurrent;
    private float yRotCurrent;

    private float currentVelosityX;
    private float currentVelosityY;

    private void Update()
    {
        if (Time.timeScale != 0)
            MouseMove();
        transform.position = pointToFollow.position;
    }

    private void MouseMove()
    {
        xRotate += Input.GetAxis("Mouse X") * sensitivity;
        yRotate += Input.GetAxis("Mouse Y") * sensitivity;

        yRotate = Mathf.Clamp(yRotate, maxRotUp, maxRotDown);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRotate, ref currentVelosityX, smoothTime * Time.deltaTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRotate, ref currentVelosityY, smoothTime * Time.deltaTime);


        transform.rotation = Quaternion.Euler(-yRotate, xRotate, 0);
        transform.parent.rotation = Quaternion.Euler(0, xRotate, 0);
    }
}

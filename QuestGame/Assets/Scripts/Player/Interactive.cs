using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    private Camera camera;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField]
    private float hitDistance;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        Ray();
        DrawRay();
    }

    private void Ray()
    {
        ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(ray, out hit, hitDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
        }
        else
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
}

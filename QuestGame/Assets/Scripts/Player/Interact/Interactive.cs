using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField]
    private GameObject interactPanel;
    [SerializeField]
    private LayerMask layerMask;
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField]
    private float hitDistance;

    private void Awake()
    {
        interactPanel.SetActive(false);
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        Ray();
        CheckInteract();
    }

    private void Ray()
    {
        ray = cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void CheckInteract()
    {
        if (Physics.Raycast(ray, out hit, hitDistance, layerMask.value))
        {
            interactPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
                hit.transform.gameObject.GetComponent<IInteractable>().Interact();
        }
        else
            interactPanel.SetActive(false);
    }
}

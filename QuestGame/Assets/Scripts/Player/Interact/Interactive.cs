using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [SerializeField]
    private char KeyToInteract;
    [SerializeField]
    private GameObject interactPanel;
    [SerializeField]
    private Animator animator;
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;
    public bool CanInteract;

    [SerializeField]
    private float hitDistance;

    private void Awake()
    {
        CanInteract = true;
        interactPanel.SetActive(false);
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
        if (Physics.Raycast(ray, out hit, hitDistance))
        {
            if (hit.collider.gameObject.layer == 3 && CanInteract)
            {
                var interactObj = hit.transform.gameObject.GetComponent<IInteractable>();

                interactPanel.SetActive(true);
                interactPanel.GetComponent<Text>().text = "[" + KeyToInteract + "] - " + interactObj.ActionText();

                Debug.DrawRay(ray.origin, ray.direction * hitDistance, Color.blue);

                if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), KeyToInteract.ToString())))
                {
                    interactObj.Interact();
                }
            }
            else
            {
                interactPanel.SetActive(false);
            }
        }
        else
        {
            interactPanel.SetActive(false);
            Debug.DrawRay(ray.origin, ray.direction * hitDistance, Color.red);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject minimap;
    public string ActionText()
    {
        return "����� �����";
    }

    public void Interact()
    {
        minimap.SetActive(true);
        Destroy(gameObject);
    }
}

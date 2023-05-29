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
        LevelChecker.IsTakeMap = true;
        PlayerNPC.Instance.PlayDialogue();
        minimap.SetActive(true);
        Destroy(gameObject);
    }
}

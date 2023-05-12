using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingZone : IInteractable
{
    [SerializeField] private GameObject fishingRod;

    public string ActionText()
    {
        if (Inventory.inventory.Contains(fishingRod.GetComponent<FishingRod>()))
            return "Забросить удочку";
        return "Для рыбалки нет удочки";
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

}

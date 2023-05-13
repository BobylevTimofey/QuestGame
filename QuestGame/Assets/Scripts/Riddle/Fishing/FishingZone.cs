using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingZone : MonoBehaviour, IInteractable
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
        if (Inventory.inventory.Contains(fishingRod.GetComponent<FishingRod>()))
            GetComponent<FishingRiddle>().StartFishing();
    }

}

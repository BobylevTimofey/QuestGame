using UnityEngine;

public class FishingZone : MonoBehaviour, IInteractable
{
    [SerializeField] private QuestObject fishingRod;

    public string ActionText()
    {
        return "Забросить удочку";
    }

    public void Interact()
    {
        if (Inventory.EquipedItem == fishingRod)
            GetComponent<FishingRiddle>().StartFishing();
        else
            Message.Instance.LoadMessage("Необходимо взять удочку", 1);
    }

}

using UnityEngine;

public class FishingZone : MonoBehaviour, IInteractable
{
    [SerializeField] private QuestObject fishingRod;

    public string ActionText()
    {
        return "��������� ������";
    }

    public void Interact()
    {
        if (Inventory.EquipedItem == fishingRod)
            GetComponent<FishingRiddle>().StartFishing();
        else
            Message.Instance.LoadMessage("���������� ����� ������", 1);
    }

}

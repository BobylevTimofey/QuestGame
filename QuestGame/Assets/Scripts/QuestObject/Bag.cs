using UnityEngine;

public class Bag : MonoBehaviour, IInteractable
{
    public string ActionText()
    {
        return "����� ������";
    }

    public void Interact()
    {
        Inventory.TakeBag();
        Destroy(gameObject);
    }
}

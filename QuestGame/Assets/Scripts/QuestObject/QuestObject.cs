using UnityEngine;

public abstract class QuestObject : MonoBehaviour, IInteractable
{
    public abstract double Weight { get; }
    public abstract string Name { get; }
    public abstract Vector3 EquipPosition { get; }
    public abstract Quaternion EquipRotation { get; }

    public Sprite Icon;

    public void Take()
    {
        Inventory.Add(this);
    }
    public void Drop()
    {
        Inventory.Drop(this);
    }

    public void Interact()
    {
        Take();
    }

    public void Equip()
    {
        Inventory.Equip(this);
    }

    public void Place(Transform place)
    {
        Inventory.Place(this, place);
    }

    public string ActionText()
    {
        return "Взять " + Name;
    }
}

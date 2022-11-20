using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestObject : MonoBehaviour, IInteractable
{
    public abstract double Weight { get; }
    public abstract string Name { get; }
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
}

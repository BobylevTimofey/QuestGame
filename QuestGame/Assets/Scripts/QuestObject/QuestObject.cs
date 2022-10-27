using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestObject : MonoBehaviour
{
    public abstract double Weight { get;}

    public void Take() 
    {
        Inventory.Add(this);
    }
    public void Drop()
    {
        Inventory.Drop(this);
    }
}

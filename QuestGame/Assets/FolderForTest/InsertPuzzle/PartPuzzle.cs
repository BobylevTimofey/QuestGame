using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class PartPuzzle : MonoBehaviour, IInteractable
{
    public InsertPuzzle Puzzle;
    public QuestObject CorrectObject;
    private QuestObject currentObject;
    public bool IsSolve;

    public string ActionText()
    {
        return "Поместить предмет";
    }

    public void Interact()
    {
        Debug.Log("Объект помещен");
        currentObject = Inventory.EquipedItem;
        currentObject.Drop();
        CheckObject();
        Puzzle.CheckPuzzle();
    }
    
    private void CheckObject()
    {
        if (currentObject.GetType() == CorrectObject.GetType())
            IsSolve = true;
        Debug.Log(IsSolve);
    }
}

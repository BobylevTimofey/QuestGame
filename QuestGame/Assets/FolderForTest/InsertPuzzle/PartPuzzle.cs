using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class PartPuzzle : MonoBehaviour, IInteractable
{
    private InsertPuzzle puzzle;
    [SerializeField]
    private QuestObject CorrectObject;
    private QuestObject currentObject;
    private BoxCollider _collider;
    public bool IsSolve;

    public string ActionText()
    {
        puzzle = transform.parent.parent.GetComponent<InsertPuzzle>();
        return "Поместить предмет";
    }

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            _collider.enabled = true;
            IsSolve = false;
        }
        else
            _collider.enabled = false;
    }
    public void Interact()
    {
        if (Inventory.EquipedItem == null)
            Message.Instance.LoadMessage("Необходимо выбрать предмет", 1);
        else
        {
            Debug.Log("Объект помещен");
            currentObject = Inventory.EquipedItem;
            currentObject.Place(transform);
            CheckObject();
            puzzle.CheckPuzzle();
        }
    }

    private void CheckObject()
    {
        IsSolve = currentObject.GetType() == CorrectObject.GetType();
        Debug.Log(IsSolve);
    }
}

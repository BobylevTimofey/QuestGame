using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Inventory
{

    public static List<QuestObject> inventory;
    public static QuestObject EquipedItem;

    private static double capacity;
    private static double currentWeihgt;
    private static InventoryFieldController inventoryController
        = GameObject.Find("InventoryController")
                    .GetComponent<InventoryFieldController>();

    static Inventory()
    {
        inventory = new List<QuestObject>();
        capacity = 0.5;
        currentWeihgt = 0;
    }

    public static void TakeBag()
    {
        capacity = 10;
    }

    public static void Add(QuestObject questObject)
    {
        questObject.gameObject.SetActive(false);
        if (currentWeihgt + questObject.Weight <= capacity)
        {
            currentWeihgt += questObject.Weight;
            inventory.Add(questObject);
            Debug.Log(questObject.Name);
        }
        else
        {
            Debug.Log("Bag is full");
        }
    }

    public static void Drop(QuestObject questObject)
    {
        if (questObject == EquipedItem)
            Unequip();
        questObject.gameObject.SetActive(true);
        currentWeihgt -= questObject.Weight;
        inventory.Remove(questObject);
        ClearInventoryItems();
        LoadInventoryItems();

    }

    public static void Equip(QuestObject questObject)
    {
        EquipedItem = questObject;
        questObject.gameObject.SetActive(true);
    }

    public static void Unequip()
    {
        if (EquipedItem != null)
            EquipedItem.gameObject.SetActive(false);
        EquipedItem = null;
    }

    public static void LoadInventoryItems()
    {
        foreach (var item in inventory)
        {
            inventoryController.Add(item);
        }
    }
    public static void ClearInventoryItems()
    {
        inventoryController.ClearField();
    }
}

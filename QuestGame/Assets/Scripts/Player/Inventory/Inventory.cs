using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        capacity = 6;
        currentWeihgt = 0;
    }

    public static void TakeBag()
    {
        capacity = 10;
    }

    public static void Add(QuestObject questObject)
    {
        if (currentWeihgt + questObject.Weight <= capacity)
        {
            questObject.transform.parent = null;
            questObject.gameObject.SetActive(false);
            currentWeihgt += questObject.Weight;
            inventory.Add(questObject);
            Debug.Log(questObject.Name);
        }
        else
        {
            Message.Instance.LoadMessage("–юкзак полон!", 1);
        }
    }

    public static void Drop(QuestObject questObject)
    {
        if (questObject == EquipedItem)
            Unequip();
        inventoryController.Drop(questObject);
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
        inventoryController.Equip(EquipedItem);
    }

    public static void Unequip()
    {
        if (EquipedItem != null)
            EquipedItem.gameObject.SetActive(false);
        EquipedItem = null;
    }

    public static void Place(QuestObject questObject, Transform place)
    {
        Unequip();
        questObject.gameObject.SetActive(true);
        inventoryController.Place(questObject, place);
        currentWeihgt -= questObject.Weight;
        inventory.Remove(questObject);
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

    public static void BlockInventoryOpen()
    {
        inventoryController.isBlocked = true;
    }

    public static void UnblockInventoryOpen()
    {
        inventoryController.isBlocked = false;
    }

    public static void PickUp(QuestObject questObject)
    {
        var needDropItem = inventory.Where(item => item.Name == questObject.name);
        foreach (var item in needDropItem)
            inventoryController.PickUp(item);
    }
}

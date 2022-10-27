using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    private static List<QuestObject> inventory;
    private static double capacity;
    private static double currentWeihgt;

    static Inventory()
    {
        inventory = new List<QuestObject>();
        capacity = 0.5;
        currentWeihgt = 0;
    }

    public static  void TakeBag()
    {
        capacity = 10;
    }

    public static void Add(QuestObject questObject)
    {
        if (currentWeihgt + questObject.Weight <= capacity)
            inventory.Add(questObject);
        else
            Debug.Log("Bag is full");
    }

    public static void Drop(QuestObject questObject)
    {
            inventory.Remove(questObject);
    }
}

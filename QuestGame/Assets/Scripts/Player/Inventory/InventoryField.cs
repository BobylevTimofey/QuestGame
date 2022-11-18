using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryField : MonoBehaviour
{
    [SerializeField]
    private Transform item;

    public void Add(QuestObject questObject)
    {
        var newItem = Instantiate(item, transform);
        newItem.GetChild(0).GetComponent<Image>().sprite = questObject.Icon;
        newItem.GetChild(1).GetComponent<Text>().text = questObject.Name;
        newItem.GetChild(2).GetComponent<Text>().text = questObject.Weight.ToString();
    }

    public void Drop(QuestObject questObject)
    {
     //TODO
    }
}

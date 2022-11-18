using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryField : MonoBehaviour
{
    [SerializeField]
    private Transform item;
    [SerializeField]
    private Transform pointToDrop;

    public Dictionary<ItemAction, QuestObject> questObjects;

    private void Start()
    {
        questObjects = new Dictionary<ItemAction, QuestObject>();
        transform.parent.gameObject.SetActive(false);
    }

    public void ClearField()
    {
        for (var i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }

    public void Add(QuestObject questObject)
    {
        var newItem = Instantiate(item, transform);
        newItem.GetChild(0).GetComponent<Image>().sprite = questObject.Icon;
        newItem.GetChild(1).GetComponent<Text>().text = questObject.Name;
        newItem.GetChild(2).GetComponent<Text>().text = questObject.Weight.ToString();
        questObjects.Add(newItem.GetComponent<ItemAction>(), questObject);
    }

    public void Drop(QuestObject questObject)
    {
        questObject.transform.position = pointToDrop.transform.position;
    }
}

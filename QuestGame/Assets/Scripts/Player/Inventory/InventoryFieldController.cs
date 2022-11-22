using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class InventoryFieldController : MonoBehaviour
{
    [SerializeField]
    private WindowsController windowsController;

    [SerializeField] 
    private Transform inventoryField;
    [SerializeField]
    private Transform item;
    [SerializeField]
    private Transform pointToDrop;
    [SerializeField]
    private Window inventoryUI;

    public Dictionary<ItemAction, QuestObject> questObjects;

    private void Start()
    {
        questObjects = new Dictionary<ItemAction, QuestObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OpenCloseInventory();
    }

    public void ClearField()
    {
        for (var i = 0; i < inventoryField.childCount; i++)
            Destroy(inventoryField.GetChild(i).gameObject);
    }

    public void Add(QuestObject questObject)
    {
        var newItem = Instantiate(item, inventoryField);
        newItem.GetChild(0).GetComponent<Image>().sprite = questObject.Icon;
        newItem.GetChild(1).GetComponent<Text>().text = questObject.Name;
        newItem.GetChild(2).GetComponent<Text>().text = questObject.Weight.ToString();
        questObjects.Add(newItem.GetComponent<ItemAction>(), questObject);
    }

    public void Drop(QuestObject questObject)
    {
        questObject.transform.position = pointToDrop.transform.position;
    }

    public void OpenCloseInventory()
    {
        if (!inventoryUI.gameObject.activeSelf)
        {
            windowsController.OpenWindow(inventoryUI);
            Inventory.LoadInventoryItems();
        }
        else
        {
            Inventory.ClearInventoryItems();
            windowsController.CloseWindow(inventoryUI);
        }
    }
}

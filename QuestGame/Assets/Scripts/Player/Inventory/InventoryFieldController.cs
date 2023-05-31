using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
    private Transform pointToEquip;
    [SerializeField]
    private Window inventoryUI;

    public Dictionary<ItemAction, QuestObject> QuestObjects;
    public bool isBlocked = false;

    private void Start()
    {
        QuestObjects = new Dictionary<ItemAction, QuestObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isBlocked)
            OpenCloseInventory();
        if (LevelChecker.IsHeroTakeTaskBlacksmith && !LevelChecker.IsHeroHelpBlacksmithWithOven)
            LevelChecker.IsHeroExtractedOre = Inventory.inventory.Where(item => item is IronOre).Count() == 4;
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
        newItem.GetChild(2).GetComponent<Text>().text = "Вес: " + questObject.Weight.ToString();
        QuestObjects.Add(newItem.GetComponent<ItemAction>(), questObject);
    }

    public void Drop(QuestObject questObject)
    {
        questObject.transform.parent = null;
        questObject.transform.position = pointToDrop.transform.position;
        questObject.transform.GetComponent<Collider>().enabled = true;
        questObject.transform.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Equip(QuestObject questObject)
    {
        questObject.transform.GetComponent<Collider>().enabled = false;
        questObject.transform.GetComponent<Rigidbody>().isKinematic = true;
        questObject.transform.SetParent(pointToEquip.transform);
        questObject.transform.localPosition = questObject.EquipPosition;
        questObject.transform.localRotation = questObject.EquipRotation;
    }
    public void Place(QuestObject questObject, Transform place)
    {
        questObject.transform.GetComponent<Collider>().enabled = true;
        questObject.transform.SetParent(place);
        questObject.transform.localPosition = Vector3.zero;
        questObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

    }

    public void PickUp(QuestObject questObject)
    {
        Inventory.Drop(questObject);
        Destroy(questObject.gameObject);
    }

    public void Unequip()
    {
        Inventory.Unequip();
    }

    public void OpenCloseInventory()
    {
        if (!inventoryUI.gameObject.activeSelf)
        {
            windowsController.OpenWindow(inventoryUI);
            Inventory.ClearInventoryItems();
            Inventory.LoadInventoryItems();
        }
        else
        {
            windowsController.CloseWindow(inventoryUI);
        }
    }
}

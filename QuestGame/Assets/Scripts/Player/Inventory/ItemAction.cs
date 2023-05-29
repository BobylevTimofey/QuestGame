using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemAction : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject chooseActionWindow;
    private InventoryFieldController inventoryController;
    private WindowsController windowsController;
    private Window gearPuzzleWindow;

    private void Awake()
    {
        inventoryController = FindObjectOfType<InventoryFieldController>();
        windowsController = FindObjectOfType<WindowsController>();
        chooseActionWindow.SetActive(false);
    }

    public UnityEvent OnPointerDown;
    public UnityEvent OnPointerExit;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnPointerDown?.Invoke();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        OnPointerExit?.Invoke();
    }

    public void Drop()
    {
        var droppedItem = inventoryController.QuestObjects[this];
        droppedItem.Drop();
    }

    public void Equip()
    {
        var equipedItem = inventoryController.QuestObjects[this];
        inventoryController.Unequip();
        equipedItem.Equip();
    }
}

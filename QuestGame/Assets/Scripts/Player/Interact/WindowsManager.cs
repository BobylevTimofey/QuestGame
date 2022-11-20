using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryUI;
    [SerializeField]
    private GameObject dialogueUI;
    [SerializeField]
    private GameObject BaseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OpenCloseInventory();
        CloseOtherWindows();
    }

    private void CloseOtherWindows()
    {
        if (inventoryUI.activeSelf)
        {
            dialogueUI.SetActive(false);
            BaseUI.SetActive(false);
        }
        else if (dialogueUI.activeSelf)
        {
            inventoryUI.SetActive(false);
            BaseUI.SetActive(false);
        }
        else if (BaseUI.activeSelf)
        {
            inventoryUI.SetActive(false);
            dialogueUI.SetActive(false);
        }
        else
            BaseUI.SetActive(true);
    }

    public void OpenCloseInventory()
    {
        if (!inventoryUI.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            inventoryUI.SetActive(true);
            Inventory.LoadInventoryItems();
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Inventory.ClearInventoryItems();
            inventoryUI.SetActive(false);
        }
    }
}

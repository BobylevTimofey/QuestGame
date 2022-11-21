using StarterAssets;
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

    private ThirdPersonController controller;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
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
        starterAssetsInputs.CanMove = inventoryUI.activeSelf;
        controller.LockCameraPosition = !inventoryUI.activeSelf;
        if (!inventoryUI.activeSelf)
        {
            starterAssetsInputs.move = Vector2.zero;
            starterAssetsInputs.jump = false;
            starterAssetsInputs.sprint = false;
            Cursor.lockState = CursorLockMode.None;
            inventoryUI.SetActive(true);
            Inventory.LoadInventoryItems();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Inventory.ClearInventoryItems();
            inventoryUI.SetActive(false);
        }
    }
}

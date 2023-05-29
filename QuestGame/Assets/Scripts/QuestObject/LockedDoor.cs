using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen;
    private Collider c;
    private bool canOpen;
    public QuestObject correctKey;
    private void Awake()
    {
        canOpen = false;
        isOpen = false;
        animator = GetComponent<Animator>();
        c = GetComponent<Collider>();

        animator.SetBool("IsOpen", false);
    }

    public void Interact()
    {
        if (Inventory.EquipedItem == correctKey)
        {
            canOpen = true;
            LevelChecker.IsOpenDoor = true;
            PlayerNPC.Instance.PlayDialogue();
        }
        if (canOpen)
        {
            animator.SetBool("IsOpen", !isOpen);
            isOpen = !isOpen;
        }
        else
        {
            Message.Instance.LoadMessage("Нужен ключ!\n[Е] - открыть инвентарь.", 3);
        }
    }

    public void DisableCollider()
    {
        c.enabled = false;
    }

    public void EnableCollider()
    {
        c.enabled = true;
    }

    public string ActionText()
    {
        return isOpen ? "Закрыть дверь" : "Открыть дверь";
    }
}
using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen;
    private Collider c;
    private bool canOpen;
    public QuestObject correctKey;
    private bool canDialgue = true;
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
            Inventory.Drop(Inventory.EquipedItem);
            canOpen = true;
            LevelChecker.IsTryOpenDoor = true;
            LevelChecker.IsOpenDoor = true;
            if (canDialgue)
            {
                canDialgue = false;
                PlayerNPC.Instance.PlayDialogue();
            }
        }
        if (canOpen)
        {
            animator.SetBool("IsOpen", !isOpen);
            isOpen = !isOpen;
        }
        else
        {
            LevelChecker.IsTryOpenDoor = true;
            PlayerNPC.Instance.PlayDialogue();
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
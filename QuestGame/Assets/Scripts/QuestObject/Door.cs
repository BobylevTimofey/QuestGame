using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen;
    private Collider c;
    private void Awake()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
        c = GetComponent<Collider>();

        animator.SetBool("IsOpen", false);
    }

    public void Interact()
    {
        animator.SetBool("IsOpen", !isOpen);
        isOpen = !isOpen;
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

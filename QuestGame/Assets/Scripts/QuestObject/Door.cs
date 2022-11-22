using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen;
    private Collider c;
    private void Start()
    {
        isOpen = false;
        animator = GetComponent<Animator>();
        c = GetComponent<Collider>();

        animator.SetBool("IsOpen", isOpen);
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
}

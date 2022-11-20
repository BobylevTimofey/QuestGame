using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        transform.localScale = transform.localScale * 3;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour, IInteractable
{
    private Animator animator;
    [SerializeField]
    private QuestObject correctKey;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public string ActionText()
    {
        return "Открыть люк";
    }

    public void Interact()
    {
        if (Inventory.EquipedItem == correctKey)
        {
            animator.Play("OpenHatch");
            LevelChecker.IsHeroFindFirstPartAI = true;
            gameObject.layer = 0;
        }
        else
            Message.Instance.LoadMessage("Нужен правильный ключ!", 2);
    }
}

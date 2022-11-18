using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
    private DialogueManager dialogueManager;
    private DialoguePlayer dialoguePlayer;
    public abstract int NPCId { get; }
    public int DialogueId { get => CheckId(); }

    public abstract int CheckId();

    public void Interact()
    {
        PlayDialogue();
    }

    public void PlayDialogue()
    {
        var phrases = dialogueManager.GetDialogue(this);
        dialoguePlayer.PlayDialogue(phrases);
    }

    private void Awake()
    {
        var dialogueController = GameObject.Find("DialogueController");
        dialogueManager = dialogueController.GetComponent<DialogueManager>();
        dialoguePlayer = dialogueController.GetComponent<DialoguePlayer>();
    }
}

using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
    private DialogueManager dialogueManager;
    private DialoguePlayer dialoguePlayer;
    private Animator animator;
    public abstract int NPCId { get; }
    public int DialogueId { get => CheckId(); }


    public string ActionText()
    {
        return "Говорить";
    }

    public abstract int CheckId();

    public void Interact()
    {
        PlayDialogue();
    }

    public void PlayDialogue()
    {
        var phrases = dialogueManager.GetDialogue(this);
        dialoguePlayer.PlayDialogue(phrases, animator);
    }

    private void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        var dialogueController = GameObject.Find("DialogueController");
        dialogueManager = dialogueController.GetComponent<DialogueManager>();
        dialoguePlayer = dialogueController.GetComponent<DialoguePlayer>();
    }
}

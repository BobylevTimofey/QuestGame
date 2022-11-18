using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class NPC : MonoBehaviour
//{
//    private DialogueManager dialogueManager;
//    private DialoguePlayer dialoguePlayer;
//    public abstract int NPCId { get; }
//    public int DialogueId { get => CheckId(); }

//    public abstract int CheckId();

//    public void PlayDialogue()
//    {
//        var phrases = dialogueManager.GetDialogue(this);
//        dialoguePlayer.PlayDialogue(phrases);
//    }

//    private void Awake()
//    {
//        dialogueManager = GameObject.Find("Camera").GetComponent<DialogueManager>();
//        dialoguePlayer = GameObject.Find("Camera").GetComponent<DialoguePlayer>();
//    }
//}

public class NPC : MonoBehaviour
{
    private GameObject dialogueController;
    private DialogueManager dialogueManager;
    private DialoguePlayer dialoguePlayer;
    public int NPCId { get => 0; }
    public int DialogueId { get => CheckId(); }

    public int CheckId()
    {
        return 1;
    }

    public void PlayDialogue()
    {
        var phrases = dialogueManager.GetDialogue(this);
        dialoguePlayer.PlayDialogue(phrases);
    }

    private void Awake()
    {
        dialogueController = GameObject.Find("DialogueController");
        dialogueManager = dialogueController.GetComponent<DialogueManager>();
        dialoguePlayer = dialogueController.GetComponent<DialoguePlayer>();
    }
}

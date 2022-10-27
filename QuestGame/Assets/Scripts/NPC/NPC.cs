using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC
{
    public abstract int NPCId { get; }
    public int DialogueId { get => CheckId(); }

    public abstract int CheckId();

    public void PlayDialogue()
    {

    }
}

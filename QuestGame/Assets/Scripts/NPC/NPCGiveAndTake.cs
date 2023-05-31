using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCGiveAndTake : NPC
{
    [SerializeField]
    private QuestObject givenQuestObject;
    [SerializeField]
    private QuestObject takenQuestObject;

    protected void GivePlayerQuestObject()
    {
        Inventory.Add(givenQuestObject);
    }

    protected void TakeQuestObjectFromPlayer()
    {
        if (Inventory.inventory.Contains(takenQuestObject))
            Inventory.PickUp(takenQuestObject);
    }
}

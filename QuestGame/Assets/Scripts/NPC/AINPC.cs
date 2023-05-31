using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINPC : NPC
{
    [SerializeField]
    private GameObject chapterController;

    public override int NPCId => 8;

    public override int CheckId()
    {
        if (LevelChecker.IsSolveQuestInCastleWithSearchItems)
            if (LevelChecker.IsHeroFindThirdPartAI)
                return 2;
            else
            {
                EndAction = EndDialogue;
                return 1;
            }
        else return 0;
    }

    private void EndDialogue()
    {
        chapterController.SetActive(true);
    }
}

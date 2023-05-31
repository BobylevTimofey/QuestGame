using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithNPC : NPCGiveAndTake
{
    public override int NPCId => 3;

    public override int CheckId()
    {
        if (LevelChecker.IsHeroTakeTaskBartender)
            if (LevelChecker.IsHeroExtractedOre)
                if (LevelChecker.IsHeroHelpBlacksmithWithOven)
                {
                    GivePlayerQuestObject();
                    LevelChecker.IsHeroGetDagger = true;
                    return 3;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                        TakeQuestObjectFromPlayer();
                    return 2;
                }
            else
            {
                EndAction = SetTrueHeroTakeTaskBlacksmith;
                return 1;
            }
        else return 0;
    }
    private void SetTrueHeroTakeTaskBlacksmith()
    {
        LevelChecker.IsHeroTakeTaskBlacksmith = true;
    }
}

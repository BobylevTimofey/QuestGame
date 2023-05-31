using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerNPC : NPCGiveAndTake
{
    public override int NPCId => 6;

    public override int CheckId()
    {
        if (LevelChecker.IsHeroTakeTaskBlacksmith)
            if (LevelChecker.IsHeroDidTaskMinerWithGears)
                if (LevelChecker.IsHeroFindFirstPartAI)
                    return 3;
                else
                {
                    LevelChecker.IsHeroDidTaskMinerWithGears = true;
                    GivePlayerQuestObject();
                    return 2;
                }
            else
            {
                LevelChecker.IsHeroTakeTaskMinerWithGears = true;
                return 1;
            }
        else return 0;
    }
}

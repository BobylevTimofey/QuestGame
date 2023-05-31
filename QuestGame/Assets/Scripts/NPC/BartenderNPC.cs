using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderNPC : NPCGiveAndTake
{
    public override int NPCId => 2;

    public override int CheckId()
    {
        if (LevelChecker.IsHeroTalkAIFirstTime)
            if (LevelChecker.IsHeroGetDagger)
            {
                TakeQuestObjectFromPlayer();
                GivePlayerQuestObject();
                LevelChecker.IsHeroReceivedHintFromBartender = true;
                return 2;
            }
            else
            {
                EndAction = SetTrueHeroTakeTaskBartender;
                return 1;
            }
        else return 0;
    }

    private void SetTrueHeroTakeTaskBartender()
    {
        LevelChecker.IsHeroTakeTaskBartender = true;
    }
}

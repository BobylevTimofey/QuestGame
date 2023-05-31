public class PlayerNPC : NPCGiveAndTake
{
    public static NPC Instance;

    public override int NPCId => 1;

    private void Start()
    {
        Instance = this;
        PlayDialogue();
    }

    public override int CheckId()
    {
        if (LevelChecker.IsGameStart)
            if (LevelChecker.IsTryOpenDoor)
                if (LevelChecker.IsOpenDoor)
                    if (LevelChecker.IsTakeMap)
                        if (LevelChecker.IsComeToMountain)
                            if (LevelChecker.IsOnBridge)
                                if (LevelChecker.IsInCastle)
                                    if (LevelChecker.IsHeroTalkAIFirstTime)
                                        return 7;
                                    else return 6;
                                else return 5;
                            else return 4;
                        else
                            return 3;
                    else
                    {
                        TakeQuestObjectFromPlayer();
                        return 2;
                    }
                else return 1;
            else
            {
                GivePlayerQuestObject();
                return 0;
            }
        else return -1;
    }
}

public class PlayerNPC : NPC
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
                            return 4;
                        else return 3;
                    else return 2;
                else return 1;
            else return 0;
        else return -1;
    }
}

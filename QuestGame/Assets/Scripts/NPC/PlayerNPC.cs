using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNPC : NPC
{
    public static NPC Instance;

    public override int NPCId => 0;

    private void Start()
    {
        Instance = this;
        PlayDialogue();
    }

    public override int CheckId()
    {
        if (LevelChecker.IsGameStart)
            if (LevelChecker.IsOpenDoor)
                if (LevelChecker.IsTakeMap)
                    return 2;
                else return 1;
            else return 0;
        else return -1;
    }
}

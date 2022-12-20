using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertPuzzle : MonoBehaviour
{
    public PartPuzzle[] PartsPuzzle;
    
    public void CheckPuzzle()
    {
        var allPartsIsSolve = true;
        foreach (var partPuzzle in PartsPuzzle)
            if (!partPuzzle.IsSolve)
                allPartsIsSolve = false;
        if (allPartsIsSolve)
            performVictoriousActions();
            
    }

    private void performVictoriousActions()
    {
        Debug.Log(" вест выполнен");
    }
}

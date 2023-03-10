using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertPuzzle : MonoBehaviour
{
    public List<PartPuzzle> PartsPuzzle;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            PartsPuzzle.Add(transform.GetChild(i).GetChild(0).GetComponent<PartPuzzle>());
    }
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
        Message.Instance.LoadMessage("Правильно!", 1);
        Debug.Log("Квест выполнен");
    }
}

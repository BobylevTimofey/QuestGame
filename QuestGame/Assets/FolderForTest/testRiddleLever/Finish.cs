using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Lever;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Прошел!");
        LevelChecker.IsSolveQuestLever = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Lever;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Прошел!");
        LevelChecker.IsSolveQuestLever = true;
    }
}

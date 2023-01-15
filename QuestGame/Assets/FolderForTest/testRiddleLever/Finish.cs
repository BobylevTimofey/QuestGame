using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Lever;
    private void OnTriggerEnter(Collider other)
    {
        if (LevelChecker.IsSolveQuestLever == false)
        {
            Debug.Log("Прошел!");
            Message.Instance.LoadMessage("Получилось!", 1);
            LevelChecker.IsSolveQuestLever = true;
        }
    }
}

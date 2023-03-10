using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] Lever lever;
    private bool isWin = false;


    private void Update()
    {
        if (isWin)
            Win();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (LevelChecker.IsSolveQuestLever == false)
            isWin = true;
    }

    private void Win()
    {
        lever.CanMove = false;
        lever.transform.SetParent(transform);
        var winPos = new Vector3(4, 0, 0);
        lever.transform.localPosition = Vector3.MoveTowards(lever.transform.localPosition, winPos, 5 * Time.deltaTime);
        if (lever.transform.localPosition == winPos)
            isWin = false;
        Debug.Log("Прошел!");
        Message.Instance.LoadMessage("Получилось!", 1);
        LevelChecker.IsSolveQuestLever = true;
    }
}

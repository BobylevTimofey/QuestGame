using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textTime;

    public void ResetTimer()
    {
        textTime.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    public void StartTimer(int seconds, Action actionEnd)
    {
        StartCoroutine(CounterTime(seconds, actionEnd));
        textTime.gameObject.SetActive(true);
    }

    IEnumerator CounterTime(int seconds, Action actionEnd)
    {
        for (var i = seconds; i >= 0; i--)
        {
            textTime.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        actionEnd();
    }
}

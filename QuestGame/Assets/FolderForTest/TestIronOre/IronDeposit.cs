using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronDeposit : MonoBehaviour
{
    public GameObject IronOre;
    private int counter = 0;
    public Slider MiningProgress;
    private readonly int WaitSeconds = 1;
    private int maxCount = 10;
    private int currentCount = 0;

    private void OnMouseDown()
    {
        if (currentCount < maxCount)
        {
            counter++;
            MiningProgress.gameObject.SetActive(true);
            MiningProgress.value = counter;
            if (counter == 3)
            {
                SpawnIronOre();
                counter = 0;
                currentCount++;
            }
        }
    }
    private void OnMouseUp()
    {
        StartCoroutine(WaitAndCloseProgress(WaitSeconds));
    }

    IEnumerator WaitAndCloseProgress(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        MiningProgress.gameObject.SetActive(false);
    }

    private void SpawnIronOre()
    {
        Instantiate(IronOre, transform.position + new Vector3(0, 0.5f), Quaternion.identity);
    }
}

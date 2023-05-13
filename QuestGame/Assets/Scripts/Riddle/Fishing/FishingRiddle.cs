using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FishingRiddle : MonoBehaviour
{
    [SerializeField] private int timeFishing = 10;
    [SerializeField] private int minWaitSeconds = 2;
    [SerializeField] private int maxWaitSeconds = 5;
    [SerializeField] private GameObject fishingRod;
    [SerializeField]
    private Slider sliderRun;
    [SerializeField]
    private Slider sliderMin;
    [SerializeField]
    private Slider sliderMax;
    [SerializeField]
    private Slider progress;
    [SerializeField]
    private bool isBite;
    private bool canWindowMove;

    public void StartFishing()
    {
        canWindowMove = true;
        fishingRod.GetComponent<FishingRod>().Equip();
        StartCoroutine(Bite());
        GetComponent<Collider>().enabled = false;
        Debug.Log("Рыбалка Началась");
    }

    private void Update()
    {
        if (isBite)
        {
            RunHandle();
            CheckHandle();
        }
        if (isBite && canWindowMove)
        {
            canWindowMove = false;
            RunWindowSlider();
        }
        if (isBite && Input.GetKey(KeyCode.F))
            sliderRun.value += 1 * Time.deltaTime;
    }

    private void CheckHandle()
    {
        if (sliderMin.value > sliderRun.value || sliderRun.value > sliderMax.value)
            progress.value -= 0.2f * Time.deltaTime;
        else
            progress.value += 0.2f * Time.deltaTime;
        if (progress.value == progress.maxValue)
            Win();

    }

    private void Win()
    {
        Debug.Log("Победа");
    }

    private void RunHandle()
    {
        sliderRun.value -= 0.5f * Time.deltaTime;
    }

    private void RunWindowSlider()
    {
        var rnd = new System.Random();
        var countStep = rnd.Next(1, 100);
        var delta = (float)((rnd.NextDouble() - 0.5) * 0.5 * Time.deltaTime);
        StartCoroutine(StepWindowSlider(countStep, delta));
    }
    IEnumerator StepWindowSlider(int countStep, float delta)
    {
        for (var i = 0; i < countStep; i++)
        {
            if (delta > 0)
            {
                if (sliderMax.value + delta < sliderMax.maxValue)
                {
                    sliderMax.value += delta;
                    sliderMin.value += delta;
                }
            }
            else
            {
                if (sliderMin.value + delta > sliderMax.minValue)
                {
                    sliderMax.value += delta;
                    sliderMin.value += delta;
                }
            }

            yield return new WaitForEndOfFrame();
        }
        canWindowMove = true;
    }

    private void StartSlider()
    {
        ActiveSlider();
        sliderRun.value = (sliderMin.value + sliderMax.value) / 2;
    }

    private int GetRandomSeconds()
    {
        var rnd = new System.Random();
        return rnd.Next(minWaitSeconds, maxWaitSeconds);
    }

    IEnumerator Bite()
    {
        yield return new WaitForSeconds(GetRandomSeconds());
        isBite = true;
        StartSlider();
    }

    private void ActiveSlider()
    {
        sliderRun.gameObject.SetActive(true);
        sliderMin.gameObject.SetActive(true);
        sliderMax.gameObject.SetActive(true);
        progress.gameObject.SetActive(true);
    }
}

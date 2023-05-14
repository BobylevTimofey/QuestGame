using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderQTE : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Slider sliderRun;
    [SerializeField]
    private Slider sliderMin;
    [SerializeField]
    private Slider sliderMax;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private ParticleSystem explosion;
    [SerializeField]
    private Light lightning;
    [SerializeField]
    private WindowsController windowsController;
    [SerializeField]
    private Window sliderQTEWindow;
    private int countStep = 3;
    private int currentStep;
    private int initialTimeRiddle = 20;
    private bool isCompleted;
    private bool isStart;
    private bool isStop;
    private bool isForwardRun = true;
    private int timeMessage = 3;

    [SerializeField]
    private CinemachineVirtualCamera cinemachine;
    private Transform previousCameraPoint;
    [SerializeField]
    private Transform cameraPoint;

    private void Awake()
    {
        lightning.enabled = false;
        previousCameraPoint = cinemachine.Follow;
    }
    public string ActionText()
    {
        if (!isCompleted)
            return "Раздуть печь";
        return "Квест уже выполнен";
    }

    public void Interact()
    {
        if (!isCompleted && !isStart)
        {
            windowsController.OpenWindow(sliderQTEWindow);
            StartStep();
            cinemachine.Follow = cameraPoint;
        }
    }

    private void StartStep()
    {
        GetComponent<Collider>().enabled = false;
        currentStep = 0;
        isStart = true;
        isStop = false;
        sliderRun.gameObject.SetActive(true);
        sliderMin.gameObject.SetActive(true);
        sliderMax.gameObject.SetActive(true);
        NextStep();
    }

    private void NextStep()
    {
        currentStep++;
        var timeDilator = 5;
        isStop = false;
        var maxDistanceValue = 0.3f / currentStep;
        var minValue = Random.Range(0, 1 - maxDistanceValue);
        var maxValue = minValue + maxDistanceValue;
        sliderMin.value = minValue;
        sliderMax.value = maxValue;
        timer.ResetTimer();
        timer.StartTimer(initialTimeRiddle - timeDilator * currentStep, FinishGameOnTime);
    }

    private void Update()
    {
        ExitByESC();
        if (isStart & !isStop)
            RunHandle();
        if (!isCompleted && isStart && Input.GetKeyDown(KeyCode.F))
            CheckResultStep();
    }

    private void CheckResultStep()
    {
        isStop = true;
        if (sliderRun.value >= sliderMin.value && sliderRun.value <= sliderMax.value)
        {
            if (currentStep < countStep)
            {
                NextStep();
                Message.Instance.LoadMessage("Еще разок!", timeMessage);
                explosion.Play();
            }
            else
                WinGame();
        }
        else
            LostGame();

    }

    private void WinGame()
    {
        LevelChecker.IsHeroHelpBlacksmithWithOven = true;
        Message.Instance.LoadMessage("Отлично все получилось!", timeMessage);
        isCompleted = true;
        ClearRiddle();
        explosion.Play();
        lightning.enabled = true;
        cinemachine.Follow = previousCameraPoint;
        windowsController.CloseWindow(sliderQTEWindow);
    }

    private void RunHandle()
    {
        var speedHandle = 1f * Time.deltaTime;
        if (sliderRun.value < sliderRun.maxValue && isForwardRun)
            sliderRun.value += speedHandle;
        else if (sliderRun.value > sliderRun.minValue)
        {
            sliderRun.value -= speedHandle;
            isForwardRun = false;
        }
        else
            isForwardRun = true;
    }

    private void FinishGameOnTime()
    {
        Message.Instance.LoadMessage("Не успел", timeMessage);
        ClearRiddle();
        cinemachine.Follow = previousCameraPoint;
        windowsController.CloseWindow(sliderQTEWindow);
    }

    private void LostGame()
    {
        Message.Instance.LoadMessage("Невовремя", timeMessage);
        ClearRiddle();
        cinemachine.Follow = previousCameraPoint;
        windowsController.CloseWindow(sliderQTEWindow);
    }

    private void ExitByESC()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearRiddle();
            cinemachine.Follow = previousCameraPoint;
        }
    }

    private void ClearRiddle()
    {
        GetComponent<Collider>().enabled = true;
        sliderRun.gameObject.SetActive(false);
        sliderMin.gameObject.SetActive(false);
        sliderMax.gameObject.SetActive(false);
        timer.ResetTimer();
        isStart = false;
    }
}

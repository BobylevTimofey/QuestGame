using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzleInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private WindowsController windowsController;
    [SerializeField]
    private Window LeverCanvas;
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;
    [SerializeField]
    private Transform cameraPoint;
    private BoxCollider collider;
    private Transform previousCameraPoint;
    private void Awake()
    {
        previousCameraPoint = cinemachine.Follow;
        collider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (LeverCanvas.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            collider.enabled = true;
            windowsController.CloseWindow(LeverCanvas);
            cinemachine.Follow = previousCameraPoint;
        }
    }

    public string ActionText()
    {
        return "Переключить рычаг";
    }

    public void Interact()
    {
        cinemachine.Follow = cameraPoint;
        windowsController.OpenWindow(LeverCanvas);
        collider.enabled = false;
    }
}

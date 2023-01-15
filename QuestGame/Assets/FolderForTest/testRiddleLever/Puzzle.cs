using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string actionText;
    [SerializeField]
    private WindowsController windowsController;
    [SerializeField]
    private Window PuzzleCanvas;
    [SerializeField]
    private CinemachineVirtualCamera cinemachine;
    [SerializeField]
    private Transform cameraPoint;
    private BoxCollider _collider;
    private Transform previousCameraPoint;
    private void Awake()
    {
        previousCameraPoint = cinemachine.Follow;
        _collider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (PuzzleCanvas.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPuzzle();
        }
    }

    public void ExitPuzzle()
    {
        windowsController.CloseWindow(PuzzleCanvas);
        _collider.enabled = true;
        cinemachine.Follow = previousCameraPoint;
    }

    public string ActionText()
    {
        return actionText;
    }

    public void Interact()
    {
        cinemachine.Follow = cameraPoint;
        windowsController.OpenWindow(PuzzleCanvas);
        _collider.enabled = false;
    }
}

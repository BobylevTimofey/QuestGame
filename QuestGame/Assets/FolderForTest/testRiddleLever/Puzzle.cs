using Cinemachine;
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
    [SerializeField]
    private Transform cutsceneCameraPoint;
    private BoxCollider _collider;
    private Transform previousCameraPoint;
    public bool CanSolve;

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
        CanSolve = false;
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
        CanSolve = true;
        cinemachine.Follow = cameraPoint;
        windowsController.OpenWindow(PuzzleCanvas);
        _collider.enabled = false;
    }

    public void PlayCutscene()
    {
        windowsController.CloseWindow(PuzzleCanvas);
        cinemachine.Follow = cutsceneCameraPoint;
    }

    public void EndCutscene()
    {
        ExitPuzzle();
    }
}

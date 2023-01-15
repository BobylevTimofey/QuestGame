using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    private bool stopMoving;
    [SerializeField]
    private bool enableCursor;
    [SerializeField]
    private bool stopTime;
    public bool OpenFromOtherWindows;
    [SerializeField]
    private bool closeByEscape;

    private GameObject player;
    private ThirdPersonController controller;
    private StarterAssetsInputs starterAssetsInputs;
    private Interactive interactive;
    private WindowsController windowsController;

    private void Awake()
    {
        windowsController = transform.parent.GetComponent<WindowsController>();
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<ThirdPersonController>();
        starterAssetsInputs = player.GetComponent<StarterAssetsInputs>();
        interactive = player.GetComponent<Interactive>();
    }

    private void Update()
    {
        if (closeByEscape && Input.GetKeyDown(KeyCode.Escape))
            CloseWindow();
    }

    public void ApplyParameters()
    {
        if (!stopMoving && !enableCursor)
            BasicParameters();
        else
        {
            if (stopMoving)
                StopMoving();
            if (enableCursor)
                EnableCursor();
            if (stopTime)
                StopTime();
        }
    }

    private void StopMoving()
    {
        starterAssetsInputs.CanMove = false;
        starterAssetsInputs.move = Vector2.zero;
        starterAssetsInputs.jump = false;
        starterAssetsInputs.sprint = false;
        interactive.CanInteract = false;
    }

    private void EnableCursor()
    {
        controller.LockCameraPosition = true;
        Cursor.lockState = CursorLockMode.None;
        interactive.CanInteract = false;
    }

    private void BasicParameters()
    {
        Time.timeScale = 1f;
        starterAssetsInputs.CanMove = true;
        controller.LockCameraPosition = false;
        interactive.CanInteract = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    private void CloseWindow()
    {
        windowsController.CloseWindow(this);
    }
}

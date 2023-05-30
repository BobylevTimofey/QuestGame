using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    public List<Window> windowsList;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            windowsList.Add(transform.GetChild(i).GetComponent<Window>());
        CloseOtherWindows(windowsList[0]);
    }

    private void CloseOtherWindows(Window activeWindow)
    {
        foreach (var window in windowsList)
            if (!window.Equals(activeWindow))
                window.gameObject.SetActive(false);
    }

    public void OpenWindow(Window window)
    {
        if (window.OpenFromOtherWindows)
        {
            window.gameObject.SetActive(true);
            CloseOtherWindows(window);
            window.ApplyParameters();
        }
        else
        {
            if (windowsList
                .Skip(1)
                .Where(win => !win.Equals(window))
                .Any(win => win.gameObject.activeSelf))
                window.gameObject.SetActive(false);
            else
            {
                window.gameObject.SetActive(true);
                CloseOtherWindows(window);
                window.ApplyParameters();
            }
        }
    }

    public void CloseWindow(Window window)
    {
        window.gameObject.SetActive(false);
        OpenWindow(windowsList[0]);
    }
}

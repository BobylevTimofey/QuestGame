using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField]
    private Transform messageText;
    public static Message Instance;

    private void Awake()
    {
        messageText.gameObject.SetActive(false);
        Instance = this;
    }

    public void LoadMessage(string message, float seconds)
    {
        StartCoroutine(ShowMessage(message, seconds));
    }

    IEnumerator ShowMessage(string message, float seconds)
    {
        messageText.gameObject.SetActive(true);
        messageText.GetComponent<Text>().text = message;
        yield return new WaitForSeconds(seconds);
        messageText.gameObject.SetActive(false);
    }
}

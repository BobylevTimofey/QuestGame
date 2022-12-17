using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    [SerializeField]
    private WindowsController windowsController;

    public Window DialogueCanvas;
    public Text NameOutput;
    public Text TextOutput;
    private Queue<Phrase> phrasess;
    private bool IsPlaying;
    private Animator newAnimator;

    public void PlayDialogue(Queue<Phrase> phrases, Animator animator)
    {
        newAnimator = animator;
        phrasess = phrases;
        windowsController.OpenWindow(DialogueCanvas);
        NextPhrase();
    }

    public void NextPhrase()
    {
        if (phrasess.Count == 0)
        {
            EndDialogue();
            newAnimator.SetBool("IsTalk", false);
            return;
        }
        var phrase = phrasess.Dequeue();
        if (phrase.Name != "Игрок")
            newAnimator.SetBool("IsTalk", true);
        NameOutput.text = phrase.Name;
        IsPlaying = true;
        StartCoroutine(TypePhrase(phrase.Text));
    }

    IEnumerator TypePhrase(string phrase)
    {
        TextOutput.text = "";
        foreach (var letter in phrase.ToCharArray())
        {
            TextOutput.text += letter;
            yield return null;
        }
        IsPlaying = false;
    }

    private void EndDialogue()
    {
        windowsController.CloseWindow(DialogueCanvas);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !IsPlaying)
            NextPhrase();
    }
}

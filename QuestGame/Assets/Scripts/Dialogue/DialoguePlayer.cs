using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    public Canvas DialogueCanvas;
    public Text NameOutput;
    public Text TextOutput;
    private Queue<Phrase> phrasess;
    private bool isPrinting;//
    private bool isOne = true;//
    public NPC npc;//
    public void PlayDialogue(Queue<Phrase> phrases)
    {
        phrasess = phrases;
        DialogueCanvas.gameObject.SetActive(true);
        NextPhrase();
    }

    public void NextPhrase()
    {
        if (phrasess.Count == 0)
        {
            EndDialogue();
            return;
        }
        var phrase = phrasess.Dequeue();
        NameOutput.text = phrase.Name;
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
        isPrinting = true;
    }

    private void EndDialogue()
    {
        DialogueCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && isOne) //
        {
            npc.PlayDialogue();
            isOne = false;
        }//
        if (Input.GetKey(KeyCode.Return) && !isPrinting)
        {
            NextPhrase();
            isPrinting = true;
        }
    }
}

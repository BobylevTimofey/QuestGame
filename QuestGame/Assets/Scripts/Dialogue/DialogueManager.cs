using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DialogueManager : MonoBehaviour
{
    private XmlDocument xmlDialogues;
    public Queue<Phrase> GetDialogue(NPC npc)
    {
        var dialogues = xmlDialogues.DocumentElement;
        foreach (XmlNode hero in dialogues)
            if (int.Parse(hero.Attributes.GetNamedItem("id").Value) == npc.NPCId)
                return FindRequiredDialogue(npc, hero);
        return null;
    }

    private Queue<Phrase> FindRequiredDialogue(NPC npc, XmlNode hero)
    {
        foreach (XmlNode dialogue in hero)
            if (int.Parse(dialogue.Attributes.GetNamedItem("id").Value) == npc.DialogueId)
                return GetPhrase(dialogue);
        return null;
    }

    private Queue<Phrase> GetPhrase(XmlNode dialogue)
    {
        var phrases = new Queue<Phrase>();
        foreach (XmlNode phrase in dialogue)
            phrases.Enqueue(new Phrase(phrase.Attributes.GetNamedItem("name").Value, phrase.InnerText));
        return phrases;
    }

    private void Awake()
    {
        xmlDialogues = new XmlDocument();
        xmlDialogues.Load("Dialogues.xml");
    }
}


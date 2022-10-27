using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrase : MonoBehaviour
{
    public string Name { get; }
    public string Text { get; }

    public Phrase(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

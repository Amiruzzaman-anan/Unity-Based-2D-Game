using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Voice_command : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private readonly Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        
        actions.Add("top", Up);
        actions.Add("down", Down);
        

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    
    private void Up()
    {
        transform.Translate(0, 2, 0);

    }

    private void Down()
    {
        transform.Translate(0, -2, 0);
    }
}

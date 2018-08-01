using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour {

    private Dictionary<string,Action> keywordActions = new Dictionary<string, Action>();
    KeywordRecognizer keywordRecognizer;

	void Start () {
        keywordActions.Add("Next", Next);
        keywordActions.Add("Click", Click);
        keywordActions.Add("Action", Click);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordRecognized;
        keywordRecognizer.Start();
    }

    private void OnKeywordRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("VioceControl: Keyword Recognized - " + args.text);
        keywordActions[args.text].Invoke();
    }

    private void Click()
    {
        throw new NotImplementedException();
    }

    private void Next()
    {
        throw new NotImplementedException();
    }
}

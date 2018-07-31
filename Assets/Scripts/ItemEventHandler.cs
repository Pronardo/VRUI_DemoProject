using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VRInteractiveItem))]
public class ItemEventHandler : MonoBehaviour {

    private VRInteractiveItem interactable;
    public UnityEvent GazeEnterEvent;
    public UnityEvent GazeLeaveEvent;
    public UnityEvent ActivationEvent;

    // Use this for initialization
    void Start () {
        interactable = GetComponent<VRInteractiveItem>();
        interactable.OnOver += OnGazeEnter;
        interactable.OnOut += OnGazeLeave;
        interactable.OnClick += OnActivation;
    }

    public void OnActivation()
    {
        Debug.Log("ItemEventHandler: Do Action");
        ActivationEvent.Invoke();
    }

    void OnGazeEnter()
    {
        Debug.Log("ItemEventHandler: GazeEnter");
        ProcessTimeGazeable(true);
            GazeEnterEvent.Invoke();
    }

    void OnGazeLeave()
    {
        Debug.Log("ItemEventHandler: GazeLeave");
        ProcessTimeGazeable(false);
            GazeLeaveEvent.Invoke();
    }

    private void ProcessTimeGazeable(bool enableStat)
    {
        var gazeable = this.gameObject.GetComponent<TimeGazeable>();
        if (gazeable != null) { gazeable.enabled = enableStat; }
        else { Debug.Log("ItemEventHandler: Script TimeGazeable not attached -> Time-based gazing disabled!"); }
    }
}

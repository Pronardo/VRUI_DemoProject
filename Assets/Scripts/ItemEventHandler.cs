using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VRInteractiveItem))]
public class ItemEventHandler : MonoBehaviour {

    private VRInteractiveItem interactable;
    public UnityEvent GazeEnterEvent;
    public UnityEvent GazeLeaveEvent;

    // Use this for initialization
    void Start () {
        interactable = GetComponent<VRInteractiveItem>();
        interactable.OnOver += OnGazeEnter;
        interactable.OnOut += OnGazeLeave;
    }

    void OnGazeEnter()
    {
        GazeEnterEvent.Invoke();
    }

    void OnGazeLeave()
    {
        GazeLeaveEvent.Invoke();
    }
}

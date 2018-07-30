using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGazeable : MonoBehaviour
{
    private float timeRemaining;
    private float gazeTimer;

    public delegate void GazeInsideEvent(float amount);
    public GazeInsideEvent InsideGaze;
    public delegate void GazeOutEvent();
    public GazeOutEvent OutOfGaze;


    private void OnEnable()
    {
        Debug.Log("TimeGazeable - OnEnable");
        var cam = GameObject.Find("VRCamera").transform;
        if (cam == null) { Debug.LogError("VR without VRCamera is horribly wrong!"); this.enabled = false; }
        gazeTimer = cam.GetComponent<VREyeRaycaster>().GazeTimer;
        timeRemaining = gazeTimer;        
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (InsideGaze != null)
        {
            Debug.Log("TimeGazeable - AddTime to ProgressBar");
            InsideGaze(Time.deltaTime);
        }
        if (timeRemaining < 0)
        {
            Debug.Log("TimeGazeable: Sharp Gaze - Do Action!");
            this.GetComponent<ItemEventHandler>().OnActivation();

            this.enabled = false;
        }
    }
    private void OnDisable()
    {
        Debug.Log("TimeGazeable - OnDisable");
        if (OutOfGaze != null)
        {
            OutOfGaze();
        }
    }
}

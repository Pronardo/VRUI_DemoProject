using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGazeable : MonoBehaviour
{
    public float GazeTimer = 0.0f;
    [Tooltip("The local variable will be overwritten & apply the value of the VRCamera on start, if checked")]
    public bool TimeGazeGlobally = true;

    private float timeRemaining;

    // Use this for initialization
    private void OnEnable()
    {
        if (TimeGazeGlobally)
        {
            GazeTimer = GameObject.Find("VRCamera").GetComponent<VREyeRaycaster>().GazeTimer;
        }
        timeRemaining = GazeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            this.GetComponent<ItemEventHandler>().OnActivation();
            Debug.Log("TimeGazeable: Sharp Gaze - Do Action!");
            this.enabled = false;
        }
    }
}

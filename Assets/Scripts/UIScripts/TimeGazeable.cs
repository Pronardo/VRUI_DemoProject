using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGazeable : MonoBehaviour
{
    private float timeRemaining;
    private float gazeTimer;

    private void OnEnable()
    {
        gazeTimer = GameObject.Find("VRCamera").GetComponent<VREyeRaycaster>().GazeTimer;
        timeRemaining = gazeTimer;
    }

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

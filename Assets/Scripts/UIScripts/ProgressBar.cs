using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Transform TextIndicator;
    [Tooltip("The delay [in milliseconds] for hiding the loading in progress elements")]
    public int HideDelay = 500;

    private float fillTime;
    private VREyeRaycaster raycaster;
    private float currentAmount;
    private float percentage;
    private Image progressGraph;

    private VRInteractiveItem[] interactables;
    private TimeGazeable[] gazeables;

    private void OnEnable()
    {
        Debug.Log("ProgressBar - OnEnable");
        var cam = GameObject.Find("VRCamera");
        if (cam == null) { Debug.LogError("VR without VRCamera is horribly wrong!"); this.enabled = false; }
        raycaster = cam.GetComponent<VREyeRaycaster>();
        progressGraph = this.transform.Find("ProgressGraph").GetComponent<Image>();
        fillTime = raycaster.GazeTimer;
        gazeables = GetComponents<TimeGazeable>();
        foreach (var gazeable in gazeables)
        {
            gazeable.InsideGaze += RefreshLoadingState;
            gazeable.OutOfGaze += Reset;
        }
    }

    /*void Update () {
	if(currentAmount<fillTime)
        {
            currentAmount += Time.deltaTime;
            percentage = currentAmount / fillTime;
            TextIndicator.GetComponent<Text>().text = ((int)(percentage*100)).ToString() + "%";
        }
        else
        {
            Debug.Log("ProgressLoading - ProgressBarFull");
            Wait(HideDelay);
            TextIndicator.gameObject.SetActive(false);
            LoadingBar.gameObject.SetActive(false);
            this.enabled = false;
        }
        LoadingBar.GetComponent<Image>().fillAmount = percentage;
    }*/

    public void RefreshLoadingState(float amount)
    {
        Debug.Log("ProgressBar - RefreshLoadingState");
        progressGraph.fillAmount=amount/fillTime; Debug.Log("" + amount / fillTime);
        if(TextIndicator!=null)
        {
            TextIndicator.GetComponent<Text>().text = ((int)(percentage * 100)).ToString() + "%";
        }
    }

    private void Wait(int milliseconds)
    {
        System.Threading.Thread.Sleep(milliseconds);
    }

    public void Reset()
    {
        Debug.Log("ProgressBar - Reset");
        progressGraph.fillAmount = 0;
        TextIndicator.GetComponent<Text>().text = "";
    }

    private void OnDisable()
    {
        foreach (var gazeable in gazeables)
        {
            gazeable.InsideGaze -= RefreshLoadingState;
            gazeable.OutOfGaze -= Reset;
        }
    }
}

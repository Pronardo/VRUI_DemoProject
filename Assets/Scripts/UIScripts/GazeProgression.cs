using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressLoading))]
public class GazeProgression : MonoBehaviour
{

    private bool gazing = false;
    private VREyeRaycaster raycaster;
    private VRInteractiveItem interactable;
    private ProgressLoading progressbar;

    void Start()
    {
        raycaster = this.transform.parent.GetComponent<VREyeRaycaster>();
        if (raycaster == null) { Debug.LogError("GazeProgression: No VREYeRaycaster found"); this.enabled = false; }
        progressbar = this.GetComponent<ProgressLoading>();
        DisableProgressionBar();
        Debug.Log("GazeProgression - OnStart");
    }

    void Update()
    {
        interactable = getCurrentInteractable();
        if (interactable!=null&&interactable.IsOver)
        {
            EnableProgressionBar();
        }
    }

    private VRInteractiveItem getCurrentInteractable()
    {
        return raycaster.CurrentInteractible;
    }

    private void EnableProgressionBar()
    {
        Debug.Log("GazeProgression: Enable ProgressionBar for current gaze action");
        progressbar.enabled = true;
    }

    private void DisableProgressionBar()
    {
        Debug.Log("GazeProgression: Disable ProgressionBar for current gaze action");
        progressbar.enabled = false;
    }
}

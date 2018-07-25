using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScanFrameResizer))]
public class DynamicScanFrame : MonoBehaviour
{
    //DynamicScanFrame is optional and allows to change resp. adapt the size of the ScanFrame during run-time
    //DynamicScanFrame uses ScanFrameResizer's methods to operate
    private ScanFrameResizer resizer;
    private GameObject scannable;
    private Vector3 currentRegistedScales;

    void Start()
    {
        resizer = this.GetComponent<ScanFrameResizer>();
        if (resizer == null) { Debug.LogError("ScanFrameResizer is needed as base script for DynamicScanFrame"); this.enabled = false; }
        scannable = getCurrentScannable();
        currentRegistedScales = resizer.GetScannableSize();
    }

    void Update()
    {
        if (currentRegistedScales != resizer.GetScannableSize())
        {
            resizer.ResizeFrame();
        }
    }

    public GameObject getCurrentScannable()
    {
        scannable = resizer.ScannableObject; if (scannable == null) { Debug.Log("scannable is null!"); }
        return scannable;
    }
}

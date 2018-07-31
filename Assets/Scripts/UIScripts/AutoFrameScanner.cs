using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFrameScanner : MonoBehaviour
{
    [Tooltip("The time in seconds waited until scanning the next ScannableObject")]
    public float ScanDelay = 3;

    private ScanFrameHandler handler;
    private ScanningBehaviour[] scannables;

    void Start()
    {
        Debug.Log("AutoFrameScanner - OnStart");
        scannables = FindObjectsOfType(typeof(ScanningBehaviour)) as ScanningBehaviour[];
        foreach (var scannable in scannables)
        {
            scannable.UnsubscribeFromUnityEvents();
            Debug.Log("AutoFrameScanner: Unsubscribed ManuScanning-Events of "+scannable.gameObject.name);
        }
        handler = this.GetComponent<ScanFrameHandler>();
        StartCoroutine(ScanningRoutine());
    }

    private IEnumerator ScanningRoutine()
    {
        while (true)
        {
            foreach (var scannable in scannables)
            {
                if(scannable.enabled)
                {
                    handler.EnableFrame(scannable.ScanningObjectType, scannable.gameObject);
                    yield return new WaitForSeconds(ScanDelay);
                    handler.ResetFame();
                    Debug.Log("AutoFrameScanner: Scanning another scannable");
                }
            }
             Debug.Log("AutoFrameScanner: Just ended an iteration over all scannables -> Time for next one");
        }
    }
}

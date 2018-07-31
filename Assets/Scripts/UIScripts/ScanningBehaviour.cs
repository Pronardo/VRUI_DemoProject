using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningBehaviour : MonoBehaviour
{
    public ScannableType ScanningObjectType = ScannableType.RECTANGLE;

    private GameObject ScanFrameManager;
    private ScanFrameHandler frameHandleMeths;

    void Start()
    {
        Debug.Log("ScanningBehaviour - OnStart");
        ScanFrameManager = GameObject.Find("ScanFrameManager");
        if (ScanFrameManager == null)
        {
            ScanFrameManager = Instantiate((GameObject)Resources.Load("ScanFrameManager"));
        }
        frameHandleMeths = ScanFrameManager.GetComponent<ScanFrameHandler>();
        if (frameHandleMeths == null) { Debug.LogError("ScanningBehaviour: The ScanFrameManager can only work with ScanningManagement script attached"); this.enabled = false; }

        Unscan();
    }

    //Order to spawn scan frame around the Object the script is attached to
    public void Scan()
    {
        frameHandleMeths.EnableFrame(ScanningObjectType, this.gameObject);
        Debug.Log("ScanningBehaviour: Scan - activate frame");
    }

    //Order to undo the scanning frame
    public void Unscan()
    {
        frameHandleMeths.ResetFame();
        Debug.Log("ScanningBehaviour: Unscan - deactivate frame");
    }

    //Method to unsubscribe events for AutoFrameScanner purposes
    public void UnsubscribeFromUnityEvents()
    {
        var eventhandler = this.GetComponent<ItemEventHandler>();
        if (eventhandler!=null)
        {
            
            eventhandler.GazeEnterEvent.RemoveListener(this.Scan);
            eventhandler.GazeEnterEvent.RemoveListener(this.Unscan);
        }    
    }
}

public enum ScannableType { RECTANGLE, SPHERE };
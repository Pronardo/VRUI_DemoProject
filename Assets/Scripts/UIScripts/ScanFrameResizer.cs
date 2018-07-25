using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanFrameResizer : MonoBehaviour {

    //Every object which has the ScanningBehaviour script attached, will set itself as ScannableObject by refering to this property
    public GameObject ScannableObject { get; set; }
    [Tooltip("FramePerScale describes a prozentual scale relative to X-Axis for the appended Frame (Input: 10%=0.1)")]
    public float FramePerScaleX = 0.1f;
    [Tooltip("FramePerScale describes a prozentual scale relative to Y-Axis for the appended Frame (Input: 10%=0.1)")]
    public float FramePerScaleY = 0.1f;
    [Tooltip("The relation between the depths of the the ScannableObject and the ScanningFrame(Input: 0.5 means 50% of the ScannableObject's depth")]
    public float RelativeFrameDepth = 0.5f;
   
    void OnEnable() {
        ResizeFrame(); Debug.Log("ScanFrameResizer: ScanFrameResizer enabled - call ResizeFrame()");
    }
    public void ResizeFrame()
    {
        Vector3 scannableDimension = GetScannableSize();
        float RelativeFrameWidthX = scannableDimension.x * FramePerScaleX;
        float RelativeFrameWidthY = scannableDimension.y * FramePerScaleY;
        this.transform.localScale =
        new Vector3(scannableDimension.x + RelativeFrameWidthX, scannableDimension.y + RelativeFrameWidthY, scannableDimension.z * RelativeFrameDepth);
        /*Vector3 parentPos = this.transform.parent.transform.position;
        this.transform.position = new Vector3(parentPos.x+parentDimension.x/2,parentPos.y,parentPos.z);*/
    }
    public Vector3 GetScannableSize()
    {
        if (ScannableObject == null)
        {
            Debug.LogError("ScanFrameResizer: ScannableObject reference null!");
            this.enabled = false;
        }

        Renderer scannableRenderer = ScannableObject.GetComponent<Renderer>();
        if (scannableRenderer == null)
        {
            Debug.LogError("ScanFrameResizer: Invalid ScannableObject - no renderer found!");
            this.enabled = false;
        }
        return scannableRenderer.bounds.size;
    }
}

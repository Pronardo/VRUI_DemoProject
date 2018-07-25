using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanFrameHandler : MonoBehaviour
{
    private GameObject frame = null;

    public void EnableFrame(ScannableType frameType, GameObject scannable)
    {
        switch (frameType) //Find the appropiate shape in ScanFrameManager
        {
            case ScannableType.RECTANGLE:
                frame = transform.Find("ScanningFrameRectangle").GetComponent<Transform>().gameObject;
                break;
            case ScannableType.SPHERE:
                frame = transform.Find("ScanningFrameSphere").GetComponent<Transform>().gameObject;
                break;
        }
        if (frame == null) { Debug.LogError("Invalid Input - No matching ScanningFrameObjects found"); this.enabled = false; }
        Vector3 pos = scannable.transform.position;
        frame.transform.position = new Vector3(pos.x, pos.y, pos.z);
        ScanFrameResizer resizer = frame.GetComponent<ScanFrameResizer>();
        if (resizer == null) { Debug.LogError("ScanFrameResizer is needed for proper scanning"); this.enabled = false; };
        resizer.ScannableObject = scannable.gameObject;
        frame.SetActive(true);
    }

    public void ResetFame()
    {
        if (frame != null && frame.activeSelf)
        {
            frame.SetActive(false);
        }
    }
}

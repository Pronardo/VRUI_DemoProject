using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningBehaviour : MonoBehaviour
{
    public GameObject ScanningFrameObject;
    private GameObject Scanner;

    void Start()
    {
            Debug.Log("ScanningBehaviour - OnStart");
            Scanner = Instantiate(ScanningFrameObject,this.transform.position,this.transform.rotation);
            Scanner.transform.SetParent(this.gameObject.transform);
            Unscan();

            Debug.Log("Parent of ScannerObject " + Scanner.transform.parent);
    }

    //Order to spawn scan frame around the Object the script is attached to
    public void Scan()
    {
            Scanner.SetActive(true);
            Debug.Log("Scan - activate frame: active =" + Scanner.activeSelf);
        
    }

    //Order to undo the scanning frame
    public void Unscan()
    {
            Scanner.SetActive(false);
            Debug.Log("Unscan - deactivate frame: active =" + Scanner.activeSelf);
    }
}

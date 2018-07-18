using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningBehaviour : MonoBehaviour
{
    public GameObject ScanningFrameObject;
    private GameObject Scanner;

    void Awake()
    {
        Scanner=Instantiate(ScanningFrameObject, this.transform.position, this.transform.rotation);
        Scanner.SetActive(false);
        Debug.Log("OnAwake");
    }

    //Order to spawn scan frame around the Object the script is attached to
    public void Scan()
    {
        Scanner.SetActive(true);
        Debug.Log("Unscan - activate frame: active =" + Scanner.activeSelf);
    }

    //Order to undo the scanning frame
    public void Unscan()
    {
        Scanner.SetActive(false);
        Debug.Log("Unscan - deactivate frame: active =" + Scanner.activeSelf);
    }
}

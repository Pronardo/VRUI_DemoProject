using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCameraBehaviour : MonoBehaviour
{

private Transform cameraToLookAt;

    void Start()
    {
        cameraToLookAt = GameObject.Find("VRCamera").transform;
    }

    void Update()
    {
        this.transform.LookAt(cameraToLookAt);
        //When rotation does not correspond, try something like:
        //this.transform.rotation *= Quaternion.Euler(0, 90, 0);
    }
}



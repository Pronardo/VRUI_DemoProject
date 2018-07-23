using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanFrameResizer : MonoBehaviour {

    public float FrameWidth = 0.1f;
	// Use this for initialization
	void Awake () {
        Transform myParent = transform.parent;
        if (myParent == null)
        {
            Debug.Log("parent reference null!");
        }
    
        Renderer parentrenderer = transform.parent.GetComponent<Renderer>();
        if (parentrenderer == null)
        {
            Debug.Log("parentrenderer reference null!");
        }

        Vector3 parentDimension = parentrenderer.bounds.size;
        this.transform.localScale =
        new Vector3(parentDimension.x + FrameWidth, parentDimension.y + FrameWidth, parentDimension.z/2);
       
        /*Vector3 parentPos = this.transform.parent.transform.position;
        this.transform.position = new Vector3(parentPos.x+parentDimension.x/2,parentPos.y,parentPos.z);*/
    }
}

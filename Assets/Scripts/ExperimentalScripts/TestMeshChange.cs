using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMeshChange : MonoBehaviour {

    public GameObject initialObject;
    public GameObject swapObject;

    Mesh swapMesh;

    GameObject theTarget;

    // Use this for initialization
    void Start()
    {
        theTarget = initialObject;
        swapMesh = swapObject.GetComponent<MeshFilter>().mesh;

        theTarget.GetComponent<MeshFilter>().mesh = swapMesh;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

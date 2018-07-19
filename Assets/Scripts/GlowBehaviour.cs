﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBehaviour : MonoBehaviour {

    public Material HighlightedMaterial;
    public Material DefaultMaterial;
    private Renderer sRenderer;
	// Use this for initialization
	void Start () {
        this.sRenderer = GetComponent<Renderer>();
        DefaultRendering();
	}

   public void HighlightRendering()
    {
        sRenderer.material = HighlightedMaterial;
        Debug.Log("SetMaterial: Highlight");

    }

    public void DefaultRendering()
    {
       sRenderer.material = DefaultMaterial;
        Debug.Log("SetMaterial: Default");
    }

}

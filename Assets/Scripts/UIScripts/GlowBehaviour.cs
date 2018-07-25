using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBehaviour : MonoBehaviour
{

    public Material HighlightedMaterial;
    public Material DefaultMaterial;
    private Renderer sRenderer;
    
    void Start()
    {
        this.sRenderer = GetComponent<Renderer>();
        DefaultRendering();
    }

    public void HighlightRendering()
    {
        sRenderer.material = HighlightedMaterial;
        Debug.Log("GlowBehaviour: SetMaterial - Highlight");
    }

    public void DefaultRendering()
    {
        sRenderer.material = DefaultMaterial;
        Debug.Log("GlowBehaviour: SetMaterial - Default");
    }

}

using UnityEngine;
using System.Collections;
public class Draw : MonoBehaviour
{
    public GameObject lines;
    public void showLines()
    {
        lines.SetActive(true);
    }
    public void hideLines()
    {
        lines.SetActive(false);
    }
}
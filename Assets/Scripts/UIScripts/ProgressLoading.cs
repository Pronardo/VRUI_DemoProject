using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressLoading : MonoBehaviour {
    public Transform LoadingBar;
    public Transform TextIndicator;
    [Tooltip("The delay [in milliseconds] for hiding the loading in progress elements")]
    public int HideDelay = 500;

    private float fillTime;
    private VREyeRaycaster raycaster;
    private float currentAmount=0;
    private float percentage=0;

    private void OnEnable()
    {
        Debug.Log("ProgressLoading - OnEnable");
        var cam = GameObject.Find("VRCamera");
        raycaster = cam.GetComponent<VREyeRaycaster>();
        fillTime = raycaster.GazeTimer;

    }

    void Update () {
	if(currentAmount<fillTime)
        {

            currentAmount += Time.deltaTime;
            percentage = currentAmount / fillTime;
            TextIndicator.GetComponent<Text>().text = ((int)(percentage*100)).ToString() + "%";
        }
        else
        {
            Debug.Log("ProgressLoading - ProgressBarFull");
            Wait(HideDelay);
            TextIndicator.gameObject.SetActive(false);
            LoadingBar.gameObject.SetActive(false);
            this.enabled = false;
        }
        LoadingBar.GetComponent<Image>().fillAmount = percentage;
    }

    private void Wait(int milliseconds)
    {
        System.Threading.Thread.Sleep(milliseconds);
    }

    private void OnDisable()
    {
        Debug.Log("ProgressLoading - OnDisable");
        currentAmount = 0;
        TextIndicator.gameObject.SetActive(false);
        LoadingBar.gameObject.SetActive(false);
    }
}

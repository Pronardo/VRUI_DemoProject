using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressLoadingElement : MonoBehaviour {
    public Transform LoadingBar;
    public Transform TextIndicator;
    public float FillTime=3.0f;
    [Tooltip("The delay [in milliseconds] for hiding the loading in progress elements")]
    public int HideDelay = 500;

    private float currentAmount;
    private float percentage;
	
	// Update is called once per frame
	void Update () {
	if(currentAmount<FillTime)
        {
            currentAmount += Time.deltaTime;
            percentage = currentAmount / FillTime;
            TextIndicator.GetComponent<Text>().text = ((int)(percentage*100)).ToString() + "%";
        }
        else
        {
            Wait(HideDelay);
            TextIndicator.gameObject.SetActive(false);
            LoadingBar.gameObject.SetActive(false);
        }
        LoadingBar.GetComponent<Image>().fillAmount = percentage;
    }

    private void Wait(int milliseconds)
    {
        System.Threading.Thread.Sleep(milliseconds);
    }
}

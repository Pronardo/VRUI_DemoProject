using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSwitch : MonoBehaviour
{
    private VRInteractiveItem[] interactables;
    private VRInteractiveItem luckyOne;

    private void Start()
    {
        interactables = FindObjectsOfType(typeof(VRInteractiveItem)) as VRInteractiveItem[];
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("OneSwitch: user intention confirmed - Searching for luckyOne to Do Action");
            luckyOne =GetCurrentInteractable();
            if(luckyOne!=null)
            {
                var evHandler=luckyOne.gameObject.GetComponent<ItemEventHandler>();
                if (evHandler == null) { Debug.Log("ItemEventHandler script is necessary for interaction events!"); this.enabled = false; }
                evHandler.OnActivation();
                Debug.Log("OneSwitch: scannable triggered - fire OnActivation event");
            }
        }
    }

    private VRInteractiveItem GetCurrentInteractable()
    {
        foreach (var interactable in interactables)
        {
            if(interactable.IsOver)
            {
                return interactable;
            }
        }
        return null;
    }
}

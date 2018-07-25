using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour {

    private GameObject menu;

	void Start () {
        menu=GameObject.Find("Menu");
        if(menu==null)
        {
            menu = Instantiate((GameObject)Resources.Load("Prefabs/Menu"));
        }
        HideMenu();
	}
	
    public void ShowMenu()
    {
        Debug.Log("DisplayMenu: ShowMenu()");
        menu.SetActive(true);
    }

    public void HideMenu()
    {
        Debug.Log("DisplayMenu: HideMenu()");
        menu.SetActive(false);
    }
}

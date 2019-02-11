using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuArrow : MonoBehaviour {
    public Menu menu;
    public string SelectImageName;
    
    private Image getSelectedImage(Button button)
    {
        return button.transform.Find(SelectImageName).GetComponent<Image>();
    }

	// Use this for initialization
	void Awake () {
        menu.onSelect += buttonSelected;
        menu.onDeselect += buttonDeselected;
    }

    private void buttonSelected(Button button)
    {
        getSelectedImage(button).enabled = true;
    }

    private void buttonDeselected(Button button)
    {
        getSelectedImage(button).enabled = false;
    }
}

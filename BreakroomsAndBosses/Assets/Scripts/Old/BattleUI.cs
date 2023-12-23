using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {
    private Button[] buttons;

	// Use this for initialization
	void Start () {
        buttons = GetComponentsInChildren<Button>();

    }
    public void isClicked(ButtonStats stats)
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

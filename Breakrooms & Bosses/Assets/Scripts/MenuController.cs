using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Menu))]
public class MenuController : MonoBehaviour {
    private Menu menu;

	// Use this for initialization
	void Start () {
        menu = GetComponent<Menu>();

	}

    void handleInput()
    {
        if (Input.GetButtonDown("Right")) {
            menu.Move(Direction.right);
        }
        if (Input.GetButtonDown("Left")) {
            menu.Move(Direction.left);
        }
        if (Input.GetButtonDown("Up")) {
            menu.Move(Direction.up);
        }
        if (Input.GetButtonDown("Down")) {
            menu.Move(Direction.down);
        }
        if (Input.GetButtonDown("Submit")) {
            menu.PressSelectedButton();
        }
    }

    // Update is called once per frame
    void Update () {
        handleInput();
	}
}

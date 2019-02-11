using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Switches a gameObject on and off using a specified key.
/// </summary>
public class GameObjectKeySwitch : MonoBehaviour
{
    [SerializeField] KeyCode switchKey;

    [SerializeField] GameObject targetObject;
	
	void Update ()
    {
        if (Input.GetKeyDown(switchKey))
        {
            Switch();
        }
	}

    void Switch ()
    {
        targetObject.SetActive(!targetObject.activeSelf);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteract : MonoBehaviour {

    public void Interact ()
    {
        Debug.Log(gameObject.name + " has been interacted with.");
    }
}

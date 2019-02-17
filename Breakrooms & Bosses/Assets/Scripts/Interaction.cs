using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public bool isInteracting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Interactable")
        {
            collision.SendMessage("Hover");            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isInteracting)
        {
            if (collision.tag == "Interactable")
            {
                collision.SendMessage("Interact");
                isInteracting = false;

            }
        }
    }
}

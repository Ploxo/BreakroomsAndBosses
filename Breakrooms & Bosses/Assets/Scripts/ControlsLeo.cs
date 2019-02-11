using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsLeo : MonoBehaviour {

    [SerializeField] KeyCode interactKey = KeyCode.E;
    [SerializeField] GameObject interactor;
    [SerializeField] float interactorDistance;
    GameObject interactorGO;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            CreateInteractor(interactor);
        }

        if (Input.GetKeyUp(interactKey))
        {
            Destroy(interactorGO);
        }
    }

    void CreateInteractor (GameObject target)
    {
        interactorGO = Instantiate(target, transform.position + Vector3.up * interactorDistance, Quaternion.identity, transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {

    [SerializeField] Text textObject;

    [TextArea] [SerializeField] string text;

    public void OnPointerEnter()
    {
        textObject.transform.parent.gameObject.SetActive(true);
        textObject.text = text;
    }

    public void OnPointerExit()
    {
        textObject.transform.parent.gameObject.SetActive(false);
    }
}

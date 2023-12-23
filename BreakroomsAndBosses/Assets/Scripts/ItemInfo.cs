using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {

    [SerializeField] public Sprite sprite;
    [SerializeField] public Text textObject;
    [SerializeField] public string topicName;
    [SerializeField] public string text;
    [SerializeField] public ItemType itemType;


    public enum ItemType
    {
        Topic, Object
    }

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

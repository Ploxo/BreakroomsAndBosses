using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    // [SerializeField] ItemSystem itemSystem;
    [SerializeField] Transform topicParent;
    [SerializeField] Transform itemParent;
    [SerializeField] Text textObject;

    //[SerializeField] GameObject topicPrefab;
    //[SerializeField] GameObject itemPrefab;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void ClearChildren (Transform parentToClear)
    {
        foreach (Transform childTF in parentToClear.GetComponentsInChildren<Transform>())
        {
            Destroy(childTF.gameObject);
        }
    }

    void AddTopic (GameObject topic)
    {
        GameObject go = Instantiate(topic, topicParent);
        go.GetComponent<ItemInfo>().textObject = textObject;
    }

    void AddItem (GameObject item)
    {
        GameObject go = Instantiate(item, itemParent);
        go.GetComponent<ItemInfo>().textObject = textObject;
    }

    void RemoveItem (string name)
    {
        Destroy(itemParent.Find(name).gameObject);
    }

    void RemoveTopic(string name)
    {
        Destroy(topicParent.Find(name).gameObject);
    }

    /*void CreateItemMenu ()
    {
        ClearChildren(itemParent.transform);

        foreach (ObjectItem item in itemSystem.objectItems)
        {
            //GameObject go = 
        }
    }

    void CreateTopicMenu ()
    {
        ClearChildren(topicParent.transform);


    }

    GameObject InstantiateTopic (GameObject target, Transform parent)
    {
        GameObject go = Instantiate(target, parent);
        TopicItem tI = go.GetComponent<TopicItem>();
        ItemInfo iI = go.GetComponent<ItemInfo>();

        iI.textObject = textObject;
        iI.text = tI.description;
        iI.GetComponent<Text>().text = tI.name;

        return go;
    }

    GameObject InstantiateItem(GameObject target, Transform parent)
    {
        GameObject go = Instantiate(target, parent);
        ObjectItem oI = go.GetComponent<ObjectItem>();
        ItemInfo iI = go.GetComponent<ItemInfo>();

        iI.textObject = textObject;
        iI.text = oI.description;
        iI.GetComponent<Image>().sprite = oI.itemSprite;

        return go;
    } */

}

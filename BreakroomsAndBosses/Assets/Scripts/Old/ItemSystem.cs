using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==============================
//==============================
//!!!! UNUSED
//==============================
//==============================



public class ItemSystem : MonoBehaviour
{
    [SerializeField] public List<TopicItem> topicItems = new List<TopicItem>();
    [SerializeField] public List<ObjectItem> objectItems = new List<ObjectItem>();

    public void AddItem(Items item)
    {
        if(item is ObjectItem)
        {
            AddObjectItem((ObjectItem)item);
        }
        else if (item is TopicItem)
        {
            AddTopicItem((TopicItem)item);
        }
        else
        {
            Debug.LogError("Items have to be of type " + typeof(TopicItem) + " or " + typeof(ObjectItem));
        }
    }

    void AddObjectItem (ObjectItem item)
    {
        objectItems.Add(item);
    }

    void AddTopicItem(TopicItem item)
    {
        topicItems.Add(item);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceBar : MonoBehaviour {

    public float widthOfParent = 800;
    private RectTransform ourRect;
    [SerializeField]
    private Influence influence;

    public Influence Influence
    {
        get {
            return influence;
        }
        set {
            influence = value;
            UpdateInfluence();
        }
    }
    

    public void UpdateInfluence()
    {
        float tempMax = Mathf.Abs(Influence.minValue) + Mathf.Abs(Influence.maxValue);
        float tempCurrent = Mathf.Abs(Influence.minValue) + Influence.CurrentInfluence;
        float ratio = tempCurrent / tempMax;
        ourRect.offsetMax = new Vector2(-(widthOfParent - ratio * widthOfParent), ourRect.offsetMax.y);
    }

    public void Awake()
    {
        ourRect = GetComponent<RectTransform>();
        Influence.onInfluenceChange += n => UpdateInfluence();
    }

	
}

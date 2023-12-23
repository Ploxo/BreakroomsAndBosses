using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat : MonoBehaviour {
    [SerializeField]
    private int level = 1;
    [SerializeField]
    private string name = "";
    public static event System.Action<float> onChangeInfluenceBy;

    public string Name
    {
        get {
            return name;
        }
        protected set {
            name = value;
        }
    }

    public int Level
    {
        get {
            return level;
        }
        protected set {
            level = value;
            level = Mathf.Max(1, level);
        }
    }

    public void levelUpBy(int i)
    {
        Level += i;
    }
    public virtual void action() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modifier
{
    [HideInInspector]
    public string name = "modifier";
    public Stat stat;
    public float value = 1;
    public int chance = 50;
}

public class Characteristics : MonoBehaviour
{
    public Modifier[] modifiers;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class badChoiceList
{
    public StatsChoice badChoice;
    public float value = 1;
}

[System.Serializable]
public class DialogChoice
{
    public List<badChoiceList> list;
}

public class Characteristics : MonoBehaviour
{
    public DialogChoice[] Dialogs;
}

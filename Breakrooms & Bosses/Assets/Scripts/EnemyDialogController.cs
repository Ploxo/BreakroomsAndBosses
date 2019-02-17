using Fungus;
using UnityEngine;

public class EnemyDialogController : MonoBehaviour
{
    private Flowchart flowchart;
    private Influence influence;

    private void Awake()
    {

        flowchart = GetComponent<Flowchart>();
        influence = GetComponent<Influence>();
        influence.onChoice += choice;


    }

    private void choice(string value)
    {
        if (!flowchart.GetBooleanVariable("isInMenu")) { return; }
        flowchart.SetBooleanVariable("isDone", true);
        flowchart.SetStringVariable("yourChoice", value);
    }

}

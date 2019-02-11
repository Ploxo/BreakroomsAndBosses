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
        influence.beforeInfluenceChangeBy += onInfluencedChangeBy;


    }

    private void onInfluencedChangeBy(float value)
    {
        if (!flowchart.GetBooleanVariable("isInMenu")) { return; }
        flowchart.SetBooleanVariable("isDone", true);
        flowchart.SetBooleanVariable("isSuccess", (value > 0));
    }
}

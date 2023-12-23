using UnityEngine;
using System.Linq;
using Fungus;

public class Influence : MonoBehaviour
{
    public float maxValue = 100;
    public float influence = 0;
    public event System.Action<float> onInfluenceChange;
    public event System.Action<string> onChoice;
    private Characteristics characteristics;
    private Flowchart flowchart;


    public float CurrentInfluence
    {
    
        get {
            return influence;
        }
        private set {
            //Debug.Log(beforeInfluenceChangeBy.GetInvocationList().Count());

            influence = value;
            influence = Mathf.Min(maxValue, influence);
            if (onInfluenceChange != null) {
                onInfluenceChange(influence);
            }
        }
    }

    public void Start()
    {
        //FadeTextController.CreateFadeText(amount.ToString(), transform);
        flowchart = GetComponent<Flowchart>();
        characteristics = GetComponent<Characteristics>();
        CurrentInfluence = influence;
    }

    private float CalculateInfluenceBy(StatsChoice stat)
    {
        float dmg = 0;
        int menuNum = flowchart.GetIntegerVariable("MenuNum")-1;
        if (menuNum < characteristics.Dialogs.Length) {
            foreach (var list in characteristics.Dialogs[menuNum].list) {
                if (list.badChoice == stat) {
                    dmg -= list.value;
                }
            }
        }
        if (onChoice != null) {
            onChoice(stat.ToString());
        }
        return dmg;
    }

    public void EffectBy(ButtonStats stat)
    {
        float influence = CalculateInfluenceBy(stat.statsOfButton.First());
        CurrentInfluence += influence;

    }
}

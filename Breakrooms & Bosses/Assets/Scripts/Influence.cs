using UnityEngine;
using System.Linq;

public class Influence : MonoBehaviour
{
    public float minValue = -100;
    public float maxValue = 100;
    public float influence = 0;
    public event System.Action<float> onInfluenceChange;
    public event System.Action<string> onChoice;
    private Characteristics characteristics;


    public float CurrentInfluence
    {
        get {
            return influence;
        }
        private set {
            //Debug.Log(beforeInfluenceChangeBy.GetInvocationList().Count());

            influence = value;
            influence = Mathf.Min(maxValue, influence);
            influence = Mathf.Max(minValue, influence);
            if (onInfluenceChange != null) {
                onInfluenceChange(influence);
            }
        }
    }

    public void Start()
    {
        characteristics = GetComponent<Characteristics>();
        CurrentInfluence = influence;
    }

    private float CalculateInfluenceBy(StatsChoice stat)
    {
        /*
        float influence = stat.Level;
        if (characteristics != null) {
            influence *=
                characteristics
                .modifiers
                .Where(m => m.stat.GetType() == stat.GetType())
                .DefaultIfEmpty(new Modifier() { value = 1 })
                .Select(m => m.value)
                .Aggregate(1f, (a, b) => a * b);

            if (onChoice != null) {
                onChoice(characteristics
                .modifiers
                .Where(m => m.stat.GetType() == stat.GetType())
                .Select(m => m.stat.Name)
                .First());
            }


        }*/


        return 0;
    }

    public void EffectBy(ButtonStats stat)
    {
        stat.statsOfButton.First();
        float influence = CalculateInfluenceBy(stat.statsOfButton.First());
        CurrentInfluence += influence;

    }
}

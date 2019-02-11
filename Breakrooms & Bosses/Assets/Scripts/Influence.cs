using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Influence : MonoBehaviour
{
    public float minValue = -100;
    public float maxValue = 100;
    public float influence = 0;
    public event System.Action<float> onInfluenceChange;
    public event System.Action<float> beforeInfluenceChangeBy;
    private Characteristics characteristics;


    public float CurrentInfluence
    {
        get {
            return influence;
        }
        private set {
            //Debug.Log(beforeInfluenceChangeBy.GetInvocationList().Count());
            if (beforeInfluenceChangeBy != null) {
                beforeInfluenceChangeBy(value-influence);
            }
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

    private float CalculateInfluenceBy(Stat stat)
    {
        float influence = stat.Level;
        if (characteristics != null) {
            int rand = Random.Range(0, 100);
            foreach (Modifier m in characteristics.modifiers) {
                if (m.stat.GetType() == stat.GetType()) {
                    if (m.chance > rand) {
                        influence *= -1;
                    }
                }
            }



                influence *=
                    characteristics
                    .modifiers
                    .Where(m => m.stat.GetType() == stat.GetType())
                    .DefaultIfEmpty(new Modifier() { value = 1 })
                    .Select(m => m.value)
                    .Aggregate(1f, (a, b) => a * b);
            

        }
        return influence;
    }

    public void EffectBy(Stat stat)
    {
        float influence = CalculateInfluenceBy(stat);
        CurrentInfluence += influence;

    }

}

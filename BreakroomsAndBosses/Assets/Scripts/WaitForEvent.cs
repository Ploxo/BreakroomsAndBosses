using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

    [CommandInfo("Flow", "Wait for event","")]
    [AddComponentMenu("")]
public class WaitForEvent : Command {

    [Tooltip("The variable whos value will be set")]
    [VariableProperty(typeof(BooleanVariable),
                          typeof(IntegerVariable),
                          typeof(FloatVariable),
                          typeof(StringVariable))]
    public Variable Variable;

    public string Label = "";
    public string Placeholder = "";

    public override void OnEnter()
    {
      

    }

    private void OnInputSubmit(string value)
    {
       
    }
}

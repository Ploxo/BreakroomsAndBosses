using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FlowchartScript : MonoBehaviour {
    public Flowchart flowchart;

	// Use this for initialization
	void Start () {
		
	}
    void runBlock(string blockName)
    {
        flowchart.ExecuteBlock(blockName);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

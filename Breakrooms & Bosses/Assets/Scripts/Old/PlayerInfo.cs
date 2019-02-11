using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInfo : MonoBehaviour {

    [SerializeField]
    public StatsInfo[] statsInfo;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[System.Serializable]
public struct StatsInfo
{
    public Stats stat;
    public float lvl;
}
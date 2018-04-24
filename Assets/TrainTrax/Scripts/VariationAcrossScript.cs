using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariationAcrossScript : MonoBehaviour {
    public int constantvariation;
    public bool varA = false;
    public bool firstrun = true;
    public int timesrun = 0; 
	// Use this for initialization
	void Start () {
        constantvariation = Random.Range(0,2) == 0 ? 0 : 2;
        if (constantvariation == 0)
            varA = true;
        else
            varA = false;
        Debug.Log("Variation: " + constantvariation);
        Debug.Log("VarA: " + varA);
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

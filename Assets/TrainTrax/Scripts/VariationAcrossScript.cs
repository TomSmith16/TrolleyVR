using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariationAcrossScript : MonoBehaviour {
    public int constantvariation;
    public bool firstrun = true;
    public int timesrun = 0; 
	// Use this for initialization
	void Start () {
        constantvariation = Random.Range(0, 3);
        Debug.Log("Variation: " + constantvariation);
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

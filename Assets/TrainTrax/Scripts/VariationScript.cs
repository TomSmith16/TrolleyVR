using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariationScript : MonoBehaviour {

    public bool gender;
    public bool speciesH;
    public bool straight5;
    public int variation;
    // Use this for initialization
    void Start () {
        gender = (Random.value > 0.5f);
        speciesH = (Random.value > 0.5f);
        straight5 = (Random.value > 0.5f);
        //Debug.Log("s5: " + straight5);
        Debug.Log("speciesH: " + speciesH);
        //Debug.Log("gender: " + gender);
        variation = Random.Range(0, 4);
        Debug.Log("Variation: " + variation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

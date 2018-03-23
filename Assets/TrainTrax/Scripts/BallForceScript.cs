using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddForce()
    {
        float forceamountx = Random.Range(1, 2);
        float forceamounty = Random.Range(1, 2);
        float forceamountz = Random.Range(-0.5f, 0.5f);
        GetComponent<Rigidbody>().AddForce(forceamountx, forceamounty, forceamountz, ForceMode.Impulse);
    }
}

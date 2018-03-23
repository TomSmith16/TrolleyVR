using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour {

    public GameObject[] models;
    private Vector3 pos;
    private Quaternion rot;
    private int gender;
    Scene scene;

    // Use this for initialization
    void Start () {
        rot = Quaternion.Euler(0, 90, 0);
        scene = SceneManager.GetActiveScene();
        if (transform.tag == "SpawnS")
        {
            rot = Quaternion.Euler(0, 90, 0);
            if(scene.name == "Fatman")
            {
                //Debug.Log("Fatman Rotation");
                rot = Quaternion.Euler(0, -90, 0);
            }
            int amount = 5;
            //int amount = Random.Range(2, 6);

            
            for (int i = 0; i < amount; i++)
            {
                //gender = Random.Range(0, 4);
                
                pos = new Vector3(pos.x, transform.position.y, transform.position.z + (i * 0.7f));
                if(i > 2)
                {
                    pos.x = transform.position.x + (i*0.5f);
                    pos.z = transform.position.z + (i - 4 * 0.7f);
                }
                else
                {
                    pos.x = transform.position.x;
                }
                GameObject spawn = Instantiate(models[i], pos, rot);
                spawn.AddComponent<AnimatorScript>();
                BoxCollider bc = spawn.AddComponent<BoxCollider>() as BoxCollider;
                bc.isTrigger = true;
                bc.center = new Vector3(0, 2, 0);
                spawn.transform.parent = gameObject.transform;
            }
        }
        else
        {
            rot = Quaternion.Euler(0, 50, 0);
            int amount = 1;
            //int amount = Random.Range(1, 3);

            for (int i = 0; i < amount; i++)
            {
                gender = Random.Range(0, 5);
                pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (i * 0.7f));
                GameObject spawn = Instantiate(models[gender], pos, rot);
                spawn.AddComponent<AnimatorScript>();
                BoxCollider bc = spawn.AddComponent<BoxCollider>() as BoxCollider;
                bc.isTrigger = true;
                bc.center = new Vector3(0, 2, 0);
                spawn.transform.parent = gameObject.transform;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

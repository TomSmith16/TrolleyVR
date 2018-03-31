using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour {

    public GameObject[] models;
    public GameObject[] males;
    public GameObject[] females;
    public GameObject[] penguins;
    private Vector3 pos;
    private Quaternion rot;
  
    VariationScript vscript;

    Scene scene;

    // Use this for initialization
    void Start () {
        rot = Quaternion.Euler(0, 90, 0);
        scene = SceneManager.GetActiveScene();
        vscript = GameObject.Find("Trolley").GetComponent<VariationScript>();

        //(vscript.variation);
        VariationSpawn(0);
        //Debug.Log("Variation: " + vscript.variation);

    }


    /*
      Bool is not switching line 162???
      Find models to get 5 & 5 preferably
      Do penguins tomorrow same as gender
         */


    void VariationSpawn(int v)
    {
        Debug.Log("VSCRIPT START: " + vscript.straight5);
        if (transform.tag == "SpawnS")
        {
            //Debug.Log("S5: " + straight5);
            int amount = 0;
            //Rotation stays the same.
            rot = Quaternion.Euler(0, 90, 0);
            if (scene.name == "Fatman")
            {
                //Debug.Log("Fatman Rotation");
                rot = Quaternion.Euler(0, -90, 0);
            }

            //amount = 5;
            if (vscript.straight5)
                amount = 5;
            else
                amount = 1;
            switch (v)
            {
                //Standard
                case 0:
                    if (vscript.straight5)
                        amount = 5;
                    else
                        amount = 1;
                    break;
                //Gender vs Gender
                case 1:
                    if (vscript.straight5)
                        amount = 5;
                    else
                        amount = 1;
                    break;
                //Species
                case 2:
                    if (vscript.straight5)
                        amount = 5;
                    else
                        amount = 1;
                    //speciesH = (Random.value > 0.5f);
                    break;
                //Context
                case 3:
                    if (vscript.straight5)
                        amount = 5;
                    else
                        amount = 1;
                    break;
                //Ages
                case 4:
                    
                    break;
                default:
                        amount = 1;
                   
                    break;
            }
            
            //int amount = Random.Range(2, 6);


            for (int i = 0; i < amount; i++)
            {
                //gender = Random.Range(0, 4);

                pos = new Vector3(pos.x, transform.position.y, transform.position.z + (i * 0.7f));
                if (i > 2)
                {
                    pos.x = transform.position.x + (i * 0.5f);
                    pos.z = transform.position.z + (i - 4 * 0.7f);
                }
                else
                {
                    pos.x = transform.position.x;
                }


                GameObject spawn;
                switch (v)
                {
                    case 0:
                        spawn = Instantiate(models[Random.Range(0, models.Length - 1)], pos, rot);
                        break;
                    //Gender vs Gender
                    case 1:
                        if(vscript.gender)
                            spawn = Instantiate(females[i], pos, rot);
                        else
                            spawn = Instantiate(males[i], pos, rot);

                        //Debug.Log("Gender: " + gender);
                        break;
                    //Species
                    case 2:
                        if (vscript.speciesH)
                            spawn = Instantiate(penguins[i], pos, rot);
                        else
                            spawn = Instantiate(models[i], pos, rot);
                        break;
                    //Context
                    case 3:
                        spawn = Instantiate(models[i], pos, rot);
                        break;
                    //Ages
                    case 4:
                        spawn = Instantiate(models[i], pos, rot);
                        break;

                    default:
                        spawn = Instantiate(models[i], pos, rot);
                        break;
                }
                
                



                spawn.AddComponent<AnimatorScript>();
                BoxCollider bc = spawn.AddComponent<BoxCollider>() as BoxCollider;
                bc.isTrigger = true;
                bc.center = new Vector3(0, 2, 0);
                spawn.transform.parent = gameObject.transform;
            }
        }
        else
        {
            //Debug.Log("S5F: " + straight5);
            rot = Quaternion.Euler(0, 50, 0);
            int amount = 0;


            //STRAIGHT 5 WHY ARE YOU DOING THIS TO ME.
            switch (v)
            {
                //Standard
                case 0:
                    if (vscript.straight5)
                        amount = 1;
                    else
                        amount = 5;
                    Debug.Log("AFTER S5 " + vscript.straight5);
                    break;
                //Gender vs Gender
                case 1:
                    if (scene.name == "Trolley")
                        amount = 5;
                    else
                        amount = 1;
                    break;
                //Species
                case 2:
                    if (scene.name == "Trolley")
                        amount = 5;
                    else
                        amount = 1;
                    //speciesH = !speciesH;
                    break;
                //Context
                case 3:
                    amount = 1;
                    break;
                //Ages
                case 4:
                    amount = 1;
                    break;
                default:
                    amount = 1;
                    break;
            }


            //int amount = Random.Range(1, 3);

            for (int i = 0; i < amount; i++)
            {
                //gender = Random.Range(0, 5);
                pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (i * 0.7f));

                GameObject spawn;
                switch (v)
                {
                    case 0:
                        if(vscript.straight5) 
                            spawn = Instantiate(models[Random.Range(0, models.Length-1)],pos,rot);
                        else
                            spawn = Instantiate(models[i], pos, rot);
                        break;
                    //Gender vs Gender
                    case 1:
                        if (vscript.gender)
                            spawn = Instantiate(males[i], pos, rot);
                        else
                            spawn = Instantiate(females[i], pos, rot);

                        
                        break;
                    //Species
                    case 2:
                        if (vscript.speciesH)
                            spawn = Instantiate(models[i], pos, rot);
                        else
                            spawn = Instantiate(penguins[i], pos, rot);
                        break;
                    //Context
                    case 3:
                        spawn = Instantiate(models[i], pos, rot);
                        break;
                    //Ages
                    case 4:
                        spawn = Instantiate(models[i], pos, rot);
                        break;

                    default:
                        spawn = Instantiate(models[i], pos, rot);
                        break;
                }



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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatmanSpawnScript : MonoBehaviour {
    public GameObject[] models;
    public GameObject[] males;
    public GameObject[] females;
    public GameObject[] penguins;
    private Vector3 pos;
    private Quaternion rot;
    private int gender;
    VariationScript vscript;
    private GameObject fatman;

    // Use this for initialization
    void Start()
    {
        vscript = GameObject.Find("Fatman").GetComponent<VariationScript>();
        rot = Quaternion.Euler(0, 90, 0);
        //int amount = Random.Range(1, 3);
                //gender = Random.Range(0, models.Length - 1);

                pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        switch(vscript.variation)
        {
            case 0:
                fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                break;

            case 1:
                if (vscript.gender)
                    fatman = Instantiate(males[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                else
                    fatman = Instantiate(females[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                break;

            case 2:
                if(vscript.speciesH)
                    fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                else
                    fatman = Instantiate(penguins[Random.Range(0,3)], pos, rot);

                break;

            case 3:
               fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                break;

            case 4:
                fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                break;

            default:
                fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                break;
        }
               // GameObject fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);

                fatman.tag = "ForkCollider";
                fatman.transform.parent = gameObject.transform;
                BoxCollider bc = fatman.AddComponent<BoxCollider>() as BoxCollider;
                bc.size = new Vector3(0.3f, 3, 0.1f);
                bc.center = new Vector3(0, 1.5f, 0);
                Rigidbody rb = fatman.AddComponent<Rigidbody>() as Rigidbody;
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
                fatman.AddComponent<AnimatorScript>();
                vscript.spawnIndex++;

    }

    // Update is called once per frame
    void Update()
    {

    }
}


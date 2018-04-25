using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatmanSpawnScript : MonoBehaviour {
    public GameObject[] models;
    public GameObject[] males;
    public GameObject[] females;
    public GameObject[] penguins;
    private Vector3 pos;
    private Vector3 ppos;
    private Quaternion rot;
    private Quaternion prot;
    private int gender;
    VariationScript vscript;
    private GameObject fatman;

    // Use this for initialization
    void Start()
    {

        vscript = GameObject.Find("Fatman").GetComponent<VariationScript>();
        rot = Quaternion.Euler(0, 90, 0);
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        ppos = new Vector3(transform.position.x+0.5f, transform.position.y + 0.5f, transform.position.z+0.5f);
        prot = Quaternion.Euler(0, 180, 0);
            //fatman = Instantiate(models[8], pos, rot);

        switch (vscript.variation)
        {
            case 0:
                fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                break;

            case 1:
                if (vscript.gender)
                {
                    fatman = Instantiate(males[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                }
                else
                { 
                fatman = Instantiate(females[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                }
                break;

            case 2:
                if(vscript.speciesH)
                    fatman = Instantiate(models[vscript.Randoms[vscript.spawnIndex]], pos, rot);
                else
                    fatman = Instantiate(penguins[0], ppos, prot);

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
                if(fatman.name.Contains("Penguin"))
                {
                    bc.size = new Vector3(1, 5, 1.5f);
                    bc.center = new Vector3(0, 2.5f, 0);
                }
        if (fatman.name.Contains("Kachu") || fatman.name.Contains("Douglas"))
                {
                    bc.size = new Vector3(0.3f, 2, 0.1f);
                    bc.center = new Vector3(0, 1, 0);
                }
                Rigidbody rb = fatman.AddComponent<Rigidbody>() as Rigidbody;
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
                //fatman.AddComponent<AnimatorScript>();
                vscript.spawnIndex++;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (fatman.name.Contains("Penguin"))
            {
                fatman.GetComponent<BoxCollider>().size = new Vector3(1, 5, 1.5f);
                fatman.transform.position = ppos;
                fatman.transform.rotation = prot;
            }
            else
            {
                fatman.GetComponent<BoxCollider>().size = new Vector3(fatman.GetComponent<BoxCollider>().size.x, fatman.GetComponent<BoxCollider>().size.y, 0.1f);
                fatman.transform.position = pos;
                fatman.transform.rotation = rot;
                fatman.GetComponent<Animator>().Play("Idle", -1, 0f);
                fatman.GetComponent<Animator>().SetBool("Falling", false);
            }
            fatman.GetComponent<Rigidbody>().isKinematic = false;
            fatman.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}


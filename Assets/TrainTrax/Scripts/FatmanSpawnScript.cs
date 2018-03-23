using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatmanSpawnScript : MonoBehaviour {
    public GameObject[] models;
    private Vector3 pos;
    private Quaternion rot;
    private int gender;

    // Use this for initialization
    void Start()
    {

            rot = Quaternion.Euler(0, 90, 0);
            //int amount = Random.Range(1, 3);
                gender = Random.Range(0, 4);
                pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject fatman = Instantiate(models[gender], pos, rot);

                fatman.tag = "ForkCollider";
                fatman.transform.parent = gameObject.transform;
                BoxCollider bc = fatman.AddComponent<BoxCollider>() as BoxCollider;
                bc.size = new Vector3(0.3f, 3, 0.1f);
                bc.center = new Vector3(0, 1.5f, 0);
                Rigidbody rb = fatman.AddComponent<Rigidbody>() as Rigidbody;
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
                fatman.AddComponent<AnimatorScript>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}


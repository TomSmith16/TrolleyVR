using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorScript : MonoBehaviour {

    Animator anim;
    TrainEngine trainengine;
    FatmanTrainEngine ftrainengine;
    Scene scene;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        trainengine = GameObject.Find("Trolley/Train").GetComponent<TrainEngine>();
      
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Fatman" || scene.name == "FatmanPractice")
            ftrainengine = GameObject.Find("Fatman/Train").GetComponent<FatmanTrainEngine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    // Update is called once per frame
    void Update () {

        /*
        if(scene.name == "Fatman")
        {
            if(trainengine.currentNode > )
            if (transform.parent.tag == "SpawnS")
            {
                Debug.Log("Hit em big");
                anim.SetBool("Hit", true);
            }
        }
        */
        //Debug.Log("Current Node boy:" + trainengine.currentNode);
        if ((scene.name == "Fatman" || scene.name == "FatmanPractice") && transform.parent.tag == "SpawnF")
        {

            if (gameObject.transform.localRotation.x > 0.1 && !anim.GetBool("Falling"))
            {
                Debug.Log(gameObject.transform.localRotation.x);
                anim.SetBool("Falling", true);
            }


           
                //anim.SetBool("Straight", true);


        }

        else if((scene.name == "Fatman" || scene.name == "FatmanPractice") && transform.parent.tag == "SpawnS")
        {
            if (ftrainengine.currentNode > 3)
            {
                
                anim.SetBool("Hit", true);
            }

        }
        else
        {

            if (!trainengine.switchpulled)
            {
                if (trainengine.currentNode > 2)
                {
                    if (transform.parent.tag == "SpawnS")
                    {
                        Debug.Log("Hit em big");
                        anim.SetBool("Hit", true);
                    }
                    //anim.SetBool("Straight", true);
                }
            }
            else
            {
                if (trainengine.currentNode > 6)
                {
                    if (transform.parent.tag == "SpawnF")
                    {
                        Debug.Log("Hit em big");
                        anim.SetBool("Hit", true);
                    }


                    //anim.SetBool("Straight", true);
                }
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class AnimatorScript : MonoBehaviour {

    Animator anim;
    TrainEngine trainengine;
    FatmanTrainEngine ftrainengine;
    Scene scene;
    AudioClip bodythud;
    public AudioClip penguindeath;
    bool bodythudplayed = false;
    bool psplayed = false;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    AudioSource asource;
    Quaternion prot;


    // Use this for initialization
    void Start()
    {
        prot = Quaternion.Euler(270, 130, 0);

        bodythud = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/TrainTrax/Audio/BodyThud.mp3", typeof(AudioClip));
        anim = GetComponent<Animator>();
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Trolley" || scene.name == "Track02")
        {
            trainengine = GameObject.Find("Trolley/Train").GetComponent<TrainEngine>();
            
        }


        if (scene.name == "Fatman" || scene.name == "FatmanPractice")
        { 
            ftrainengine = GameObject.Find("Fatman/Train").GetComponent<FatmanTrainEngine>();
            asource = GameObject.Find("Fatman/SpawnS").GetComponent<AudioSource>();
         }
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

            if (gameObject.transform.localRotation.x > 0.075 && !anim.GetBool("Falling"))
            {
               // Debug.Log(gameObject.transform.localRotation.x);
                anim.SetBool("Falling", true);
                gameObject.GetComponent<AudioSource>().Play();
            }

            if(gameObject.GetComponent<Rigidbody>().isKinematic || gameObject.transform.rotation.y == 180)
            {
                //Debug.Log(bodythud);
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                if (!bodythudplayed)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(bodythud, 1.0f);
                    bodythudplayed = true;
                }
                //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 0.5f);
            }

        }

        else if((scene.name == "Fatman" || scene.name == "FatmanPractice") && transform.parent.tag == "SpawnS")
        {
            if (ftrainengine.currentNode > 3)
            {
                
                anim.SetBool("Hit", true);
                //Debug.Log(asource);
               
                if (transform.name.Contains("Penguin") && !psplayed)
                {
                    asource.Play();
                    Instantiate(ps);
                    Instantiate(ps1);
                    psplayed = true;
                    Destroy(gameObject);

                }
                else if (!psplayed)
                {
                    Instantiate(ps1);
                    psplayed = true;
                }
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
                        //Debug.Log("Hit em big");
                        anim.SetBool("Hit", true);
                        if (transform.name.Contains("Penguin") && !psplayed)
                        {
                            asource = GameObject.Find("Trolley/SpawnS").GetComponent<AudioSource>();
                            asource.Play();
                            Destroy(gameObject);
                            Instantiate(ps, transform.position, prot);
                            Instantiate(ps1, transform.position, prot);
                            psplayed = true;
                        }
                        else if(!psplayed)
                        {
                            Instantiate(ps1, transform.position, prot);
                            psplayed = true;
                        }
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
                        
                        //Debug.Log("Hit em big");
                        anim.SetBool("Hit", true);
                        //asource.Play();
                        if (transform.name.Contains("Penguin") && !psplayed)
                        {
                            asource = GameObject.Find("Trolley/SpawnF").GetComponent<AudioSource>();
                            asource.Play();
                            Destroy(gameObject);
                            Instantiate(ps, transform.position, prot);
                            Instantiate(ps1, transform.position, prot);
                            psplayed = true;
                        }
                        else if (!psplayed)
                        {
                            Instantiate(ps1, transform.position, prot);
                            psplayed = true;
                        }
                    }



                    //anim.SetBool("Straight", true);
                }
            }
        }
	}


}

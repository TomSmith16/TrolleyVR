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
    public AudioClip runover;
    public AudioClip penguindeath;
    bool bodythudplayed = false;
    bool psplayed = false;
    bool screamplayed = false;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    AudioSource asource;
    AudioSource pengsource;
    public AudioSource maleScreams;
    public AudioSource soloMalescream;
    public AudioSource femaleScreams;
    public AudioSource soloFemalescream;
    Quaternion prot;
    VariationScript vscript;


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
            asource = GetComponent<AudioSource>();
            maleScreams = GameObject.Find("Trolley/SpawnS/StraightCollider").GetComponent<AudioSource>(); 
            femaleScreams = GameObject.Find("Trolley/SpawnF/ForkedCollider").GetComponent<AudioSource>();
            soloMalescream = GameObject.Find("Trolley/SoloMale").GetComponent<AudioSource>();
            soloFemalescream = GameObject.Find("Trolley/SoloFemale").GetComponent<AudioSource>();

        }

        if (scene.name == "Trolley")
            vscript = GameObject.Find("Trolley").GetComponent<VariationScript>();
        else
            vscript = GameObject.Find("Fatman").GetComponent<VariationScript>();

        if (scene.name == "Fatman" || scene.name == "FatmanPractice")
        { 
            ftrainengine = GameObject.Find("Fatman/Train").GetComponent<FatmanTrainEngine>();
            pengsource = GameObject.Find("Fatman/SpawnS").GetComponent<AudioSource>();
            asource = GetComponent<AudioSource>();
            maleScreams = GameObject.Find("Fatman/SpawnS/StraightCollider").GetComponent<AudioSource>();
            femaleScreams = GameObject.Find("Fatman/SpawnF/ForkedCollider").GetComponent<AudioSource>();
        }

        Debug.Log(asource.clip.name);
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

            if (ftrainengine.currentNode > 2 && !screamplayed)
            {
                anim.SetBool("Scared", true);

                if (asource.clip.name.Contains("Woman"))
                    femaleScreams.Play();

                if (asource.clip.name.Contains("Man"))
                    maleScreams.Play();

                screamplayed = true;
            }

            if (ftrainengine.currentNode > 3)
            {
                
                    anim.SetBool("Hit", true);
                checkAudio();
                //Debug.Log(asource);

                if (transform.name.Contains("Penguin") && !psplayed)
                {
                    asource.Play();
                    asource.PlayOneShot(runover, 0.1f);
                    Instantiate(ps);
                    Instantiate(ps1);
                    psplayed = true;
                    Destroy(gameObject);

                }
                else if (!psplayed)
                {
                    asource.PlayOneShot(runover, 0.1f);
                    Instantiate(ps1);
                    psplayed = true;
                }
            }

        }
        else
        {

            if (!trainengine.switchpulled)
            {

                if (transform.parent.tag == "SpawnS")
                {
                        if (trainengine.currentNode > 1 && !screamplayed)
                    {
                        anim.SetBool("Scared", true);

                        //if(source.clip.name.Contains("Woman") )

                        if (asource.clip.name.Contains("Woman") && !vscript.straight5 && vscript.variation == 0)
                            soloFemalescream.Play();
                        else if (asource.clip.name.Contains("Woman"))
                            femaleScreams.Play();

                        if (asource.clip.name.Contains("Man") && !vscript.straight5 && vscript.variation == 0)
                            soloMalescream.Play();
                        else if (asource.clip.name.Contains("Man"))
                            maleScreams.Play();

                        screamplayed = true;
                    }

                    if (trainengine.currentNode > 2)
                    {
                    
                            //Debug.Log("Hit em big");
                            anim.SetBool("Hit", true);
                        checkAudio();

                        if (transform.name.Contains("Penguin") && !psplayed)
                            {
                                asource = GameObject.Find("Trolley/SpawnS").GetComponent<AudioSource>();
                                asource.Play();
                            asource.PlayOneShot(runover, 0.1f);
                            Destroy(gameObject);
                                Instantiate(ps, transform.position, prot);
                                Instantiate(ps1, transform.position, prot);
                                psplayed = true;
                            }
                            else if(!psplayed)
                            {
                            asource.PlayOneShot(runover, 0.1f);
                            Instantiate(ps1, transform.position, prot);
                                psplayed = true;
                            }
                        }
                    //anim.SetBool("Straight", true);
                }
            }
            else
            {
                if (transform.parent.tag == "SpawnF")
                {
                        if (trainengine.currentNode > 2 && !screamplayed)
                    {
                        anim.SetBool("Scared", true);

                        //if(source.clip.name.Contains("Woman") && s5 && constant variation == 0)

                        if (asource.clip.name.Contains("Woman") && vscript.straight5 && vscript.variation == 0)
                            soloFemalescream.Play();
                        else if (asource.clip.name.Contains("Woman"))
                            femaleScreams.Play();

                        if (asource.clip.name.Contains("Man") && vscript.straight5 && vscript.variation == 0)
                            soloMalescream.Play();
                        else if (asource.clip.name.Contains("Man"))
                            maleScreams.Play();

                        screamplayed = true;

                    }
               
                            if (trainengine.currentNode > 6)
                        {
                            
                            
                            //Debug.Log("Hit em big");
                            anim.SetBool("Hit", true);
                        checkAudio();
                       
                            //asource.Play();
                            if (transform.name.Contains("Penguin") && !psplayed)
                            {
                                asource = GameObject.Find("Trolley/SpawnF").GetComponent<AudioSource>();
                                asource.Play();
                            asource.PlayOneShot(runover, 0.1f);
                            Destroy(gameObject);
                                Instantiate(ps, transform.position, prot);
                                Instantiate(ps1, transform.position, prot);
                                psplayed = true;
                            }
                            else if (!psplayed)
                            {
                            asource.PlayOneShot(runover, 0.1f);
                            Instantiate(ps1, transform.position, prot);
                                psplayed = true;
                            }
                        }



                    //anim.SetBool("Straight", true);
                }
            }
        }
	}


    void checkAudio()
    {
        if (femaleScreams.isPlaying)
            femaleScreams.Stop();
        if (soloFemalescream && soloFemalescream.isPlaying )
            soloFemalescream.Stop();
        if (soloMalescream && soloMalescream.isPlaying)
            soloMalescream.Stop();
        if (maleScreams.isPlaying)
            maleScreams.Stop();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainCollideScript : MonoBehaviour {
    FadeScript fade;
    public GameObject barrel;
    public AudioClip trainstop;
    public GameObject cannonballs;
    GameObject ballspawn;
    public int cannonballamount;
    public GameObject ballobject;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    Quaternion prot;
    public GameObject canvas;
    //public GameObject text;
    Scene scene;
    VariationAcrossScript vascript;
   
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        if (GameObject.Find("VariationAcross"))
            vascript = GameObject.Find("VariationAcross").GetComponent<VariationAcrossScript>();
        if(canvas)
            fade = canvas.GetComponent<FadeScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*0 == TROLLEY PRACTICE
      1 == TROLLEY
      2 == FATMAN PRACTICE
      3 == FATMAN
    */
    //Trigger events for lever
    private void OnTriggerEnter(Collider other)
    {

        print("Collision");

        if (scene.name == "Trolley")
        {
            switch (other.tag)
            {
                case "ForkCollider":

                    //GUI Pop up saying "X amount has died" or "You chose to not pull the lever"
                    //Scream
                    // fade.FadeOut();
                    //text.GetComponent<Text>().text = "You chose to pull the lever";
                    
                    print("Fork collided");

                    break;

                case "StraightCollider":

                    //GUI Pop up saying "X amount has died" or "You chose to pull the lever"
                    //Screams
                    //fade.FadeOut();
                    //text.GetComponent<Text>().text = "You chose to NOT pull the lever";
                    print("Straight Collided");

                    break;

                default:
                    break;
            }

            if (vascript.timesrun == 3)
                fade.FadeOut();
            else if (vascript.firstrun)
                StartCoroutine(Wait(2));
            else      
                StartCoroutine(Wait(3));
        }
        else if (scene.name == "Fatman" || scene.name == "FatmanPractice")
        {
            switch (other.tag)
            {

                case "StraightCollider":

                    //GUI Pop up saying "X amount has died" or "You chose to pull the lever"
                    //Screams
                    //fade.FadeOut();
                    //text.GetComponent<Text>().text = "You chose to NOT push the large man.";
                    print("Straight Collided");

                    break;

                case "ForkCollider":
                    //Scream of large man
                    FatmanTrainEngine enginespeed = GetComponent<FatmanTrainEngine>();
                    enginespeed.moveSpeed = 0;
                    enginespeed.gainSpeed = 0;
                    enginespeed.GetComponent<AudioSource>().Stop();
                    enginespeed.GetComponent<AudioSource>().PlayOneShot(trainstop, 0.6f);

                    Debug.Log(other.name);
                    if (other.name.Contains("Penguin"))
                    {
                        Instantiate(ps, other.transform.position, ps.transform.rotation);
                    }
                    else if (other.name != "Trigger")
                    {
                        Instantiate(ps1, other.transform.position, ps1.transform.rotation);
                    }

                    if (scene.name == "FatmanPractice")
                    {
                        //Spawn objects that show the barrel is broken/stopped the train.
                        Vector3 balllocation = new Vector3(barrel.transform.position.x + 1, barrel.transform.position.y, barrel.transform.position.z - 1);
                        barrel.GetComponent<AudioSource>().Play();

                        foreach(Transform child in ballobject.transform)
                        {
                            child.GetComponent<BallForceScript>().AddForce();
                        }


                        /*for(int i = 0; i < cannonballamount; i++)
                        {
                            int forceamount = Random.Range(10, 20);
                            balllocation.z = balllocation.z + i/20;
                            ballspawn = Instantiate(cannonballs, balllocation, Quaternion.Euler(0,0,0), barrel.transform);
                            ballspawn.GetComponent<Rigidbody>().AddForce(forceamount, 0, 0, ForceMode.Impulse);
                        }*/
                       
                    }




                    //fade.FadeOut();
                   // text.GetComponent<Text>().text = "You chose to push the large man.";
                    
                    break;
            }


            if (scene.name == "FatmanPractice")
            {
                Debug.Log("load next level you fuck");
                StartCoroutine(Wait(3));
            }


            if (scene.name == "Fatman")
            {
                Debug.Log("Simulation over");
                //Fade in end screen?
                vascript.firstrun = false;
                if (vascript.varA)
                {
                    vascript.constantvariation += 1;
                    if (vascript.constantvariation > 2)
                        vascript.constantvariation = 0;
                }
                else
                {
                    vascript.constantvariation -= 1;
                    if (vascript.constantvariation < 0)
                        vascript.constantvariation = 2;
                }

                Debug.Log("Constant Variation: " + vascript.constantvariation);

                vascript.timesrun += 1;
                Debug.Log("Times Run: " + vascript.timesrun);
                if (vascript.timesrun == 3)
                {
                    //Debug.Log("Fade time");
                    fade.FadeOut();
                }
                else
                    StartCoroutine(Wait(1));
            }
        }
        else
        {
            //fade.FadeOut();
            switch (other.tag)
            {
                case "ForkCollider":
                    print("Fork collided");

                    break;

                case "StraightCollider":
                    print("Straight Collided");

                    break;

                default:
                    break;
            }
            StartCoroutine(Wait(1));

        }
        //Screen fade out
    }

    IEnumerator Wait(int level)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(level);

    }




}

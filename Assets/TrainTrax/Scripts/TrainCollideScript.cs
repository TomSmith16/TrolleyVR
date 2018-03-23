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
    //public GameObject canvas;
    //public GameObject text;
    Scene scene;
   
    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        //fade = canvas.GetComponent<FadeScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Trigger events for lever

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
            StartCoroutine(Wait(2));
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

                    if(scene.name == "FatmanPractice")
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
                    print("Train blocked");
                    break;
            }
            if (scene.name == "FatmanPractice")
            {
                
                StartCoroutine(Wait(3));
            }
            if (scene.name == "Fatman")
            {
                Debug.Log("Simulation over");
                //Fade in end screen?
                //StartCoroutine(Wait(4));
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

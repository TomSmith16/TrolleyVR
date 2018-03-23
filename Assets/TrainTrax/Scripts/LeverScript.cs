using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {

    AudioSource audio;
    private GameObject straightArrow;
    private GameObject curvedArrow;
    private bool neutral = false;
    public bool switchpulled = false;
    public GameObject train;
    public GameObject target;
    public AudioClip leverstraight;
    public AudioClip leverpulled;
    TrainEngine trainEngine;
    MouseLook mouselook;
    public GameObject alivescript;
    private Vector3 targetpoint;
    private Quaternion oldpoint;
    public float max;
    public float min;
    // Use this for initialization
    void Start () {
        mouselook = alivescript.GetComponent<MouseLook>();
        audio = GetComponent<AudioSource>();
        straightArrow = GameObject.Find("Trolley/Signpost/StraightArrow");
        curvedArrow = GameObject.Find("Trolley/Signpost/CurvedArrow");
        //train = GameObject.Find("Trolley/Train");
        
        trainEngine = train.GetComponent<TrainEngine>();
    }
	
	// Update is called once per frame
	void Update () {

       
            if (trainEngine.currentNode < 2)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {

                    /////////////BOX COLLIDER SCRIPTS, ON TRIGGER ENTER/EXIT
                    //if (leverrotation.z > 24 || leverrotation.z < -24)
                    if (switchpulled)
                    {
                    //GetComponent<Rigidbody>().AddForce(0, 0, 100);
                    switchpulled = false;
                    /*straightArrow.GetComponent<Renderer>().enabled = true;
                    curvedArrow.GetComponent<Renderer>().enabled = false;
                    audio.PlayOneShot(leverpulled, 0.5f);*/
                }
                    else
                    {

                    //GetComponent<Rigidbody>().AddForce(0, 0, -100);
                    switchpulled = true;
                    /*straightArrow.GetComponent<Renderer>().enabled = false;
                    curvedArrow.GetComponent<Renderer>().enabled = true;
                    audio.PlayOneShot(leverstraight, 0.5f);*/
                }

                    


                }
            }
       // print("X = " + target.transform.localPosition.x);
        //transform.rotation.eulerAngles.z >= 332 || transform.rotation.eulerAngles.z <= 27
        //-0.6
        //0.45
        if (target.transform.localPosition.x >= min && target.transform.localPosition.x <= max)
        {
            Quaternion newRotation = Quaternion.LookRotation(transform.position - target.transform.position, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 8);
            oldpoint = newRotation;
        }
        else
        {
            if(target.transform.localPosition.x <= min)
            {
                target.transform.localPosition = new Vector3(min+0.01f, target.transform.localPosition.y, target.transform.localPosition.z);
                //trainEngine.active = true;
            }
            else
            {
                target.transform.localPosition = new Vector3(max-0.01f, target.transform.localPosition.y, target.transform.localPosition.z);
               
                //START TRAIN ON LEVER PULL

                /* if (!trainEngine.active)
                {
                    StartCoroutine(trainEngine.StartSound());
                }
                */

            }
            //Either stop the grabbable object from moving anyfurther
            //Stop the rotation of the lever 
           // transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 35.0f);
        }

    }


    //Trigger events for lever
    //private void OnTriggerEnter(Collider other)
    //{
        
    //    //    switch (other.tag)
    //    //    {
    //    //        case "Straight":
    //    if (other.tag != "Hand")
    //    {
    //        straightArrow.GetComponent<Renderer>().enabled = true;
    //        curvedArrow.GetComponent<Renderer>().enabled = false;
    //        audio.PlayOneShot(leverpulled, 0.5f);
    //        trainEngine.switchpulled = false;
    //        print("Straight");
    //    }
    //        //    break;

    //        //    case "Forked":
    //        //       
                
    //        //    break;

    //        //    default:
    //        //        break;
    //        //}
        

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag != "Hand")
    //    {
    //        straightArrow.GetComponent<Renderer>().enabled = false;
    //        curvedArrow.GetComponent<Renderer>().enabled = true;
    //        audio.PlayOneShot(leverstraight, 0.5f);
    //        trainEngine.switchpulled = true;
    //        print("Forked");
    //    }

    //}


}

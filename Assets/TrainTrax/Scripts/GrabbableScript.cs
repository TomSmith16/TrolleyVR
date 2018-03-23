using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableScript : MonoBehaviour {

    AudioSource audio;
    private GameObject straightArrow;
    private GameObject curvedArrow;
    private bool neutral = false;
    public bool switchpulled = false;
    public GameObject train;
    public AudioClip leverstraight;
    public AudioClip leverpulled;
    TrainEngine trainEngine;
    MouseLook mouselook;
    private Vector3 targetpoint;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        straightArrow = GameObject.Find("Trolley/Signpost/StraightArrow");
        curvedArrow = GameObject.Find("Trolley/Signpost/CurvedArrow");
        //train = GameObject.Find("Trolley/Train");

        trainEngine = train.GetComponent<TrainEngine>();
    }

    //Trigger events for lever
    private void OnTriggerEnter(Collider other)
    {

        //    switch (other.tag)
        //    {
        //        case "Straight":
        if (other.tag == "Straight")
        {
            straightArrow.GetComponent<Renderer>().enabled = true;
            curvedArrow.GetComponent<Renderer>().enabled = false;
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(leverpulled, 0.5f);
            }
            trainEngine.switchpulled = false;
            print("Straight");
        }
        //    break;

        //    case "Forked":
        //       

        //    break;

        //    default:
        //        break;
        //}


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Straight")
        {
            straightArrow.GetComponent<Renderer>().enabled = false;
            curvedArrow.GetComponent<Renderer>().enabled = true;
            if (!audio.isPlaying)
            {
                audio.PlayOneShot(leverstraight, 0.5f);
            }
           
            trainEngine.switchpulled = true;
            print("Forked");
        }

    }
}

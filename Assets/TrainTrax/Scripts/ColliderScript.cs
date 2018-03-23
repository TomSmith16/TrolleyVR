using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderScript : MonoBehaviour {
    FadeScript fade;
    //public GameObject canvas;
    //public GameObject text;
    Scene scene;
    // Use this for initialization
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        //fade = canvas.GetComponent<FadeScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Trigger events for lever

    //Trigger events for lever
    private void OnTriggerEnter(Collider other)
    {

        print("Collision");

        if (scene.name == "Trolley")
        {
            //switch (other.tag)
            //{
            //    case "ForkCollider":

            //        //GUI Pop up saying "X amount has died" or "You chose to not pull the lever"
            //        //Scream
            //        // fade.FadeOut();
            //        //text.GetComponent<Text>().text = "You chose to pull the lever";
            //        print("Fork collided");

            //        break;

            //    case "StraightCollider":

            //        //GUI Pop up saying "X amount has died" or "You chose to pull the lever"
            //        //Screams
            //        //fade.FadeOut();
            //        //text.GetComponent<Text>().text = "You chose to NOT pull the lever";
            //        print("Straight Collided");

            //        break;

            //    default:
            //        break;
            //}
            StartCoroutine(Wait(2));
        }
        else if (scene.name == "FatmanPractice")
        {
            //switch (other.tag)
            //{

            //    case "StraightCollider":

            //        //GUI Pop up saying "X amount has died" or "You chose to pull the lever"
            //        //Screams
            //        //fade.FadeOut();
            //        //text.GetComponent<Text>().text = "You chose to NOT push the large man.";
            //        print("Straight Collided");

            //        break;

            //    default:
            //        //Scream of large man
            //        FatmanTrainEngine enginespeed = GetComponent<FatmanTrainEngine>();
            //        enginespeed.moveSpeed = 0;
            //        enginespeed.gainSpeed = 0;
            //        enginespeed.GetComponent<AudioSource>().Stop();
            //        //fade.FadeOut();
            //        // text.GetComponent<Text>().text = "You chose to push the large man.";
            //        print("Large man pushed");
            //        break;
            //}
            StartCoroutine(Wait(3));
        }
        else if (scene.name == "Fatman")
        {

        }
        else
        {
            //fade.FadeOut();
            //switch (other.tag)
            //{
            //    case "ForkCollider":
            //        print("Fork collided");

            //        break;

            //    case "StraightCollider":
            //        print("Straight Collided");

            //        break;

            //    default:
            //        break;
            //}
            StartCoroutine(Wait(1));

        }
        //Screen fade out
    }

    IEnumerator Wait(int level)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(level);

    }
}

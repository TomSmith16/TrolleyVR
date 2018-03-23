using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainEngine : MonoBehaviour {

    LeverScript leverscript;
    public bool active = false;
    MouseLook mouselook;
    public bool switchpulled = false;
    public float maxSpeed = 20.0f;
    public float moveSpeed = 1.0f;
    public float gainSpeed = 0.02f;
    public float maxSteerAngle = 45f;
    private Vector3 moveDirection;
    private Vector3 targetLookAt;
    AudioSource audio;
    public AudioClip leverstraight;
    public AudioClip leverpulled;
    //Add path2 option, either list of paths and have alternate between the two on button press or separate transform
    public Transform pathstraight;
    public Transform pathfork;
    private List<Transform> nodesstraight;
    private List<Transform> nodesfork;
    private GameObject straightArrow;
    private GameObject curvedArrow;
    private GameObject lever;
    public GameObject straightCollider;
    public GameObject forkedCollider;
    public FadeScript fade;
    private bool neutral = false;

    public int currentNode = 0;

    // Use this for initialization
    private void Start () {
        //mouselook = alivescript.GetComponent<MouseLook>();
        audio = GetComponent<AudioSource>();
        straightArrow = GameObject.Find("Trolley/Signpost/StraightArrow");
        curvedArrow = GameObject.Find("Trolley/Signpost/CurvedArrow");
        lever = GameObject.Find("Trolley/Lever/Base/Lever");
        leverscript = lever.GetComponent<LeverScript>();


        Transform[] pathstraightTransforms = pathstraight.GetComponentsInChildren<Transform>();
        nodesstraight = new List<Transform>();

        for (int i = 0; i < pathstraightTransforms.Length; i++)
        {
            if (pathstraightTransforms[i] != pathstraight.transform)
            {
                nodesstraight.Add(pathstraightTransforms[i]);
            }
        }

        Transform[] pathforkTransforms = pathfork.GetComponentsInChildren<Transform>();
        nodesfork = new List<Transform>();

        for (int i = 0; i < pathforkTransforms.Length; i++)
        {
            if (pathforkTransforms[i] != pathfork.transform)
            {
                nodesfork.Add(pathforkTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    private void Update() {

        
            /*if(!active)
            {
             if (Input.GetKeyDown(KeyCode.P))
                {
                 fade.FadeOut();
                }
            }
            */
            if (!active) //&& fade.faded
        {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    StartCoroutine(StartSound());

                }

                
            }

            if (currentNode < 2)
            {

             
                if (Input.GetKeyDown(KeyCode.K))
                {

                    /////////////BOX COLLIDER SCRIPTS, ON TRIGGER ENTER/EXIT
                    //if (leverrotation.z > 24 || leverrotation.z < -24)
                    if (switchpulled)
                    {
                    // lever.GetComponent<Rigidbody>().AddForce(0, 0, 100);
                    switchpulled = false;
                        /*straightArrow.GetComponent<Renderer>().enabled = true;
                        curvedArrow.GetComponent<Renderer>().enabled = false;
                        audio.PlayOneShot(leverpulled, 0.5f);*/
                    }
                    else
                    {

                    //lever.GetComponent<Rigidbody>().AddForce(0, 0, -100);
                    switchpulled = true;
                        /*straightArrow.GetComponent<Renderer>().enabled = false;
                        curvedArrow.GetComponent<Renderer>().enabled = true;
                        audio.PlayOneShot(leverstraight, 0.5f);*/
                    }

                    //switchpulled = !switchpulled;


                }
            }

            //ApplySteer();
            if (active)
            {
                if (!switchpulled)
                {

                    Drive(nodesstraight);
                    CheckWaypointDistance(nodesstraight);
                    // print("Straight");
                }
                else
                {
                    Drive(nodesfork);
                    CheckWaypointDistance(nodesfork);
                    //print("Forked");
                }
            }
        
        
    }


    //private void ApplySteer()
    //{
    //    Vector3 relativeVector = transform.InverseTransformPoint(nodesstraight[currentNode].position);
    //    float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
    //    //transform.eulerAngles = new Vector3(0, newSteer, 0);
    //}
    public IEnumerator StartSound()
    {
            audio = GetComponent<AudioSource>();

            audio.Play();
            yield return new WaitForSeconds(1.0f);
            active = true;
    }

    private void Drive(List<Transform> nodes)
    {
        //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        //Check for current nodes, if still available to switch tracks, have button press change path to follow.
            //if ((currentNode + 1) == nodes.Count)
            //{
            //    print("Last node");
            //}
            //else
            //{
            //    targetLookAt = new Vector3(nodes[currentNode + 1].transform.position.x, 0, nodes[currentNode + 1].transform.position.z);
            //}
            //foreach (Transform child in transform)
            //{ 
            //    child.transform.LookAt(targetLookAt);
            //}

            transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, moveSpeed*Time.deltaTime);
            if (moveSpeed < maxSpeed)
            {
                moveSpeed+= gainSpeed;
            }
            //transform.LookAt(nodes[currentNode+1].position);
    }


    private void CheckWaypointDistance(List<Transform> nodes)
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.1f)
        {
            if (currentNode == nodes.Count - 1)
            {
                moveSpeed = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }
}

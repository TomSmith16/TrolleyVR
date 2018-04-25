using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FatmanTrainEngine : MonoBehaviour {
    public bool active = false;

    public bool switchpulled = false;
    public float maxSpeed = 20.0f;
    public float moveSpeed = 1.0f;
    public float gainSpeed = 0.02f;
    public float maxSteerAngle = 45f;
    private Vector3 moveDirection;
    private Vector3 targetLookAt;
    AudioSource audiofatman;
    //Add path2 option, either list of paths and have alternate between the two on button press or separate transform
    public Transform pathstraight;
    private List<Transform> nodesstraight;
    private List<Transform> nodesfork;
    public GameObject largeman;
    public GameObject forkcollider;
    public FadeScript fade;
    Vector3 cratePos;
    Quaternion crateRot;
    Scene scene;
    

    public int currentNode = 0;

    // Use this for initialization
    private void Start()
    {
        audiofatman = GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene();
        Transform[] pathstraightTransforms = pathstraight.GetComponentsInChildren<Transform>();
        nodesstraight = new List<Transform>();
        largeman = GameObject.Find("Fatman/Crate");

        for (int i = 0; i < pathstraightTransforms.Length; i++)
        {
            if (pathstraightTransforms[i] != pathstraight.transform)
            {
                nodesstraight.Add(pathstraightTransforms[i]);
            }
        }

    }

    // Update is called once per frame
    private void Update()
    {
        /*
        if (!active)
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
            if (scene.name == "Fatman")
            {
                largeman = forkcollider.transform.GetChild(1).gameObject;
            }
            else
            {
                //largeman = GameObject.Find("Fatman/Barrel");
                largeman = GameObject.Find("Fatman/Crate");

                /*
                if (Input.GetKeyDown(KeyCode.B))
                {
                    
                    largeman.transform.position = cratePos;
                    largeman.transform.rotation = crateRot;
                }
                */
            }
            
        }

        if (largeman.transform.position.y < 1)
        {
            largeman.GetComponentInChildren<BoxCollider>().size = new Vector3(largeman.GetComponentInChildren<BoxCollider>().size.x, largeman.GetComponentInChildren<BoxCollider>().size.y, 4);
            largeman.GetComponentInChildren<Rigidbody>().isKinematic = true;
            largeman.GetComponentInChildren<BoxCollider>().isTrigger = true;

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
    IEnumerator StartSound()
    {
        audiofatman = GetComponent<AudioSource>();

        audiofatman.Play();
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

        transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, moveSpeed * Time.deltaTime);
        if (moveSpeed < maxSpeed)
        {
            moveSpeed += gainSpeed;
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

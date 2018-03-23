using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatmanOrientation : MonoBehaviour {


    private Vector3 moveDirection;
    private Vector3 targetLookAt;
    //Add path2 option, either list of paths and have alternate between the two on button press or separate transform
    public Transform pathstraight;
    private List<Transform> nodesstraight;
    private List<Transform> nodesfork;
    GameObject theTrain;
    FatmanTrainEngine trainEngine;


    // Use this for initialization
    void Start()
    {

        theTrain = GameObject.Find("Fatman/Train");
        trainEngine = theTrain.GetComponent<FatmanTrainEngine>();



        Transform[] pathstraightTransforms = pathstraight.GetComponentsInChildren<Transform>();
        nodesstraight = new List<Transform>();

        for (int i = 0; i < pathstraightTransforms.Length; i++)
        {
            if (pathstraightTransforms[i] != pathstraight.transform)
            {
                nodesstraight.Add(pathstraightTransforms[i]);
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trainEngine.active == true)
        {
            if (!trainEngine.switchpulled)
            {
                Orientation(nodesstraight);
                //CheckWaypointDistance(nodesstraight);
            }
            else
            {
                Orientation(nodesfork);
                //CheckWaypointDistance(nodesfork);
            }
        }

    }


    private void Orientation(List<Transform> nodes)
    {
        if ((trainEngine.currentNode + 1) == nodes.Count)
        {
            //print("Last node");
        }
        else
        {
            targetLookAt = new Vector3(nodes[trainEngine.currentNode + 1].transform.position.x, 0, nodes[trainEngine.currentNode + 1].transform.position.z);
            //print("Node to look at: " + nodes[trainEngine.currentNode + 1]);
        }

        transform.LookAt(targetLookAt);
    }

}

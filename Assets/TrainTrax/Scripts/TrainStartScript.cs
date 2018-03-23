using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStartScript : MonoBehaviour {

    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();



    
    // Use this for initialization
    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

        for (int j = 0; j < nodes.Count; j++)
        {
            Vector3 currentNode = nodes[j].position;
            Vector3 previousNode = Vector3.zero;
            //Check to make full loop, -1 node doesnt exist
            if (j > 0)
            {
                previousNode = nodes[j - 1].position;
            }
            else if (j == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawWireSphere(currentNode, 0.3f);
        }
    }

	/* Update is called once per frame
	void Update () {

    */
}

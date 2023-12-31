using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;
    public float speed = 5.0f;
    float accuracy = 5.0f;
    public float rotSpeed = 5.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;
    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[15]);
        currentWP = 0;
    }

    public void GoToStart()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRock()
    {
        g.AStar(currentNode, wps[6]);
        currentWP = 0;
    }

    public void GoToFactory()
    {
        g.AStar(currentNode, wps[12]);
        currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (g.pathList.Count == 0 || currentWP == g.pathList.Count)
        {
            return;
        }

        if (Vector3.Distance(g.pathList[currentWP].getId().transform.position, this.transform.position) < accuracy)
        {
            currentNode = g.pathList[currentWP].getId();
            currentWP++;
        }

        if (currentWP < g.pathList.Count)
        {
            goal = g.pathList[currentWP].getId().transform;
            Debug.Log(goal.name);
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}

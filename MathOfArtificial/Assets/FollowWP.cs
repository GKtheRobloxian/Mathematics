using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;
    public float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;

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

        Invoke("GoToRock", 1.5f);
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[15]);
        currentWP = 0;
        Debug.Log(wps[15].name);
    }

    public void GoToRock()
    {
        g.AStar(currentNode, wps[6]);
        currentWP = 0;
        Debug.Log(wps[6].name);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log(currentWP);
        Debug.Log(g.pathList.Count);
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

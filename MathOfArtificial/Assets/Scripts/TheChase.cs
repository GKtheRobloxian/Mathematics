using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheChase : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public GameObject[] waypoints;
    public int currentWaypoint = 0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(waypoints[currentWaypoint % waypoints.Length].transform.position);
        GetComponent<Rigidbody>().AddRelativeForce(transform.forward * acceleration);

        if (Mathf.Abs(transform.position.x) >= 10.0f)
        {
            transform.position = new Vector3(0, 0.5f, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (Mathf.Abs(transform.position.z) >= 5.0f)
        {
            transform.position = new Vector3(0, 0.5f, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        Debug.DrawLine(transform.position, rb.velocity, Color.blue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == waypoints[currentWaypoint % waypoints.Length])
        {
            currentWaypoint++;
        }
    }
}

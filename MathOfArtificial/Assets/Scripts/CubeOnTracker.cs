using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOnTracker : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float rotationSpeed;
    public GameObject tracking;
    float speed;
    public GameObject[] waypoints;
    public int currentWaypoint = 0;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
        Quaternion lookAt = Quaternion.LookRotation(tracking.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, rotationSpeed * Time.deltaTime);
        speed += acceleration * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (Mathf.Abs(transform.position.x) >= 10.0f)
        {
            transform.position = new Vector3(0, 1.0f, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.LookAt(waypoints[currentWaypoint % waypoints.Length].transform.position);
        }
        if (Mathf.Abs(transform.position.z) >= 5.0f)
        {
            transform.position = new Vector3(0, 1.0f, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.LookAt(waypoints[currentWaypoint % waypoints.Length].transform.position);
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        Debug.DrawLine(transform.position, rb.velocity, Color.blue);

        if (Vector3.Distance(tracking.transform.position, transform.position) > 3f)
        {
            tracking.GetComponent<TheChase>().speed = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == waypoints[currentWaypoint % waypoints.Length])
        {
            currentWaypoint++;
        }
    }
}

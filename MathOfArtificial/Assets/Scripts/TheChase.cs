using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheChase : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float rotationSpeed;
    public float speed;
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
        Quaternion lookAt = Quaternion.LookRotation(waypoints[currentWaypoint % waypoints.Length].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, rotationSpeed * Time.deltaTime);
        speed += acceleration * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (Mathf.Abs(transform.position.x) >= 10.0f)
        {
            transform.position = new Vector3(0, 1.0f, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (Mathf.Abs(transform.position.z) >= 5.0f)
        {
            transform.position = new Vector3(0, 1.0f, 0);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        Debug.DrawLine(transform.position, rb.velocity, Color.blue);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == waypoints[currentWaypoint % waypoints.Length])
        {
            currentWaypoint++;
        }
    }
}

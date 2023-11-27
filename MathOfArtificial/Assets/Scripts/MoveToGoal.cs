using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public float speed = 1.0f;
    public float accuracy = 0.01f;
    public Transform goal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(goal.position);
        Vector3 direction = goal.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.black);
        if (direction.magnitude > accuracy)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}

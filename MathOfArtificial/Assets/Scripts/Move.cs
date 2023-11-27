using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 goal = new Vector3(5, 0, 4);
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(goal.normalized * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.left * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * horizontal * speed * Time.deltaTime);

    }
}

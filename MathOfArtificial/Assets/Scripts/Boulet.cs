using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulet : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        rb.velocity -= Vector3.forward * 9.8f * Time.deltaTime;
        //WHY UNITYY
    }

}

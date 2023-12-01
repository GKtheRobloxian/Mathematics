using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        float random = Random.Range(-8.0f, 8.0f);
        float random2 = Random.Range(-8.0f, 8.0f);
        transform.position = new Vector3(random, 1.001f, random2);
        Debug.Log("I am (supposed to) collide with " + other);

        //a
    }
}

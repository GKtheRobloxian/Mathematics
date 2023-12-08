using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LifetimeCheck : MonoBehaviour
{
    public float lifetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;

        if (transform.position.z < 0)
        {
            // Debug.Log(lifetime);
        }
    }
}

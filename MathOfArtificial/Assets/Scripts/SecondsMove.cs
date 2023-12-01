using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsMove : MonoBehaviour
{
    float timeStartOffset = 0;
    bool gotStartTimee = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gotStartTimee)
        {
            timeStartOffset = Time.realtimeSinceStartup;
            gotStartTimee = true;
        }

        transform.position = new Vector3(Time.realtimeSinceStartup - timeStartOffset - 4.5f, transform.position.y, transform.position.z);
    }
}

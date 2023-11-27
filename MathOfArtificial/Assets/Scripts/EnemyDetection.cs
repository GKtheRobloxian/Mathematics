using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject counterpart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counterpart.transform.rotation.y == transform.rotation.y + 180 || counterpart.transform.rotation.y == transform.rotation.y - 180)
        {
            Debug.Log("Hell yeah");
        }
        //no
    }
}

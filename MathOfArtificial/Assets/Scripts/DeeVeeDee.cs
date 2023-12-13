using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeeVeeDee : MonoBehaviour
{
    public float speed;
    public Transform speedAim;
    // Start is called before the first frame update
    void Start()
    {
        float randomRadians = Random.Range(0f, 2 * Mathf.PI);
        speedAim.localPosition = new Vector3(Mathf.Cos(randomRadians), 0, Mathf.Sin(randomRadians));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * (speedAim.position - transform.position) * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) >= 9.5f)
        {
            speedAim.localPosition = new Vector3(-speedAim.localPosition.x, 0, speedAim.localPosition.z);
        }
        if(Mathf.Abs(transform.position.z) >= 4.5f)
        {
            speedAim.localPosition = new Vector3(speedAim.localPosition.x, 0, -speedAim.localPosition.z);
        }
    }
}

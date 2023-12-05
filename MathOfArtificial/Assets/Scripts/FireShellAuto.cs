using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShellAuto : MonoBehaviour
{
    public GameObject shell;
    public GameObject spawnPoint;
    public GameObject target;
    public float rotationSpeed;
    public float launchPower;
    public float fireRate;
    float fireRateInit;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        fireRateInit = fireRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 distance = target.transform.position - spawnPoint.transform.position;
        float xDistance = distance.x;
        float zDistance = Mathf.Abs(distance.z);
        float zRotation = transform.localEulerAngles.y;
        float initialZVelocity = Mathf.Abs(launchPower * Mathf.Sin(zRotation * Mathf.PI / 180f) / 3f);
        float initialXVelocity = Mathf.Abs(launchPower * Mathf.Cos(zRotation * Mathf.PI / 180f) / 3f);
        float launchVelocity = launchPower / 3f;
        float airTime = 2 * (50 / (3 * 9.8f) * Mathf.Sin(zRotation * Mathf.PI / 180f)) + (initialZVelocity + Mathf.Sqrt(initialZVelocity * initialZVelocity + 4 * 4.9f * zDistance)) / 9.8f;
        Debug.Log((50/3) * Mathf.Sin(zRotation * Mathf.PI/180f) / 9.8f);
        Debug.Log(airTime);

        // -zDistance = -initialZPower*time - 4.9(time*time)

        // (50/3)/9.8
    }
}

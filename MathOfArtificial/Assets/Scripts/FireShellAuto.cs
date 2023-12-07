using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

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
        Vector3 distance = transform.position - target.transform.position;
        float xDistance = distance.x;
        float zRotation = transform.localEulerAngles.y + 90f;
        float zRotationAngle = zRotation * Mathf.PI / 180f;
        float launchVelocity = launchPower / 3f;
        float initialZVelocity = (launchVelocity * Mathf.Sin(zRotationAngle));
        float initialXVelocity = (launchVelocity * Mathf.Cos(zRotationAngle));
        float airTime = (launchVelocity * (Mathf.Sin(zRotationAngle)) / 4.9f);
        float xLaunch = airTime * initialXVelocity;
        float properXLaunch = xDistance;
        float properZRotation = 90 + (Mathf.Asin((properXLaunch * 4.9f) / (launchVelocity * launchVelocity)) * 180f / Mathf.PI);
        if (properZRotation - zRotation < 0 && Mathf.Abs(properZRotation - (zRotation - 315)) > 1f)
        {
            transform.rotation = Quaternion.Euler(new Vector3 (90, transform.localEulerAngles.y - rotationSpeed * Time.deltaTime, 0));
            Debug.Log("I SHOULD BE ROTATING");
        }
        else if (properZRotation - zRotation > 0 && Mathf.Abs(properZRotation - (zRotation - 315)) > 1f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(90, transform.localEulerAngles.y + rotationSpeed * Time.deltaTime, 0));
            Debug.Log("I SHOULD BE ROTATING");
        }

        Debug.Log(properZRotation);
        Debug.Log(zRotation);

        // arcsin((xLaunch * 4.9f) / (launchVelocity ^ 2)) = ((2theta))
    }
}

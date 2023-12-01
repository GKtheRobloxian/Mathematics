using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float maxSpeed = 4.0f;
    public float acceleration = 1.0f;
    float currentMovement;
    bool forwardMovement;
    bool youShouldTakeOver = false;
    public float deceleration = 1.0f;
    float speed;
    public float rotationSpeed = 120.0f;
    float turningSharpness;

    public GameObject fuel;
    public GameObject forwardDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CalculateDistance()
    {
        Vector3 fP = fuel.transform.position;
        Vector3 tP = transform.position;

        float distance = (fP - tP).magnitude;
        Debug.Log("distance is" + distance);
    }

    // Update is called once per frame
    void Update()
    {
        if (youShouldTakeOver)
        {
            ManualMovement();
        }
        else
        {
            AutomaticMovement();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            youShouldTakeOver = !youShouldTakeOver;
        }
    }

    void AutomaticMovement()
    {
        speed = speed + (acceleration * Time.deltaTime);
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        Vector3 tF = forwardDirection.transform.position - transform.position;
        Vector3 fD = fuel.transform.position - transform.position;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float angle = (Mathf.Acos(((tF.x * fD.x) + (tF.z * fD.z)) / ((tF.magnitude) * fD.magnitude)))*180 / Mathf.PI;
        Vector3 crossProduct = new Vector3(tF.y * fD.z - tF.z * fD.y, tF.z * fD.x - tF.x * fD.z, tF.x * fD.y - tF.y * fD.x);
        float turningDirection = crossProduct.y;
        if (turningDirection < 0 && Mathf.Abs(angle) > 0.1f)
        {
            Debug.Log("turn right");
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }
        else if (turningDirection > 0 && Mathf.Abs(angle) > 0.1f)
        {
            Debug.Log("turn left");
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Angle is " + angle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateDistance();
        }
    }

    void ManualMovement()
    {
        Vector3 tF = forwardDirection.transform.position - transform.position;
        Vector3 fD = fuel.transform.position - transform.position;
        float angle = (Mathf.Acos(((tF.x * fD.x) + (tF.z * fD.z)) / ((tF.magnitude) * fD.magnitude))) * 180 / Mathf.PI;
        Debug.Log("Angle is " + angle);
        currentMovement = speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateDistance();
        }
        speed += Input.GetAxisRaw("Vertical") * acceleration * Time.deltaTime;
        if (speed < 0)
        {
            forwardMovement = false;
        }
        else if (speed > 0)
        {
            forwardMovement = true;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            if (forwardMovement)
            {
                speed -= deceleration * Time.deltaTime;
            }
            else if (!forwardMovement)
            {
                speed += deceleration * Time.deltaTime;
            }
            if (Mathf.Abs(speed) <= 0.01f)
            {
                speed = 0.0f;
            }
        }
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        float translation = speed * Time.deltaTime;
        float rotation = Input.GetAxisRaw("Horizontal") * -rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, -rotation, 0);

        // The script is right here Unity. Come on.
    }
}

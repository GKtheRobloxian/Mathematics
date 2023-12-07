using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class FireShell : MonoBehaviour
{
    public GameObject shell;
    public GameObject spawnPoint;
    public float upAndDown;
    public float leftAndRight;
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
    void Update()
    {
        upAndDown = Input.GetAxisRaw("Vertical");
        leftAndRight = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.back * rotationSpeed * upAndDown * Time.deltaTime);
        speed += leftAndRight * Time.deltaTime;
        if (speed > 3f)
        {
            speed = 3f;
        }
        if (leftAndRight == 0)
        {
            speed = Mathf.Lerp(speed, 0, 0.002f);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        fireRate -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && fireRate < 0)
        {
            GameObject spawn = Instantiate(shell, transform.position, Quaternion.identity);
            spawn.GetComponent<Rigidbody>().AddRelativeForce((spawnPoint.transform.position - transform.position).normalized * launchPower, ForceMode.Impulse);
            fireRate = fireRateInit;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnWaypoints : MonoBehaviour
{
    public float trackLength;
    public GameObject toSpawn;
    float lastX = 0;
    float lastZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(toSpawn, Vector3.up + Vector3.right*2, Quaternion.identity);
        for (int i = 0; i < trackLength - 1; i++)
        {
            if (lastX > 0 && lastZ > 0)
            {
                GameObject instantiated = Instantiate(toSpawn, new Vector3(lastX - Random.Range(0.0f, 10.0f), 1f, lastZ - Random.Range(0.0f, 5.0f)), Quaternion.identity);
                lastX = instantiated.transform.position.x;
                lastZ = instantiated.transform.position.z;
            }
            else if (lastX > 0 && lastZ < 0)
            {
                GameObject instantiated = Instantiate(toSpawn, new Vector3(lastX - Random.Range(0.0f, 10.0f), 1f, lastZ + Random.Range(0.0f, 5.0f)), Quaternion.identity);
                lastX = instantiated.transform.position.x;
                lastZ = instantiated.transform.position.z;
            }
            else if (lastX < 0 && lastZ < 0)
            {
                GameObject instantiated = Instantiate(toSpawn, new Vector3(lastX + Random.Range(0.0f, 10.0f), 1f, lastZ + Random.Range(0.0f, 5.0f)), Quaternion.identity);
                lastX = instantiated.transform.position.x;
                lastZ = instantiated.transform.position.z;
            }
            else if (lastX < 0 && lastZ > 0)
            {
                GameObject instantiated = Instantiate(toSpawn, new Vector3(lastX + Random.Range(0.0f, 10.0f), 1f, lastZ - Random.Range(0.0f, 5.0f)), Quaternion.identity);
                lastX = instantiated.transform.position.x;
                lastZ = instantiated.transform.position.z;
            }
            else if (lastX == 0 && lastZ == 0)
            {
                GameObject instantiated = Instantiate(toSpawn, new Vector3(lastX + Random.Range(-9.5f, 9.5f), 1f, lastZ + Random.Range(-4.5f, 4.5f)), Quaternion.identity);
                lastX = instantiated.transform.position.x;
                lastZ = instantiated.transform.position.z;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}

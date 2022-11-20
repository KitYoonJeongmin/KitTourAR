using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronGenerator : MonoBehaviour
{
    public GameObject Dron;
    public Transform arCamera;
    float distance = 20.0f;
    float minDistance = 10.0f;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("Generator", 2.0f,4.5f);
    }
    void Generator()
    {
        float x, z;
        x = Random.Range(minDistance, distance);
        z = Random.Range(-3.0f, 3.0f);
        if(Random.Range(-1.0f, 1.0f) >0) { z *= (-1); }
        Instantiate(Dron, arCamera.transform.forward * x + arCamera.transform.right * z, arCamera.transform.rotation);
        transform.LookAt(transform);
    }
}

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
        InvokeRepeating("Generator", 2.0f,4.0f);
    }
    void Generator()
    {
        float x, z,y;
        x = Random.Range(minDistance, distance);
        y = Random.Range(0.0f, 5.0f);
        z = Random.Range(0.0f, 5.0f);
        if(Random.Range(-1.0f, 1.0f) >0) { z *= (-1); }
        GameObject cloneDrone = Instantiate(Dron, arCamera.transform.forward * x + arCamera.transform.right * z+new Vector3(0,y,0), arCamera.transform.rotation);
        cloneDrone.transform.LookAt(arCamera.transform);
    }
}

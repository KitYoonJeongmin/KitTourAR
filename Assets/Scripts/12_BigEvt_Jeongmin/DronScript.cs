using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronScript : MonoBehaviour
{
    public GameObject projectile;
    private Transform arCamera;
    float speed = 0.5f;
    float time=0.0f;
    private void Start()
    {
        arCamera = GameObject.Find("AR Camera").transform;
    }
    void Update()
    {
        transform.LookAt(arCamera);
        transform.position += transform.forward * speed * Time.deltaTime;
        time += Time.deltaTime;
        if(time > 3.0f)
        {
            if(Random.Range(0, 100)==0)
            {
                time = 0.0f;
                GameObject dronProjec = Instantiate(projectile, transform.position+transform.forward ,transform.rotation);
                dronProjec.GetComponent<Rigidbody>().AddForce(transform.forward * 100.0f);
            }
        }
    }

}

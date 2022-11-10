using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharactor : MonoBehaviour
{
    public GameObject GPSManager;
    public Camera cam;
    public Vector3 locationVec;
    public Vector3 checkloc;
    private float mov_speed = 10.0f;
    private float rot_speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GPSManager = GameObject.Find("GPSManager");
        checkloc = GPSEncoder.GPSToUCS(36.142164f, 128.393760f);
        GetLatitude();
        location();
        
    }
    void GetLatitude()
    {
        //locationVec = GPSManager.GetComponent<GPS>().unityCoor;
        locationVec = checkloc;
    }
    
    // Update is called once per frame
    void Update()
    {
        KeybordMove();
    }
    void location()
    {
        locationVec.y += 10; 
        transform.position = locationVec;
        
    }

    void KeybordMove()
    {
        Vector3 mov = transform.forward * Input.GetAxis("Vertical");
        Vector3 rot = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.position += (mov * mov_speed * Time.deltaTime);
        transform.Rotate(rot * rot_speed * Time.deltaTime);


    }
}

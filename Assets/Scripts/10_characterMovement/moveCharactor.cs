using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharactor : MonoBehaviour
{
    public GameObject GPSManager;
    public Camera cam;
    private Vector3 locationVec;
    public float lat = 36.142952f;
    public float lon = 128.394272f;
    //private float mov_speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GPSManager = GameObject.Find("GPSManager");
        GetLatitude();
    }
    // Update is called once per frame
    void Update()
    {
        //KeybordMove();
        charactorMove();
    }

    void charactorMove()
    {
        KeybordMove();
        GetLatitude();
        transform.position = locationVec;
    }
    void GetLatitude()
    {
        //locationVec = GPSManager.GetComponent<GPS>().unityCoor;
        locationVec = GPSEncoder.GPSToUCS(lat, lon);
    }
    void KeybordMove()
    {

        lon -= 0.00001f * Input.GetAxis("Vertical");
        lat += 0.000005f * Input.GetAxis("Horizontal");
        //36.14011, 128.3974
        //36.14919, 128.3858
    }
}

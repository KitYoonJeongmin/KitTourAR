using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharactor : MonoBehaviour
{
    private Vector3 locationVec;
    private float moveSpeed = 4.0f;
    private float turnSpeed = 4.0f;
    public float lat = 36.142952f;
    public float lon = 128.394272f;
    //private float mov_speed = 10.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        locationVec = GPS.unityCoor;
        transform.position = locationVec;
    }
    // Update is called once per frame
    void Update()
    {
        //KeybordMove();
        charactorMove();
    }

    void charactorMove()
    {
        Move();
        GetLatitude();
        transform.position = Vector3.Lerp(transform.position, locationVec, 0.1f);
    }
    void GetLatitude()
    {
        locationVec = GPS.unityCoor;
        //locationVec = GPSEncoder.GPSToUCS(lat, lon);
    }
    void Move()
    {
        mouseMove();
        KeybordMove();
    }
    void mouseMove()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize*Time.deltaTime*5;
        transform.eulerAngles = new Vector3(0, yRotate, 0);
    }
    void KeybordMove()
    {
        lon -= 0.00001f * Input.GetAxis("Vertical");
        lat += 0.00001f * Input.GetAxis("Horizontal");
        //36.14011, 128.3974
        //36.14919, 128.3858
        //Vector3 move =
        //    transform.forward * Input.GetAxis("Vertical") +
        //    transform.right * Input.GetAxis("Horizontal");
        //transform.position += move * moveSpeed * Time.deltaTime;
    }
}

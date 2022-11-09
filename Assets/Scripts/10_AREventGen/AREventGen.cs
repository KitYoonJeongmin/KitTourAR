//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;
//using UnityEngine.UI;


//public class AREventGen : MonoBehaviour
//{
//    public Text text1;
//    public Text text2;
//    public struct LatLong
//    {
//        public float lat;
//        public float lon;
//    }
//    //��ġ�� ���ϱ� ���� ����
//    private GameObject GPSManager;
//    private Vector3 currentLocation;
//    private Vector3 eventLoaction;
//    //�̺�Ʈ �������� �����ϱ� ���� ����
//    public GameObject eventPre;

//    //�����浵
//    public LatLong[] latLongs;
//    //�̺�Ʈ ���� ����
//    public bool isGen;
//    //����ĳ��Ʈ ����
//    ARRaycastManager arRayMan;


//    // Start is called before the first frame update
//    void Start()
//    {
//        //GPS Object ������
//        GPSManager = GameObject.Find("GPSManager");
//        arRayMan = GetComponent<ARRaycastManager>();
//        eventPre.SetActive(false);
//        isGen = false;
//    }
//    void Update()
//    {
//        text2.text = "���� ����: " + isGen.ToString();
//        currentLocation = GPSManager.GetComponent<GPS>().unityCoor;
//        if (!isGen)
//        {
//            GenerateEventPre();
//        }
//        else
//        {
//            DestroyEventPre();
//        }

//    }
//    void DestroyEventPre()
//    {

//        if (1000000 < Vector3.Magnitude(eventPre.transform.position - currentLocation))
//        {
//            eventPre.SetActive(false);
//            isGen = false;
//        }
//    }

//    void GenerateEventPre()
//    {

//        //����Ʈ�� ��ũ���� Center�� ã��
//        Vector2 centerPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
//        //Ray�� �ε��� ������ ������ ������ ����Ʈ ����
//        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();
//        //��ũ�� �߾��������� ���� Ray�� �߻� ���� ��, Plane Ÿ���� ��ü�� �����Ѵٸ�,
//        if (arRayMan.Raycast(centerPoint, hitInfos, TrackableType.Planes))
//        {
//            //ǥ�� ������Ʈ Ȱ��ȭ
//            eventPre.SetActive(true);
//            //ǥ�� ������Ʈ�� ��ġ�� ȸ���� ������Ʈ
//            eventPre.transform.position = hitInfos[0].pose.position;
//            eventPre.transform.rotation = hitInfos[0].pose.rotation;
//        }

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
public class AREventGen : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public GameObject eventPre; //�ε������� ����
    ARRaycastManager arRayMan; //ARRaycastManager ������Ʈ ����
    private GameObject GPSManager;
    private Vector3 currentLocation;
    public bool isGen;
    public struct LatLong
    {
        public float lat;
        public float lon;
    }
    public LatLong[] latLongs;
    void Start()
    {
        GPSManager = GameObject.Find("GPSManager");

        //�ε������� ��Ȱ��ȭ
        eventPre.SetActive(false);
        isGen = false;
        //������Ʈ���� ARRaycastManaget ȹ��
        arRayMan = GetComponent<ARRaycastManager>();
        InvokeRepeating("GetUNTCoord", 0.5f, 0.2f);
        latLongs[0].lat = 36.1254f;
        latLongs[0].lon = 128.3625f;
    }
    void DetectPlace()
    {
        foreach(LatLong latLong in latLongs)
        {
            if(Vector3.Magnitude(currentLocation
                - GPSEncoder.GPSToUCS(latLong.lat, latLong.lon))>20)
            {
                return;
            }
            DetectGround();
        }
        
    }
    void DetectGround()
    {
        //����Ʈ�� ��ũ���� Center�� ã��
        Vector2 centerPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        //Ray�� �ε��� ������ ������ ������ ����Ʈ ����
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();
        //��ũ�� �߾��������� ���� Ray�� �߻� ���� ��, Plane Ÿ���� ��ü�� �����Ѵٸ�,
        if (arRayMan.Raycast(centerPoint, hitInfos, TrackableType.Planes))
        {
            //ǥ�� ������Ʈ Ȱ��ȭ
            eventPre.SetActive(true);
  
            //ǥ�� ������Ʈ�� ��ġ�� ȸ���� ������Ʈ
            eventPre.transform.position = hitInfos[0].pose.position;
            eventPre.transform.rotation = hitInfos[0].pose.rotation;
            isGen = true;
        }
    }
    void DestroyEventPre()
    {

        if (1000000 < Vector3.Magnitude(eventPre.transform.position - currentLocation))
        {
            eventPre.SetActive(false);
            isGen = false;
        }
    }
    void Update()
    {
        
        text1.text = "x: "+ eventPre.transform.position.x.ToString() + ",y: " + eventPre.transform.position.y.ToString() + ",z: " + eventPre.transform.position.z.ToString();
        text2.text = "���� ����: " + isGen.ToString();

        if (!isGen)
        {
            DetectGround();
        }
        else
        {
            DestroyEventPre();
        }

    }
    void GetUNTCoord()
    {
        currentLocation = GPSManager.GetComponent<GPS>().unityCoor;
    }

}
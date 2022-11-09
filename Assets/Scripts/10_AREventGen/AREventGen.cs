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
//    //위치를 구하기 위한 변수
//    private GameObject GPSManager;
//    private Vector3 currentLocation;
//    private Vector3 eventLoaction;
//    //이벤트 프리팹을 생성하기 위한 변수
//    public GameObject eventPre;

//    //위도경도
//    public LatLong[] latLongs;
//    //이벤트 생성 유무
//    public bool isGen;
//    //레이캐스트 저장
//    ARRaycastManager arRayMan;


//    // Start is called before the first frame update
//    void Start()
//    {
//        //GPS Object 가져옴
//        GPSManager = GameObject.Find("GPSManager");
//        arRayMan = GetComponent<ARRaycastManager>();
//        eventPre.SetActive(false);
//        isGen = false;
//    }
//    void Update()
//    {
//        text2.text = "생성 유무: " + isGen.ToString();
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

//        //스마트폰 스크린의 Center를 찾음
//        Vector2 centerPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
//        //Ray에 부딪힌 대상들의 정보를 저장할 리스트 생성
//        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();
//        //스크린 중앙지점으로 부터 Ray를 발사 했을 때, Plane 타입의 물체가 존재한다면,
//        if (arRayMan.Raycast(centerPoint, hitInfos, TrackableType.Planes))
//        {
//            //표식 오브젝트 활성화
//            eventPre.SetActive(true);
//            //표식 오브젝트의 위치와 회전값 업데이트
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
    public GameObject eventPre; //인디케이터 저장
    ARRaycastManager arRayMan; //ARRaycastManager 컴포넌트 저장
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

        //인디케이터 비활성화
        eventPre.SetActive(false);
        isGen = false;
        //컴포넌트에서 ARRaycastManaget 획득
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
        //스마트폰 스크린의 Center를 찾음
        Vector2 centerPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        //Ray에 부딪힌 대상들의 정보를 저장할 리스트 생성
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();
        //스크린 중앙지점으로 부터 Ray를 발사 했을 때, Plane 타입의 물체가 존재한다면,
        if (arRayMan.Raycast(centerPoint, hitInfos, TrackableType.Planes))
        {
            //표식 오브젝트 활성화
            eventPre.SetActive(true);
  
            //표식 오브젝트의 위치와 회전값 업데이트
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
        text2.text = "생성 유무: " + isGen.ToString();

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
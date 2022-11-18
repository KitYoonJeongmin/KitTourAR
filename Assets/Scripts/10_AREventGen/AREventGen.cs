using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using Firebase.Firestore;
using System.Threading.Tasks;
using System.Threading;


public class AREventGen : MonoBehaviour
{
    //오브젝트-유저 사이의 거리와 오브젝트 생성 여부를 알려주는 text
    public Text text1;
    public Text text2;
    public string place;
    public GameObject eventPre; //이벤트 프리팹 저장
    ARRaycastManager arRayMan; //ARRaycastManager 컴포넌트 저장
    private GameObject GPSManager;
    private Vector3 currentLocation;
    public bool isInPlace;
    public bool isGen;
    public int distance; //이벤트 프리팹을 활성화/비활성화 하기위한 거리
    [Serializable]
    public struct LatLong //위경도 저장 구조체
    {
        public string name;
        public float lat;
        public float lon;
    }
    [Header("위치 정보")]
    public LatLong[] latLongs; //위경도 저장 배열

    void Start()
    {
        distance = 7;
        latLongs = new LatLong[22];
        GetLatLonFromFB();
        GPSManager = GameObject.Find("GPS Manager");

        //인디케이터 비활성화
        eventPre.SetActive(false);
        isInPlace = false;
        //컴포넌트에서 ARRaycastManaget 획득
        arRayMan = GetComponent<ARRaycastManager>();
        InvokeRepeating("GetUNTCoord", 0.5f, 0.2f);
        InvokeRepeating("DetectPlace", 0.1f, 0.2f);
    }

    /** 근처에 이벤트를 생성할 곳이 있는지 확인*/
    void DetectPlace()
    {
        foreach (LatLong latLong in latLongs)
        {
            if (Vector3.Magnitude(currentLocation - GPSEncoder.GPSToUCS(latLong.lat, latLong.lon)) > distance)
            {
                isInPlace = false;
                continue;
            }
            
            isInPlace = true;
            place = latLong.name;
            return;
        }

    }

    /**이벤트 프리팹 생성*/
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
            isGen = true;
            //표식 오브젝트의 위치와 회전값 업데이트
            eventPre.transform.position = hitInfos[0].pose.position;
            eventPre.transform.rotation = hitInfos[0].pose.rotation;
        }
    }

    /**유저가 이벤트 프리팹과 멀어질 때 프리팹 비활성화*/
    void DestroyEventPre()
    {
        Debug.Log("Destroy");
        eventPre.SetActive(false);
        isGen = false;
    }

    /**이벤트 프리팹의 활성화, 비활성화를 감지*/
    void Update()
    {

        //text1.text = "x: "+ eventPre.transform.position.x.ToString() + ",y: " + eventPre.transform.position.y.ToString() + ",z: " + eventPre.transform.position.z.ToString();
        text1.text = "위치: " + isInPlace.ToString();
        text2.text = "생성 유무: " + isGen.ToString();
        if (!isInPlace) 
        {
            if (isGen)
            {
                DestroyEventPre();
            }
            return; 
        }
        if (!isGen)
        {
            DetectGround();
        }
        

    }
    /**현재위치를 unity coord로 변환한 것을 0.2초마다 가져옴*/
    void GetUNTCoord()
    {
        currentLocation = GPS.unityCoor;
    }

    /**firebase에서 latlong를 가져옴*/
    async void GetLatLonFromFB()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("smallEvent");  //smallEvent 컬렉션을 기리킴.
        QuerySnapshot snapshot= await playlistref.GetSnapshotAsync();  //data들을 가져오라고 서버에 요청
        
        int i = 0;
        foreach (DocumentSnapshot document in snapshot.Documents)   //각 문서들에 접근
        {
            latLongs[i].name = document.Id.ToString();
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //각 문서를 dictionary로 받음.
            GeoPoint geoPoint = (GeoPoint)documentDictionary["coordinate"];
            latLongs[i].lat = float.Parse(geoPoint.Latitude.ToString());
            latLongs[i].lon = float.Parse(geoPoint.Longitude.ToString());

            i++;
        }
    }
}
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
    //������Ʈ-���� ������ �Ÿ��� ������Ʈ ���� ���θ� �˷��ִ� text
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public string place;
    public GameObject eventPre; //�̺�Ʈ ������ ����
    ARRaycastManager arRayMan; //ARRaycastManager ������Ʈ ����
    private GameObject GPSManager;
    private Vector3 currentLocation;

    public bool isInPlace;
    public bool isGen;

    public int distance; //�̺�Ʈ �������� Ȱ��ȭ/��Ȱ��ȭ �ϱ����� �Ÿ�

    private bool isBigEvent = false;
    private bool isBigEventPlace;
    public GameObject bigEventPre;

    public string bigEventPlace;

    public struct LatLong //���浵 ���� ����ü
    {
        public string name;
        public float lat;
        public float lon;
    }
    [Header("��ġ ����")]
    public LatLong[] latLongs; //smallEvent ���浵 ���� �迭
    public LatLong[] bigEvtLatLongs;

    void Start()
    {
        distance = 10;
        latLongs = new LatLong[22];
        bigEvtLatLongs = new LatLong[4];
        GetLatLonFromFB();
        GetBigEventLatLonFromFB();
        GPSManager = GameObject.Find("GPS Manager");

        //�ε������� ��Ȱ��ȭ
        eventPre.SetActive(false);
        isInPlace = false;
        //������Ʈ���� ARRaycastManaget ȹ��
        arRayMan = GetComponent<ARRaycastManager>();
        InvokeRepeating("GetUNTCoord", 0.5f, 0.2f);
        InvokeRepeating("DetectPlace", 0.1f, 0.2f);
    }

    /** ��ó�� �̺�Ʈ�� ������ ���� �ִ��� Ȯ��*/
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
        foreach (LatLong latLong in bigEvtLatLongs)
        {
            if (Vector3.Magnitude(currentLocation - GPSEncoder.GPSToUCS(latLong.lat, latLong.lon)) > distance)
            {
                isBigEventPlace = false;
                continue;
            }

            isBigEventPlace = true;
            bigEventPlace = latLong.name;
            return;
        }

    }

    /**�̺�Ʈ ������ ����*/
    void DetectGround(int evtNum)   //0:small event, 1:big event
    {
        //����Ʈ�� ��ũ���� Center�� ã��
        Vector2 centerPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        //Ray�� �ε��� ������ ������ ������ ����Ʈ ����
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        //��ũ�� �߾��������� ���� Ray�� �߻� ���� ��, Plane Ÿ���� ��ü�� �����Ѵٸ�,
        if (arRayMan.Raycast(centerPoint, hitInfos, TrackableType.Planes))
        {
            if(evtNum == 0)
            {
                //ǥ�� ������Ʈ Ȱ��ȭ
                eventPre.SetActive(true);
                isGen = true;
                //ǥ�� ������Ʈ�� ��ġ�� ȸ���� ������Ʈ
                eventPre.transform.position = hitInfos[0].pose.position;
                eventPre.transform.rotation = hitInfos[0].pose.rotation;
                eventPre.transform.Rotate(new Vector3(0, -90, 0));
            }
            else if(evtNum == 1)
            {
                bigEventPre.SetActive(true);
                isBigEvent = true;
                bigEventPre.transform.position = hitInfos[0].pose.position;
                bigEventPre.transform.rotation = hitInfos[0].pose.rotation;
            }
            
        }
    }

    /**������ �̺�Ʈ �����հ� �־��� �� ������ ��Ȱ��ȭ*/
    void DestroyEventPre()
    {
        Debug.Log("Destroy");
        eventPre.SetActive(false);
        isGen = false;
    }

    /**�̺�Ʈ �������� Ȱ��ȭ, ��Ȱ��ȭ�� ����*/
    void Update()
    {
        if (text1 != null)
            text1.text = "위치: " + isInPlace.ToString();
        if (text2 != null)
            text2.text = "생성여부: " + isGen.ToString();
        if(text3 != null)
            text3.text = "big위치: " + isBigEventPlace.ToString();
        if(text4 != null)
            text4.text = "big생성여부: " + isBigEvent.ToString();
        //BigEventPlace = true -> isBigEvent = false-> BigEventPrefab ����
        if (isBigEventPlace)
        {
            if(isBigEvent == false)
            {
                DetectGround(1);
                //���̺�Ʈ ������ ����
            }
        }
        else 
        { 
            if(isBigEvent)
            {
                bigEventPre.SetActive(false);
                isBigEvent = false;
            }
        }
        //BigEventPlace = false -> isBigEvent = true -> BigEventPrefab ����
        if (!isInPlace) 
        {
            if (isBigEvent == false)
            {
                DetectGround(1);
                //���̺�Ʈ ������ ����
            }
        }
        else
        {
            if (isBigEvent)
            {
                bigEventPre.SetActive(false);
                isBigEvent = false;
            }
        }
        //BigEventPlace = false -> isBigEvent = true -> BigEventPrefab ����
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
            DetectGround(0);
        }


    }
    /**������ġ�� unity coord�� ��ȯ�� ���� 0.2�ʸ��� ������*/
    void GetUNTCoord()
    {
        currentLocation = GPS.unityCoor;
    }

    /**firebase���� latlong�� ������*/
    async void GetLatLonFromFB()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("smallEvent");  //smallEvent �÷����� �⸮Ŵ.
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û

        int i = 0;
        foreach (DocumentSnapshot document in snapshot.Documents)   //�� �����鿡 ����
        {
            latLongs[i].name = document.Id.ToString();
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //�� ������ dictionary�� ����.
            GeoPoint geoPoint = (GeoPoint)documentDictionary["coordinate"];
            latLongs[i].lat = float.Parse(geoPoint.Latitude.ToString());
            latLongs[i].lon = float.Parse(geoPoint.Longitude.ToString());

            i++;
        }
    }
    async void GetBigEventLatLonFromFB()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("bigEvent");  //smallEvent �÷����� �⸮Ŵ.
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û

        int i = 0;
        foreach (DocumentSnapshot document in snapshot.Documents)   //�� �����鿡 ����
        {
            bigEvtLatLongs[i].name = document.Id.ToString();
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //�� ������ dictionary�� ����.
            if(documentDictionary.ContainsKey("coordinate"))
            {
                GeoPoint geoPoint = (GeoPoint)documentDictionary["coordinate"];
                bigEvtLatLongs[i].lat = float.Parse(geoPoint.Latitude.ToString());
                bigEvtLatLongs[i].lon = float.Parse(geoPoint.Longitude.ToString());
                i++;
            }
            

            
        }
    }
}
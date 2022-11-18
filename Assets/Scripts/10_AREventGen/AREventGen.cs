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
    public string place;
    public GameObject eventPre; //�̺�Ʈ ������ ����
    ARRaycastManager arRayMan; //ARRaycastManager ������Ʈ ����
    private GameObject GPSManager;
    private Vector3 currentLocation;
    public bool isInPlace;
    public bool isGen;
    public int distance; //�̺�Ʈ �������� Ȱ��ȭ/��Ȱ��ȭ �ϱ����� �Ÿ�
    [Serializable]
    public struct LatLong //���浵 ���� ����ü
    {
        public string name;
        public float lat;
        public float lon;
    }
    [Header("��ġ ����")]
    public LatLong[] latLongs; //���浵 ���� �迭

    void Start()
    {
        distance = 7;
        latLongs = new LatLong[22];
        GetLatLonFromFB();
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

    }

    /**�̺�Ʈ ������ ����*/
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
            isGen = true;
            //ǥ�� ������Ʈ�� ��ġ�� ȸ���� ������Ʈ
            eventPre.transform.position = hitInfos[0].pose.position;
            eventPre.transform.rotation = hitInfos[0].pose.rotation;
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

        //text1.text = "x: "+ eventPre.transform.position.x.ToString() + ",y: " + eventPre.transform.position.y.ToString() + ",z: " + eventPre.transform.position.z.ToString();
        text1.text = "��ġ: " + isInPlace.ToString();
        text2.text = "���� ����: " + isGen.ToString();
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
        QuerySnapshot snapshot= await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û
        
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
}
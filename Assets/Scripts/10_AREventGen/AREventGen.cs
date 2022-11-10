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

    public GameObject eventPre; //�̺�Ʈ ������ ����
    ARRaycastManager arRayMan; //ARRaycastManager ������Ʈ ����
    private GameObject GPSManager;
    private Vector3 currentLocation;
    public bool isGen;
    static public int distance = 20; //�̺�Ʈ �������� Ȱ��ȭ/��Ȱ��ȭ �ϱ����� �Ÿ�
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
        latLongs = new LatLong[30];
        GetLatLonFromFB();
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

    /** ��ó�� �̺�Ʈ�� ������ ���� �ִ��� Ȯ��*/
    void DetectPlace()
    {
        foreach(LatLong latLong in latLongs)
        {
            if(Vector3.Magnitude(currentLocation
                - GPSEncoder.GPSToUCS(latLong.lat, latLong.lon))> distance)
            {
                return;
            }
            DetectGround(latLong);
        }
        
    }

    /**�̺�Ʈ ������ ����*/
    void DetectGround(LatLong latLong)
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
            text1.text = latLong.name;
        }
    }

    /**������ �̺�Ʈ �����հ� �־��� �� ������ ��Ȱ��ȭ*/
    void DestroyEventPre()
    {

        if (distance < Vector3.Magnitude(eventPre.transform.position - currentLocation))
        {
            eventPre.SetActive(false);
            isGen = false;
        }
    }

    /**�̺�Ʈ �������� Ȱ��ȭ, ��Ȱ��ȭ�� ����*/
    void Update()
    {
        
        //text1.text = "x: "+ eventPre.transform.position.x.ToString() + ",y: " + eventPre.transform.position.y.ToString() + ",z: " + eventPre.transform.position.z.ToString();
        text2.text = "���� ����: " + isGen.ToString();

        if (!isGen)
        {
            DetectPlace();
        }
        else
        {
            DestroyEventPre();
        }

    }
    /**������ġ�� unity coord�� ��ȯ�� ���� 0.2�ʸ��� ������*/
    void GetUNTCoord()
    {
        currentLocation = GPSManager.GetComponent<GPS>().unityCoor;
    }

    /**firebase���� latlong�� ������**/
    async void GetLatLonFromFB()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("smallEvent");  //smallEvent �÷����� �⸮Ŵ.
        QuerySnapshot snapshot= await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û
        
        int i = 0;
        foreach (DocumentSnapshot document in snapshot.Documents)   //�� �����鿡 ����
        {
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //�� ������ dictionary�� ����.
            latLongs[i].name = documentDictionary["name"].ToString();
            GeoPoint geoPoint = (GeoPoint)documentDictionary["coordinate"];
            latLongs[i].lat = float.Parse(geoPoint.Latitude.ToString());
            latLongs[i].lon = float.Parse(geoPoint.Longitude.ToString());

            i++;
        }
    }
}
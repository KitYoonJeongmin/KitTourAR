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

public class ReportARGen : MonoBehaviour
{
    //������Ʈ-���� ������ �Ÿ��� ������Ʈ ���� ���θ� �˷��ִ� text

    public string place;
    ARRaycastManager arRayMan; //ARRaycastManager ������Ʈ ����
    private GameObject GPSManager;
    private Vector3 currentLocation;
    public bool isInPlace;
    public bool isGen;
    public int distance; //�̺�Ʈ �������� Ȱ��ȭ/��Ȱ��ȭ �ϱ����� �Ÿ�

    public GameObject reportPre;
    [Serializable]
    public struct LatLong //���浵 ���� ����ü
    {
        public string name;
        public float lat;
        public float lon;
        public bool isDestroy;
    }

    [Header("��ġ ����")]
    public LatLong[] latLongs; //���浵 ���� �迭

    // Start is called before the first frame update
    void Start()
    {
        latLongs = new LatLong[12];
        GetLatLonFromFB();

        GPSManager = GameObject.Find("GPS Manager");

        //�ε������� ��Ȱ��ȭ
        reportPre.SetActive(false);
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
            if(latLong.isDestroy == false)
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
    }

    public void ReportDestroy(string repoPlace)
    {
        for(int i = 0; i<latLongs.Length; i++)
        {
            if (latLongs[i].name == repoPlace)
                latLongs[i].isDestroy = true;
        }
    }

    /**�̺�Ʈ ������ ����*/
    void DetectGround()
    {
        //����Ʈ�� ��ũ���� Center�� ã��
        Vector2 centerPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        //Ray�� �ε��� ������ ������ ������ ����Ʈ ����
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();
        foreach(var latLong in latLongs)
        {
            if(latLong.isDestroy == false)
            {
                //��ũ�� �߾��������� ���� Ray�� �߻� ���� ��, Plane Ÿ���� ��ü�� �����Ѵٸ�,
                if (arRayMan.Raycast(centerPoint, hitInfos, TrackableType.Planes))
                {
                    //ǥ�� ������Ʈ Ȱ��ȭ
                    reportPre.SetActive(true);
                    isGen = true;
                    //ǥ�� ������Ʈ�� ��ġ�� ȸ���� ������Ʈ
                    reportPre.transform.position = hitInfos[0].pose.position;
                    reportPre.transform.rotation = hitInfos[0].pose.rotation;
                }
            }
        }
    }

    /**������ �̺�Ʈ �����հ� �־��� �� ������ ��Ȱ��ȭ*/
    void DestroyEventPre()
    {
        Debug.Log("Destroy");
        reportPre.SetActive(false);
        isGen = false;
    }

    /**�̺�Ʈ �������� Ȱ��ȭ, ��Ȱ��ȭ�� ����*/
    void Update()
    {

        //text1.text = "x: "+ eventPre.transform.position.x.ToString() + ",y: " + eventPre.transform.position.y.ToString() + ",z: " + eventPre.transform.position.z.ToString();
        if (!isInPlace)
        {
            if (isGen)
            {
                DestroyEventPre();
            }
            return;
        }
        if (!isGen )
        {
            DetectGround();
        }
    }
    /**������ġ�� unity coord�� ��ȯ�� ���� 0.2�ʸ��� ������*/
    void GetUNTCoord()
    {
        currentLocation = GPS.unityCoor;
    }

    async void GetLatLonFromFB()
    {

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("reports");
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û

        int i = 0;

        foreach (DocumentSnapshot document in snapshot.Documents)   //�� �����鿡 ����
        {
            latLongs[i].name = document.Id.ToString();
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //�� ������ dictionary�� ����.
            GeoPoint geoPoint = (GeoPoint)documentDictionary["coordinate"];
            latLongs[i].lat = float.Parse(geoPoint.Latitude.ToString());
            latLongs[i].lon = float.Parse(geoPoint.Longitude.ToString());
            latLongs[i].isDestroy = false;

            i++;
        }
    }
    
}


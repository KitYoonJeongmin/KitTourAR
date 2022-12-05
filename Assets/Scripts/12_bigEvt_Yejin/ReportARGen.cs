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
    public Text isRef;
    public string place;
    public GameObject reportPre;
    private GameObject GPSManager;
    private Vector3 currentLocation;

    public bool findReport;
    public bool isGen = false;

    public int distance;
    ARRaycastManager arRayMan;

    public struct LatLong
    {
        public string name;
        public float lat;
        public float lon;
        public bool isDestroyed;
    }

    [Header("��ġ ����")]
    public LatLong[] reportLatLongs;

    void Start()
    {
        if(ReportMapManager.reportEvt == 9)
        {
            distance = 15;
            reportLatLongs = new LatLong[12];
            GetReportsLatLonFromFB();
            GPSManager = GameObject.Find("GPS Manager");

            reportPre.SetActive(false);
            findReport = false;
            arRayMan = GetComponent<ARRaycastManager>();
            InvokeRepeating("GetUNTCoord", 0.5f, 0.2f);
            InvokeRepeating("DetectPlace", 0.1f, 0.2f);
        }
    }

    void DetectPlace()
    {
        foreach (LatLong latLong in reportLatLongs)
        {
            if (Vector3.Magnitude(currentLocation - GPSEncoder.GPSToUCS(latLong.lat, latLong.lon)) > distance)
            {
                findReport = false;
                continue;
            }

            findReport = true;
            place = latLong.name;
            return;
        }
    }

    void DetectGround()
    {
        //����Ʈ�� ��ũ���� Center�� ã��
        Vector2 centerPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        //Ray�� �ε��� ������ ������ ������ ����Ʈ ����
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();
        foreach (var latLong in reportLatLongs)
        {
            if (latLong.isDestroyed == false)
            {
                //��ũ�� �߾��������� ���� Ray�� �߻� ���� ��, Plane Ÿ���� ��ü�� �����Ѵٸ�,
                if (arRayMan.Raycast(centerPoint, hitInfos, TrackableType.Planes))
                {
                    isGen = true;
                    //ǥ�� ������Ʈ Ȱ��ȭ
                    reportPre.SetActive(true);
                    //ǥ�� ������Ʈ�� ��ġ�� ȸ���� ������Ʈ
                    reportPre.transform.position = hitInfos[0].pose.position;
                    reportPre.transform.rotation = hitInfos[0].pose.rotation;
                }
            }
        }
    }

    void DestroyEventPre()
    {
        Debug.Log("Destroy");
        reportPre.SetActive(false);
        isGen = false;
    }

    void Update()
    {
        if(ReportMapManager.reportEvt == 9)
        {
            if (isRef != null)
                isRef.text = "ref����: " + isGen.ToString();

            if (!findReport)
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
    }

    void GetUNTCoord()
    {
        currentLocation = GPS.unityCoor;
    }
    public void ReportDestroy(string repoPlace)
    {
        reportPre.SetActive(false);

        for (int i = 0; i < reportLatLongs.Length; i++)
        {
            if (reportLatLongs[i].name == repoPlace)
            {
                reportLatLongs[i].isDestroyed = true;
            }
        }
    }

    async void GetReportsLatLonFromFB()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("reports");
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();

        int i = 0;
        foreach (DocumentSnapshot document in snapshot.Documents)
        {
            reportLatLongs[i].name = document.Id.ToString();
            Debug.Log(reportLatLongs[i].name + " is ready");
            Dictionary<string, object> documentDictionary = document.ToDictionary();
            GeoPoint geoPoint = (GeoPoint)documentDictionary["coordinate"];
            reportLatLongs[i].lat = float.Parse(geoPoint.Latitude.ToString());
            reportLatLongs[i].lon = float.Parse(geoPoint.Longitude.ToString());

            reportLatLongs[i].isDestroyed = false;
            Debug.Log("hi");
            i++;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class ReportMapGen : MonoBehaviour
{
    public GameObject report;
    static public Dictionary<string, GameObject> reportIns = new Dictionary<string, GameObject>();
    private static GameObject gameObj;
    string place;

    private void Awake()
    {
        var obj = FindObjectsOfType<ReportMapGen>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Debug.Log(reportIns.Count);
        if (ReportMapManager.reportEvt == 9)
        {
            foreach(KeyValuePair<string, GameObject> rl in reportIns)
            {
                rl.Value.SetActive(true);
            }
        }
            
    }
    public async void ReportsEventStart()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("reports");  //smallEvent �÷����� �⸮Ŵ.
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û

        foreach (DocumentSnapshot document in snapshot.Documents)   //�� �����鿡 ����
        {
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //�� ������ dictionary�� ����.

            place = document.Id;
            Vector3 coor;   //unity ��ǥ�� ����

            //Dictionary<string, object> statistics = new Dictionary<string, object> { };
            GeoPoint geo = (GeoPoint)documentDictionary["coordinate"];
            coor = GPSEncoder.GPSToUCS(float.Parse(geo.Latitude.ToString()), float.Parse(geo.Longitude.ToString()));

            coor.y = 7;
            GenReportSpot(coor);            
        }
    }

    private void Update()
    {
        if (ReportMapManager.reportEvt == 10)
        {
            gameObject.SetActive(false);
            return;
        }
    }


    //firebase���� ������ unityCoord��ġ�� �̺�Ʈ ������ �����ϴ� �Լ�
    public void GenReportSpot(Vector3 coordinate)
    {
        reportIns.Add(place, Instantiate(report, coordinate, report.transform.rotation));

        foreach (KeyValuePair<string, GameObject> rl in reportIns)
        {
            rl.Value.SetActive(true);
            DontDestroyOnLoad(rl.Value);
        }
    }
}

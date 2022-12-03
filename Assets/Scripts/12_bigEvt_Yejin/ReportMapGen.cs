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
        CollectionReference playlistref = db.Collection("reports");  //smallEvent 컬렉션을 기리킴.
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data들을 가져오라고 서버에 요청

        foreach (DocumentSnapshot document in snapshot.Documents)   //각 문서들에 접근
        {
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //각 문서를 dictionary로 받음.

            place = document.Id;
            Vector3 coor;   //unity 좌표를 저장

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


    //firebase에서 가져온 unityCoord위치에 이벤트 프리팹 생성하는 함수
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

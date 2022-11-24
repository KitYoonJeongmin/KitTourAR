using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;


// 이 스크립트 안 쓸지도
public class FindReports : MonoBehaviour
{
    [Serializable]
    public struct LatLong //위경도 저장 구조체
    {
        public string name;
        public float lat;
        public float lon;
    }
    [Header("위치 정보")]
    public LatLong[] latLongs; //위경도 저장 배열

    // Start is called before the first frame update
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference document = db.Collection("smallEvent").Document("findReports");  //smallEvent 컬렉션을 기리킴.
        DocumentSnapshot snapshot = await document.GetSnapshotAsync();  //data들을 가져오라고 서버에 요청

        Dictionary<string, object> docDictionary = snapshot.ToDictionary();    //각 문서를 dictionary로 받음.
        int num = (int)docDictionary["num"];

        for(int i = 0; i<num; i++)
        {
            Dictionary<int, object> geoDic = (Dictionary<int, object>)docDictionary["coordinate"];
            GeoPoint geoPoint = (GeoPoint)geoDic[i];
            latLongs[i].lat = float.Parse(geoPoint.Latitude.ToString());
            latLongs[i].lon = float.Parse(geoPoint.Longitude.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;


// �� ��ũ��Ʈ �� ������
public class FindReports : MonoBehaviour
{
    [Serializable]
    public struct LatLong //���浵 ���� ����ü
    {
        public string name;
        public float lat;
        public float lon;
    }
    [Header("��ġ ����")]
    public LatLong[] latLongs; //���浵 ���� �迭

    // Start is called before the first frame update
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference document = db.Collection("smallEvent").Document("findReports");  //smallEvent �÷����� �⸮Ŵ.
        DocumentSnapshot snapshot = await document.GetSnapshotAsync();  //data���� ��������� ������ ��û

        Dictionary<string, object> docDictionary = snapshot.ToDictionary();    //�� ������ dictionary�� ����.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class EventPrefab : MonoBehaviour
{
    public GameObject building;
    
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("smallEvent");  //smallEvent �÷����� �⸮Ŵ.
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û

        foreach (DocumentSnapshot document in snapshot.Documents)   //�� �����鿡 ����
        {
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //�� ������ dictionary�� ����.
            
            
            Vector3 coor;   //unity ��ǥ�� ����

            Dictionary<string, object> statistics = new Dictionary<string, object> { };
            GeoPoint geo = (GeoPoint)documentDictionary["coordinate"];
            coor = GPSEncoder.GPSToUCS(float.Parse(geo.Latitude.ToString()), float.Parse(geo.Longitude.ToString()));   
            

            newBuilding(coor);
            
        }
    }


    //firebase���� ������ unityCoord��ġ�� �̺�Ʈ ������ �����ϴ� �Լ�
    public void newBuilding(Vector3 coordinate)
    {
        Instantiate(building, coordinate, Quaternion.identity);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class BigEvtPrefab : MonoBehaviour
{
    public GameObject evtPref;

    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference playlistref = db.Collection("bigEvent");  //smallEvent �÷����� �⸮Ŵ.
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data���� ��������� ������ ��û

        foreach (DocumentSnapshot document in snapshot.Documents)   //�� �����鿡 ����
        {
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //�� ������ dictionary�� ����.
                                                                                        //Debug.Log("Name:  " + documentDictionary["name"] as string);

            Vector3 coor;   //unity ��ǥ�� ����

            Dictionary<string, object> statistics = new Dictionary<string, object> { };
            statistics = (Dictionary<string, object>)documentDictionary["unityCoord"];

            coor.x = float.Parse((statistics["x"]).ToString());
            coor.y = float.Parse((statistics["y"]).ToString()) + 2.0f;
            coor.z = float.Parse((statistics["z"]).ToString());
            //string,Parse(statistics[item].ToString()

            Debug.Log((statistics["x"]).ToString() + (statistics["y"]).ToString() + (statistics["z"]).ToString());

            newBuilding(coor);

        }
    }


    //firebase���� ������ unityCoord��ġ�� �̺�Ʈ ������ �����ϴ� �Լ�
    public void newBuilding(Vector3 coordinate)
    {
        Instantiate(evtPref, coordinate, Quaternion.identity);
    }

}
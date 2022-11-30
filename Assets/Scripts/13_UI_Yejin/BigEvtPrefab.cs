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
        CollectionReference playlistref = db.Collection("bigEvent");  //smallEvent 컬렉션을 기리킴.
        QuerySnapshot snapshot = await playlistref.GetSnapshotAsync();  //data들을 가져오라고 서버에 요청

        foreach (DocumentSnapshot document in snapshot.Documents)   //각 문서들에 접근
        {
            Dictionary<string, object> documentDictionary = document.ToDictionary();    //각 문서를 dictionary로 받음.
                                                                                        //Debug.Log("Name:  " + documentDictionary["name"] as string);

            Vector3 coor;   //unity 좌표를 저장

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


    //firebase에서 가져온 unityCoord위치에 이벤트 프리팹 생성하는 함수
    public void newBuilding(Vector3 coordinate)
    {
        Instantiate(evtPref, coordinate, Quaternion.identity);
    }

}
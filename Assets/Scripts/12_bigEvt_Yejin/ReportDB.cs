using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using System.Linq;

public class ReportDB : MonoBehaviour
{
    Dictionary<string, string[]> textData;  //smallEvent에 직접적으로 사용될 text 딕셔너리입니다.
    List<object> objList;

    public class DBTextManager : MonoBehaviour
    {
        Dictionary<string, string[]> textData;
        List<object> objList;

        void Awake()
        {
            textData = new Dictionary<string, string[]>();
            InputDocInfo();
        }

        async void InputDocInfo()
        {
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
            CollectionReference collRef = db.Collection("reports");
            QuerySnapshot snapshot = await collRef.GetSnapshotAsync();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                //str에 넣어줄 list(array가 리스트 형태임) => strList.ToArray()로 변환해 textData에 넣어줄 것
                objList = new List<object>();

                //여기에 문서 필드 들어가있음=>text string 형식으로 빼내어 textData value로 넣어주어야 함
                Dictionary<string, object> documentDictionary = document.ToDictionary();
                //Debug.Log(documentDictionary["name"].ToString() + "\n");

                try
                {
                    objList = (List<object>)documentDictionary["text"];
                }
                catch { }

                //List<object> => List<string> 변환
                List<string> strList = objList.Select(s => (string)s).ToList();

                //foreach (var i in strList)    Debug.Log(i);   //strList 데이터 출력(확인용)

                textData.Add(document.Id, strList.ToArray());
            }
        }
    }
    public string GetText(string documentId, int textAryIndex)
    {
        //return textData[documentId][0];
        if (textAryIndex == textData[documentId].Length)
            return null;
        else
            return textData[documentId][textAryIndex];
        // 파이어스토어 배열으로 지정해준 인덱스 단위로 문자열을 반환합니다.
    }

    public int textNum(string documentId)
    {
        return textData[documentId].Length;
    }
}

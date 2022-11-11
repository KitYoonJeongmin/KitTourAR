using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;

public class DBTextManager : MonoBehaviour
{
    Dictionary<string, string[]> textData;  //smallEvent에 직접적으로 사용될 text 딕셔너리입니다.
    List<object> objList;

    void Awake()
    {
        textData = new Dictionary<string, string[]>();
        InputDocInfo();
    }

    async void InputDocInfo()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        CollectionReference collRef = db.Collection("smallEvent");
        QuerySnapshot snapshot = await collRef.GetSnapshotAsync();

        CollectionReference subCollRef = null;
        bool subref = false;

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
            catch
            {
                // [Debug.Log("List<object>으로 변환 불가]\n
                // 필드에 text가 없는 경우 뜹니다!\n
                // button 컬렉션 text가 들어있으면 무시해주세용\n");
            }

            //List<object> => List<string> 변환
            List<string> strList = objList.Select(s => (string)s).ToList();

            //foreach (var i in strList)    Debug.Log(i);   //strList 데이터 출력(확인용)

            textData.Add(document.Id, strList.ToArray());

            try
            {
                subCollRef = collRef.Document(document.Id).Collection("button");
                subref = true;
            }
            catch {}

            if (subref)
            {
                InputSubDocInfo(subCollRef);     // button 하위콜렉션 문서 데이터 삽입
                subref = false;
            }
        }
        /*
        foreach (KeyValuePair<string, string[]> entry in textData)
        {
            Debug.Log(entry.Key + " " + entry.Value);
        }
        */
    }

    async void InputSubDocInfo(CollectionReference subCollRef)
    {
        QuerySnapshot snapshot = await subCollRef.GetSnapshotAsync();
        CollectionReference subsubCollRef = null;
        bool subref = false;

        foreach (DocumentSnapshot document in snapshot.Documents)
        {
            objList = new List<object>();

            Dictionary<string, object> documentDictionary = document.ToDictionary();
            //Debug.Log(documentDictionary["name"].ToString() + "\n");

            try     { objList = (List<object>)documentDictionary["text"]; }
            catch   {}

            List<string> strList = objList.Select(s => (string)s).ToList();
            //foreach (var i in strList)    Debug.Log(i);   //strList 데이터 출력(확인용)

            textData.Add(document.Id, strList.ToArray());

            //foreach (var i in strList) Debug.Log(i);   //strList 데이터 출력(확인용)
            try
            {
                subsubCollRef = subCollRef.Document(document.Id).Collection("button");
                subref = true;
            }
            catch { }

            if (subref)
            {
                InputSubDocInfo(subsubCollRef);
                subref = false;
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

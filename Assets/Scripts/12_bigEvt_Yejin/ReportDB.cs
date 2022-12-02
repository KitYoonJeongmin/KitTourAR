using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;

public class ReportDB : MonoBehaviour
{
    Dictionary<string, string[]> textData;  //smallEvent�� ���������� ���� text ��ųʸ��Դϴ�.
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
            //str�� �־��� list(array�� ����Ʈ ������) => strList.ToArray()�� ��ȯ�� textData�� �־��� ��
            objList = new List<object>();

            //���⿡ ���� �ʵ� ������=>text string �������� ������ textData value�� �־��־�� ��
            Dictionary<string, object> documentDictionary = document.ToDictionary();

            try
            {
                objList = (List<object>)documentDictionary["text"];
            }
            catch { }

            //List<object> => List<string> ��ȯ
            List<string> strList = objList.Select(s => (string)s).ToList();

            foreach (var i in strList)    Debug.Log(i);   //strList ������ ���(Ȯ�ο�)

            textData.Add(document.Id, strList.ToArray());
        }
    }
    
    public string GetText(string documentId, int textAryIndex)
    {
        //return textData[documentId][0];
        if (textAryIndex == textData[documentId].Length)
            return null;
        else
            return textData[documentId][textAryIndex];
        // ���̾��� �迭���� �������� �ε��� ������ ���ڿ��� ��ȯ�մϴ�.
    }

    public int textNum(string documentId)
    {
        return textData[documentId].Length;
    }
}

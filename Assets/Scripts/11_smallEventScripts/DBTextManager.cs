using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;

public class DBTextManager : MonoBehaviour
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
        CollectionReference collRef = db.Collection("smallEvent");
        QuerySnapshot snapshot = await collRef.GetSnapshotAsync();

        CollectionReference subCollRef = null;
        bool subref = false;

        foreach (DocumentSnapshot document in snapshot.Documents)
        {
            //str�� �־��� list(array�� ����Ʈ ������) => strList.ToArray()�� ��ȯ�� textData�� �־��� ��
            objList = new List<object>();    
            
            //���⿡ ���� �ʵ� ������=>text string �������� ������ textData value�� �־��־�� ��
            Dictionary<string, object> documentDictionary = document.ToDictionary();
            //Debug.Log(documentDictionary["name"].ToString() + "\n");

            try
            {
                objList = (List<object>)documentDictionary["text"];
            }
            catch
            {
                // [Debug.Log("List<object>���� ��ȯ �Ұ�]\n
                // �ʵ忡 text�� ���� ��� ��ϴ�!\n
                // button �÷��� text�� ��������� �������ּ���\n");
            }

            //List<object> => List<string> ��ȯ
            List<string> strList = objList.Select(s => (string)s).ToList();

            //foreach (var i in strList)    Debug.Log(i);   //strList ������ ���(Ȯ�ο�)

            textData.Add(document.Id, strList.ToArray());

            try
            {
                subCollRef = collRef.Document(document.Id).Collection("button");
                subref = true;
            }
            catch {}

            if (subref)
            {
                InputSubDocInfo(subCollRef);     // button �����ݷ��� ���� ������ ����
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
            //foreach (var i in strList)    Debug.Log(i);   //strList ������ ���(Ȯ�ο�)

            textData.Add(document.Id, strList.ToArray());

            //foreach (var i in strList) Debug.Log(i);   //strList ������ ���(Ȯ�ο�)
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
        // ���̾��� �迭���� �������� �ε��� ������ ���ڿ��� ��ȯ�մϴ�.
    }

    public int textNum(string documentId)
    {
        return textData[documentId].Length;
    }
}

using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class SmallEventManager : MonoBehaviour
{
    public DBTextManager textManager;
    public GameObject textUi;        //ȭ�鿡 ��µ� canvas(UI)
    public Text eventText;           //text event(canvas ���� text(Legacy) ����)

    public GameObject scanPlace;     //��� ����� �̺�Ʈ�� ������� ����
    public bool isView;              //�̺�Ʈ�� ��� ������ ���� Ȯ��
    public int textAryIndex;

    public void View(GameObject place)
    {

        if(isView)
        {
            isView = false;
        }
        else
        {
            isView = true;

            scanPlace = place;
            PlaceInfo placeInfo = scanPlace.GetComponent<PlaceInfo>();
            Debug.Log(placeInfo.documentId);
            TextView(placeInfo.documentId);
        }
        textUi.SetActive(isView);
    }

    void TextView(string documentId)
    {
        int textLen = textManager.textNum(documentId);
        string eventData = textManager.GetText(documentId, textAryIndex);
        
        if (textAryIndex == textLen)
        {
            isView = false;
            textAryIndex = 0;
            return;
        }

        eventText.text = eventData;
        isView = true;

        textAryIndex++;
    }
}

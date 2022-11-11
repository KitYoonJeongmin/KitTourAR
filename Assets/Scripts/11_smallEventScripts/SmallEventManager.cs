using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class SmallEventManager : MonoBehaviour
{
    public DBTextManager textManager;
    public GameObject textUi;        //화면에 출력될 canvas(UI)
    public Text eventText;           //text event(canvas 내부 text(Legacy) 연결)

    public GameObject scanPlace;     //어느 장소의 이벤트를 출력할지 지정
    public bool isView;              //이벤트가 출력 중인지 여부 확인
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

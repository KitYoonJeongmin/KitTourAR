using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class SmallEventManager : MonoBehaviour
{
    public DBTextManager textManager;
    public GameObject btnUi;
    public GameObject textUi;        //화면에 출력될 canvas(UI)
    public Text eventText;           //text event(canvas 내부 text(Legacy) 연결)

    public GameObject scanPlace;     //어느 장소의 이벤트를 출력할지 지정
    public bool isView;              //이벤트가 출력 중인지 여부 확인
    public int textAryIndex;
    private bool isBtnView;
    public int btnIndex;

    public void View(GameObject place)
    {
        isView = true;

        scanPlace = place;
        PlaceInfo placeInfo = scanPlace.GetComponent<PlaceInfo>();
        Debug.Log(placeInfo.documentId);
        TextView(placeInfo.documentId);
        if (!gameObject.name.Contains("Btn"))
        {
            Btn(placeInfo.documentId);
        }

        textUi.SetActive(isView);
        
    }

    public void TextView(string documentId) //함수 다른 스크립트에서 사용하려고 public으로 바꿔줬습니다.
    {
        Debug.Log(documentId);
        int textLen = textManager.textNum(documentId);
        string eventData = textManager.GetText(documentId, textAryIndex);
        //Debug.Log(textAryIndex.ToString());
        //Debug.Log(eventData);

        if (textAryIndex == textLen)
        {
            
            if (!gameObject.name.Contains("Btn"))
            {
                isBtnView = false;
                btnUi.SetActive(isBtnView);
            }
            else if(gameObject.name.Contains("Btn"))
            {
                Debug.Log("------------btn remake----------");
                isBtnView = true;
                btnUi.SetActive(isBtnView);
            }
            isView = false;
            textAryIndex = 0;
            textUi.SetActive(isView); //text 더이상 볼거 없으면 UI바로 비활성화 시켜줬습니다.
            return;
        }

        eventText.text = eventData;
        
        eventText.text = eventText.text.Replace("\\n", "\n");   // 줄바꿈 수정
        isView = true;

        textAryIndex++;
    }
    public void Btn(string documentId)
    {
        Debug.Log(documentId);
        if (documentId.Contains("stuentHall_underground")) { btnIndex = 0; isBtnView = true; }
        else if (documentId.Contains("stuentHall_ground")) { btnIndex = 1; isBtnView = true; }
        else if (documentId.Contains("busStop")) { btnIndex = 3; isBtnView = true; }
        else if (documentId.Contains("digitalBuilding")) { btnIndex = 4; isBtnView = true; }
        else if (documentId.Contains("domitory")) { btnIndex = 5; isBtnView = true; }
        else if (documentId.Contains("internationalEducation")) { btnIndex = 6; isBtnView = true; }
        else if (documentId.Contains("library")) { btnIndex = 7; isBtnView = true; }
        btnUi.SetActive(isBtnView);
    }
}

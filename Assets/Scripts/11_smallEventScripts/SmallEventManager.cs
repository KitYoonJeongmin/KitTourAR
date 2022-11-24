using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class SmallEventManager : MonoBehaviour
{
    public DBTextManager textManager;
    public ReportDB reportDB;

    public GameObject btnUi;
    public GameObject textUi;        //화면에 출력될 canvas(UI)
    public Text eventText;           //text event(canvas 내부 text(Legacy) 연결)
    public GameObject imageUi;       //image event (canvas 내부 image 연결)

    public GameObject scanPlace;     //어느 장소의 이벤트를 출력할지 지정
    public bool isView;              //text이벤트가 출력 중인지 여부 확인
    public int textAryIndex;
    private bool isBtnView;
    public int btnIndex;

    public Sprite[] imgArray;       //이미지 넣고 start()에서 imgDetectWord("[키워드]",imgArray의index);작성해주세요.
    private Dictionary<string,int> imgDetectWord = new Dictionary<string, int>(); //이미지 출력할 단어(trigger)

    void Start()
    {
        imgDetectWord.Add("휴먼",0);
        imgDetectWord.Add("너굴맨",1);
    }
    public void View(GameObject place)
    {
        isView = true;

        scanPlace = place;
        PlaceInfo placeInfo = scanPlace.GetComponent<PlaceInfo>();


        if (placeInfo.documentId.FirstOrDefault() == 'r')
            ReportEventView(placeInfo.documentId);
        else
        {
            Debug.Log(placeInfo.documentId);
            TextView(placeInfo.documentId);
        }
        if (!gameObject.name.Contains("Btn") && isBtnView == false)
        {
            Btn(placeInfo.documentId);
        }

        textUi.SetActive(isView);
        
    }

    public void TextView(string documentId) //함수 다른 스크립트에서 사용하려고 public으로 바꿔줬습니다.
    {
        int textLen = textManager.textNum(documentId);
        string eventData = textManager.GetText(documentId, textAryIndex);

        if (textAryIndex == textLen)
        {
            
            if(gameObject.name.Contains("Btn"))
            {
                isBtnView = true;
                btnUi.SetActive(isBtnView);
            }
            isView = false;
            textAryIndex = 0;
            textUi.SetActive(isView); //text 더이상 볼거 없으면 UI바로 비활성화 시켜줬습니다.
            return;
        }
        foreach (KeyValuePair<string, int> word in imgDetectWord) // text에 img를 출력할 단어가 있는지 검사
        {
            if (eventData.Contains(word.Key)) //text에 img를 출력할 단어가 있다면
            {
                ImageView(word.Key); // 해당 단어에 적합한 이미지 출력
                break;
                //isImage = true; //이미지 출력중
            }
            imageUi.SetActive(false); //이미지 항상 비활성화

        }

        eventText.text = eventData;
        eventText.text = eventText.text.Replace("\\n", "\n"); // 줄바꿈 수정

        isView = true;

        textAryIndex++;
    }
    void ImageView(string imageWord)
    {
        imgDetectWord.TryGetValue(imageWord, out int imageNum);
        imageUi.GetComponent<Image>().sprite = imgArray[imageNum];
        imageUi.SetActive(true);
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

    public void ReportEventView(string documentId)
    {
        int textLen = reportDB.textNum(documentId);
        string eventData = reportDB.GetText(documentId, textAryIndex);

        if (textAryIndex == textLen)
        {

            if (gameObject.name.Contains("Btn"))
            {
                isBtnView = true;
                btnUi.SetActive(isBtnView);
            }
            isView = false;
            textAryIndex = 0;
            textUi.SetActive(isView); //text 더이상 볼거 없으면 UI바로 비활성화 시켜줬습니다.
            return;
        }
        foreach (KeyValuePair<string, int> word in imgDetectWord) // text에 img를 출력할 단어가 있는지 검사
        {
            if (eventData.Contains(word.Key)) //text에 img를 출력할 단어가 있다면
            {
                ImageView(word.Key); // 해당 단어에 적합한 이미지 출력
                break;
                //isImage = true; //이미지 출력중
            }
            imageUi.SetActive(false); //이미지 항상 비활성화

        }

        eventText.text = eventData;
        eventText.text = eventText.text.Replace("\\n", "\n"); // 줄바꿈 수정

        isView = true;

        textAryIndex++;
    }
}
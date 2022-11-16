using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public static bool firstView;
    public GameObject btnObj;
    public GameObject textCanvas;
    public LayoutSetting layoutSetting;
    public GameObject btnUi;

    Button btn;
    
    private void Awake()
    {
        btnObj = GameObject.Find("BtnManager");
    }

    void Start()
    {
        
        btnUi = GameObject.Find("ButtonCanvas");
        btn = this.transform.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(TextEvent);
        }
        btnObj.SetActive(false);
        textCanvas.SetActive(false);
    }

    void TextEvent()
    {
        Debug.Log(btnObj.name);
        btnObj.SetActive(true);
        btnObj.transform.GetComponent<PlaceInfo>().documentId = EventSystem.current.currentSelectedGameObject.name;
        //btnObj.transform.GetComponent<ChildTextEvent>();
        Debug.Log("------------------BtnTTTTTTTTTTTTTTTouch!!!!!------------");
        firstView = true;
        Debug.Log(textCanvas.name);
        //Debug.Log(LayoutSetting.layoutIndex.ToString());
        textCanvas.SetActive(true);
        
        
        Debug.Log("touch Btn");
        //GameObject.Find("BtnSmallEvent").GetComponent<SmallEventManager>().View(gameObject);
        if (btnObj.transform.GetComponent<PlaceInfo>().documentId == "restaurant")
        {
            textCanvas.transform.Find("TextImage").Find("DialogText").GetComponent<Text>().text = "오늘은 뭘 먹지?";
            LayoutSetting.layoutIndex = 1;
            layoutSetting.layout[LayoutSetting.layoutIndex].SetActive(true);
        }
        btnUi.SetActive(false);   //버튼 클릭하면 버튼리스트 레이아웃은 false
    }
}

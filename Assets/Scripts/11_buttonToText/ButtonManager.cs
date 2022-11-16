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

    Button btn;

    private void Awake()
    {
        btnObj = GameObject.Find("BtnManager");
    }
    void Start()
    {
        btn = this.transform.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(TextEvent);
        }
        btnObj.SetActive(false);

    }

    void TextEvent()
    {
        btnObj.SetActive(true);
        btnObj.transform.GetComponent<PlaceInfo>().documentId = EventSystem.current.currentSelectedGameObject.name;
        btnObj.transform.GetComponent<ChildTextEvent>();
        
        firstView = true;

        //Debug.Log(LayoutSetting.layoutIndex.ToString());

        layoutSetting.layout[LayoutSetting.layoutIndex].SetActive(false);   //�迭�� �޾ƿ;���, ��ư Ŭ���ϸ� ��ư����Ʈ ���̾ƿ��� false
        textCanvas.SetActive(true);

        if (btnObj.transform.GetComponent<PlaceInfo>().documentId == "restaurant")
        {
            textCanvas.transform.Find("TextImage").Find("DialogText").GetComponent<Text>().text = "������ �� ����?";
            LayoutSetting.layoutIndex = 1;
            layoutSetting.layout[LayoutSetting.layoutIndex].SetActive(true);
        }
    }
}

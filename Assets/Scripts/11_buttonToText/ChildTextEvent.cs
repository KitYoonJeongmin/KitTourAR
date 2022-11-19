using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChildTextEvent : MonoBehaviour
{
    private bool noLoop;
    string firstView;
    public GameObject textCanvas;
    public LayoutSetting layoutSetting;

    public SmallEventManager smallEventManager;

    private void OnEnable()
    {
        smallEventManager.View(GameObject.Find("BtnManager"));
    }
    void Start()    
    {
    }

    void Update()
    {
        /*
        //데탑클릭 확인용
        if (Input.GetMouseButtonDown(0))
        {
            if (!smallEventManager.isView)
            {
                if (noLoop == true)  // 작은 이벤트 텍스트ui를 다 클릭하면 다시 안 뜨게 함(작은이벤트 무한클릭 방지)
                {
                    noLoop = false;
                    gameObject.SetActive(false);
                    if (LayoutSetting.layoutIndex == 1)
                        LayoutSetting.layoutIndex = 0;

                    layoutSetting.layout[LayoutSetting.layoutIndex].SetActive(true);
                    return;
                }
                smallEventManager.View(gameObject);
                //layoutSetting.layout[LayoutSetting.layoutIndex].SetActive(true);
            }

            else
            {
                smallEventManager.TextView(GetComponent<PlaceInfo>().documentId);
                noLoop = true;
            }
        }
        */
        
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log("childTextEvent touch start");
            if (smallEventManager.isView)
            {
                //smallEventManager.TextView(GameObject.Find("BtnManager").GetComponent<PlaceInfo>().documentId);
            }
            else
            {
                

                noLoop = true;
            }
        }
        
    }
    public void NextTextView()
    {
        smallEventManager.TextView(GameObject.Find("BtnManager").GetComponent<PlaceInfo>().documentId);
    }
}

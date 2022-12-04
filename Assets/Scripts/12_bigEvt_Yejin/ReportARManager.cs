using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class ReportARManager : MonoBehaviour
{
    public TimerManager timerManager;
    public EventMsg eventMsg;

    Dictionary<int, string[]> eventDic;

    private ARRaycastManager raycast;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); //Ray가 맞은 오브젝트 정보 저장
    [SerializeField] private Camera arCamera;

    public GameObject textUI;
    public Text evtText;

    public int evtIndex;
    public bool isAct;

    void Start()
    {
        if (ReportMapManager.reportEvt > 0 && ReportMapManager.reportEvt < 9)
        {
            evtIndex = 0;
            textUI.SetActive(false);

            TextView();
        }
    }

    public void TextView()
    {
        eventDic = eventMsg.eventData;
        if (textUI.activeSelf == false)
        {
            textUI.SetActive(true);
        }

        if (evtIndex >= eventDic[ReportMapManager.reportEvt].Length)
        {
            if (ReportMapManager.reportEvt == 1)
            {
                ReportMapManager.reportEvt = 10;
                //timerUI.SetActive(true);
                timerManager.TimeSet();
            }
            
            evtIndex = 0;
            textUI.SetActive(false);

            if (ReportMapManager.reportEvt > 1 && ReportMapManager.reportEvt < 9)
            {
                Destroy(gameObject.transform.Find("EventBar"));
                Destroy(gameObject);
                ReportMapManager.reportEvt = 10;
            }
            return;
        }

        string evtData = eventDic[ReportMapManager.reportEvt][evtIndex];
        Debug.Log(evtData);
            
        evtText.text = evtData;
        evtText.text = evtText.text.Replace("\\n", "\n");
            
        evtIndex++;
    }
}

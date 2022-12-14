using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SmallEventStart : MonoBehaviour
{
    public Material[] mat = new Material[2];

    public SmallEventManager smallEventManager;
    public ReportARGen reportARGen;
    private ARRaycastManager raycastMgr;

    public static string destroyMapObj;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); //Ray가 맞은 오브젝트 정보 저장
    [SerializeField] private Camera arCamera;
    // Start is called before the first frame update
    
    void Start()
    {
        raycastMgr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;  //터치 횟수가 0이면 return

        Touch touch = Input.GetTouch(0);
        
        if (touch.phase == TouchPhase.Began) // 터치 시작시
        {
            Ray ray;
            RaycastHit hitobj;
            ray = arCamera.ScreenPointToRay(touch.position); //카메라 정중앙에서 ray쏨

            if (Physics.Raycast(ray, out hitobj)) //맞은 오브젝트가 있으면 hitobj에 저장하고 if들어감
            {
                //터치한 곳에 오브젝트 이름이 smallEvent를 포함하면
                if (hitobj.collider.CompareTag("smallEventPre"))
                {
                    //현재 위치의 document id 들고옴
                    GetComponent<PlaceInfo>().documentId = GameObject.Find("AR Session Origin").GetComponent<AREventGen>().place;
                    //UI띄움
                    if (!smallEventManager.isView) // UI가 비활성 상태면 띄우기
                    {
                        smallEventManager.View(GameObject.Find("smallEvent"));
                        MatChange(1);
                    }
                        
                    //else // 활성상태면 index증가해서 다음 text띄우기
                    //    smallEventManager.TextView(GetComponent<PlaceInfo>().documentId);
                }
                
                if (hitobj.collider.CompareTag("reportEventPre"))
                {
                    if (ReportMapManager.reportEvt != 9)
                        return;
                    if (ReportMapManager.reportEvt == 9)
                    {
                        gameObject.GetComponent<PlaceInfo>().documentId = GameObject.Find("AR Session Origin").GetComponent<ReportARGen>().place;
                        destroyMapObj = gameObject.GetComponent<PlaceInfo>().documentId;
                        if (!smallEventManager.isView)
                        {
                            //TimerManager.tmp = "뷰까지 동작가능";
                            smallEventManager.View(GameObject.Find("ReportPref"));
                        }
                    }
                }

            }
        }
    }
    public void NextTextView()
    {
        smallEventManager.TextView(GetComponent<PlaceInfo>().documentId);
    }
    public void ReportsNextTextView()
    {
        smallEventManager.ReportEventView(GetComponent<PlaceInfo>().documentId);
    }

    public void MatChange(int matNum) //material 변경
    {
        gameObject.GetComponent<MeshRenderer>().material = mat[matNum];
    }

}

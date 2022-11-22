using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class BigEventStart : MonoBehaviour
{
    private ARRaycastManager raycastMgr;
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
                if (hitobj.collider.CompareTag("bigEvent"))
                {
                    string sceneName = GameObject.Find("AR Session Origin").GetComponent<AREventGen>().bigEventPlace;
                    //현재 위치의 document id 들고옴
                    SceneManager.LoadScene(sceneName);
                }

            }
        }
    }
}

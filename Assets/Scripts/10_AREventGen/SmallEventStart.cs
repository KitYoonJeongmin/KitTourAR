using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SmallEventStart : MonoBehaviour
{
    private ARRaycastManager raycastMgr;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField] private Camera arCamera;
    // Start is called before the first frame update
    void Start()
    {
        raycastMgr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        // 터치 시작시

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray;
            RaycastHit hitobj;
            ray = arCamera.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hitobj))
            {
                //터치한 곳에 오브젝트 이름이 smallEvent를 포함하면
                if (hitobj.collider.name.Contains("smallEvent"))
                {
                    Debug.Log("------------------UIUIUIUIUIUIUUIUIUIUUIUIU------------------");
                    gameObject.SetActive(false);
                }
            }
        }
    }
}

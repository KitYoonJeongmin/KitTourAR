using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SmallEventStart : MonoBehaviour
{
    public SmallEventManager smallEventManager;
    private ARRaycastManager raycastMgr;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); //Ray�� ���� ������Ʈ ���� ����
    [SerializeField] private Camera arCamera;
    // Start is called before the first frame update
    
    void Start()
    {
        raycastMgr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;  //��ġ Ƚ���� 0�̸� return

        Touch touch = Input.GetTouch(0);
        
        if (touch.phase == TouchPhase.Began) // ��ġ ���۽�
        {
            Ray ray;
            RaycastHit hitobj;
            ray = arCamera.ScreenPointToRay(touch.position); //ī�޶� ���߾ӿ��� ray��
            if (Physics.Raycast(ray, out hitobj)) //���� ������Ʈ�� ������ hitobj�� �����ϰ� if��
            {
                //��ġ�� ���� ������Ʈ �̸��� smallEvent�� �����ϸ�
                if (hitobj.collider.CompareTag("smallEventPre"))
                {
                    //���� ��ġ�� document id ����
                    GetComponent<PlaceInfo>().documentId = GameObject.Find("AR Session Origin").GetComponent<AREventGen>().place;
                    //UI���
                    if (!smallEventManager.isView) // UI�� ��Ȱ�� ���¸� ����
                        smallEventManager.View(GameObject.Find("smallEvent"));
                    else // Ȱ�����¸� index�����ؼ� ���� text����
                        smallEventManager.TextView(GetComponent<PlaceInfo>().documentId);
                }
                
            }
        }
    }
}

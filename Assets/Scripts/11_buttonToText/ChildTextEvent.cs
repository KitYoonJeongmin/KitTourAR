using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChildTextEvent : MonoBehaviour
{
    public SmallEventManager smallEventManager;

    // Start is called before the first frame update
    void Start()    {   }

    // Update is called once per frame
    void Update()
    {
        /*
        //데탑클릭 확인용
        if (Input.GetMouseButtonDown(0))
        {
            if (!smallEventManager.isView)
                smallEventManager.View(this.gameObject);
            else
                smallEventManager.TextView(GetComponent<PlaceInfo>().documentId);
        }
        */

        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            if (!smallEventManager.isView)
                smallEventManager.View(this.gameObject);
            else
                smallEventManager.TextView(GetComponent<PlaceInfo>().documentId);
        }
    }
}

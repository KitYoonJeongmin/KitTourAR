using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public GameObject btnObj;
    Button btn;

    void Start()
    {
        btn = this.transform.GetComponent<Button>();
        btnObj = transform.Find("BtnManager").gameObject;

        btnObj.SetActive(false);
    }
    void Update()
    {
        if (btn != null)
        {
            btn.onClick.AddListener(TextEvent);
        }
    }
    void TextEvent()
    {
        btnObj.SetActive(true);
        btnObj.transform.GetComponent<PlaceInfo>().documentId = EventSystem.current.currentSelectedGameObject.name.ToLower();
        btnObj.transform.GetComponent<ChildTextEvent>();
    }
}

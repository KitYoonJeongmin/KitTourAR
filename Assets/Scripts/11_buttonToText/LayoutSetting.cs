using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutSetting : MonoBehaviour
{
    public static int layoutIndex;

    public List<GameObject> layout;

    // Start is called before the first frame update
    void Start()
    {
        layoutIndex = GameObject.Find("GameManager").GetComponent<SmallEventManager>().btnIndex;

        foreach (var i in layout)
            i.SetActive(false);

        layout[layoutIndex].SetActive(true);
    }
}

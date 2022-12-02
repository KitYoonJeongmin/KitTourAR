using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> nameList;
    public Text name;

    void Start()
    {
        name = gameObject.GetComponent<Text>();
        name.text = nameList[IsCatch.crowImgNum];
    }
}

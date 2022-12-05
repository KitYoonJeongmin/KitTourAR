using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeCrow : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] crowSp;

    private Image crow;

    void Start()
    {
        crow = gameObject.GetComponent<Image>();
        crow.sprite = crowSp[IsCatch.crowImgNum];
    }
}

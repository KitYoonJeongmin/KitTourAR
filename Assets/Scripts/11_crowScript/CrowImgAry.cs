using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowImgAry : MonoBehaviour
{
    CrowTrigger crowTrigger;
    public Image image;

    [SerializeField]
    private Sprite[] sprites;

    void Start()
    {

    }

    void Update()
    {
        image.sprite = sprites[crowTrigger.crowIndex];
    }
}

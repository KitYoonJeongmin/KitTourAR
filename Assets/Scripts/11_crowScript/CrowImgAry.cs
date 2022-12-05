using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowImgAry : MonoBehaviour
{
    public Image image;

    [SerializeField]
    private Sprite[] sprites;

    void Start()
    {

    }

    void Update()
    {
        image.sprite = sprites[IsCatch.crowImgNum];
    }
}

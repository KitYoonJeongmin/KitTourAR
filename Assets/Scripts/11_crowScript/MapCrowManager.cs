using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCrowManager : MonoBehaviour
{
    public CrowTrigger crowTrigger;
    public GameObject button;
    public Image image;

    void Start()
    {

        if (IsCatch.crowMap == 1)
        {
            //image.sprite = sprites[IsCatch.crowImgNum];
            //키값은 생성시 존재하지만 만약에 존재하지 않는경우 생성하고 키값 1로 설정__진행되는 코드는 잡은 경우를 나타내기 때문에 들어오는 값은 항상 1임
         
            if (!(PlayerPrefs.HasKey("Crow" + IsCatch.crowImgNum.ToString())))
                PlayerPrefs.SetInt("Crow" + IsCatch.crowImgNum.ToString(),1);
            PlayerPrefs.SetInt("Crow" + IsCatch.crowImgNum.ToString(), 1);
        }
    }
}


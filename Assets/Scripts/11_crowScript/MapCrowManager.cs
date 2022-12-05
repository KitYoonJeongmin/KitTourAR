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
            //Ű���� ������ ���������� ���࿡ �������� �ʴ°�� �����ϰ� Ű�� 1�� ����__����Ǵ� �ڵ�� ���� ��츦 ��Ÿ���� ������ ������ ���� �׻� 1��
         
            if (!(PlayerPrefs.HasKey("Crow" + IsCatch.crowImgNum.ToString())))
                PlayerPrefs.SetInt("Crow" + IsCatch.crowImgNum.ToString(),1);
            PlayerPrefs.SetInt("Crow" + IsCatch.crowImgNum.ToString(), 1);
        }
    }
}


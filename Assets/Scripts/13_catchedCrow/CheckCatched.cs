using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class CheckCatched : MonoBehaviour
{
    GameObject gm;
    private Image ima;
    public Sprite[] booksprites;
    int test;



    //����� �� �̹��� �迭 �߰��ϱ�


    public void ChangeImage()
    {
        //for(int i = 0; i < 4; i++)
        //{
        //    test = Random.Range(0, 2);
        //    PlayerPrefs.SetInt("Crow"+i.ToString(), test);
        //}

        //PlayerPrefs.SetInt("Crow0", 0);
        //PlayerPrefs.SetInt("Crow1", 0);
        //PlayerPrefs.SetInt("Crow2", 0);
        //PlayerPrefs.SetInt("Crow3", 0);
        for (int i = 0; i < 4; i++)
        {
            if (PlayerPrefs.GetInt("Crow"+i.ToString()) == 1)
            {
                gm = GameObject.Find("Image" + i.ToString());
                ima = gm.GetComponent<Image>();
                //���� ������ ��� �׽�Ʈ�� �������� ���ؼ� ���Ƿ� �ۼ�
                //ima.sprite = booksprites[IsCatch.crowImgNum]; // �����ڵ�
                //�ڵ� ���ذ� �߸����� ��� ���� ���ɤ�
                ima.sprite = booksprites[i];
                ima.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}

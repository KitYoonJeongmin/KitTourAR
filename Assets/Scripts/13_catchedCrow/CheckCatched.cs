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



    //잡았을 때 이미지 배열 추가하기


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
                //현재 삼족오 잡는 테스트를 진행하지 못해서 임의로 작성
                //ima.sprite = booksprites[IsCatch.crowImgNum]; // 원본코드
                //코드 이해가 잘못됐을 경우 수정 가능ㅇ
                ima.sprite = booksprites[i];
                ima.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}

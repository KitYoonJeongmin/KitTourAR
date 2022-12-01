using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCrowManager : MonoBehaviour
{
    public CrowTrigger crowTrigger;
    public GameObject button;
    //public Button crowBtn;
    public Image image;
    

    [SerializeField]
    private Sprite[] sprites;
    


    void Start()
    {
        //crowBtn = transform.Find("Crow").GetComponent<Button>();
        button.SetActive(false);

        if (IsCatch.crowMap == 1)
        {
            Debug.Log("hi");
            button.SetActive(true);
            Debug.Log(IsCatch.crowImgNum.ToString());
            
            image.sprite = sprites[IsCatch.crowImgNum];
            //Ű���� ������ ���������� ���࿡ �������� �ʴ°�� �����ϰ� Ű�� 1�� ����__����Ǵ� �ڵ�� ���� ��츦 ��Ÿ���� ������ ������ ���� �׻� 1��
            if (!(PlayerPrefs.HasKey("Crow" + IsCatch.crowImgNum.ToString())))
                PlayerPrefs.SetInt("Crow" + IsCatch.crowImgNum.ToString(),1);
            PlayerPrefs.SetInt("Crow" + IsCatch.crowImgNum.ToString(), 1);
        }
    }
}


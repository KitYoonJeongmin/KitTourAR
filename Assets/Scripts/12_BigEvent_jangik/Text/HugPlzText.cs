using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HugPlzText : MonoBehaviour
{
    //
    //
    //
    //
    //

    //100�� ä��
    // �� ������ ��������... �ٵ� �ᱹ �ӿ�������..?

    //���ӿ���
    //
    public GameObject HugPlz0;
    public GameObject HugPlz1;
    public GameObject HugPlz2;
    private Text textViewport;
    private List<string> HugText = new List<string>();
    private List<string> HugTextSuccess = new List<string>();
    private List<string> HugTextFail = new List<string>();
    private int textIndex;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        textIndex = 0;

        HugText.Add("??? : �Ⱦ����!");
        HugText.Add("���? �����Ҹ���?");
        HugText.Add("??? : �Ⱦ����!!");
        HugText.Add("��! �Ӿ�? ��� ���� �Ҹ���?");
        HugText.Add("??? : ��! ��! ��! ��!!!");
        HugText.Add("���������� �𸣰����� �ϵ� ��������!");
 
        HugTextSuccess.Add("��.. �����̾� ���� �̻��� �Ҹ��� �ȵ鸮��...");
        HugTextSuccess.Add("�׷��� ��ü ����������...?");
        HugTextSuccess.Add("...");

        HugTextFail.Add("??? : ��Ҵ�!");
        HugTextFail.Add("����!......?");
        HugTextFail.Add("(??? �Ϳ���?)");
        HugTextFail.Add("���ٶ��� : �Ⱦ����!");
        HugTextFail.Add("��.. �׷�...(�Ϳ���!!)");
        HugTextFail.Add("���� ��í��í �ȱ� ���ع��ȴ�....");

        textViewport = GameObject.Find("Text").GetComponent<Text>();
        if(sceneName.Contains("start")) { textViewport.text = HugText[textIndex]; }
        else if (sceneName.Contains("Success")) { textViewport.text = HugTextFail[textIndex]; }
        else if (sceneName.Contains("GameOver")) { textViewport.text = HugTextSuccess[textIndex]; } 
    }
    public void Click()
    {
        textIndex++;
        if (sceneName.Contains("start"))
        {
            if (textIndex == 2)
            {
                HugPlz0.SetActive(false);
                HugPlz1.SetActive(true);
            }
            if (textIndex == 4)
            {
                HugPlz1.SetActive(false);
                HugPlz2.SetActive(true);
            }
            textViewport.text = HugText[textIndex];
            textViewport.text = textViewport.text.Replace("\\n", "\n");

            if (textIndex == HugText.Count - 1)
            {
                SceneManager.LoadScene("avoidGame");
                return;
            }
        }
        else if (sceneName.Contains("Success"))
        {
            if (textIndex == 3)
            {
                HugPlz0.SetActive(false);
                HugPlz1.SetActive(true);
            }
            if (textIndex == HugTextFail.Count)
            {
                SceneManager.LoadScene("KitMapScene");
                return;
            }
            textViewport.text = HugTextFail[textIndex];
            textViewport.text = textViewport.text.Replace("\\n", "\n");
        }
        else if (sceneName.Contains("GameOver"))
        {
            if (textIndex == HugTextSuccess.Count -1)
            {
                SceneManager.LoadScene("KitMapScene");
                return;
            }
            Debug.Log("Ŭ����");
            textViewport.text = HugTextSuccess[textIndex];
            textViewport.text = textViewport.text.Replace("\\n", "\n");
        }
    }
}
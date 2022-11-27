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
    public GameObject HugPlz;
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

        HugTextFail.Add("���ٶ���� : ��Ҵ�!");
        HugTextFail.Add("����!......?");
        HugTextFail.Add("(??? �Ϳ���?)");
        HugTextFail.Add("���ٶ��� : �Ⱦ����!");
        HugTextFail.Add("��.. �׷�...(�Ϳ���!!)");
        HugTextFail.Add("���� ��í��í �ȱ� ���ع��ȴ�....");

        textViewport = GameObject.Find("Text").GetComponent<Text>();
        if(sceneName.Contains("start")) { textViewport.text = HugText[textIndex]; }
    }

}

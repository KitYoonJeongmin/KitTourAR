using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlogText : MonoBehaviour
{
    public GameObject flog;
    public GameObject flog2;
    private Text textViewport;
    private List<string> FlogTextList = new List<string>();
    private int textIndex;
    private string sceneName;
    void Start()
    {
        flog.SetActive(false);
        flog2.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        textIndex = 0;
        FlogTextList.Add("��? �̰� ���� �Ҹ���?");
        FlogTextList.Add("<������>\n ����");
        FlogTextList.Add("�� �� ��� �ִ�?");
        FlogTextList.Add("<������>\n�� �뷡�� �θ��� ������ ���� �θ� ����� ����...");
        FlogTextList.Add("(����...���� ���� ����߰ڴ�.)");
        FlogTextList.Add("���� ���� ���ٰ�.");
        FlogTextList.Add("<������>\n����?");
        FlogTextList.Add("��!");
        FlogTextList.Add("<������>\n�׷��� �������� ���缭 �ϴܿ� �ִ� ������ ��ư�� ������~");
        FlogTextList.Add("...");

        textViewport = GameObject.Find("FlogText").GetComponent<Text>();
        if (sceneName.Contains("FlogTalk")) { textViewport.text = FlogTextList[textIndex]; }
    }
    public void Click()
    {
        textIndex++;

        textViewport.text = FlogTextList[textIndex];
        textViewport.text = textViewport.text.Replace("\\n", "\n");

        if (textIndex == 1)
        {
            flog.SetActive(true);
        }

        if (textIndex == 6)
        {
            flog.SetActive(false);
            flog2.SetActive(true);
        }

        if (textIndex == FlogTextList.Count-1)
        {
            SceneManager.LoadScene("Rhythm");
            return;
        }
         
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTracking : MonoBehaviour
{
    private List<string> startText = new List<string>();
    public Text text;

    public Button yes, no;

    private int index;

    void Start()
    {
        startText.Add("�л�, �� �����ǿ��� ���� �Ϸ� �湮����?");
        startText.Add("���� ������ �оߴ� ����Ʈ �������̽��� Ȯ�����Ƿ� ���� �л��� ����ϰ� �ִ� ���õ� Ȯ�������� ����� AR�� ���Ȱ̴ϴ�.");
        startText.Add("�츮 �����ǿ����� XR�� ���� �������̽� ������ �������ε� ���� �ֳ���?");

        index = 0;
        text.text = startText[index];
        index++;
    }
    public void NextText()
    {
        
        if (index == startText.Count)
        {
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(true);

        }
        else
        {
            text.text = startText[index];
            index++;
        }
        
    }
    
    public void YesBtn()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        text.text = "�� ���Ϸ� �������ּ���.";
        Application.OpenURL("https://sites.google.com/view/dschoi");

        index = 0;
    }

    public void NoBtn()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        text.text = "�ƽ��׿�. ������ ���������� �����ּ���.";
        

        index = 0;
    }
}

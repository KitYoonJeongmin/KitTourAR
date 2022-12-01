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
        startText.Add("학생, 제 연구실에는 무슨 일로 방문했죠?");
        startText.Add("저희 연구실 분야는 스마트 인터페이스와 확장현실로 지금 학생이 사용하고 있는 어플도 확장현실의 기술인 AR이 사용된겁니다.");
        startText.Add("우리 연구실에서는 XR을 위한 인터페이스 기기들을 연구중인데 관심 있나요?");

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
        text.text = "제 메일로 연락해주세요.";
        Application.OpenURL("https://sites.google.com/view/dschoi");

        index = 0;
    }

    public void NoBtn()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        text.text = "아쉽네요. 다음에 관심있으면 연락주세요.";
        

        index = 0;
    }
}

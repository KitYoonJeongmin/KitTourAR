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
        FlogTextList.Add("어? 이게 무슨 소리지?");
        FlogTextList.Add("<개구리>\n 엉엉");
        FlogTextList.Add("너 왜 울고 있니?");
        FlogTextList.Add("<개구리>\n난 노래를 부르고 싶은데 같이 부를 사람이 없어...");
        FlogTextList.Add("(저런...내가 같이 해줘야겠다.)");
        FlogTextList.Add("내가 같이 해줄게.");
        FlogTextList.Add("<개구리>\n정말?");
        FlogTextList.Add("응!");
        FlogTextList.Add("<개구리>\n그러면 빨간선에 맞춰서 하단에 있는 개구리 버튼을 눌러줘~");
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

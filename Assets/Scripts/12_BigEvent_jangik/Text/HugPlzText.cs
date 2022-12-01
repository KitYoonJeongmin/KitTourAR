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

    //100점 채움
    // 휴 간신히 도망갔네... 근데 결국 머였던거지..?

    //게임오버
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

        HugText.Add("??? : 안아줘요!");
        HugText.Add("어라? 무슨소리지?");
        HugText.Add("??? : 안아줘요!!");
        HugText.Add("헉! 머야? 어디서 나는 소리야?");
        HugText.Add("??? : 안! 아! 줘! 요!!!");
        HugText.Add("무슨일인진 모르겠지만 일딴 도망가자!");
 
        HugTextSuccess.Add("휴.. 다행이야 이제 이상한 소리가 안들리네...");
        HugTextSuccess.Add("그런데 대체 뭐였던거지...?");
        HugTextSuccess.Add("...");

        HugTextFail.Add("??? : 잡았다!");
        HugTextFail.Add("으악!......?");
        HugTextFail.Add("(??? 귀엽네?)");
        HugTextFail.Add("날다람쥐 : 안아줘요!");
        HugTextFail.Add("응.. 그래...(귀여워!!)");
        HugTextFail.Add("이후 메챠쿠챠 안김 당해버렸다....");

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
            Debug.Log("클릭됨");
            textViewport.text = HugTextSuccess[textIndex];
            textViewport.text = textViewport.text.Replace("\\n", "\n");
        }
    }
}
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

        HugText.Add("??? : 안아줘요!");
        HugText.Add("어라? 무슨소리지?");
        HugText.Add("??? : 안아줘요!!");
        HugText.Add("헉! 머야? 어디서 나는 소리야?");
        HugText.Add("??? : 안! 아! 줘! 요!!!");
        HugText.Add("무슨일인진 모르겠지만 일딴 도망가자!");

        HugTextSuccess.Add("휴.. 다행이야 이제 이상한 소리가 안들리네...");
        HugTextSuccess.Add("그런데 대체 뭐였던거지...?");

        HugTextFail.Add("날다람쥐들 : 잡았다!");
        HugTextFail.Add("으악!......?");
        HugTextFail.Add("(??? 귀엽네?)");
        HugTextFail.Add("날다람쥐 : 안아줘요!");
        HugTextFail.Add("응.. 그래...(귀여워!!)");
        HugTextFail.Add("이후 메챠쿠챠 안김 당해버렸다....");

        textViewport = GameObject.Find("Text").GetComponent<Text>();
        if(sceneName.Contains("start")) { textViewport.text = HugText[textIndex]; }
    }

}

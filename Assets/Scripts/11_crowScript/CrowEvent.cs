using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 삼족오 이미지 트리거에 맞게 바꿔주기 
public class CrowEvent : MonoBehaviour
{
    public Image image;

    [SerializeField]
    private Sprite[] sprites;

    public Button btnCatch;
    public Button btnQuit;
    public Text text;

    private Touch theTouch;

    public static int imgIndex;
    public static bool isCatched;

    private int evtNum;
    private bool sceneChange;

    void Start()
    {
        image.sprite = sprites[imgIndex];

        sceneChange = false;
        isCatched = false;
        evtNum = -1;
    }

    public void Update()
    {
        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)    //텍스트UI(text.text) 내용 수정할 것
            {
                if(sceneChange)
                {
                    sceneChange = false;
                    SceneManager.LoadScene(0);      //킷맵씬으로 전환

                }

                if (evtNum == 1)        //'도망간다' 버튼을 눌렀을 경우
                {
                    text.text = "강의 들으러 가자 ...";
                    sceneChange = true;

                }
                else if (evtNum == 0)   //'잡는다' 버튼을 눌렀을 경우
                {
                    if(isCatched == false)
                    {
                        text.text = "삼족오(이)가 도망갔다! 아쉬워~";
                    }
                    else
                    {
                        text.text = "삼족오(을)를 잡았다!";
                    }
                    sceneChange = true;
                }
            }
        }
    }
    public void OnClickCatchBtn()
    {
        int prob = Random.Range(1, 10);
        if (prob > 5)
        {
            isCatched = true;
        }
            
        evtNum = 0;
    }

    public void OnClickQuitBtn()
    {
        evtNum = 1;
    }
}

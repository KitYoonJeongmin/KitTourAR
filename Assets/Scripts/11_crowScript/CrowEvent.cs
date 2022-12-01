using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ������ �̹��� Ʈ���ſ� �°� �ٲ��ֱ� 
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

            if (theTouch.phase == TouchPhase.Began)    //�ؽ�ƮUI(text.text) ���� ������ ��
            {
                if(sceneChange)
                {
                    sceneChange = false;
                    SceneManager.LoadScene(0);      //Ŷ�ʾ����� ��ȯ

                }

                if (evtNum == 1)        //'��������' ��ư�� ������ ���
                {
                    text.text = "���� ������ ���� ...";
                    sceneChange = true;

                }
                else if (evtNum == 0)   //'��´�' ��ư�� ������ ���
                {
                    if(isCatched == false)
                    {
                        text.text = "������(��)�� ��������! �ƽ���~";
                    }
                    else
                    {
                        text.text = "������(��)�� ��Ҵ�!";
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

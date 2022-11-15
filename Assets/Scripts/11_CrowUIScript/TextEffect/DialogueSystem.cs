using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public Text txtSentence;
    public GameObject ButtonLayout;
    Queue<string> sentences = new Queue<string>();  //Dialogue에 있는 List앞에서 순차적으로 보여주기 위해 자료형 큐 사용
    public Dialogue info;
    int check = 0;  //한번 실행했는지 체크하는 변수

    
    private void Start()
    {
        ButtonLayout.SetActive(false);
        Invoke("Trigger", 2);
    }
    public void Trigger()
    {
        //시스템에 접근해서 Begin에 현재 들고 있는 정보를 넘겨줌
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);

    }
    public void Begin(Dialogue info)
    {

        sentences.Clear();

        //foreach로 sentences를 돈다
        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }

    public void Next()  //다음 문장 호출
    {
        //이제 sentences가 없다면
        if(sentences.Count==0)
        {
            if (check == 0)
            {
                End();
                return;
            }
            else
            {

                Invoke("SceneChange", 1);
                return;
            }
        }
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(Typing(sentences.Dequeue()));
        
    }
    IEnumerator Typing(string sentence) //타이핑 효과처럼 텍스트 출력
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void End()
    {
        ButtonLayout.SetActive(true);
        check = 1;

    }

    private void SceneChange()
    {
        SceneManager.LoadScene("KitMapScene");
    }

}
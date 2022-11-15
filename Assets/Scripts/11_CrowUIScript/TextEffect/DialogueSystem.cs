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
    public bool isSelect;
    int check=0;

    private void Start()
    {
        isSelect = false;
        ButtonLayout.SetActive(false);
        Begin(info);
    }

    public void Begin(Dialogue info)
    {
        sentences.Clear();

        //foreach로 sentences를 돈다
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);

        }
        Invoke("Next", 2);
    }

    public void Next()  //다음 문장 호출
    {
        var system = FindObjectOfType<YesNoSystem>();

        //이제 sentences가 없다면
        if (sentences.Count==0)
        {
            if (isSelect)
            {

                Invoke("SceneChange", 1);
                return;
            }
            if (check == 0)
            {
                End();
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
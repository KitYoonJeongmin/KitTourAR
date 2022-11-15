using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YesNoSystem : MonoBehaviour
{
    [SerializeField]
    public bool isCatch;
    
    public GameObject ButtonLayout;
    public Text txtSentence;
    Queue<string> sentences = new Queue<string>();  //Dialogue에 있는 List앞에서 순차적으로 보여주기 위해 자료형 큐 사용
    public Dialogue info;


    private void Start()
    {
        
        isCatch = false;
    }
    public void Trigger()
    {
        
        Debug.Log("111");
        //시스템에 접근해서 Begin에 현재 들고 있는 정보를 넘겨줌
        var system = FindObjectOfType<DialogueSystem>();
        ButtonLayout.SetActive(false);
        system.Begin(info);
        system.isSelect = true;

    }
    public void Begin(Dialogue info)
    {

        sentences.Clear();
        //isCatch.crowMap = isCatch;

        //foreach로 sentences를 돈다
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }

    public void Next()
    {
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(Typing(sentences.Dequeue()));

    }
    IEnumerator Typing(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
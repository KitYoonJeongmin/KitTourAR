using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class YesNoSystem : MonoBehaviour
{
    [SerializeField]
    public int isCatch;
    
    public GameObject ButtonLayout;
    public Text txtSentence;
    Queue<string> sentences = new Queue<string>();  //Dialogue�� �ִ� List�տ��� ���������� �����ֱ� ���� �ڷ��� ť ���
    public Dialogue info;

    public void Trigger()
    {
        IsCatch.crowMap = isCatch;
        Debug.Log("111");
        //�ý��ۿ� �����ؼ� Begin�� ���� ��� �ִ� ������ �Ѱ���
        var system = FindObjectOfType<DialogueSystem>();
        ButtonLayout.SetActive(false);
        system.Begin(info,1);
        system.isSelect = true;

        //Debug.Log("HI"); Debug.Log("HI");
        system.Begin(info,1);
    }
    public void Begin(Dialogue info)
    {


        sentences.Clear();
        //isCatch.crowMap = isCatch;

        //foreach�� sentences�� ����
        //foreach (var sentence in info.sentences)
        //{
        //    sentences.Enqueue(sentence);
        //}
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
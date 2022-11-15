using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public Text txtSentence;
    public GameObject ButtonLayout;
    Queue<string> sentences = new Queue<string>();  //Dialogue�� �ִ� List�տ��� ���������� �����ֱ� ���� �ڷ��� ť ���
    public Dialogue info;
    int check = 0;  //�ѹ� �����ߴ��� üũ�ϴ� ����

    
    private void Start()
    {
        ButtonLayout.SetActive(false);
        Invoke("Trigger", 2);
    }
    public void Trigger()
    {
        //�ý��ۿ� �����ؼ� Begin�� ���� ��� �ִ� ������ �Ѱ���
        var system = FindObjectOfType<DialogueSystem>();
        system.Begin(info);

    }
    public void Begin(Dialogue info)
    {

        sentences.Clear();

        //foreach�� sentences�� ����
        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }

    public void Next()  //���� ���� ȣ��
    {
        //���� sentences�� ���ٸ�
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
    IEnumerator Typing(string sentence) //Ÿ���� ȿ��ó�� �ؽ�Ʈ ���
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
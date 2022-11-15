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

        //foreach�� sentences�� ����
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);

        }
        Invoke("Next", 2);
    }

    public void Next()  //���� ���� ȣ��
    {
        var system = FindObjectOfType<YesNoSystem>();

        //���� sentences�� ���ٸ�
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

            return;
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
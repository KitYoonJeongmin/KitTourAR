using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    Result theResult;


    public int bpm = 0; //1�д� ��Ʈ ��
    double currentTime = 0d;

    [SerializeField] Transform[] tfNoteAppear; //note�� ������ ��ġ
    [SerializeField] GameObject goNote = null; //note �������� ���� ����

    TimingManager theTimingManager;
    EffectManager theEffectManager;
    ComboManager theComboManager;

    [Header("�뷡 ����")]
    public int[] tempo;
    private int tempoCount,count;


    private void Start()
    {
        count = 0;//����
        theEffectManager = FindObjectOfType<EffectManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theTimingManager = GetComponent<TimingManager>();
        theResult = FindObjectOfType<Result>();


    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime>=60d/bpm)    //�ʰ� ������ ����
        {
            Debug.Log(tempo[count].ToString());
            //�� ���� �ݺ��ǵ���
            //���� ���� ������ ���� ������ ����� ����
            if (tempo[count] == 0) { count++; currentTime -= 60d / bpm; return; }
            int ran = Random.Range(0, 4);
            //������ ���
            GameObject t_note = Instantiate(goNote, tfNoteAppear[ran].position, Quaternion.identity) ;
            t_note.transform.SetParent(this.transform); //�� ��ũ��Ʈ�� �پ��ִ� ��ü�� �θ�� ����
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
            count++;
            

        }
        if(count==301)
        {
            //��� ȭ�� ���
            theResult.ShowResult();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag()) 
            {
                theTimingManager.MissRecord();
                theEffectManager.JudgementEffect(4);
                theComboManager.ResetCombo();
            }
            
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{

    public List<GameObject> boxNoteList = new List<GameObject>();

    int[] judgementRecord = new int[5];

    [SerializeField] Transform Center = null;   //������ ��Ʈ�� ��� List(���� ������ �ִ��� ��� ��Ʈ�� ���ؾ� ��)
    [SerializeField] RectTransform[] timingRect = null; //���� ����(perfect,cool,good,bad)
    Vector2[] timingBoxs = null;        //���� �������� �� ��

    EffectManager theEffect;
    ScoreManager theScoreManager;
    ComboManager theComboManager;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();

        //Ÿ�̹� �ڽ� ����
        timingBoxs = new Vector2[timingRect.Length];

        for(int i = 0; i< timingRect.Length;i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height / 2, Center.localPosition.y + timingRect[i].rect.height / 2);
        }
    }

    public void CheckTiming()
    {
        for(int i=0;i<boxNoteList.Count;i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int y=0;y<timingBoxs.Length;y++)
            {
                if(timingBoxs[y].x<=t_notePosY&&t_notePosY<=timingBoxs[y].y)
                {
                    if (t_notePosX <= -208) {
                        //��Ʈ ����
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //����Ʈ ����
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);   //���� ����
                        judgementRecord[y]++;   //���� ���

                        //���� ����
                        theScoreManager.IncreaseScore(y);

                        return;
                    }
                   
                }
            }
        }
        theComboManager.ResetCombo();
        theEffect.JudgementEffect(timingBoxs.Length);
        MissRecord();
    }
    public void CheckTiming2()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int y = 0; y < timingBoxs.Length; y++)
            {
                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                {
                    if (-208 <= t_notePosX  && t_notePosX<=27)
                    {
                        //��Ʈ ����
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //����Ʈ ����
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);
                        judgementRecord[y]++;   //���� ���

                        //���� ����
                        theScoreManager.IncreaseScore(y);

                        return;
                    }

                }
            }
        }
        theComboManager.ResetCombo();
        theEffect.JudgementEffect(timingBoxs.Length);
        MissRecord();
    }
    public void CheckTiming3()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int y = 0; y < timingBoxs.Length; y++)
            {
                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                {
                    if (27 <= t_notePosX && t_notePosX <= 235)
                    {
                        //��Ʈ ����
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //����Ʈ ����
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);
                        judgementRecord[y]++;   //���� ���

                        //���� ����
                        theScoreManager.IncreaseScore(y);

                        return;
                    }

                }
            }
        }
        theComboManager.ResetCombo();
        theEffect.JudgementEffect(timingBoxs.Length);
        MissRecord();
    }
    public void CheckTiming4()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int y = 0; y < timingBoxs.Length; y++)
            {
                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                {
                    if (235 <= t_notePosX)
                    {
                        //��Ʈ ����
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //����Ʈ ����
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);
                        judgementRecord[y]++;   //���� ���

                        //���� ����
                        theScoreManager.IncreaseScore(y);

                        return;
                    }

                }
            }
        }
        theComboManager.ResetCombo();
        theEffect.JudgementEffect(timingBoxs.Length);
        MissRecord();
    }
    public int[] GetJudgementRecord()
    {
        return judgementRecord;
    }

    public void MissRecord()
    {
        judgementRecord[4]++;   //���� ���
    }
}

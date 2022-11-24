using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{

    public List<GameObject> boxNoteList = new List<GameObject>();

    int[] judgementRecord = new int[5];

    [SerializeField] Transform Center = null;   //생성된 노트를 담는 List(판정 범위에 있는지 모든 노트를 비교해야 함)
    [SerializeField] RectTransform[] timingRect = null; //판정 범위(perfect,cool,good,bad)
    Vector2[] timingBoxs = null;        //실제 판정에서 쓸 것

    EffectManager theEffect;
    ScoreManager theScoreManager;
    ComboManager theComboManager;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();

        //타이밍 박스 설정
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
                        //노트 제거
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //이펙트 연출
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);   //판정 연출
                        judgementRecord[y]++;   //판정 기록

                        //점수 증가
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
                        //노트 제거
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //이펙트 연출
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);
                        judgementRecord[y]++;   //판정 기록

                        //점수 증가
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
                        //노트 제거
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //이펙트 연출
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);
                        judgementRecord[y]++;   //판정 기록

                        //점수 증가
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
                        //노트 제거
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);

                        //이펙트 연출
                        if (y < timingBoxs.Length - 1)
                            theEffect.NoteHitEffect();
                        theEffect.JudgementEffect(y);
                        judgementRecord[y]++;   //판정 기록

                        //점수 증가
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
        judgementRecord[4]++;   //판정 기록
    }
}

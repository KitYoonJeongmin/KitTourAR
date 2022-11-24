using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    Result theResult;


    public int bpm = 0; //1분당 비트 수
    double currentTime = 0d;

    [SerializeField] Transform[] tfNoteAppear; //note가 생성될 위치
    [SerializeField] GameObject goNote = null; //note 프리팹을 담을 변수

    TimingManager theTimingManager;
    EffectManager theEffectManager;
    ComboManager theComboManager;

    [Header("노래 박자")]
    public int[] tempo;
    private int tempoCount,count;


    private void Start()
    {
        count = 0;//마디
        theEffectManager = FindObjectOfType<EffectManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theTimingManager = GetComponent<TimingManager>();
        theResult = FindObjectOfType<Result>();


    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime>=60d/bpm)    //초가 지나면 생성
        {
            Debug.Log(tempo[count].ToString());
            //한 마디가 반복되도록
            //마디가 가진 변수를 보고 개구리 출력을 결정
            if (tempo[count] == 0) { count++; currentTime -= 60d / bpm; return; }
            int ran = Random.Range(0, 4);
            //개구리 출력
            GameObject t_note = Instantiate(goNote, tfNoteAppear[ran].position, Quaternion.identity) ;
            t_note.transform.SetParent(this.transform); //이 스크립트가 붙어있는 객체를 부모로 설정
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
            count++;
            

        }
        if(count==301)
        {
            //결과 화면 출력
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

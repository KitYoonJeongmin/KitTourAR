using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMsg : MonoBehaviour
{
    public Dictionary<int, string[]> eventData;
    // Start is called before the first frame update
    void Awake()
    {
        eventData = new Dictionary<int, string[]>();
        TextList();
    }

    void TextList()
    {
        eventData.Add(1, new string[] { "앗! 과제물을 잃어버렸어...", "학교를 돌아다니면서 찾아볼까?", "(AR 화면에서 과제 아이콘이 보이면 터치해주세요!)" });
        eventData.Add(2, new string[] { "과제를 " + TimerManager.countReport.ToString() + "장 찾았어!", "역시 과제가 많은 강의는 힘들어~" });
        eventData.Add(3, new string[] { "과제가 " + TimerManager.countReport.ToString() + "장인 강의라 다행이야!" });
        eventData.Add(4, new string[] { "과제를 한 장도 못 찾았어...\n강의 다 끝나면 메일 드려야겠다." });

        //이벤트 전체 구조
    }
}

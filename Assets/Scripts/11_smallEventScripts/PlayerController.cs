using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject scanPlace;
    public SmallEventManager smallEventManager;

    // Start is called before the first frame update
    void Start()
    {
        //Place 오브젝트를 건드렸을 때 해당 함수 호출되도록 이벤트 만들어주어야 함!!

        //로직예시: if(사용자가 어떤 버튼을 눌렀을 때(맵 건물 아이콘 등))
        //  smallEventManager.View(scanPlace); 함수 실행

        // 조건코드를 따로 작성해야 버튼을 다시 눌렀을 때 text UI가 꺼집니다.(<= text 카운트 변수(textAryIndex) 등록함)
    }

    // Update is called once per frame
    void Update()
    {

        //테스트용 코드입니다! 플레이어컨트롤러 관련 스크립트에서 업데이트 함수 말고 개별 함수 만들어서 사용해주시면 됩니다!
        if(Input.GetMouseButtonDown(0))
        {
            smallEventManager.View(scanPlace);
        }
    }
}

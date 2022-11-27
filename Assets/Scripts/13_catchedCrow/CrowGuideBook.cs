using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGuideBook : MonoBehaviour
{
    
    //코드 실행시 기본베이스 저장값 생성
    void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            if (!(PlayerPrefs.HasKey("Crow" + i.ToString())))
            {
                PlayerPrefs.SetInt("Crow" + i.ToString(), 0);
                Debug.Log("생성" + i.ToString());
            }
            Debug.Log("존재" + i.ToString());
        }
    }
    

}

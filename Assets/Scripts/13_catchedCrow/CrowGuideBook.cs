using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowGuideBook : MonoBehaviour
{
    
    //�ڵ� ����� �⺻���̽� ���尪 ����
    void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            if (!(PlayerPrefs.HasKey("Crow" + i.ToString())))
            {
                PlayerPrefs.SetInt("Crow" + i.ToString(), 0);
                Debug.Log("����" + i.ToString());
            }
            Debug.Log("����" + i.ToString());
        }
    }
    

}

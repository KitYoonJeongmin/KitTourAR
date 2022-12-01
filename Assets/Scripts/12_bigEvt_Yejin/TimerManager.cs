using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public ReportARManager reportARManager;

    public Text timerText;
    public Text reportText;
    public Text tmp_;
    public static float time = 3600f;
    private float countDown = 1;

    public static int countReport;
    public static string tmp;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void TimeSet()
    {
        gameObject.SetActive(false);
        if (ReportMapManager.reportEvt == 10) //reportEvt == 10, Ÿ�̸� load
        {
            gameObject.SetActive(true);
            countDown = time;
            countReport = 0;
            tmp = "�׽�Ʈ";
            ReportMapManager.reportEvt = 9; //reportEvt == 9, ���� ���� ����(���)
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Floor(countDown) <= 0 && ReportMapManager.reportEvt == 9)  
        {
            if (countReport > 5)
                ReportMapManager.reportEvt = 2;
            else if (countReport > 0)
            {
                ReportMapManager.reportEvt = 3;
            }
            else
                ReportMapManager.reportEvt = 4;

            SceneManager.LoadScene("GenUI 1");
            reportARManager.TextView();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log(ReportMapManager.reportEvt);
            countDown -= Time.deltaTime;
            timerText.text = ((int)countDown / 60 % 60).ToString() + " : " + ((int)countDown % 60).ToString();
            reportText.text = countReport.ToString() + " ��";
            tmp_.text = tmp;
        }
        
    }
}

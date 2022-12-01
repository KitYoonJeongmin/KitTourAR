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
        if (ReportMapManager.reportEvt == 10) //reportEvt == 10, 타이머 load
        {
            gameObject.SetActive(true);
            countDown = time;
            countReport = 0;
            tmp = "테스트";
            ReportMapManager.reportEvt = 9; //reportEvt == 9, 게임 진행 상태(대기)
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
            reportText.text = countReport.ToString() + " 개";
            tmp_.text = tmp;
        }
        
    }
}

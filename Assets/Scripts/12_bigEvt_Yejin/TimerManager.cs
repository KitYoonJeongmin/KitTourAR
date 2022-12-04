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
    public static float time = 3600f;
    private int eventViewFrameWait = 30;

    private float countDown = 1;
    public static bool gameEnd = false;

    public static int countReport;

    private void Awake()
    {
        if (gameEnd == true)
            Destroy(gameObject);

        var obj = FindObjectsOfType<TimerManager>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TimeSet()
    {
        if (gameEnd == true)
            Destroy(gameObject);
        gameObject.SetActive(false);
        if (ReportMapManager.reportEvt == 10) //reportEvt == 10, 타이머 load
        {
            if (gameEnd == true)
                gameObject.transform.Find("Image").gameObject.SetActive(false);
            gameObject.SetActive(true);
            countDown = time;
            countReport = 0;
            ReportMapManager.reportEvt = 9; //reportEvt == 9, 게임 진행 상태(대기)
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Floor(countDown) <= 0 && ReportMapManager.reportEvt == 9)  
        {
            SceneManager.LoadScene("GenUI 1");

            gameObject.transform.Find("Image").gameObject.SetActive(false);
            if (countReport > 5)
                ReportMapManager.reportEvt = 2;
            else if (countReport > 0)
            {
                ReportMapManager.reportEvt = 3;
            }
            else
                ReportMapManager.reportEvt = 4;

            
            eventViewFrameWait--;
            if (eventViewFrameWait <= 0)
            {
                gameEnd = true;
                reportARManager.TextView();
                Destroy(gameObject);
                eventViewFrameWait = 5;
            }
        }
        else
        {
            if (gameEnd == true)
            {
                Destroy(gameObject);
            }
                
            Debug.Log(ReportMapManager.reportEvt);
            countDown -= Time.deltaTime;
            timerText.text = ((int)countDown / 60 % 60).ToString() + " : " + ((int)countDown % 60).ToString();
            reportText.text = countReport.ToString() + " 개";
        }
        
    }
}

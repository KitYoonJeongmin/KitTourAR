using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Controller : MonoBehaviour
{
    TimingManager theTimingManager;

    private void Start()
    {
        theTimingManager = FindObjectOfType<TimingManager>();
    }

    public void Click()
    {
        theTimingManager.CheckTiming();//���� üũ
    }
    public void Click2()
    {
        theTimingManager.CheckTiming2();//���� üũ
    }
    public void Click3()
    {
        theTimingManager.CheckTiming3();//���� üũ
    }
    public void Click4()
    {
        theTimingManager.CheckTiming4();//���� üũ
    }
}

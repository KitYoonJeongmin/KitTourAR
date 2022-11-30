using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveControl : MonoBehaviour
{
    private bool isBtnDown = false;
    
    void Update()
    {
        if (isBtnDown)
        {
            Debug.Log("BTN DOWN");
        }
    }
    public void down()
    {
        isBtnDown = true;
    }
    public void up()
    {
        isBtnDown = false;
    }
}

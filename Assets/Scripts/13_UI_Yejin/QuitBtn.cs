using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitBtn : MonoBehaviour
{
    [SerializeField]
    public GameObject quitUI;
    public void IsQuit()
    {
        quitUI.SetActive(true);
    }
    public void clickedQuit()
    {
        Application.Quit();
    }
    public void clickedCon()
    {
        quitUI.SetActive(false);
    }
}

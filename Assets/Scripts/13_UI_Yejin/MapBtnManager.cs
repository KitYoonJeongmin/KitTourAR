using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapBtnManager : MonoBehaviour
{
    private bool isView;

    [SerializeField]
    public GameObject quitUI;
    public List<GameObject> btnList;

    private GameObject tgBtn;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "KitMapScene")
        {
            gameObject.transform.Find("Map").gameObject.SetActive(false);
            gameObject.transform.Find("AR").gameObject.SetActive(true);
        }
        
        if (SceneManager.GetActiveScene().name == "GenUI 1")
        {
            gameObject.transform.Find("AR").gameObject.SetActive(false);
            gameObject.transform.Find("Map").gameObject.SetActive(true);
        }

        isView = false;
        foreach (var bl in btnList)
            bl.SetActive(false);
        
        tgBtn = gameObject.transform.Find("Menu").gameObject;
    }

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
    public void OpenKit()
    {
        Application.OpenURL("http://www.kumoh.ac.kr/ko/index.do");
    }

    public void OpenGit()
    {
        Application.OpenURL("http://github.com/KitYoonJeongmin/KitTourAR");
    }

    public void Toggle()
    {
        tgBtn.GetComponent<Button>().interactable = false;
        StartCoroutine(PlayNowCoroutine());
        
        tgBtn.GetComponent<Button>().interactable = true;
    }

    IEnumerator PlayNowCoroutine()
    {
        if (isView == false)
        {
            for (int i = 0; i < btnList.Count; i++)
            {
                btnList[i].SetActive(true);
                yield return new WaitForSeconds(0.15f);
            }
            isView = true;
        }
        else if (isView == true)
        {
            for (int i = btnList.Count - 1; i >= 0; i--)
            {
                btnList[i].SetActive(false);
                yield return new WaitForSeconds(0.15f);
            }
            isView = false;
        }
    }
}

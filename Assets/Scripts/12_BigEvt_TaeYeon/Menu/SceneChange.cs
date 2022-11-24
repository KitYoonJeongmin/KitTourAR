using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void FlogSceneChange()
    {
        SceneManager.LoadScene("FlogTalk");
    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("KitMapScene");
    }
}

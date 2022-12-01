using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenKit()
    {
        Application.OpenURL("http://www.kumoh.ac.kr/ko/index.do");
    }

}

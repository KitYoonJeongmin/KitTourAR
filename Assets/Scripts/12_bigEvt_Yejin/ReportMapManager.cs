using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReportMapManager : MonoBehaviour
{
    public static int reportEvt = 0;
    // Start is called before the first frame update
    private void Start()
    {
        if (reportEvt != 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag == "mapCharacter")) { return; }
        if (reportEvt == 0)
        {
            reportEvt = 1;
            SceneManager.LoadScene("GenUI 1");
        }
    }
}

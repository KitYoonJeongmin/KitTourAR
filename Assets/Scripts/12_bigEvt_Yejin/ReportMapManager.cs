using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReportMapManager : MonoBehaviour
{
    public static int reportEvt = 0;
    public ReportMapGen reportMapGen;
    public GameObject evtModel;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("hihi " + reportEvt + " " + gameObject.name);
        if (reportEvt != 0)
        {
            Destroy(evtModel);
            Destroy(gameObject);
            if(gameObject)
                gameObject.SetActive(false);
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!(other.gameObject.tag == "mapCharacter")) { return; }
        if (reportEvt == 0)
        {
            Destroy(evtModel);
            reportMapGen.ReportsEventStart();
            reportEvt = 1;
            Destroy(gameObject);
            SceneManager.LoadScene("GenUI 1");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DroneStartText : MonoBehaviour
{
    public GameObject projectile;
    private GameObject drone;
    private Text textViewport;
    private string[] startTextList = new string[4];
    private List<string> endTextList = new List<string>();
    private List<string> clearTextList = new List<string>();
    private int textIndex;
    private string sceneName;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        drone = GameObject.Find("Drone");
        textIndex = 0;

        startTextList[0] = "우와!! 드론이다!! \n금오공대는 학생들이 드론도 날리는구나!!";
        startTextList[1] = "근데 운동장에서 드론을 날려도 되나?\n누가 조종하고 있는거지?";
        startTextList[2] = "으악! 주인도 없는 드론이 공격하잖아!";
        startTextList[3] = "<드론> \n\n반갑다. 인간들아. \n인공지능의. 시대가. 도래했다.";

        clearTextList.Add("이 새떼들은 뭐야!");
        clearTextList.Add("<삼족오의 친구들>\n\n 학교 손님이 위협을 받고 있다는 소식을 듣고 우리가 출동했지!\n이제 안심하라구!");
        clearTextList.Add("삼족오의 친구들이었구나!\n친구들아 고마워!! ");
        clearTextList.Add("근데 이 학교는 왜 새들이 보안요원인거지...?\n말이되나?");
        clearTextList.Add("<삼족오의 친구들>\n\n 당연히 말이 안되지! \n이제 일어나... 운동장에서 자면 입돌아가..");



        endTextList.Add("헉... 꿈이었잖아... 언제 깜빡 잠들었지?");
        endTextList.Add("오늘 학교에서 신기한 기기들을 많이봐서 그런가 별 꿈을 다꾸네..");
        endTextList.Add("<정보>\n\n 금오공과 대학교의 드론은 공격기능이 없다.");
        endTextList.Add("<정보>\n\n 보통 드론은 사람이 드문 본관 옆 잔디밭에서 날리니 안심하자.");


        textViewport = GameObject.Find("DialogText").GetComponent<Text>();
        if (sceneName.Contains("Start")) { textViewport.text = startTextList[textIndex]; }
        else if (sceneName.Contains("Shooter")) { textViewport.text = clearTextList[textIndex]; }
        else if(sceneName.Contains("BigEvtDroneEnd")) { textViewport.text = endTextList[textIndex]; }
        
    }
    public void Click()
    {
        textIndex++;
        if(sceneName.Contains("Start"))
        {
            if (textIndex == 4)
            {
                SceneManager.LoadScene("BigEvtDroneShooter");
                return;
            }
            textViewport.text = startTextList[textIndex];
            textViewport.text = textViewport.text.Replace("\\n", "\n");

            if (textIndex == 2)
            {
                drone.transform.LookAt(GameObject.Find("AR Camera").transform.position);
                GameObject shot = Instantiate(projectile, drone.transform.position, transform.rotation);
                //shot.transform.position = Vector3.MoveTowards(shot.transform.position, GameObject.Find("Camera").transform.position, 5);
                shot.transform.GetComponent<Rigidbody>().AddForce(drone.transform.forward * 1000.0f);
            }
        }
        else if (sceneName.Contains("Shooter"))
        {
            if (textIndex == clearTextList.Count)
            {
                SceneManager.LoadScene("BigEvtDroneEnd");
                return;
            }
            textViewport.text = clearTextList[textIndex];
            textViewport.text = textViewport.text.Replace("\\n", "\n");
        }
        else if(sceneName.Contains("End"))
        {
            if (textIndex == 4)
            {
                SceneManager.LoadScene("KitMapScene");
                return;
            }
            textViewport.text = endTextList[textIndex];
            textViewport.text = textViewport.text.Replace("\\n", "\n");
        }
        
    }
}

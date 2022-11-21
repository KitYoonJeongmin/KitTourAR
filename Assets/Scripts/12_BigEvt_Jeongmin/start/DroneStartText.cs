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

        startTextList[0] = "���!! ����̴�!! \n�ݿ������ �л����� ��е� �����±���!!";
        startTextList[1] = "�ٵ� ��忡�� ����� ������ �ǳ�?\n���� �����ϰ� �ִ°���?";
        startTextList[2] = "����! ���ε� ���� ����� �������ݾ�!";
        startTextList[3] = "<���> \n\n�ݰ���. �ΰ����. \n�ΰ�������. �ô밡. �����ߴ�.";

        clearTextList.Add("�� �������� ����!");
        clearTextList.Add("<�������� ģ����>\n\n �б� �մ��� ������ �ް� �ִٴ� �ҽ��� ��� �츮�� �⵿����!\n���� �Ƚ��϶�!");
        clearTextList.Add("�������� ģ�����̾�����!\nģ����� ����!! ");
        clearTextList.Add("�ٵ� �� �б��� �� ������ ���ȿ���ΰ���...?\n���̵ǳ�?");
        clearTextList.Add("<�������� ģ����>\n\n �翬�� ���� �ȵ���! \n���� �Ͼ... ��忡�� �ڸ� �Ե��ư�..");



        endTextList.Add("��... ���̾��ݾ�... ���� ���� ������?");
        endTextList.Add("���� �б����� �ű��� ������ ���̺��� �׷��� �� ���� �ٲٳ�..");
        endTextList.Add("<����>\n\n �ݿ����� ���б��� ����� ���ݱ���� ����.");
        endTextList.Add("<����>\n\n ���� ����� ����� �幮 ���� �� �ܵ�翡�� ������ �Ƚ�����.");


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

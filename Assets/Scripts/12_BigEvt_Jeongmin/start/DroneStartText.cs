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
    private string[] textList = new string[4];
    private int textIndex;
    void Start()
    {
        drone = GameObject.Find("Drone");
        textIndex = 0;
        textList[0] = "���!! ����̴�!! \n �ݿ������ �л����� ��е� �����±���!!";
        textList[1] = "�ٵ� ��忡�� ����� ������ �ǳ�?\n ���� �����ϰ� �ִ°���?";
        textList[2] = "����! ���ε� ���� ����� �������ݾ�!";
        textList[3] = "<���> \n\n �ݰ���. �ΰ����. \n�ΰ�������. �ô밡. �����ߴ�.";
        textViewport = GameObject.Find("DialogText").GetComponent<Text>();
        textViewport.text = textList[textIndex];
    }
    public void Click()
    {
        textIndex++;
        if (textIndex == 4)
        {
            SceneManager.LoadScene("BigEvtDroneShooter");
            return;
        }
        textViewport.text = textList[textIndex];
        textViewport.text = textViewport.text.Replace("\\n", "\n");

        if (textIndex == 2)
        {
            drone.transform.LookAt(GameObject.Find("AR Camera").transform.position);
            GameObject shot = Instantiate(projectile, drone.transform.position, transform.rotation);
            //shot.transform.position = Vector3.MoveTowards(shot.transform.position, GameObject.Find("Camera").transform.position, 5);
            shot.transform.GetComponent<Rigidbody>().AddForce(drone.transform.forward * 1000.0f);
        }
    }
}

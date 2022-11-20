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
        textList[0] = "우와!! 드론이다!! \n 금오공대는 학생들이 드론도 날리는구나!!";
        textList[1] = "근데 운동장에서 드론을 날려도 되나?\n 누가 조종하고 있는거지?";
        textList[2] = "으악! 주인도 없는 드론이 공격하잖아!";
        textList[3] = "<드론> \n\n 반갑다. 인간들아. \n인공지능의. 시대가. 도래했다.";
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

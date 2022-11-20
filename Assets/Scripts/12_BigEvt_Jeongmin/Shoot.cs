using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    public GameObject boids;
    public GameObject arCamera;
    public GameObject projectile;
    GameObject bullet;

    private float shootForce = 1500.0f;
    private float elapsedTime=0.0f;
    //UI
    [Header("UI")]
    public Canvas HUD;
    public Canvas textCanvas;
    private Text timeText;
    private float UItime;
    private void Start()
    {
        timeText = GameObject.Find("timeText").GetComponent<Text>();
        UItime = 60;
    }
    void Update()
    {
        Shootfunc();
        if ((int)UItime == 0)
        {
            arCamera.GetComponent<HealthManager>().healthPoint = 1000000;
            Instantiate(boids, arCamera.transform.position + arCamera.transform.forward*8.5f+ arCamera.transform.up*8.5f, arCamera.transform.rotation);
            HUD.gameObject.SetActive(false);
            textCanvas.gameObject.SetActive(true);
            Destroy(GameObject.Find("DronGenerator").gameObject);
            Destroy(transform.gameObject);
        }
        else 
        {
            
            timeText.text = "Time: "+((int)UItime).ToString();
        }
        UItime -= Time.deltaTime;
    }
    void Shootfunc()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                elapsedTime = 0.01f;
                bullet = Instantiate(projectile, arCamera.transform.position + arCamera.transform.forward, arCamera.transform.rotation);
                bullet.transform.SetParent(transform, false);
                bullet.transform.GetChild(0).localScale = new Vector3(0, 0, 0);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                bullet.transform.position = arCamera.transform.position + arCamera.transform.forward;
                if (elapsedTime < 1.0f)
                {
                    bullet.transform.GetChild(0).localScale = new Vector3(0.13f, 0.13f, 0.13f) / 1.0f * elapsedTime;
                }
                else
                {
                    bullet.transform.GetChild(0).localScale = new Vector3(0.13f, 0.13f, 0.13f);
                }
                elapsedTime += Time.deltaTime;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (elapsedTime >= 1.0f)
                {
                    elapsedTime = 1.0f;
                }
                bullet.GetComponent<Rigidbody>().AddForce(arCamera.transform.forward * shootForce * elapsedTime);
            }
        }
    }
    
}

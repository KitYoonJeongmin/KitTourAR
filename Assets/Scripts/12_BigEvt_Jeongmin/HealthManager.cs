using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Text healthText;
    private Image healthImg;
    public Image attackView;
    public int healthPoint=100;
    public GameObject effect;

    private void Start()
    {
        if(transform.tag == "MainCamera")
        {
            healthText = GameObject.Find("healthText").GetComponent<Text>();
            healthImg = GameObject.Find("HealthBar").GetComponent<Image>();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "Drone" && transform.tag == "MainCamera")//카메라가 드론에 맞았을 때
        {
            Instantiate(effect, transform.position, transform.rotation);//파티클 생성
            Destroy(other.gameObject);//드론 삭제
            healthPoint -= 15;//체력 감소
        }
        else if(other.transform.tag == "Projectile")//카메라가 발사체에 맞았을 때
        {
            if (transform.tag == "MainCamera") 
            {
                Destroy(other.gameObject);
                healthPoint -= 10; //체력감소
                if(healthPoint<100)
                {
                    attackView.transform.gameObject.SetActive(true);
                    healthText.text = healthPoint.ToString() + "/100";
                    healthImg.fillAmount = healthPoint * 0.01f;
                }
                if (healthPoint <= 0)
                {
                    SceneManager.LoadScene("BigEvtDroneEnd");
                }
            }
            else if (transform.name.Contains("Eagle"))
            {
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(other.transform.gameObject);
            }
            else if(transform.name == "back")
            {
                Destroy(other.gameObject);
            }
        }
        else if(other.transform.tag == "ProjectileMain")
        {
            if (transform.tag == "Drone") 
            {
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(other.gameObject);
                
                healthPoint -= 100;
                if (healthPoint <= 0)
                {
                    Destroy(transform.gameObject);
                }
            }
        }
        else if(other.transform.tag == "Drone")
        {
            if(transform.name.Contains("Eagle"))
            {
                Instantiate(effect, transform.position, transform.rotation);
                Destroy(other.transform.gameObject);
            }
        }

        

    }
}

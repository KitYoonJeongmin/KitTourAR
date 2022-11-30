using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = gameObject.GetComponent<Image>();
    }

    public void setHp(int health)
    {
        hpBar.fillAmount = health / 4f;
    }
}

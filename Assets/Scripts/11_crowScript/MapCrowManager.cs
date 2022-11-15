using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCrowManager : MonoBehaviour
{
    public CrowTrigger crowTrigger;
    public GameObject button;
    //public Button crowBtn;
    public Image image;

    [SerializeField]
    private Sprite[] sprites;

    void Start()
    {
        //crowBtn = transform.Find("Crow").GetComponent<Button>();
        button.SetActive(false);

        if (IsCatch.crowMap == true)
        {
            Debug.Log("hi");
            button.SetActive(true);
            image.sprite = sprites[IsCatch.crowImgNum];
        }
    }
}


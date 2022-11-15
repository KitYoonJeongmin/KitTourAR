using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCrowManager : MonoBehaviour
{
    CrowTrigger crowTrigger;

    private Button crowBtn;
    public Image image;

    [SerializeField]
    private Sprite[] sprites;

    void Start()
    {
        crowBtn = transform.Find("Crow").GetComponent<Button>();
        crowBtn.interactable = false;
    }

    void Update()
    {
        if (IsCatch.crowMap == true)
        {
            crowBtn.interactable = true;
            image.sprite = sprites[crowTrigger.crowIndex];
        }
    }
}


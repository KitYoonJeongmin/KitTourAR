using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowTrigger : MonoBehaviour
{
    private float fDestroyTime = 100f;
    private float fTickTime;

    CrowImgAry crowImgAry;

    public int crowIndex;
    private void Start()
    {
        if(PlayerPrefs.GetInt("Crow"+ crowIndex.ToString())==1) { gameObject.SetActive(false); }
    }
    
    private void Awake()
    {
        if (IsCatch.crowMap == 1 || IsCatch.crowMap == 2)
            gameObject.SetActive(false);

        fTickTime = 0;

    }

    private void Update()
    {
        fTickTime += Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (!(other.gameObject.tag == "mapCharacter")) { return; } //�浹�� object�� character�� �ƴϸ� return ������
        IsCatch.crowImgNum = crowIndex;
        gameObject.SetActive(false);

        if (IsCatch.crowMap == 2)
        {
            if (fTickTime >= fDestroyTime)
                gameObject.SetActive(true);
        }

        SceneManager.LoadScene("SamJocUI");      // 0 ��� ������ �̺�Ʈ �� �־��ֱ�
    }
}

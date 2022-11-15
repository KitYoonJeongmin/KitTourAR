using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrowTrigger : MonoBehaviour
{
    CrowImgAry crowImgAry;

    public int crowIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (IsCatch.crowMap == true)
        {
            IsCatch.crowImgNum = crowIndex;
            gameObject.SetActive(false);
            return;
        }

        SceneManager.LoadScene("SamJocUI");      // 0 ��� ������ �̺�Ʈ �� �־��ֱ�
    }
}

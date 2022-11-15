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
            gameObject.SetActive(false);
            return;
        }

        SceneManager.LoadScene(0);      // 0 ��� ������ �̺�Ʈ �� �־��ֱ�
    }
}

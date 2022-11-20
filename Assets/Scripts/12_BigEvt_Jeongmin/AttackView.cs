using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackView : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("NotActive", 0.5f);
    }
    void NotActive()
    {
        transform.gameObject.SetActive(false);
    }
}

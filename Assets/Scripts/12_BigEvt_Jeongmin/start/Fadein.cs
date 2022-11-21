using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fadein : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        transform.GetComponent<Image>().color = new Color(0, 0, 0, time);
        if(time<=0) { Destroy(this.transform.gameObject); }
    }
}

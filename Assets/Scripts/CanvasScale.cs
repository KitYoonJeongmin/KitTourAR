using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScale : MonoBehaviour
{
    // Start is called before the first frame update
    Canvas canvas;
    CanvasScaler thisCanvas;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        thisCanvas = canvas.GetComponent<CanvasScaler>();
        //Default �ػ� ����
        float fixedAspectRatio = 9f / 16f;

        //���� �ػ��� ����
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        //���� �ػ� ���� ������ �� �� ���
        if (currentAspectRatio > fixedAspectRatio) thisCanvas.matchWidthOrHeight = 0;
        //���� �ػ��� ���� ������ �� �� ���
        else if (currentAspectRatio < fixedAspectRatio) thisCanvas.matchWidthOrHeight = 1;
    }

}

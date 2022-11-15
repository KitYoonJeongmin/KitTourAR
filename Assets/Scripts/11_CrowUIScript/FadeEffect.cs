using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// ȭ�� ó�� ������ �� fadeȿ��
public enum FadeState { FadeIn=0,FadeOut, FadeInOut, FadeLoop, FadeOutIn}

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime; //fadeSpeed���� 10�̸� 1��(���� Ŭ���� ����)
    [SerializeField]
    private AnimationCurve fadeCurve;   //���̵� ȿ���� ����Ǵ� ���� ���� ��� ������ ����
    private Image image;    //���̵� ȿ���� ���Ǵ� ���� ���� �̹���
    private FadeState fadeState;    //���̵� ȿ�� ����

    private void Awake()
    {
        image = GetComponent<Image>();

        OnFade(FadeState.FadeIn);
    }

    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch(fadeState)
        {
            case FadeState.FadeIn:  //Fade In. ����� ���İ��� 1���� 0����(ȭ���� ���� �������)
                StartCoroutine(Fade(1, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1)); //Fade Out. ����� ���İ��� 0���� 1�� (ȭ���� ���� ��ο�����)
                break;
            case FadeState.FadeInOut:   //Fadeȿ���� In->Out 1ȸ �ݺ�
            case FadeState.FadeLoop:    //Fadeȿ���� In->Out ���� �ݺ�
                StartCoroutine(FadeInOut());
                break;
            case FadeState.FadeOutIn:   //Fadeȿ���� Out->In 1ȸ �ݺ�
                StartCoroutine(FadeOutIn());
                break;
        }
    }

    private IEnumerator FadeInOut()
    {
        while(true)
        {
            //�ڷ�ƾ ���ο��� �ڷ�ƾ �Լ��� ȣ���ϸ� �ش� �ڷ�ƾ �Լ��� ����Ǿ�� ���� ���� ����
            yield return StartCoroutine(Fade(1, 0));    //Fade In

            yield return StartCoroutine(Fade(0, 1));    //Fade Out

            //1ȸ�� ����ϴ� ������ �� break;
            if(fadeState == FadeState.FadeInOut)
            {
                break;
            }
        }
    }
    private IEnumerator FadeOutIn()
    {
        //�ڷ�ƾ ���ο��� �ڷ�ƾ �Լ��� ȣ���ϸ� �ش� �ڷ�ƾ �Լ��� ����Ǿ�� ���� ���� ����
        yield return StartCoroutine(Fade(0, 1));    //Fade In

        yield return StartCoroutine(Fade(1, 0));    //Fade Out
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent<1)
        {
            //fadeTime���� ����� fadeTime�ð� ����
            //percent ���� 0���� 1�� �����ϵ��� ��
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            //���İ��� start���� end���� fadeTime �ð� ���� ��ȭ��Ų��.
            Color color = image.color;
            //color.a = Mathf.Lerp(start, end, percent);
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;

            yield return null;
        }
    }
        
}
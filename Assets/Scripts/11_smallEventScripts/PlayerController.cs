using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject scanPlace;
    public SmallEventManager smallEventManager;

    // Start is called before the first frame update
    void Start()
    {
        //Place ������Ʈ�� �ǵ���� �� �ش� �Լ� ȣ��ǵ��� �̺�Ʈ ������־�� ��!!

        //��������: if(����ڰ� � ��ư�� ������ ��(�� �ǹ� ������ ��))
        //  smallEventManager.View(scanPlace); �Լ� ����

        // �����ڵ带 ���� �ۼ��ؾ� ��ư�� �ٽ� ������ �� text UI�� �����ϴ�.(<= text ī��Ʈ ����(textAryIndex) �����)
    }

    // Update is called once per frame
    void Update()
    {

        //�׽�Ʈ�� �ڵ��Դϴ�! �÷��̾���Ʈ�ѷ� ���� ��ũ��Ʈ���� ������Ʈ �Լ� ���� ���� �Լ� ���� ������ֽø� �˴ϴ�!
        if(Input.GetMouseButtonDown(0))
        {
            smallEventManager.View(scanPlace);
        }
    }
}

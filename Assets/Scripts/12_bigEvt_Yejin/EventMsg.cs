using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMsg : MonoBehaviour
{
    public Dictionary<int, string[]> eventData;
    // Start is called before the first frame update
    void Awake()
    {
        eventData = new Dictionary<int, string[]>();
        TextList();
    }

    void TextList()
    {
        eventData.Add(1, new string[] { "��! �������� �Ҿ���Ⱦ�...", "�б��� ���ƴٴϸ鼭 ã�ƺ���?", "(AR ȭ�鿡�� ���� �������� ���̸� ��ġ���ּ���!)" });
        eventData.Add(2, new string[] { "������ " + TimerManager.countReport.ToString() + "�� ã�Ҿ�!", "���� ������ ���� ���Ǵ� �����~" });
        eventData.Add(3, new string[] { "������ " + TimerManager.countReport.ToString() + "���� ���Ƕ� �����̾�!" });
        eventData.Add(4, new string[] { "������ �� �嵵 �� ã�Ҿ�...\n���� �� ������ ���� ����߰ڴ�." });

        //�̺�Ʈ ��ü ����
    }
}

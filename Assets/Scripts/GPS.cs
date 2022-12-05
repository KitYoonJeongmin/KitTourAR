using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{

    //�ؽ�Ʈ ui����
    public static GPS instance;

    public float maxWaitTime = 10.0f;
    public float resendTime = 1.0f;

    //��ħ�� ���� (y�� rotate�� ���)
    public static float magneticHeading;
    public static float trueHeading;

    //���� �浵 ����
    public float latitude = 0;
    public float longitude = 0;

    static public Vector3 unityCoor;
    public Vector3 un;
    float waitTime = 0;

    public bool receiveGPS = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        StartCoroutine(GPS_On());
    }

    //GPSó�� �Լ�
    public IEnumerator GPS_On()
    {
        //����,GPS��� �㰡�� ���� ���ߴٸ�, ���� �㰡 �˾��� ���
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                yield return null;
            }
        }

        //���� GPS ��ġ�� ���� ���� ������ ��ġ ������ ������ �� ���ٰ� ǥ��
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        //��ġ �����͸� ��û -> ���� ���
        Input.location.Start(2.0f, 1.0f);
        //��ħ�� Ȱ��ȭ
        Input.compass.enabled = true;

        //GPS ���� ���°� �ʱ� ���¿��� ���� �ð� ���� �����
        while (Input.location.status == LocationServiceStatus.Initializing && waitTime < maxWaitTime)
        {
            yield return new WaitForSeconds(1.0f);
            waitTime++;
        }


        //���ŵ� GPS �����͸� ȭ�鿡 ���/

        LocationInfo li = Input.location.lastData;
        latitude = li.latitude;
        longitude = li.longitude;


        //��ġ ���� ���� ���� üũ
        receiveGPS = true;

        //��ġ ������ ���� ���� ���� resendTime ������� ��ġ ������ �����ϰ� ���
        while (receiveGPS)
        {
            li = Input.location.lastData;
            latitude = li.latitude;
            longitude = li.longitude;
            //��ħ�� �� ��������
            if (Input.compass.headingAccuracy == 0 || Input.compass.headingAccuracy > 0)
            {
                magneticHeading = Input.compass.magneticHeading; // �ںϱ�
                trueHeading = Input.compass.trueHeading; // ������ �ϱ�
            }
            //ui�� ���

            //latitude = 36.14301f;
            //longitude = 128.3945f;
            unityCoor = GPSEncoder.GPSToUCS(latitude, longitude);
            
            //Debug.Log("hihi " + unityCoor.x.ToString() + " "+ unityCoor.z.ToString());
            yield return new WaitForSeconds(resendTime);
        }
    }
}

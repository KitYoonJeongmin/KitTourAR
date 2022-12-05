using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{

    //텍스트 ui변수
    public static GPS instance;

    public float maxWaitTime = 10.0f;
    public float resendTime = 1.0f;

    //나침반 각도 (y축 rotate에 사용)
    public static float magneticHeading;
    public static float trueHeading;

    //위도 경도 변경
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

    //GPS처리 함수
    public IEnumerator GPS_On()
    {
        //만일,GPS사용 허가를 받지 못했다면, 권한 허가 팝업을 띄움
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                yield return null;
            }
        }

        //만일 GPS 장치가 켜져 있지 않으면 위치 정보를 수신할 수 없다고 표시
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        //위치 데이터를 요청 -> 수신 대기
        Input.location.Start(2.0f, 1.0f);
        //나침반 활성화
        Input.compass.enabled = true;

        //GPS 수신 상태가 초기 상태에서 일정 시간 동안 대기함
        while (Input.location.status == LocationServiceStatus.Initializing && waitTime < maxWaitTime)
        {
            yield return new WaitForSeconds(1.0f);
            waitTime++;
        }


        //수신된 GPS 데이터를 화면에 출력/

        LocationInfo li = Input.location.lastData;
        latitude = li.latitude;
        longitude = li.longitude;


        //위치 정보 수신 시작 체크
        receiveGPS = true;

        //위치 데이터 수신 시작 이후 resendTime 경과마다 위치 정보를 갱신하고 출력
        while (receiveGPS)
        {
            li = Input.location.lastData;
            latitude = li.latitude;
            longitude = li.longitude;
            //나침반 값 가져오기
            if (Input.compass.headingAccuracy == 0 || Input.compass.headingAccuracy > 0)
            {
                magneticHeading = Input.compass.magneticHeading; // 자북극
                trueHeading = Input.compass.trueHeading; // 지리적 북극
            }
            //ui에 출력

            //latitude = 36.14301f;
            //longitude = 128.3945f;
            unityCoor = GPSEncoder.GPSToUCS(latitude, longitude);
            
            //Debug.Log("hihi " + unityCoor.x.ToString() + " "+ unityCoor.z.ToString());
            yield return new WaitForSeconds(resendTime);
        }
    }
}

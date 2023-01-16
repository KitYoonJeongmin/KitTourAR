# 💙Kit Tour AR

>   **어플리케이션 필수 요구사항**
>
>   *   Android 7.0'Nougat' Version 이상
>   *   GPS 연결
>   *   디바이스 네트워크 연결

<br/>

## 시연 영상

[![[Unity5] 금오공과대학교 AR](https://user-images.githubusercontent.com/93882395/212685850-2a59688e-5e1c-44d1-a614-0a7375df6117.png)](https://www.youtube.com/watch?v=fs6GoU8HAss)

<br/>

## 소개

<img src="https://user-images.githubusercontent.com/93882395/212694065-f59d8669-f75e-44b7-912d-aed6bc57cdd3.png" alt="image" style="zoom: 50%;" />

사용자의 현실 위치에 따라 3D 맵과 상호작용할 수 있는 어플리케이션입니다! 교내 건물에 다가가 AR 화면으로 전환하면 각 건물에 해당하는 설명과 재미를 주는 여러 이벤트를 발견할 수 있습니다.😊

<br/>

## 주요 기능

1.   **교내 건물 안내**

     <img src="https://user-images.githubusercontent.com/93882395/212695766-8dcf2f3a-f0f4-47b7-a601-87be6a297a7d.gif" alt="프레젠테이션2" width="20%" height="20%" /> 

     교내 건물에 대한 설명과 관련 활동을 안내해 아직 학교가 익숙하지 않은 학생들의 적응을 돕습니다.

     <br/>

2.   **미니 게임**

     <img src="https://user-images.githubusercontent.com/93882395/212694661-f78cc9e4-41c3-48f9-bdc9-c1ec68d9f6f5.gif" alt="프레젠테이션1-1 (2)" width="20%" height="20%" /><img src="https://user-images.githubusercontent.com/93882395/212694784-7b469987-6653-402c-9c21-1e804fbbf521.gif" alt="프레젠테이션1" width="20%" height="20%" /><img src="https://user-images.githubusercontent.com/93882395/212695859-232ec123-9a8f-4800-9545-e276095274a9.gif" alt="프레젠테이션3" width="20%" height="20%" /><img src="https://user-images.githubusercontent.com/93882395/212695867-0b7895b0-8b19-4af4-a0f5-796458dff37f.gif" alt="프레젠테이션4" width="20%" height="20%" /><img src="https://user-images.githubusercontent.com/93882395/212695878-251061d4-a149-4c20-a184-a36e117f268c.gif" alt="프레젠테이션5" width="20%" height="20%" />

     교내 부지마다 간단한 미니 게임을 제공합니다.🎮

     1.   **과제물 찾기 AR**: 제한 시간 내 하트 모양의 아이콘을 찾아 과제물 수집

     2.   **개구리와 리듬 게임**: 개구리와 대화 후 노래에 맞춰 리듬게임 진행

     3.   **안아줘요**: 화면의 화살표를 눌러 플레이어를 따라다니는 적 회피

     4.   **드론 슈팅 AR**: 발사체를 만들어 제한 시간 내 AR 화면에 생성되는 드론 제거

     <br/>

3.   **돌발 이벤트: 삼족오 출몰**

     <img src="https://user-images.githubusercontent.com/93882395/212701861-2e141edc-bd91-4bad-8842-c412242718fa.png" alt="image" /> 

     학교 이야깃거리와 어울리는 테마의 금오공대 마스코트가 돌발 출몰하는 이벤트입니다.

     <br/>

4.   **교내 이미지 트래킹**

     프로젝트 담당 교수님의 연구실 호실판을 AR 카메라로 촬영하면 연구실 정보와 홈페이지가 나타납니다.

<br/>

## 사용 설명  

1.   지도 화면에서 사용자와 이벤트 위치 확인 가능
     1.   이벤트는 `꽃` 아이콘으로 표시
     2.   특정 위치에서 `삼족오 잡기` 돌발 이벤트 발생

2.   `꽃` 아이콘 근처에서 AR 화면으로 전환 시 사용자 상호작용 이벤트 생성
     1.   **노란색 꽃**: 건물 정보 안내. 말풍선을 터치하면 다음 정보 제공
     2.   **주황색 꽃**: 미니 게임 시작

2.   게임 버튼 설명

     1.  `AR`:  AR화면으로 전환

     2.   `Menu`:  사용자 편의 기능

            1. `github`: 개발자 github 주소 이동

          2.   `Kit`금오공대 학교 홈페이지로 이동

          3.   `X`: 어플리케이션 종료

     2.   `🥚`: 수집한 삼족오 종류 확인

<br/>

## 오픈소스 활용

<img src="https://user-images.githubusercontent.com/93882395/212704071-d7fca7e8-202c-4d07-8dff-ef49f0123dcb.png" alt="image" style="zoom: 30%;" /> 

<br/>

## 역할 분담

**윤정민 [[KitYoonJeongmin](https://github.com/KitYoonJeongmin)]**

```
- 사용자 GPS 연동 및 GPS와 유니티 좌표 매핑
- 사용자 위치마다 실시간 아이콘 움직임 보간
- 위치별 Map 이벤트 오브젝트 생성 자동화 구현
- AR 이벤트 기능 구현(카메라, 레이캐스트, 이미지 트래킹)
- AR 슈팅 게임 오픈소스 활용 및 제작
```

**안예진 [[yj59](https://github.com/yj59)]**

```
- 데이터베이스 구축 후 프로젝트와 연동
- 이벤트/사용자 오브젝트 및 버튼 UI 제작
- 장소 정보 안내 이벤트 구현
- 돌발 이벤트 트리거 생성 및 UI 연동
- 과제물 찾기 AR 이벤트 구현
```

**권태연 [[Taetae1123](https://github.com/Taetae1123)]**

```
- 시작/로딩 화면 UI 제작
- 돌발 이벤트 씬 UI 생성 및 디자인 일괄
- 돌발 이벤트 진행 구현
- 이벤트마다 필요한 스토리와 디자인 전반
- 개구리 리듬 게임 디자인 및 구현 구현
```

**장정익 [[erldang](https://github.com/erldang)]**

```
- 구글 Map SDK 활용해 교내 지도 프리팹 구현
- 지도 Scene 환경 디자인 (인도, skybox 등)
- 삼족오 이벤트 결과와 인벤토리 연동
- 삼족오 인벤토리 UI 제작
- 2D게임 오픈소스 활용해 피하기 게임 제작
```


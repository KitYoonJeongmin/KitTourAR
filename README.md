# KitTourAR
오픈소스프로젝트(금오공과대학교 학교투어 AR Project) 사용법

**Team Universe**
- KitYoonJeongmin(팀장) : https://github.com/KitYoonJeongmin

요악  
이 리포지토리는 금오공과대학교를 처음 방문하거나 교내 지리가 낯선 학생 및 방문객들에게 학교에 대한 지리적 이해를 높여줄 수 있는 어플리케이션입니다. 추가적으로 안드로이드 7.0'Nougat'이상의 버전에서만 작동합니다. 또한 GPS의 위치와 서버에서 저장되어 있는 각 건물들의 위치를 받아오기위해 인터넷 연결이 필수적으로 되어 있어야 합니다.

#### 시연영상  
[![[Unity5] 금오공과대학교 AR](http://img.youtube.com/vi/fs6GoU8HAss/0.jpg)](https://www.youtube.com/watch?v=fs6GoU8HAss)


## 소개
***
아직 학교가 익숙하지 않은 학생들이 건물을 쉽게 찾을 수 있도록 해주고, 학교에 대한 정보를 제공함으로써 학교에 적응하는데 도움을 주는 어플리케이션 입니다. 학교를 AR로 투어하며 각 건물마다 정보를 알 수 있는 작은 이벤트들이 있습니다. 또한 흥미를 위해 건물마다 있는 이벤트 뿐만 아니라 소소하게 즐길 수 있는 미니게임과 사용자의 위치에 따라 특정위치를 지나게 될 경우 발생하게되는 이스터에그도 존재합니다.

## 주요기능
***
##### 1. 작은 이벤트  
 학교내에 있는 건물들을 기준으로하여 각 건물들에 대한 설명을 작성해 놓았다. 건물들에 다가가면 위치정보를 확인하고 지정해 놓은 위경도를 통해 일정거리 이상 가까워 질 경우 평평한 바닥에 이벤트 프리팹을 생성한다. 이렇게 생성된 이벤트 프리팹을 터치하면 각 건물들에대한 상세한 설명이나 해당 건물에서 할 수 있는 활동, 또는 관련된 시간표(예를 들면 식당운영시간이라던가 버스시간표 등) 등을 확인 할 수 있게 되어있다.  
 
 ![image](https://user-images.githubusercontent.com/37210406/206257596-1d836181-6a84-46e0-8921-3410503edd49.png)  
   
##### 2. 큰 이벤트  
 건물들과 별개로 어플리케이션 내에서 학교내 부지들 돌아다니다 보면 작은이벤트와는 조금 거리가 있는 특이한 이벤트 들이 존재한다. 이것들은 단순히 어플리케이션이 단순히 학교내 설명만을 가지고 있을 경우 지루해질것 같은 분위기를 환기시켜주기위해 간단한 미니게임으로 구성되어 있다. AR을 통한 슈팅게임이나 리듬게임같은 게임들이 존재하는데 자세한 게임들은 직접 플레이 하면서 찾아보면 더욱 재미있을 것이다.  
   
![image](https://user-images.githubusercontent.com/37210406/206258068-306c5c7e-f029-4e06-a1fb-0cc0ea147e9f.png)  
  
##### 3. 삼족오 이벤트  
 학교 내 부지를 돌아다니다 보면 눈에 보이는 이벤트들과 달리 어딘가 숨어있는 이스터에그로 학교의 마스코트인 삼족오가 숨어있다.(어디 숨겨져 있는지는 저도 몰라요 XD) 이 이스터에그 역시 특정위치의 위경도에 가까워지면 발생하는데 이때, 이 삼족오를 잡을경우 함께 다닐수 있습니다! 심지어 도감도 있으니 기회가 된다면 모든 삼족오들을 만나 도감을 채워보도록 해봐요.  
   
![image](https://user-images.githubusercontent.com/37210406/206258255-1b8f2c7c-346f-4536-a121-5bc1c2ac8ab5.png)  
  
##### 4. 캐릭터 GPS기능  
 사용자의 움직임은 사용자의 GPS의 정보를 받아와 현재 사용자의 위치를 지도에 표시해 줍니다. GPS의 정보는 사용자의 위치를 나타낼 뿐만 아니라 이벤트들의 활성화를 위해 사용됩니다.  
 추가적으로 사용된 GPS기능의 API는 다음과 같다.  
  #### GPS정보 받아오는 API  
 https://docs.unity3d.com/ScriptReference/LocationService.Start.html  
  #### GPS정보를 Unity 맵으로 변환해주는 API  
 https://github.com/MichaelTaylor3D/UnityGPSConverter/blob/master/GPSEncoder.cs  
  
#### 5. 이미지 트래킹 기능  
 GPS기능과 별개로 개발과정의 담당교수님인 최동수 교수님의 연구실 팻말을 AR카메라로 바라볼 경우 교수님의 연구실에 대한 정보를 얻으실수 있습니다!  
 사용된 API의 경우 유니티에서 제공되는 AR Foundation 인터페이스를 플랫폼에 맞게 구현하기 위해 AR코어를 사용했습니다.
  
  
## 어플리케이션 다운로드  
 우리의 멋진 어플리케이션의 경우 제시된 링크에서 다운받으실 수 있습니다.  
  https://www.dropbox.com/s/853jxb2w6ytjzx2/KitARTour.apk?dl=0  
  
## 사용방법  
***
1. 어플리케이션을 실행하면 시장버튼과 사용방법 버튼이 나온다.  
 1.1. 방법 버튼을 누르면 앱에 대한 간단한 설명이 나타난다.  
 1.2. 시작 버턴을 누를 경우 로딩 화면이 뜨며 지도에 현재 자신의 위치가 표시된다.  
  
2. 처음 시작지 사용자의 위치가 표시되어있는 지도화면이 나타난다.  
 2.1. 화면 우측하단에 있는 'AR' 버튼을 누를경우 AR화면으로 변경이된다.  
 2.2. 화면 좌측하단에 있는 메뉴 버튼을 누를경우 여러가지 버튼이 추가로 나타난다.  
  2.2.1. github 버튼은 github 주소로 이동할 수 있다.
  2.2.2. 금오공대 마크 버튼을 누를경우 금오공대 학교 홈페이지로 이동한다.  
  2.2.3. 'X' 버튼을 누를경우 종료할것인지 다시 확인하는 버튼이 출력되며 '그만할래요' 버튼을 터치할 시 앱을 종료시킨다.  
  
3. 지도화면에서는 이벤트의 위치를 확인 할 수 있다.  
 3.1.이벤트가 발생하는 곳은 꽃으로 표시된다.  
  3.1.1. 작은이벤트의 경우 노란꽃이다.  
  3.1.2. 큰 이벤트의 경우 주황꽃이다.  
  
4. 이벤트가 발생하는 위치에 도착시 AR화면으로 전환할 경우 화면에서 물체가 발생하는데 물체를 터치할 경우 각각의 이벤트를 실행하는 물체가 발생한다.  
 4.1. AR화면에서 이전의 지도화면으로 돌아가고 싶은경우 우측하단에 있는 버튼을 누르면 지도화면으로 화면이 전환된다.  
 4.2. 작은이벤트의 경우 별모양으로 물체가 발생한다.  
 4.3. 큰 이벤트의 경우 나비모양으로 물체가 발생한다.  
  
5. 작은이벤트의 발생시 AR화면에서 텍스트로 학교의 정보를 알려준다.  
 5.1. 텍스트UI를 터치할 경우 다음문장으로 넘어간다.  
  5.1.1. 텍스트UI와 별개로 선택할 버튼이 발생할 경우 버튼UI가 텍스트UI옆에 추가로 발생한다.  
 5.2. 문장이 끝날경우 텍스트 박스가 사라진다.  
  
6. 큰이벤트의 발생시 위치에 따라 각각 다른 미니게임이 발생된다.  
 6.1. 과제물 찾기게임  
  6.1.1. 이벤트 시작이후 화면에 보이는 하트모양의 아이콘을 찾아 이동한다.  
  6.1.2. 해당위치에서 AR화면을 전환하고 카메라화면을 바닥에 비출경우 문서그림이 발생하며 이를 터치할 경우 과제물을 습득한 것으로 처리된다.  
  6.1.3. 1~2과정을 반복하며 제한시간내에 최대한 많은 과제물을 습득하면 된다.  
 6.2. 리듬게임  
  6.2.1. 개구리와 간단한 대화를 한 후 리듬게임을 한다.  
  6.2.2. 리듬게임의 경우 연꽃잎모양의 아이콘이 빨간선에 왔을 때 해당하는 줄에 개구리 모양을 누르면 된다.  
 6.3. 피하기게임  
  6.3.1. 게임시작전 간단한 대사가 출력된다.  
  6.3.2. 대사가 끝날경우 바로 게임이 시작되며 화면 좌측하단에 있는 화살표를 눌러 플레이어를 움직여 플레이어 주변에 생성되는 적들을 피하면된다.  
 6.4. AR슈팅게임  
  6.4.1. 화면에 나타나는 드론을 따라가며 스토리를 진행하며 스토리가 끝난후 게임화면으로 전환된다.  
  6.4.2. 게임화면에선 화면을 길게 터치하여 발사체를 생성하고 터치를 떼는순간 발사체가 발사되며 이를 통해 게임에 생성되는 드론들을 제거한다.  
  
7. 삼족오이벤트의경우 지도에 표시되지않지만 정해진 위치를 지나게 될 경우 삼족오 이벤트가 발생하게 된다.  
 7.1. 우측상단에 삼족오의 모습이 도트로 출력되며 좌측상단에는 삼족오의 이름이 나타난다.  
 7.2. 선택지를 통해 삼족오를 잡거나 잡지않을 수 있다.  
  7.2.1. 잡는다는 선택지를 고를경우 우측하단에 있는 알 모양의 버튼을 통해 잡은 삼족오의 모습을 볼 수 있다.  
  7.2.2. 도망간다는 선택지를 고를경우 지도화면으로 돌아오게 되며 잡았다는 표시는 뜨지않는다.  

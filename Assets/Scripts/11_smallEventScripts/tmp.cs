using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class tmp : MonoBehaviour
{
    //다루게 될 텍스트 UI
    public Text textUi;

    // Start is called before the first frame update
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("smallEvent").Document("stadium"); //사용할 문서의 ID를 입력해줍니다.
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

        if (snapshot.Exists)
        {
            Dictionary<string, object> res = snapshot.ToDictionary();

            //가져올 필드의 Key값을 입력해줍니다. ToString 붙여주세요.
            textUi.text = res["text1"].ToString();
            textUi.text = textUi.text.Replace("\\n", "\n"); //줄바꿈표시

            //콘솔에 찍어보기 => 캔버스 출력 제대로 안 되면 로그 찍어보세요!
            //foreach (KeyValuePair<string, object> pair in city)
            //    Debug.Log(pair.Key + pair.Value);
        }
        else
        {   // 문서 ID가 검색되지 않을 경우(snapshot이 존재하지 않음, 파이어스토어 확인해보세요.)
            Debug.Log("Document " + snapshot.Id + " does not exist!");
        }
    }

        // Update is called once per frame
        void Update() {}
}

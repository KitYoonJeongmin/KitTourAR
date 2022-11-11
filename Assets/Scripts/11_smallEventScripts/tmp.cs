using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class tmp : MonoBehaviour
{
    //�ٷ�� �� �ؽ�Ʈ UI
    public Text textUi;

    // Start is called before the first frame update
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("smallEvent").Document("stadium"); //����� ������ ID�� �Է����ݴϴ�.
        DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

        if (snapshot.Exists)
        {
            Dictionary<string, object> res = snapshot.ToDictionary();

            //������ �ʵ��� Key���� �Է����ݴϴ�. ToString �ٿ��ּ���.
            textUi.text = res["text1"].ToString();
            textUi.text = textUi.text.Replace("\\n", "\n"); //�ٹٲ�ǥ��

            //�ֿܼ� ���� => ĵ���� ��� ����� �� �Ǹ� �α� ������!
            //foreach (KeyValuePair<string, object> pair in city)
            //    Debug.Log(pair.Key + pair.Value);
        }
        else
        {   // ���� ID�� �˻����� ���� ���(snapshot�� �������� ����, ���̾��� Ȯ���غ�����.)
            Debug.Log("Document " + snapshot.Id + " does not exist!");
        }
    }

        // Update is called once per frame
        void Update() {}
}

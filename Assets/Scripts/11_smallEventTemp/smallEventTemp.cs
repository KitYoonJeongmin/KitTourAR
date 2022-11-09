using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Firebase.Firestore;

public class smallEventTemp : MonoBehaviour
{
    public Text TextLegacy;

    // Start is called before the first frame update
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference outdoorTheaterRef = db.Collection("smallEvent").Document("outdoorTheater");
        DocumentSnapshot snap = await outdoorTheaterRef.GetSnapshotAsync();

        if (snap.Exists)
        {
            Dictionary<string, object> res = snap.ToDictionary();
            foreach(var item in res)
            {
                string txt = item.Key.ToString() + item.Value.ToString();
                Debug.Log(txt);
            }
        }
        else
        {
            string id = "Document " + snap.Id.ToString() + " does not exist!";
            Debug.Log(id);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

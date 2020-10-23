
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Collections;

public class firedatabase : MonoBehaviour
{
    public string myURL;
    DatabaseReference reference;

    private string jsonUser;
    private string jsonLink;
    private string tipeAcc;
    private string userId = "";

    static public firedatabase instance;

    void Start()
    {
        instance = this;
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(myURL);

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        /*
        LinkedAcc linkedAcc = new LinkedAcc("Google", "m.zeafarhan@gmail.com", "asuu");
        StartCoroutine(WriteNewUser("anaks", linkedAcc));
        */
    }

    public IEnumerator WriteNewUser(string username, LinkedAcc linkedAcc)
    {
        loadJumlahUser();
        while (userId == "") yield return new WaitUntil(() => userId != "");
        User user = new User(userId, linkedAcc);
        jsonUser = JsonUtility.ToJson(user);
        jsonLink = JsonUtility.ToJson(linkedAcc);
        tipeAcc = linkedAcc.tipeacc;

        reference.Child("users").Child(username).SetRawJsonValueAsync(jsonUser);
        Dictionary<string, object> mychild = new Dictionary<string,object>();
        mychild["/linkedacc"] = null;
        reference.Child("users").Child(username).UpdateChildrenAsync(mychild);
        mychild["/Linked"+linkedAcc.tipeacc+"/id"] = linkedAcc.id;
        mychild["/Linked"+linkedAcc.tipeacc+"/name"] = linkedAcc.name;
        mychild["/Linked"+linkedAcc.tipeacc+"/email"] = linkedAcc.email;
        mychild["/Linked"+linkedAcc.tipeacc+"/tipeacc"] = linkedAcc.tipeacc;
        reference.Child("users").Child(username).UpdateChildrenAsync(mychild);
        userId = "";
    }

    private void loadJumlahUser()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").ValueChanged += Firedatabase_ValueChanged;
    }

    private void Firedatabase_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        userId = e.Snapshot.ChildrenCount.ToString();
    }
}


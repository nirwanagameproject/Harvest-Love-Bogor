
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Collections;

public class Pemain { 
    
}


public class firedatabase : MonoBehaviour
{
    public string myURL;
    DatabaseReference reference;
    static public Firebase.Auth.FirebaseAuth auth;

    private string jsonUser;
    private string jsonLink;
    private string tipeAcc;
    private string userId = "";

    public Image loading;
    public GameObject pilihusername;
    public GameObject inputLogin;
    public GameObject buttonok;
    public Text textlogin;
    public string currentAuth;
    public string currentUsername;
    public string playerlevel;
    public Text textnamadanlevel;
    public bool jalan;
    public bool createaccount;
    public bool langsunglogin;
    public bool langsunglogin2;
    public bool nickudahterpakai;

    static public firedatabase instance;

    void Start()
    {
        instance = this;
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(myURL);

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        //LinkedAcc linkedAcc = new LinkedAcc("Google", "m.zeafarhan@gmail.com", "asuu","2132131232");
        //StartCoroutine(WriteNewUser("anaks", linkedAcc));
        //auth.SignOut();

        //cekuserexist("Facebook", "10217132794112246");
        InvokeRepeating("loadinggif", 0f, 0.15f);
    }

    void Update()
    {
        if (jalan)
        {
            openUsername();
            jalan = false;
        }
        if (createaccount)
        {
            buttonok.gameObject.SetActive(false);
            loading.gameObject.SetActive(true);
            StartCoroutine(WriteNewUser(currentUsername, new LinkedAcc(currentAuth, auth.CurrentUser.Email, auth.CurrentUser.DisplayName, auth.CurrentUser.UserId)));
            createaccount = false;
        }
        if (langsunglogin)
        {
            cekatributplayer(currentUsername);
            langsunglogin = false;
        }
        if (nickudahterpakai)
        {
            loading.gameObject.SetActive(false);
            StartCoroutine(tampilkantext("Username sudah terpakai"));
            nickudahterpakai = false;
        }
        if (langsunglogin2)
        {
            textnamadanlevel.text = currentUsername + "\nlevel " + playerlevel;
            loading.gameObject.SetActive(false);
            MainMenuController.instance.loginmultiplayerOBJ.SetActive(false);
            MainMenuController.instance.ClickMultiPlayer();
            langsunglogin2 = false;
        }

    }

    void loadinggif()
    {
        loading.gameObject.transform.eulerAngles = new Vector3(loading.transform.eulerAngles.x, loading.transform.eulerAngles.y, loading.transform.eulerAngles.z - 30);
    }

    public IEnumerator WriteNewUser(string username, LinkedAcc linkedAcc)
    {
        loadJumlahUser();
        while (userId == "") yield return new WaitUntil(() => userId != "");
        User user = new User(userId, null);
        jsonUser = JsonUtility.ToJson(user);
        jsonLink = JsonUtility.ToJson(linkedAcc);
        tipeAcc = linkedAcc.tipeacc;

        //reference.Child("users").Child(username).SetRawJsonValueAsync(jsonUser);
        Dictionary<string, object> mychild = new Dictionary<string, object>();
        mychild["/id"] = userId;
        mychild["/level"] = "1";
        reference.Child("users").Child(username).UpdateChildrenAsync(mychild);
        reference.Child("linkedacc").Child(linkedAcc.tipeacc).Child(username).SetRawJsonValueAsync(jsonLink);

        buttonok.SetActive(true);
        loading.gameObject.SetActive(false);
        pilihusername.SetActive(false);
        langsunglogin = true;
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

    public void openUsername()
    {
        MainMenuController.instance.notifkonek.SetActive(false);
        pilihusername.gameObject.SetActive(true);
    }

    public void bikinAccount()
    {
        string inputField = inputLogin.GetComponent<InputField>().text;
        if (inputField.Length == 0) StartCoroutine(tampilkantext("Nama tidak boleh kosong"));
        else if(inputField.Length > 10) StartCoroutine(tampilkantext("Username terlalu panjang"));
        else cekuserexist(inputLogin.GetComponent<InputField>().text);
    }

    public void signout()
    {
        auth.SignOut();
    }

    IEnumerator tampilkantext(string textku)
    {
        textlogin.text = textku;
        loading.gameObject.SetActive(false);
        textlogin.gameObject.SetActive(true);
        buttonok.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        textlogin.gameObject.SetActive(false);
        buttonok.gameObject.SetActive(true);
    }

    public void cekuserexist(string username)
    {
        loading.gameObject.SetActive(true);
        buttonok.gameObject.SetActive(false);
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(username)
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.Log("error"); // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot users = task.Result;
                  if (users.GetRawJsonValue() == null)
                  {
                      Debug.Log("Bisa bikin "+ auth.CurrentUser.ProviderId +" - "+ auth.CurrentUser.ProviderData);
                      createaccount = true;currentUsername = username;
                      
                  }else if(users.Key.ToString() == username)
                  {
                      nickudahterpakai = true;
                  }
              }
          });
    }

    public void cekatributplayer(string username)
    {
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(username)
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.Log("error"); // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  Debug.Log("masuk sini");
                  DataSnapshot users = task.Result;
                  playerlevel = users.Child("level").Value.ToString();
                  langsunglogin2 = true;
              }
          });
    }

    public void cekidexist(string linkedacc, string id)
    {
        Debug.Log(linkedacc + " - " + id);
        FirebaseDatabase.DefaultInstance
          .GetReference("linkedacc").Child(linkedacc).OrderByChild("id").EqualTo(id)
          .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              Debug.Log("error"); // Handle the error...
          }
          else if (task.IsCompleted)
          {
                  DataSnapshot linkacc = task.Result;
                  Debug.Log(linkacc.GetRawJsonValue());
                  if (linkacc.GetRawJsonValue() == null || linkacc.GetRawJsonValue()=="{}")
                  {
                      jalan = true;
                      currentAuth = linkedacc;
                  }
                  else
                  if (linkacc.HasChildren)
                      foreach (var users in linkacc.Children)
                      {
                          currentAuth = linkedacc;
                          currentUsername = users.Key;
                          langsunglogin = true;
                          break;
                      }
              }
          });
    }
}


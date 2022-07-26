
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System.Collections;
using Firebase.Storage;
using UnityEngine.Networking;
using Firebase.Extensions;
using System.Linq;

public class Pemain { 
    
}


public class firedatabase : MonoBehaviour
{
    public string myURL;
    public DatabaseReference reference;
    static public Firebase.Auth.FirebaseAuth auth;

    private string jsonUser;
    private string jsonLink;
    private string tipeAcc;
    private string userId = "";

    public Image loading;
    public GameObject pilihusername;
    public GameObject inputLogin;
    public GameObject buttonok;
    public GameObject notifPanel;
    public GameObject isiInventory;
    public GameObject ButtonUang;
    public GameObject ButtonBarang;
    public GameObject isiShop;
    public GameObject isiFriendList;
    public GameObject ButtonFriend;
    public GameObject ButtonAddFriend;
    public GameObject ButtonRequest;
    public GameObject ButtonUangShop;
    public GameObject ButtonBarangShop;
    public GameObject notifKonfirmRemoveFriend;
    public GameObject notifAddFriend;
    public GameObject inputusernameAddFriend;
    public Text textlogin;
    public string currentAuth;
    public string currentUsername;
    private string currentEmail;
    public string playerlevel;
    public Text textnamadanlevel;
    public bool jalan;
    public bool createaccount;
    public bool langsunglogin;
    public bool langsunglogin2;
    public bool nickudahterpakai;
    public bool task1return;
    bool muterloading;
    public DataSnapshot snapshot;

    static public firedatabase instance;

    FirebaseStorage storage;
    public StorageReference storageReference;

    public IEnumerator LoadImage(string MediaUrl, RawImage imageProduk)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl); //Create a request
        yield return request.SendWebRequest(); //Wait for the request to complete
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            imageProduk.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            muterloading = false;
            for (int i = 0; i < isiShop.transform.childCount; i++)
            {
                isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles = new Vector3(isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.x, isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.y, 0f);
            }
            // setting the loaded image to our object
        }
    }

    void Start()
    {
        instance = this;
        // Set this before calling into the realtime database.
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(myURL);
        AppOptions options = new AppOptions();
        Uri uri = new Uri(myURL);
        options.DatabaseUrl = uri;
        FirebaseApp app = FirebaseApp.Create(options);

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        //initialize storage reference
        storage = FirebaseStorage.DefaultInstance;
        storageReference = storage.GetReferenceFromUrl("gs://harvest-love-bogor-59519622.appspot.com/");

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
            StartCoroutine(WriteNewUser(currentUsername, new LinkedAcc(currentAuth, currentEmail, auth.CurrentUser.DisplayName, auth.CurrentUser.UserId)));
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
            StartCoroutine(UpdateLastLogin());
            langsunglogin2 = false;
        }
        

    }

    void FixedUpdate()
    {
        if (muterloading)
        {
            float kecepatanmuter = 2f;
            for (int i = 0; i < isiShop.transform.childCount; i++)
            {
                isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles = new Vector3(isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.x, isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.y, isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.z + kecepatanmuter);    
            }
            for (int i = 0; i < isiFriendList.transform.childCount; i++)
            {
                isiFriendList.transform.GetChild(i).GetChild(0).transform.eulerAngles = new Vector3(isiFriendList.transform.GetChild(i).GetChild(0).transform.eulerAngles.x, isiFriendList.transform.GetChild(i).GetChild(0).transform.eulerAngles.y, isiFriendList.transform.GetChild(i).GetChild(0).transform.eulerAngles.z + kecepatanmuter);
                isiFriendList.transform.GetChild(i).GetChild(1).transform.eulerAngles = new Vector3(isiFriendList.transform.GetChild(i).GetChild(0).transform.eulerAngles.x, isiFriendList.transform.GetChild(i).GetChild(0).transform.eulerAngles.y, isiFriendList.transform.GetChild(i).GetChild(0).transform.eulerAngles.z + kecepatanmuter);
            }
        }
    }

    void loadinggif()
    {
        loading.gameObject.transform.eulerAngles = new Vector3(loading.transform.eulerAngles.x, loading.transform.eulerAngles.y, loading.transform.eulerAngles.z - 30);
    }

    public IEnumerator UpdateLastLogin()
    {
        Dictionary<string, object> mychild = new Dictionary<string, object>();
        mychild["/lastlogin"] = getTimeInIndonesia().ToString();
        reference.Child("users").Child(currentUsername).UpdateChildrenAsync(mychild);
        yield return new WaitForSeconds(15f);
        if(currentAuth!=null && currentUsername!=null && auth.CurrentUser!=null)
        StartCoroutine(UpdateLastLogin());
    }

    public IEnumerator WriteNewUser(string username, LinkedAcc linkedAcc)
    {
        loadJumlahUser();
        while (userId == "") yield return new WaitUntil(() => userId != "");
        User user = new User(userId, null);
        jsonUser = JsonUtility.ToJson(user);
        jsonLink = JsonUtility.ToJson(linkedAcc);
        tipeAcc = linkedAcc.tipeacc;

        //ADD ID LEVEL LAST LOGIN
        Dictionary<string, object> mychild = new Dictionary<string, object>();
        mychild["/id"] = userId;
        mychild["/level"] = "1";
        mychild["/lastlogin"] = getTimeInIndonesia();
        reference.Child("users").Child(username).UpdateChildrenAsync(mychild);

        //ADD CURRENCY AND HAT
        mychild = new Dictionary<string, object>();
        mychild["/kelereng"] = "0";
        mychild["/kelerengemas"] = "0";
        reference.Child("users").Child(username).Child("currency").UpdateChildrenAsync(mychild);

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

    public DateTime getTimeInIndonesia()
    {
        DateTime dt = DateTime.Now;
        dt = TimeZone.CurrentTimeZone.ToUniversalTime(dt);
        dt = dt.Add(TimeSpan.FromHours(7));
        return dt;
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
                  Debug.Log("masuk sini "+ username);
                  DataSnapshot users = task.Result;
                  playerlevel = users.Child("level").Value.ToString();
                  langsunglogin2 = true;
              }
          });
    }

    void TASK1CEKID(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        Debug.Log(args.Snapshot.GetRawJsonValue());
        snapshot = args.Snapshot;
        task1return = true;
        // Do something with the data in args.Snapshot
    }

    public void cekIDGoogle(string linkedacc, string id, string myEmail)
    {
        Debug.Log("CEKIDGOOGLE " + linkedacc + " - " + id + " - " + myEmail);
        string awallinkedacc = linkedacc;
        //TASK ID 1
        FirebaseDatabase.DefaultInstance
          .GetReference("linkedacc").Child(linkedacc).OrderByChild("id").EqualTo(id)
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.Log("error"); // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  if (task.Result.GetRawJsonValue() == null)
                  {
                      //TASK ID 2
                      if (linkedacc.Equals("Facebook")) linkedacc = "Google";
                      else if (linkedacc.Equals("Google")) linkedacc = "Facebook";
                      FirebaseDatabase.DefaultInstance
                      .GetReference("linkedacc").Child(linkedacc).OrderByChild("id").EqualTo(id)
                      .GetValueAsync().ContinueWith(task2 => {
                          if (task2.IsFaulted)
                          {
                              Debug.Log("error"); // Handle the error...
                          }
                          else if (task2.IsCompleted)
                          {
                              if (task2.Result.GetRawJsonValue() == null)
                              {
                                  //TASK EMAIL 3
                                  if (linkedacc.Equals("Facebook")) linkedacc = "Google";
                                  else if (linkedacc.Equals("Google")) linkedacc = "Facebook";
                                  FirebaseDatabase.DefaultInstance
                                  .GetReference("linkedacc").Child(linkedacc).OrderByChild("email").EqualTo(myEmail)
                                  .GetValueAsync().ContinueWith(task3 => {
                                      if (task3.IsFaulted)
                                      {
                                          Debug.Log("error"); // Handle the error...
                                      }
                                      else if (task3.IsCompleted)
                                      {
                                          if (task3.Result.GetRawJsonValue() == null)
                                          {
                                              //TASK EMAIL 4
                                              if (linkedacc.Equals("Facebook")) linkedacc = "Google";
                                              else if (linkedacc.Equals("Google")) linkedacc = "Facebook";
                                              FirebaseDatabase.DefaultInstance
                                              .GetReference("linkedacc").Child(linkedacc).OrderByChild("email").EqualTo(myEmail)
                                              .GetValueAsync().ContinueWith(task4 => {
                                                  if (task4.IsFaulted)
                                                  {
                                                      Debug.Log("error"); // Handle the error...
                                                  }
                                                  else if (task4.IsCompleted)
                                                  {
                                                      if (task4.Result.GetRawJsonValue() == null)
                                                      {
                                                          //CREATENEW USER
                                                          jalan = true;
                                                          currentAuth = awallinkedacc;
                                                          currentEmail = myEmail;
                                                      }
                                                      else
                                                      {
                                                          foreach (var child in task4.Result.Children)
                                                          {
                                                              if (child != null)
                                                              {
                                                                  //LOGIN
                                                                  currentAuth = linkedacc;
                                                                  currentUsername = child.Key;
                                                                  langsunglogin = true;
                                                              }
                                                          }
                                                      }
                                                  }
                                              });
                                          }
                                          else
                                          {
                                              foreach (var child in task3.Result.Children)
                                              {
                                                  if (child != null)
                                                  {
                                                      //LOGIN
                                                      currentAuth = linkedacc;
                                                      currentUsername = child.Key;
                                                      langsunglogin = true;
                                                  }
                                              }
                                          }
                                      }
                                  });
                              }
                              else
                              {
                                  foreach (var child in task2.Result.Children)
                                  {
                                      if (child != null)
                                      {
                                          //LOGIN
                                          currentAuth = linkedacc;
                                          currentUsername = child.Key;
                                          langsunglogin = true;
                                      }
                                  }
                              }
                          }
                      });
                  }
                  else
                  {
                      foreach (var child in task.Result.Children)
                      {
                          if (child != null)
                          {
                              //LOGIN
                              currentAuth = linkedacc;
                              currentUsername = child.Key;
                              langsunglogin = true;
                          }
                      }
                  }
              }
          });
    }

    string removefriend;
    //REMOVE FRIEND
    public void removeFriend(string name)
    {
        MainMenuController.instance.callAudioClicked();
        notifKonfirmRemoveFriend.gameObject.SetActive(true);
        notifKonfirmRemoveFriend.transform.Find("BotNotif").Find("TextNama").GetComponent<Text>().text = name+" ?";
        removefriend = name;
        MainMenuController.instance.ClickChangeLanguage(MainMenuController.instance.inputDropdownLanguage);
    }
    //BUTTON REMOVE FRIEND OK
    public void OKremove()
    {
        MainMenuController.instance.callAudioClicked();
        notifKonfirmRemoveFriend.gameObject.SetActive(false);
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(currentUsername).Child("friend").Child(removefriend).RemoveValueAsync();
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(removefriend).Child("friend").Child(currentUsername).RemoveValueAsync();
        StartCoroutine(cekFriendList("friend"));
        Debug.Log(name + " removed");
        MainMenuController.instance.ClickChangeLanguage(MainMenuController.instance.inputDropdownLanguage);
    }
    //BUTTON REMOVE FRIEND NO
    public void NOremove()
    {
        MainMenuController.instance.callAudioWrongClicked();
        notifKonfirmRemoveFriend.gameObject.SetActive(false);
        MainMenuController.instance.ClickChangeLanguage(MainMenuController.instance.inputDropdownLanguage);
    }
    //ACCEPT FRIEND REQ
    public void AcceptFriendReq(string name)
    {
        MainMenuController.instance.callAudioClicked();
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(currentUsername).Child("request").Child(name).RemoveValueAsync();
        Dictionary<string, object> mychild = new Dictionary<string, object>();
        mychild["/"+name] = "";
        reference.Child("users").Child(currentUsername).Child("friend").UpdateChildrenAsync(mychild);
        mychild = new Dictionary<string, object>();
        mychild["/" + currentUsername] = "";
        reference.Child("users").Child(name).Child("friend").UpdateChildrenAsync(mychild);
        StartCoroutine(cekFriendList("request"));
        MainMenuController.instance.ClickChangeLanguage(MainMenuController.instance.inputDropdownLanguage);
    }
    //DENY FRIEND REQ
    public void DenyFriendReq(string name)
    {
        MainMenuController.instance.callAudioClicked();
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(currentUsername).Child("request").Child(name).RemoveValueAsync();
        StartCoroutine(cekFriendList("request"));
        MainMenuController.instance.ClickChangeLanguage(MainMenuController.instance.inputDropdownLanguage);
    }
    //ADD FRIEND
    public void AddFriend()
    {
        MainMenuController.instance.callAudioClicked();
        notifAddFriend.gameObject.SetActive(true);
        MainMenuController.instance.GantiBahasa();
    }
    //BACK ADD FRIEND
    public void BatalAddFriend()
    {
        MainMenuController.instance.callAudioClicked();
        notifAddFriend.gameObject.SetActive(false);
        MainMenuController.instance.ClickChangeLanguage(MainMenuController.instance.inputDropdownLanguage);
    }
    DataSnapshot datacari;
    bool ketemu;
    //ADD FRIEND TAMBAHKAN
    public void AddFriendTambahkan()
    {
        string username = inputusernameAddFriend.GetComponent<Text>().text;
        if (username.Equals("") || username.Equals(currentUsername))
        {
            MainMenuController.instance.callAudioWrongClicked();
            string inputField = inputusernameAddFriend.GetComponent<Text>().text;
            if (inputField.Length == 0)
            {
                inputusernameAddFriend.transform.parent.parent.Find("ButtonOK").gameObject.SetActive(false);
                StartCoroutine(textAddFriend(100));
            }else
            if (username.Equals(currentUsername))
            {
                inputusernameAddFriend.transform.parent.parent.Find("ButtonOK").gameObject.SetActive(false);
                StartCoroutine(textAddFriend(102));
            }
            return;
        }
        MainMenuController.instance.callAudioClicked();
        inputusernameAddFriend.transform.parent.parent.Find("ButtonOK").gameObject.SetActive(false);
        inputusernameAddFriend.transform.parent.parent.Find("Loading").gameObject.SetActive(true);

        FirebaseDatabase.DefaultInstance
        .GetReference("users").Child(username)
        .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("error"); // Handle the error...
            }
            else if (task.IsCompleted)
            {
                if (task.Result.GetRawJsonValue() == null)
                {
                    Debug.Log("Tidak ada data " + task.Result.GetRawJsonValue());
                    datacari = task.Result;
                    ketemu = false;
                }
                else
                {
                    datacari = task.Result;
                    ketemu = true;
                    Debug.Log("RESULT CARI TEMEN: " + task.Result.GetRawJsonValue());
                }
            }
        });
        StartCoroutine(textAddFriend(101));
    }

    IEnumerator textAddFriend(int languagecode)
    {
        if (languagecode == 101)
        {
            yield return new WaitUntil(() => datacari != null);
            if (ketemu)
            {
                notifAddFriend.transform.Find("NotifPanel").gameObject.SetActive(true);
                notifAddFriend.transform.Find("NotifPanel").Find("BotNotif").Find("Username").GetComponent<Text>().text = datacari.Key;
                Dictionary<string, object> mychild = new Dictionary<string, object>();
                mychild["/"+currentUsername] = "";
                reference.Child("users").Child(datacari.Key).Child("request").UpdateChildrenAsync(mychild);
            }
        }
        inputusernameAddFriend.transform.parent.parent.Find("Loading").gameObject.SetActive(false);
        inputusernameAddFriend.transform.parent.parent.Find("Info").gameObject.SetActive(true);
        inputusernameAddFriend.transform.parent.parent.Find("Info").GetComponent<ChangeLanguage>().indexText = languagecode;
        inputusernameAddFriend.transform.parent.parent.Find("Info").GetComponent<ChangeLanguage>().ChangedLanguge();
        yield return new WaitForSeconds(2f);
        inputusernameAddFriend.transform.parent.parent.Find("ButtonOK").gameObject.SetActive(true);
        inputusernameAddFriend.transform.parent.parent.Find("Info").gameObject.SetActive(false);
        notifAddFriend.transform.Find("NotifPanel").gameObject.SetActive(false);
        ketemu = false;
        datacari = null;
    }

    //CEK FRIENDLIST AND REQUEST
    public IEnumerator cekFriendList(string tipe)
    {
        muterloading = true;
        notifPanel.gameObject.SetActive(true);
        DataSnapshot users = null;
        bool selesai = false;
        if (tipe.Equals("friend"))
        {
            ButtonFriend.transform.GetComponent<Image>().color = new Color(0.735849f, 0.6407826f, 0.4408152f);
            ButtonAddFriend.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
            ButtonRequest.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
        }
        else if (tipe.Equals("request"))
        {
            ButtonRequest.transform.GetComponent<Image>().color = new Color(0.735849f, 0.6407826f, 0.4408152f);
            ButtonAddFriend.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
            ButtonFriend.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
        }

        for (int i = 0; i < isiFriendList.transform.childCount; i++)
        {
            isiFriendList.transform.GetChild(i).gameObject.SetActive(true);
            var tempColor = isiFriendList.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color;
            tempColor.a = 1f;
            isiFriendList.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color = tempColor;
            isiFriendList.transform.GetChild(i).GetChild(0).transform.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/loading");
            isiFriendList.transform.GetChild(i).GetChild(1).transform.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/loading");
            isiFriendList.transform.GetChild(i).GetChild(2).transform.GetComponent<Text>().text = "";
            isiFriendList.transform.GetChild(i).GetChild(3).transform.GetComponent<Text>().text = "";
            isiFriendList.transform.GetChild(i).GetChild(4).transform.GetComponent<Text>().text = "";
            if (tipe.Equals("request"))
            {
                isiFriendList.transform.GetChild(i).GetChild(5).gameObject.SetActive(false);
                isiFriendList.transform.GetChild(i).GetChild(6).gameObject.SetActive(true);
                isiFriendList.transform.GetChild(i).GetChild(7).gameObject.SetActive(true);
            }
            else if(tipe.Equals("friend"))
            {
                isiFriendList.transform.GetChild(i).GetChild(5).gameObject.SetActive(true);
                isiFriendList.transform.GetChild(i).GetChild(6).gameObject.SetActive(false);
                isiFriendList.transform.GetChild(i).GetChild(7).gameObject.SetActive(false);
            }
        }
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(currentUsername).Child(tipe)
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.Log("error"); // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  users = task.Result;
                  if (users.GetRawJsonValue() == null)
                  {
                      Debug.Log("Tidak ada data " + users.GetRawJsonValue());

                  }
                  else
                  {
                      Debug.Log("MY FRIENDLIST: " + users.GetRawJsonValue());
                  }
              }
              selesai = true;
          });
        yield return new WaitUntil(() => selesai);
        selesai = false;
        int jumlahdata = 0;
        List<string> listuserfriend = new List<string>();
        List<string> listuserfriendnew = new List<string>();
        foreach (var childid in users.Children)
        {
            listuserfriend.Add(childid.Key);
            jumlahdata++;
        }
        Dictionary<string, int> friendku = new Dictionary<string, int>();
        for(int i=0; i<listuserfriend.Count;i++)
        FirebaseDatabase.DefaultInstance
        .GetReference("users").Child(listuserfriend[i]).OrderByChild("level")
        .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                Debug.Log("error"); // Handle the error...
            }
            else if (task.IsCompleted)
            {
                if (task.Result.GetRawJsonValue() == null)
                {
                    Debug.Log("Tidak ada data " + task.Result.GetRawJsonValue());

                }
                else
                {
                    Debug.Log("RESULT2: "+ task.Result.GetRawJsonValue());
                    friendku.Add(task.Result.Key+"-"+task.Result.Child("lastlogin").Value.ToString(), Int32.Parse(task.Result.Child("level").Value.ToString()));
                }
            }
        });
        yield return new WaitForDone(2f,() => (friendku.Count == listuserfriend.Count));
        int mulai = 0;
        if (friendku.ContainsValue(0) || friendku.Count < listuserfriend.Count)
        {
            Debug.Log("ULANG FRIENDLIST");
            StartCoroutine(cekFriendList("friend"));
            yield break;
        }
        foreach (var k in friendku.OrderByDescending(x => x.Value))
        {
            string[] subs = k.Key.Split('-');

            isiFriendList.transform.GetChild(mulai).GetChild(0).transform.eulerAngles = new Vector3(isiFriendList.transform.GetChild(mulai).GetChild(0).transform.eulerAngles.x, isiFriendList.transform.GetChild(mulai).GetChild(0).transform.eulerAngles.y, 0f);
            isiFriendList.transform.GetChild(mulai).name = subs[0];
            isiFriendList.transform.GetChild(mulai).GetChild(2).GetComponent<Text>().text = subs[0];
            isiFriendList.transform.GetChild(mulai).GetChild(3).GetComponent<Text>().text = "Level " + k.Value;
            DateTime timeUser = Convert.ToDateTime(subs[1]);
            DateTime dt = DateTime.Now;
            dt = dt.Add(TimeSpan.FromSeconds(-60));
            string onlinega;
            if (timeUser > dt)
            {
                onlinega = "Online";
                isiFriendList.transform.GetChild(mulai).GetChild(4).GetComponent<Text>().color = new Color(0.1902685f, 0.5471698f, 0.1522784f);
            }
            else
            {
                onlinega = "Offline";
                isiFriendList.transform.GetChild(mulai).GetChild(4).GetComponent<Text>().color = new Color(0.8679245f, 0.1269135f, 0.1559274f);
            }
            isiFriendList.transform.GetChild(mulai).GetChild(4).GetComponent<Text>().text = onlinega;
            isiFriendList.transform.GetChild(mulai).GetChild(1).transform.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/loading");
            var tempColor = isiFriendList.transform.GetChild(mulai).GetChild(0).GetComponent<RawImage>().color;
            tempColor.a = 0f;
            isiFriendList.transform.GetChild(mulai).GetChild(0).GetComponent<RawImage>().color = tempColor;
            mulai++;
        }
        //HILANGKAN SELAIN FRIEND
        for (;mulai<isiFriendList.transform.childCount;mulai++)
        {
            isiFriendList.transform.GetChild(mulai).gameObject.SetActive(false);
        }
        notifPanel.gameObject.SetActive(false);
        muterloading = false;
        MainMenuController.instance.ClickChangeLanguage(MainMenuController.instance.inputDropdownLanguage);
    }

    //CEK SHOP
    public IEnumerator cekShop(string tipe)
    {
        string tipechild = "";
        bool selesai = false;
        DataSnapshot users = null;
        if (tipe.Equals("money")) tipechild = "currency";
        else if (tipe.Equals("item")) tipechild = "item";
        notifPanel.gameObject.SetActive(true);
        MainMenuController.instance.GantiBahasa();

        for (int i = 0; i < isiShop.transform.childCount; i++)
        {
            isiShop.transform.GetChild(i).GetChild(0).transform.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/loading");
        }
        muterloading = true;
        FirebaseDatabase.DefaultInstance
          .GetReference("shop").Child(tipechild)
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.Log("error"); // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  users = task.Result;
                  if (users.GetRawJsonValue() == null)
                  {
                      Debug.Log("Tidak ada data " + users.GetRawJsonValue());

                  }
                  else
                  {
                      Debug.Log("Jumlah kelereng " + users.GetRawJsonValue());
                  }
              }
              selesai = true;
          });
        yield return new WaitUntil(() => selesai);
        int jumlahdatashop = 0;
        foreach (var child in users.Children)
        {
            foreach (var childid in child.Children)
            {
                jumlahdatashop++;
            }
        }

            if (tipe.Equals("money"))
            {
                ButtonUangShop.transform.GetComponent<Image>().color = new Color(0.735849f, 0.6407826f, 0.4408152f);
                ButtonBarangShop.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
            }
            else if (tipe.Equals("item"))
            {
                ButtonBarangShop.transform.GetComponent<Image>().color = new Color(0.735849f, 0.6407826f, 0.4408152f);
                ButtonUangShop.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
            }
            

            int mulai = 0;
            List<string> listproduk = new List<string>();
            
            foreach (var child in users.Children)
            {
                int idchild = 0;
                foreach (var childid in child.Children)
                {
                    isiShop.transform.GetChild(mulai).name = childid.Child("id").Value.ToString();
                    var tempColor = isiShop.transform.GetChild(mulai).GetChild(0).GetComponent<RawImage>().color;
                    tempColor.a = 1f;
                    isiShop.transform.GetChild(mulai).GetChild(0).GetComponent<RawImage>().color = tempColor;

                    if (tipe.Equals("money"))
                    {
                    isiShop.transform.GetChild(mulai).GetChild(1).GetComponent<Text>().text = "Rp " + childid.Child("price").Value.ToString() + " -> " + childid.Child("amount").Value;
                    }
                    else if (tipe.Equals("item"))
                    {
                    isiShop.transform.GetChild(mulai).GetChild(1).GetComponent<Text>().text = "Rp " + childid.Child("price").Value.ToString();
                    }
                    
                    isiShop.transform.GetChild(mulai).GetChild(2).GetComponent<Text>().text = childid.Child("judul").Value.ToString();

                    idchild++;
                    mulai++;

                    listproduk.Add(childid.Child("id").Value.ToString());

                    //END HILANGKAN SELAIN LIST DI SHOP
                    if (mulai >= (jumlahdatashop))
                        for (int i = mulai; i < isiShop.transform.childCount; i++)
                        {
                            tempColor = isiShop.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color;
                            tempColor.a = 0f;
                            isiShop.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color = tempColor;
                            isiShop.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
                            isiShop.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "";
                        }
                    if (mulai >= jumlahdatashop)
                    {
                        IAPManager.instance.InitializePurchasing(jumlahdatashop, listproduk);
                        int mulaidonlod = 0;

                        for (; mulaidonlod < jumlahdatashop; mulaidonlod++)
                        {
                            DownloadImageProduk(listproduk[mulaidonlod], mulaidonlod,tipe);
                        }


                    }

                }

            }
        
        notifPanel.gameObject.SetActive(false);
    }

    public void DownloadImageProduk(string listproduk, int mulaidonlod, string tipe)
    {
        Debug.Log(listproduk+" - "+ mulaidonlod + " - " + tipe );
        if (tipe.Equals("item")) { storageReference = storage.GetReferenceFromUrl("gs://harvest-love-bogor-59519622.appspot.com/item/");}
        else if (tipe.Equals("money")) { storageReference = storage.GetReferenceFromUrl("gs://harvest-love-bogor-59519622.appspot.com/");}
        StorageReference image = storageReference.Child(listproduk + ".png");
        //Get the download link of file
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                StartCoroutine(LoadImage(Convert.ToString(task.Result), isiShop.transform.GetChild(mulaidonlod).GetChild(0).GetComponent<RawImage>())); //Fetch file from the link
            }
            else
            {
                Debug.Log(task.Exception);
            }
        });
    }

    //CEK INVENTORY
    public IEnumerator cekInventory(string tipe)
    {
        string tipechild = "";
        bool selesai = false;
        DataSnapshot users = null;
        if (tipe.Equals("money")) tipechild = "currency";
        else if (tipe.Equals("item")) tipechild = "inventory";
        notifPanel.gameObject.SetActive(true);
        FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(currentUsername).Child(tipechild)
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.Log("error"); // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  users = task.Result;
                  if (users.GetRawJsonValue() == null)
                  {
                      Debug.Log("Tidak ada data " + users.GetRawJsonValue());

                  }
                  else
                  {
                      Debug.Log("Jumlah kelereng " + users.GetRawJsonValue());
                  }
              }
              selesai = true;
          });
        yield return new WaitUntil(() => selesai);
        if (tipe.Equals("money"))
        {
            ButtonUang.transform.GetComponent<Image>().color = new Color(0.735849f, 0.6407826f, 0.4408152f);
            ButtonBarang.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
            for (int i = 0; i < 2; i++)
            {
                var tempColor = isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color;
                tempColor.a = 1f;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color = tempColor;
            }
            isiInventory.transform.GetChild(0).GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/Gameplay UI/kelereng");
            isiInventory.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = users.Child("kelereng").Value.ToString();
            isiInventory.transform.GetChild(1).GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/Gameplay UI/kelerengemas");
            isiInventory.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = users.Child("kelerengemas").Value.ToString();
            for(int i=2;i< isiInventory.transform.childCount; i++)
            {
                var tempColor = isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color;
                tempColor.a = 0f;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color = tempColor;
                isiInventory.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
            }
        }else if (tipe.Equals("item"))
        {
            ButtonBarang.transform.GetComponent<Image>().color = new Color(0.735849f, 0.6407826f, 0.4408152f);
            ButtonUang.transform.GetComponent<Image>().color = new Color(1f, 0.8858795f, 0.6462264f);
            for (int j=0;j<10;j++)
            {
                var tempColor = isiInventory.transform.GetChild(j).GetChild(0).GetComponent<RawImage>().color;
                tempColor.a = 0f;
                isiInventory.transform.GetChild(j).GetChild(0).GetComponent<RawImage>().color = tempColor;
                isiInventory.transform.GetChild(j).GetChild(1).GetComponent<Text>().text = "";
            }
            
            int i = 0;
            foreach (var child in users.Child("topi").Children)
            {
                var tempColor = isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color;
                tempColor.a = 1f;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color = tempColor;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/Topi/"+ child.Key);
                isiInventory.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = child.Value.ToString();
                i++;
            }
            foreach (var child in users.Child("baju").Children)
            {
                var tempColor = isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color;
                tempColor.a = 1f;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color = tempColor;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/Baju/" + child.Key);
                isiInventory.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = child.Value.ToString();
                i++;
            }
            foreach (var child in users.Child("celana").Children)
            {
                var tempColor = isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color;
                tempColor.a = 1f;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().color = tempColor;
                isiInventory.transform.GetChild(i).GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/Celana/" + child.Key);
                isiInventory.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = child.Value.ToString();
                i++;
            }
        }
        notifPanel.gameObject.SetActive(false);
    }
}

public sealed class WaitForDone : CustomYieldInstruction
{
    private Func<bool> m_Predicate;
    private float m_timeout;
    private bool WaitForDoneProcess()
    {
        m_timeout -= Time.deltaTime;
        return m_timeout <= 0f || m_Predicate();
    }

    public override bool keepWaiting => !WaitForDoneProcess();

    public WaitForDone(float timeout, Func<bool> predicate)
    {
        m_Predicate = predicate;
        m_timeout = timeout;
    }
}


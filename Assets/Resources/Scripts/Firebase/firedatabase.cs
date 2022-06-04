
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
    public GameObject ButtonUangShop;
    public GameObject ButtonBarangShop;
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
            langsunglogin2 = false;
        }
        if (muterloading)
        {
            for (int i = 0; i < isiShop.transform.childCount; i++)
            {
                isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles = new Vector3(isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.x, isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.y, isiShop.transform.GetChild(i).GetChild(0).transform.eulerAngles.z+0.5f);
            }
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

    /*
    public IEnumerator cekidexist(string linkedacc, string id, string email)
    {
        //TASK ID 1
        Debug.Log(linkedacc + " - " + id + " - " + email);
        Debug.Log("TASK ID 1");
        string awallinkedacc = linkedacc;
        FirebaseDatabase.DefaultInstance
          .GetReference("linkedacc").Child(linkedacc).OrderByChild("id").EqualTo(id).ValueChanged += TASK1CEKID;
        yield return new WaitUntil(() => task1return);
        Debug.Log("TASK ID GAS "+ snapshot.HasChildren);
        if (snapshot.HasChildren)
            foreach(var child in snapshot.Children)
            {
                if (child != null)
                {
                    //LOGIN
                    currentAuth = linkedacc;
                    currentUsername = child.Key;
                    langsunglogin = true;
                    Debug.Log(child.Key);
                }
            }
        else
        {
            //TASK ID 2
            Debug.Log("TASK ID 2");
            task1return = false;
            if (linkedacc.Equals("Facebook")) linkedacc = "Google";
            else if (linkedacc.Equals("Google")) linkedacc = "Facebook";
            FirebaseDatabase.DefaultInstance
          .GetReference("linkedacc").Child(linkedacc).OrderByChild("id").EqualTo(id).ValueChanged += TASK1CEKID;
            yield return new WaitUntil(() => task1return);
            if (snapshot.HasChildren)
                foreach (var child in snapshot.Children)
                {
                    if (child != null)
                    {
                        //LOGIN
                        currentAuth = linkedacc;
                        currentUsername = child.Key;
                        langsunglogin = true;
                    }
                }
            else
            {
                //TASK ID 3
                Debug.Log("TASK EMAIL 3");
                task1return = false;
                if (linkedacc.Equals("Facebook")) linkedacc = "Google";
                else if (linkedacc.Equals("Google")) linkedacc = "Facebook";
                FirebaseDatabase.DefaultInstance
              .GetReference("linkedacc").Child(linkedacc).OrderByChild("email").EqualTo(email).ValueChanged += TASK1CEKID;
                yield return new WaitUntil(() => task1return);
                if (snapshot.HasChildren)
                    foreach (var child in snapshot.Children)
                    {
                        if (child != null)
                        {
                            //LOGIN
                            currentAuth = linkedacc;
                            currentUsername = child.Key;
                            langsunglogin = true;
                        }
                    }
                else
                {
                    //TASK ID 4
                    Debug.Log("TASK EMAIL 4");
                    task1return = false;
                    if (linkedacc.Equals("Facebook")) linkedacc = "Google";
                    else if (linkedacc.Equals("Google")) linkedacc = "Facebook";
                    FirebaseDatabase.DefaultInstance
                  .GetReference("linkedacc").Child(linkedacc).OrderByChild("email").EqualTo(email).ValueChanged += TASK1CEKID;
                    yield return new WaitUntil(() => task1return);
                    if (snapshot.HasChildren)
                        foreach (var child in snapshot.Children)
                        {
                            if (child != null)
                            {
                                //LOGIN
                                currentAuth = linkedacc;
                                currentUsername = child.Key;
                                langsunglogin = true;
                            }
                        }
                    else
                    {
                        //CREATENEW USER
                        jalan = true;
                        currentAuth = awallinkedacc;
                        currentEmail = email;
                    }
                }
            }
        }
    }*/

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

    //CEK SHOP
    public IEnumerator cekShop(string tipe)
    {
        string tipechild = "";
        bool selesai = false;
        DataSnapshot users = null;
        if (tipe.Equals("money")) tipechild = "currency";
        else if (tipe.Equals("item")) tipechild = "item";
        notifPanel.gameObject.SetActive(true);

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


using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Gamesetupcontroller : MonoBehaviourPunCallbacks
{
    public GameObject mycharcewe;
    public GameObject mycharcowo;
    public GameObject transisi;
    public AudioClip myclipspring;
    public AudioClip myclipsummer;
    public AudioClip myclipfall;
    public AudioClip myclipwinter;
    public AudioClip myclipnight;

    public Texture cewek;
    public Texture cowok;
    public Sprite[] weather;

    public GameObject[] gameObjects;

    public GameObject go;

    public GameObject waitingother;
    public GameObject waitingother2;

    public bool minFoV;
    public bool minFoVClothes;
    public bool maxFoVClothes;
    public bool maxFoV;

    static public Gamesetupcontroller instance;

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        
        PlayerPrefs.SetInt("tanggal",int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString()));
        PlayerPrefs.SetString("musim",PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString());
        PlayerPrefs.SetInt("tahun",int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString()));

        GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString();
        GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString();

        
        setmusic();

        if (propertiesThatChanged.ContainsKey("tanggal"))
        {
            Image mymusim = GameObject.Find("Canvas").transform.Find("UIKiri").Find("Weather").GetComponent<Image>();
            Text dateskrg = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDate").GetComponent<Text>();
            string hariskrg = "";
            if(PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString()=="Senin") hariskrg = ChangeLanguage.instance.GetLanguage(108);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Selasa") hariskrg = ChangeLanguage.instance.GetLanguage(109);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Rabu") hariskrg = ChangeLanguage.instance.GetLanguage(110);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Kamis") hariskrg = ChangeLanguage.instance.GetLanguage(111);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Jumat") hariskrg = ChangeLanguage.instance.GetLanguage(112);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Sabtu") hariskrg = ChangeLanguage.instance.GetLanguage(113);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Minggu") hariskrg = ChangeLanguage.instance.GetLanguage(114);
            dateskrg.text = hariskrg + ", "+ PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString();
            if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Spring") mymusim.sprite = weather[0];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Summer") mymusim.sprite = weather[1];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Fall") mymusim.sprite = weather[2];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Winter") mymusim.sprite = weather[3];
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString();
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString();
        }
        

        if (propertiesThatChanged.ContainsKey("jumlahMauTidur"))
        { 
            GameObject.Find("Canvas").transform.Find("TextNotif").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("TextNotif").GetComponent<Text>().text = PlayerPrefs.GetString("ygngajakBobo") + " nyuruh kalian untuk tidur (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
            if (PlayerPrefs.GetString("level") == "MasukRumah")
                if (propertiesThatChanged.ContainsKey("Bed11") || propertiesThatChanged.ContainsKey("Bed12"))
                    waitingother.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Menunggu pemain lain untuk tidur  (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
                else if (propertiesThatChanged.ContainsKey("Bed21") || propertiesThatChanged.ContainsKey("Bed22"))  waitingother2.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Menunggu pemain lain untuk tidur  (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";

            
        }

        //SET CHICKEN FOOD DINDING
        if (propertiesThatChanged.ContainsKey("ChickenFood") && PlayerPrefs.GetString("level")=="MasukKandangAyam")
        {
            GameObject.Find("Barang").transform.Find("Pakan").Find("JumlahPakan").GetComponent<TextMesh>().text = PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"].ToString();
        }
        if (propertiesThatChanged.ContainsKey("CowFood") && PlayerPrefs.GetString("level") == "MasukKandangSapi")
        {
            GameObject.Find("Barang").transform.Find("Pakan").Find("JumlahPakan").GetComponent<TextMesh>().text = PhotonNetwork.CurrentRoom.CustomProperties["CowFood"].ToString();
        }
        if (propertiesThatChanged.ContainsKey("ChickenFood") || propertiesThatChanged.ContainsKey("CowFood")){
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("chickenfoodtext").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"].ToString();
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("cowfoodtext").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["CowFood"].ToString();
        }

        //OPEN GATE SEKOLAH
        if (propertiesThatChanged.ContainsKey("openGateSekolah"))
        {
            if (PlayerPrefs.GetString("level") == "Perkampungan_1")
            {
                if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["openGateSekolah"])
                {
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_left").GetComponent<Rigidbody>().isKinematic = false;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_right").GetComponent<Rigidbody>().isKinematic = false;
                }
                else
                {
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_left").GetComponent<Rigidbody>().isKinematic = true;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_left").transform.position = Vector3.zero;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_left").transform.eulerAngles = Vector3.zero;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_right").GetComponent<Rigidbody>().isKinematic = true;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_right").transform.position = Vector3.zero;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_right").transform.eulerAngles = Vector3.zero;
                }
            }
        }
        
    }

    public void HapusObjek(String name)
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
        bool playersama = false;
        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].name.Contains("Player") && GameObjects[i].name != name)
            {
                playersama = true;
            }
        }
        if (!playersama)
        {
            for (int i = 0; i < GameObjects.Length; i++)
            {
                if (GameObjects[i].tag != "Player" && GameObjects[i].tag != "DontDestroy" && GameObjects[i].tag != "MainCamera" && GameObjects[i].name != "PhotonMono" && GameObjects[i].name != "[Debug Updater]")
                    Destroy(GameObjects[i]);
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Debug.Log("GameSetup Loaded");
        GameObject.Find("Clicked").transform.Find("Heart").gameObject.SetActive(false);

        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
        hash.Add("online", true);
        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
        transisi = GameObject.Find("Canvas").transform.Find("Transisi").gameObject;
        if(!GameObject.Find("ServerConnection").GetComponent<MyConnection>().ingame)
        GameObject.Find("ServerConnection").GetComponent<MyConnection>().ingame = true;
        RawImage fotoku = GameObject.Find("Canvas").transform.Find("UIKiri").Find("Foto").GetComponent<RawImage>();
        Image mymusim = GameObject.Find("Canvas").transform.Find("UIKiri").Find("Weather").GetComponent<Image>();
        Text myname = GameObject.Find("Canvas").transform.Find("UIKiri").Find("Nama").GetComponent<Text>();
        Text mystamina = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextStamina").GetComponent<Text>();
        Text dateskrg = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDate").GetComponent<Text>();
        Text myduit = GameObject.Find("Canvas").transform.Find("UIkanan").Find("JumlahDuit").GetComponent<Text>();

        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("buttonTidur"))PlayerPrefs.DeleteKey("buttonTidur");

        myname.text = PlayerPrefs.GetString("myname");
        mystamina.text = ""+PlayerPrefs.GetInt("stamina");
        myduit.text = "" + PlayerPrefs.GetInt("money");

        if (!PhotonNetwork.IsConnected)
        {
            dateskrg.text = PlayerPrefs.GetInt("tanggal") + " " + PlayerPrefs.GetString("musim") + " " + PlayerPrefs.GetInt("tahun");
            if (PlayerPrefs.GetString("musim") == "Spring") mymusim.sprite = weather[0];
            else if (PlayerPrefs.GetString("musim") == "Summer") mymusim.sprite = weather[1];
            else if (PlayerPrefs.GetString("musim") == "Fall") mymusim.sprite = weather[2];
            else if (PlayerPrefs.GetString("musim") == "Winter") mymusim.sprite = weather[3];
        }
        else
        {
            if (PhotonNetwork.IsMasterClient)
            {
                int bulan = 1;
                if (PlayerPrefs.GetString("musim") == "Spring") { mymusim.sprite = weather[0]; bulan = 1; }
                else if (PlayerPrefs.GetString("musim") == "Summer") { mymusim.sprite = weather[1]; bulan = 2; }
                else if (PlayerPrefs.GetString("musim") == "Fall") { mymusim.sprite = weather[2]; bulan = 3; }
                else if (PlayerPrefs.GetString("musim") == "Winter") { mymusim.sprite = weather[3]; bulan = 4; }

                int tgl = PlayerPrefs.GetInt("tanggal");
                int tahun = (PlayerPrefs.GetInt("tahun")-1)*120;
                bulan = (bulan-1)*30;
                int totalhitungtanggal = (tgl+bulan+tahun)-1;

                int modulonya = 30 % 7;
                string nexthari="";
                if (PlayerPrefs.GetString("hari") == "Senin")
                {
                    if(modulonya == 2)
                    {
                        nexthari = "Rabu";
                    }
                }

                //Debug.Log("MODULO "+ (nexthari));
                dateskrg.text = PlayerPrefs.GetString("hari") + ", " + PlayerPrefs.GetInt("tanggal") + " " + PlayerPrefs.GetString("musim") + " " + PlayerPrefs.GetInt("tahun");

                ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
                
                PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
                Debug.Log("KEBUNKU "+PhotonNetwork.CurrentRoom.CustomProperties["mykucing"].ToString());
            }
            else
            {
                dateskrg.text = PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString();
                if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Spring") mymusim.sprite = weather[0];
                else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Summer") mymusim.sprite = weather[1];
                else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Fall") mymusim.sprite = weather[2];
                else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Winter") mymusim.sprite = weather[3];
                GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString();
                GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString();
            }
        }

        //STATUS PROFIL
        string judulkebun = "";
        if (PlayerPrefs.GetString("bahasa") == "Indonesia") judulkebun = "Kebun " + PhotonNetwork.CurrentRoom.CustomProperties["mykebun"].ToString();
        else if (PlayerPrefs.GetString("bahasa") == "English") judulkebun = PhotonNetwork.CurrentRoom.CustomProperties["mykebun"].ToString() + " Farm";
        else if (PlayerPrefs.GetString("bahasa") == "Japan") judulkebun = PhotonNetwork.CurrentRoom.CustomProperties["mykebun"].ToString() + "の農場";
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = judulkebun;
        
        GetComponent<PhotonView>().RPC("updatePlayerUI", RpcTarget.All);

        int jumlahayam = 0;
        for (int i=0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenMax"];i++)
            if(PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i]!=null)
                if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString().Split('-')[0] == "Chicken") jumlahayam++;
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("ayamtext").GetComponent<Text>().text = ""+jumlahayam;
        int jumlahduck = 0;
        for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenMax"]; i++)
            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i] != null)
                if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString().Split('-')[0] == "Duck") jumlahduck++;
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("ducktext").GetComponent<Text>().text = "" + jumlahduck;
        int jumlahcow = 0;
        for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; i++)
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] != null)
                if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString().Split('-')[0] == "Cow") jumlahcow++;
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("cowtext").GetComponent<Text>().text = "" + jumlahcow;
        int jumlahgoat = 0;
        for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; i++)
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] != null)
                if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString().Split('-')[0] == "Goat") jumlahgoat++;
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("goattext").GetComponent<Text>().text = "" + jumlahgoat;
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("chickenfoodtext").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"].ToString();
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("cowfoodtext").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["CowFood"].ToString();
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(2).Find("cattext").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["mykucing"].ToString();
        //NEW DAY
        newday();

        //Tambah Batu diLadang
        updatebatu();

        updatelahan();

        //CUACA HUJAN OR NOT
        if (luarRumah())
        {
            //RENDER SKYBOX
            RenderSettings.skybox.SetFloat("_Exposure", (float)PhotonNetwork.CurrentRoom.CustomProperties["skyboxfloat"]);

            Debug.Log("HUJAN masuk??"+ (bool)PhotonNetwork.CurrentRoom.CustomProperties["rain"]);
            if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["rain"])
            {
                //CUACA HUJAN
                GameObject.Find("Main Camera").transform.Find("Hujan").gameObject.SetActive(true);
                GameObject.Find("Sun").transform.Find("Directional Light").GetComponent<Light>().color = new Color32(85, 85, 61, 255);
            }
            else
            {
                //NOT HUJAN
                GameObject.Find("Main Camera").transform.Find("Hujan").gameObject.SetActive(false);
                GameObject.Find("Sun").transform.Find("Directional Light").GetComponent<Light>().color = new Color32(255, 244, 214, 255);
            }

            if (PlayerPrefs.GetString("level") == "Perkampungan_1")
            {
                if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["openGateSekolah"])
                {
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_left").GetComponent<Rigidbody>().isKinematic = false;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_right").GetComponent<Rigidbody>().isKinematic = false;
                }
                else
                {
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_left").GetComponent<Rigidbody>().isKinematic = true;
                    GameObject.Find("gate").transform.Find("gate_main").Find("gate_right").GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        

        if (PlayerPrefs.GetString("level") == "MasukRumah" && PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed11") && PhotonNetwork.CurrentRoom.CustomProperties["Bed11"].ToString()!="")
                GameObject.Find("Barang").transform.Find("Bed1").GetComponent<bed>().orangtidur.Add(PhotonNetwork.CurrentRoom.CustomProperties["Bed11"].ToString());
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed12") && PhotonNetwork.CurrentRoom.CustomProperties["Bed12"].ToString() != "")
                GameObject.Find("Barang").transform.Find("Bed1").GetComponent<bed>().orangtidur.Add(PhotonNetwork.CurrentRoom.CustomProperties["Bed12"].ToString());
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed21") && PhotonNetwork.CurrentRoom.CustomProperties["Bed21"].ToString() != "")
                GameObject.Find("Barang").transform.Find("Bed2").GetComponent<bed>().orangtidur.Add(PhotonNetwork.CurrentRoom.CustomProperties["Bed21"].ToString());
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed22") && PhotonNetwork.CurrentRoom.CustomProperties["Bed22"].ToString() != "")
                GameObject.Find("Barang").transform.Find("Bed2").GetComponent<bed>().orangtidur.Add(PhotonNetwork.CurrentRoom.CustomProperties["Bed22"].ToString());
        }

        //SET JUMLAH PAKAN AYAM SAPI
        if (PlayerPrefs.GetString("level") == "MasukKandangAyam" && PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"] != null)
                GameObject.Find("Barang").transform.Find("Pakan").Find("JumlahPakan").GetComponent<TextMesh>().text = PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"].ToString();
        }
        if (PlayerPrefs.GetString("level") == "MasukKandangSapi" && PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["CowFood"] != null)
                GameObject.Find("Barang").transform.Find("Pakan").Find("JumlahPakan").GetComponent<TextMesh>().text = PhotonNetwork.CurrentRoom.CustomProperties["CowFood"].ToString();
        }


        setmusic();

        Debug.Log("PLAYER RESPAWN: "+ PlayerPrefs.GetString("respawn"));
        GameObject myrespawn = null;
        if (PlayerPrefs.GetString("respawn") == "pintumasukrumah") myrespawn = GameObject.Find("PlayerSpawnPintu");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja") myrespawn = GameObject.Find("BangunTidurSpawn");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja2") myrespawn = GameObject.Find("BangunTidurSpawn2");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja3") myrespawn = GameObject.Find("BangunTidurSpawn3");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja4") myrespawn = GameObject.Find("BangunTidurSpawn4");
        else if (PlayerPrefs.GetString("respawn") == "pintukeluarrumah") myrespawn = GameObject.Find("LuarRumahSpawn");
        else if (PlayerPrefs.GetString("respawn") == "pintumasukkandangayam") myrespawn = GameObject.Find("PlayerSpawnPintu");
        else if (PlayerPrefs.GetString("respawn") == "pintumasukkandangsapi") myrespawn = GameObject.Find("PlayerSpawnPintu");
        else if (PlayerPrefs.GetString("respawn") == "pintukeluarkandangayam") myrespawn = GameObject.Find("LuarKandangAyamSpawn");
        else if (PlayerPrefs.GetString("respawn") == "pintukeluarkandangsapi") myrespawn = GameObject.Find("LuarKandangSapiSpawn");
        else {
            myrespawn = GameObject.Find(PlayerPrefs.GetString("respawn"));
        }

        System.Random rnd = new System.Random();
        double val = rnd.NextDouble(); // range 0.0 to 1.0
        val -= 0.5;

        Vector3 respawnrandom = new Vector3(myrespawn.transform.position.x+ (float)val, myrespawn.transform.position.y, myrespawn.transform.position.z);
        if (GameObject.Find("Player (" + PlayerPrefs.GetString("myname") + ")") == null)
            if (PlayerPrefs.GetString("gender") == "cewek")
            {
                //Debug.Log("GOGO");
                fotoku.texture = cewek;
                if (PhotonNetwork.IsConnectedAndReady)
                    go = PhotonNetwork.Instantiate(Path.Combine("Model/MainMenu/Prefab", "Sendagaya_Shino_axe"), respawnrandom, Quaternion.identity);
                else
                    go = Instantiate(mycharcewe, myrespawn.transform.position, Quaternion.identity);
            }
            else
            {
                fotoku.texture = cowok;
                if (PhotonNetwork.IsConnectedAndReady)
                    go = PhotonNetwork.Instantiate(Path.Combine("Model/MainMenu/Prefab", "Sakurada_Fumiriya_axe"), respawnrandom, Quaternion.identity);
                else
                    go = Instantiate(mycharcowo, myrespawn.transform.position, Quaternion.identity);
            }
        else
        {
            go = GameObject.Find("Player (" + PlayerPrefs.GetString("myname") + ")");
            go.transform.position = myrespawn.transform.position;
            go.GetComponent<Controller>().enabled = true;
        }
        go.name = "Player (" + PlayerPrefs.GetString("myname") + ")";
        go.transform.parent = GameObject.Find("PlayerSpawn").transform;
        go.transform.LookAt(new Vector3(Camera.main.transform.position.x, go.transform.position.y,Camera.main.transform.position.z));

        //LOAD SKIN
        Color32 mycolorskin= new Color32((byte)PlayerPrefs.GetInt("warnaskinred"), (byte)PlayerPrefs.GetInt("warnaskingreen"), (byte)PlayerPrefs.GetInt("warnaskinblue"), 255);
        int nomormat = 8;
        go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorskin;
        go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[0].color = mycolorskin;
        //go.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);

        ExitGames.Client.Photon.Hashtable setWarna = new ExitGames.Client.Photon.Hashtable();
        setWarna.Add("gender", PlayerPrefs.GetString("gender"));
        setWarna.Add("hairred", PlayerPrefs.GetInt("warnahairred"));
        setWarna.Add("hairgreen", PlayerPrefs.GetInt("warnahairgreen"));
        setWarna.Add("hairblue", PlayerPrefs.GetInt("warnahairblue"));
        setWarna.Add("clothred", PlayerPrefs.GetInt("warnaclothesred"));
        setWarna.Add("clothgreen", PlayerPrefs.GetInt("warnaclothesgreen"));
        setWarna.Add("clothblue", PlayerPrefs.GetInt("warnaclothesblue"));
        setWarna.Add("pantsred", PlayerPrefs.GetInt("warnapantsred"));
        setWarna.Add("pantsgreen", PlayerPrefs.GetInt("warnapantsgreen"));
        setWarna.Add("pantsblue", PlayerPrefs.GetInt("warnapantsblue"));
        setWarna.Add("skinred", PlayerPrefs.GetInt("warnaskinred"));
        setWarna.Add("skingreen", PlayerPrefs.GetInt("warnaskingreen"));
        setWarna.Add("skinblue", PlayerPrefs.GetInt("warnaskinblue"));
        PhotonNetwork.LocalPlayer.SetCustomProperties(setWarna);
        GameObject myweapon = GameObject.Find("PlayerSpawn");
        myweapon = go.transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
        for (int i = 0; i < myweapon.transform.childCount; i++)
            myweapon.transform.GetChild(i).gameObject.SetActive(false);
        Debug.Log(PlayerPrefs.GetString("peralatannama0"));
        myweapon.transform.Find(PlayerPrefs.GetString("peralatannama0")).gameObject.SetActive(true);

        //Ubah image senjata
        if (PlayerPrefs.GetString("peralatannama0") != "")
        {
            GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().enabled = true;
            GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().enabled = true;
            GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Peralatan/" + PlayerPrefs.GetString("peralatannama0"));
            if (PlayerPrefs.GetInt("peralatanjumlah0") == -1) GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "";
            else if (PlayerPrefs.GetInt("peralatanjumlah0") > 0) GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah0");
        }

        //setroomOpenfirst
        if (PhotonNetwork.IsMasterClient && !PhotonNetwork.CurrentRoom.IsOpen)
            PhotonNetwork.CurrentRoom.IsOpen = true;

        photonView.RPC("mintaposisi", RpcTarget.Others);

        transisi.SetActive(true);
    }

    public void LoadSkinMine(GameObject go,Color32 colorbaju)
    {
        Debug.Log("LOADSKIN"+go.name);
        Color32 mycolorhair = new Color32((byte)PlayerPrefs.GetInt("warnahairred"), (byte)PlayerPrefs.GetInt("warnahairgreen"), (byte)PlayerPrefs.GetInt("warnahairblue"), 255);
        int nomormat = 0;
        if (PlayerPrefs.GetString("gender") == "cewek")
        {
            for (; nomormat < go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorhair;
            }
        }
        else
        {
            for (; nomormat < go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                Debug.Log(go.transform.Find("Hair001"));
                go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorhair;
            }
        }
        Color32 mycolorclothes = colorbaju;
        nomormat = 0;
        for (; nomormat < go.transform.Find("Top").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
        {
            go.transform.Find("Top").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorclothes;
        }

        //LOAD CELANA
        Color32 mycolorcelana = new Color32((byte)PlayerPrefs.GetInt("warnapantsred"), (byte)PlayerPrefs.GetInt("warnapantsgreen"), (byte)PlayerPrefs.GetInt("warnapantsblue"), 255);
        nomormat = 0;
        go.transform.Find("Bottom").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorcelana;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transisi.activeSelf && (int)(255 * transisi.GetComponent<Image>().color.a) > 0 && !PlayerPrefs.HasKey("masuk"))
        {
            if ((int)(255 * transisi.GetComponent<Image>().color.a) <= 5)
            {
                transisi.SetActive(false);
            }else
            {
                int myalpha = (int)(255 * transisi.GetComponent<Image>().color.a) - 10;
                transisi.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)myalpha);
            }
        }
        //PLAYER HIDE AND ACTIVE
        for (int i = 0; i < GameObject.Find("PlayerSpawn").transform.childCount; i++)
            if (GameObject.Find("PlayerSpawn").transform.GetChild(i).GetComponent<Player1>().level == PlayerPrefs.GetString("level"))
            {
                GameObject.Find("PlayerSpawn").transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                GameObject.Find("PlayerSpawn").transform.GetChild(i).gameObject.SetActive(false);
            }
        //ITEM HIDE AND ACTIVE
        for (int i = 0; i < GameObject.Find("ItemSpawn").transform.childCount; i++)
        {
            if (GameObject.Find("ItemSpawn").transform.GetChild(i).GetComponent<Buah>() != null)
                if (PlayerPrefs.GetString("level") == GameObject.Find("ItemSpawn").transform.GetChild(i).GetComponent<Buah>().level)
                {
                    GameObject.Find("ItemSpawn").transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    GameObject.Find("ItemSpawn").transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                }
        }
        //AI
        for (int i = 0; i < GameObject.Find("AISpawn").transform.childCount; i++)
            if (GameObject.Find("AISpawn").transform.GetChild(i).tag == "NPC")
            {
                if (PlayerPrefs.GetString("level") == GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<NPC>().level)
                {
                    GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<Collider>().enabled = true;
                    GameObject.Find("AISpawn").transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                    if(GameObject.Find("CubeAction") !=null)
                        GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<NPC>().cubeaction = GameObject.Find("CubeAction").gameObject;
                }
                else
                {
                    GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<Collider>().enabled = false;
                    GameObject.Find("AISpawn").transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                    if (GameObject.Find("CubeAction") != null)
                        GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<NPC>().cubeaction = null;
                }
            }

        //AI BINATANG
        for (int i = 0; i < GameObject.Find("AISpawn").transform.childCount; i++)
            if (GameObject.Find("AISpawn").transform.GetChild(i).tag == "NPChewan")
            {
                if (PlayerPrefs.GetString("level") == GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<Cat>().level)
                {
                    GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<Collider>().enabled = true;
                    GameObject.Find("AISpawn").transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                    if (GameObject.Find("CubeAction") != null)
                        GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<Cat>().cubeaction = GameObject.Find("CubeAction").gameObject;
                }
                else
                {
                    GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<Collider>().enabled = false;
                    GameObject.Find("AISpawn").transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
                    if (GameObject.Find("CubeAction") != null)
                        GameObject.Find("AISpawn").transform.GetChild(i).GetComponent<Cat>().cubeaction = null;
                }
            }

        if (minFoV)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40f, 0.1f);
            if (Camera.main.fieldOfView <= 41) { minFoV = false; }
        }else
        if (maxFoV)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, 0.1f);
            if (Camera.main.fieldOfView >= 59) { maxFoV = false; }
        }
        if (minFoVClothes)
        {
            maxFoVClothes = false;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40f, 0.1f);
            if (Camera.main.fieldOfView <= 41) minFoVClothes = false;
        }else
        if (maxFoVClothes)
        {
            minFoVClothes = false;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, 0.1f);
            if (Camera.main.fieldOfView >= 59) maxFoVClothes = false;
        }


    }

    public void newday()
    {
        if (PlayerPrefs.GetString("newday") == "no" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text == "06" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text == "00")
        {
            PlayerPrefs.SetString("ambilduitharian", "no");
            PlayerPrefs.SetFloat("directionalSun", 0);

            if (PhotonNetwork.IsMasterClient)
            {
                //SET CHICKEN FEED
                int jumlahayam = 0;
                int jumlahfeedayam = 0;

                for(int i = 0; i < PlayerPrefs.GetInt("ChickenMax"); i++)
                {
                    ExitGames.Client.Photon.Hashtable setbox = new ExitGames.Client.Photon.Hashtable();
                    setbox.Add("box" + (i + 1), PlayerPrefs.GetString("box" + (i + 1)));
                    PhotonNetwork.CurrentRoom.SetCustomProperties(setbox);

                    if (PlayerPrefs.GetString("Chicken" + i) != "") jumlahayam++;
                    if (PlayerPrefs.GetString("box" + (i + 1)) != "") jumlahfeedayam++;
                }    

                //CEK AYAM MAKAN
                for(int i = 0; i < PlayerPrefs.GetInt("ChickenMax"); i++)
                {
                    if (PlayerPrefs.GetString("Chicken" + i) != "")
                    {
                        if (jumlahfeedayam>0)
                        {
                            if (PlayerPrefs.GetInt("ChickenHeart"+i) < 100)
                                PlayerPrefs.SetInt("ChickenHeart" + i, PlayerPrefs.GetInt("ChickenHeart"+i) + 1);
                            if (PlayerPrefs.GetInt("ChickenGold"+i) == 1)
                            {

                            }
                            else if (PlayerPrefs.GetInt("ChickenSilver"+i) == 1)
                            {

                            }
                            else
                            {
                                for (int j = 0; j < PlayerPrefs.GetInt("ChickenMax"); j++)
                                {
                                    if(PlayerPrefs.GetString("box" + (j + 1)) != "")
                                    {
                                        PhotonNetwork.Destroy(GameObject.Find("ItemSpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["box" + (j + 1)].ToString()).GetComponent<PhotonView>());
                                        PlayerPrefs.SetString("box"+(j+1),"");
                                        ExitGames.Client.Photon.Hashtable setbox = new ExitGames.Client.Photon.Hashtable();
                                        setbox.Add("box" + (j + 1), "");
                                        PhotonNetwork.CurrentRoom.SetCustomProperties(setbox);
                                        break;
                                    }
                                }
                                GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", "telor"+ PlayerPrefs.GetString("ChickenTipe" + i)), new Vector3(PlayerPrefs.GetFloat("ChickenPosX" + i), PlayerPrefs.GetFloat("ChickenPosY" + i), PlayerPrefs.GetFloat("ChickenPosZ" + i)), Quaternion.identity);
                                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("tumbuhBuah", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("ChickenLevel" + i));
                                jumlahfeedayam--;
                                if (i+1 == jumlahayam) break;
                            }
                        }
                        else
                        {
                            if (PlayerPrefs.GetInt("ChickenSick"+i) < 4)
                                PlayerPrefs.SetInt("ChickenSick" + i, PlayerPrefs.GetInt("ChickenSick"+i) + 1);
                            ExitGames.Client.Photon.Hashtable setbox = new ExitGames.Client.Photon.Hashtable();
                            setbox.Add("ChickenSick" + i, PlayerPrefs.GetInt("ChickenSick" + i));
                            PhotonNetwork.CurrentRoom.SetCustomProperties(setbox);
                        }
                    }
                }

                //CEK SISA MAKANAN
                for (int i = 0; i < PlayerPrefs.GetInt("ChickenMax"); i++)
                    if (PlayerPrefs.GetString("box" + (i + 1)) != "")
                        if (GameObject.Find("ItemSpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["box" + (i + 1)].ToString()) == null)
                        {
                            Vector3 temppos = new Vector3(2.89f, 0.22f, 2.23f);
                            if (i == 0) temppos = new Vector3(2.89f, 0.22f, 2.23f);
                            else if (i == 1) temppos = new Vector3(2.89f, 0.22f, 3.73f);
                            else if (i == 2) temppos = new Vector3(2.89f, 0.22f, 5.23f);
                            else if (i == 3) temppos = new Vector3(2.89f, 0.22f, 6.73f);
                            else if (i == 4) temppos = new Vector3(2.89f, 0.22f, 8.23f);
                            else if (i == 5) temppos = new Vector3(4.52f, 0.22f, 2.23f);
                            else if (i == 6) temppos = new Vector3(4.52f, 0.22f, 3.73f);
                            else if (i == 7) temppos = new Vector3(4.52f, 0.22f, 5.23f);
                            else if (i == 8) temppos = new Vector3(4.52f, 0.22f, 6.73f);
                            else if (i == 9) temppos = new Vector3(4.52f, 0.22f, 8.23f);
                            GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", "FeedChicken"), temppos, Quaternion.identity);
                            string[] splitnama = PlayerPrefs.GetString("box" + (i + 1)).Split('-');
                            item.GetComponent<PhotonView>().ViewID = Int32.Parse(splitnama[1]);
                            StartCoroutine(nungguplayerspawn(item.name));
                        }

                //SET COW FEED
                int jumlahsapi = 0;
                int jumlahfeedsapi = 0;

                for (int i = 0; i < PlayerPrefs.GetInt("CowMax"); i++)
                {
                    ExitGames.Client.Photon.Hashtable setbox = new ExitGames.Client.Photon.Hashtable();
                    setbox.Add("boxcow" + (i + 1), PlayerPrefs.GetString("boxcow" + (i + 1)));
                    PhotonNetwork.CurrentRoom.SetCustomProperties(setbox);

                    if (PlayerPrefs.GetString("Cow" + i) != "") jumlahsapi++;
                    if (PlayerPrefs.GetString("boxcow" + (i + 1)) != "") jumlahfeedsapi++;
                }

                //CEK SAPI MAKAN
                for (int i = 0; i < PlayerPrefs.GetInt("CowMax"); i++)
                {
                    if (PlayerPrefs.GetString("Cow" + i) != "")
                    {
                        if (jumlahfeedsapi > 0)
                        {
                            if (PlayerPrefs.GetInt("CowHeart" + i) < 100)
                                PlayerPrefs.SetInt("CowHeart" + i, PlayerPrefs.GetInt("CowHeart" + i) + 1);
                            if (PlayerPrefs.GetInt("CowGold" + i) == 1)
                            {

                            }
                            else if (PlayerPrefs.GetInt("CowSilver" + i) == 1)
                            {

                            }
                            else
                            {
                                for (int j = 0; j < PlayerPrefs.GetInt("CowMax"); j++)
                                {
                                    if (PlayerPrefs.GetString("boxcow" + (j + 1)) != "")
                                    {
                                        PhotonNetwork.Destroy(GameObject.Find("ItemSpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["boxcow" + (j + 1)].ToString()).GetComponent<PhotonView>());
                                        PlayerPrefs.SetString("boxcow" + (j + 1), "");
                                        ExitGames.Client.Photon.Hashtable setbox = new ExitGames.Client.Photon.Hashtable();
                                        setbox.Add("boxcow" + (j + 1), "");
                                        PhotonNetwork.CurrentRoom.SetCustomProperties(setbox);
                                        break;
                                    }
                                }
                                //SPAWN SUSU
                                ExitGames.Client.Photon.Hashtable setmilk = new ExitGames.Client.Photon.Hashtable();
                                setmilk.Add("CowMilk" + i, "small");
                                PhotonNetwork.CurrentRoom.SetCustomProperties(setmilk);
                                PlayerPrefs.SetString("CowMilk" + i, "small");
                                //GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", "telor" + PlayerPrefs.GetString("CowTipe" + i)), new Vector3(PlayerPrefs.GetFloat("CowPosX" + i), PlayerPrefs.GetFloat("CowPosY" + i), PlayerPrefs.GetFloat("CowPosZ" + i)), Quaternion.identity);
                                //GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("tumbuhBuah", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("ChickenLevel" + i));
                                jumlahfeedsapi--;
                                if (i + 1 == jumlahsapi) break;
                            }
                        }
                        else
                        {
                            if (PlayerPrefs.GetInt("CowSick" + i) < 4)
                                PlayerPrefs.SetInt("CowSick" + i, PlayerPrefs.GetInt("CowSick" + i) + 1);
                            ExitGames.Client.Photon.Hashtable setbox = new ExitGames.Client.Photon.Hashtable();
                            setbox.Add("CowSick" + i, PlayerPrefs.GetInt("CowSick" + i));
                            PhotonNetwork.CurrentRoom.SetCustomProperties(setbox);
                        }
                    }
                }

                //CEK SISA MAKANAN
                for (int i = 0; i < PlayerPrefs.GetInt("CowMax"); i++)
                    if (PlayerPrefs.GetString("boxcow" + (i + 1)) != "")
                        if (GameObject.Find("ItemSpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["boxcow" + (i + 1)].ToString()) == null)
                        {
                            Vector3 temppos = new Vector3(2.89f, 0.22f, 2.23f);
                            if (i == 0) temppos = new Vector3(2.89f, 0.22f, 2.23f);
                            else if (i == 1) temppos = new Vector3(2.89f, 0.22f, 3.73f);
                            else if (i == 2) temppos = new Vector3(2.89f, 0.22f, 5.23f);
                            else if (i == 3) temppos = new Vector3(2.89f, 0.22f, 6.73f);
                            else if (i == 4) temppos = new Vector3(2.89f, 0.22f, 8.23f);
                            else if (i == 5) temppos = new Vector3(4.52f, 0.22f, 2.23f);
                            else if (i == 6) temppos = new Vector3(4.52f, 0.22f, 3.73f);
                            else if (i == 7) temppos = new Vector3(4.52f, 0.22f, 5.23f);
                            else if (i == 8) temppos = new Vector3(4.52f, 0.22f, 6.73f);
                            else if (i == 9) temppos = new Vector3(4.52f, 0.22f, 8.23f);
                            GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", "FeedCow"), temppos, Quaternion.identity);
                            string[] splitnama = PlayerPrefs.GetString("box" + (i + 1)).Split('-');
                            item.GetComponent<PhotonView>().ViewID = Int32.Parse(splitnama[1]);
                            StartCoroutine(nungguplayerspawn(item.name));
                        }


                //Sethujan
                ExitGames.Client.Photon.Hashtable setrain = new ExitGames.Client.Photon.Hashtable();
                if (PhotonNetwork.CurrentRoom.CustomProperties["nextrain"] == null) setrain.Add("rain", false);
                else setrain.Add("rain", (bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"]);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setrain);
                ExitGames.Client.Photon.Hashtable setLahan = new ExitGames.Client.Photon.Hashtable();

                //TANEMAN
                for (int i = 0; i < PhotonNetwork.CurrentRoom.CustomProperties.Count; i++)
                {
                    if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("lahancangkulnama" + i))
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulnama" + i].ToString() != "")
                        {
                            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("lahancangkulbuah" + i))
                            {
                                if (PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulbuah" + i].ToString() != "")
                                {
                                    //KALO UDAH MATI
                                    if (System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmati" + i].ToString()) > 3 || PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulseason" + i].ToString() != PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString())
                                    {
                                        setLahan.Add("lahancangkulsiram" + i, false);
                                    }
                                    else
                                    {
                                        //MATI GA DISIRAM
                                        if (!(bool)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulsiram" + i])
                                            setLahan.Add("lahancangkulmati" + i, System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmati" + i].ToString()) + 1);
                                        else
                                        {
                                            //NAMBAH UMUR DISIRAM
                                            if (System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString()) < System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString()))
                                            {
                                                setLahan.Add("lahancangkulumur" + i, System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString()) + 1);
                                                //Max UMUR BERBUAH
                                                if (System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString()) + 1 == System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString()))
                                                {

                                                }
                                            }
                                            //Max UMUR BERBUAH JUGA
                                            else if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulrenewable" + i])
                                            {
                                                //Max UMUR BERBUAH
                                                if (System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumurberbuah" + i].ToString()) == System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumurberbuah" + i].ToString()))
                                                {
                                                    setLahan.Add("lahancangkulumurberbuah" + i, 1);

                                                    GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulbuah" + i].ToString()),
                                                        new Vector3((float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposx" + i] + NextFloat(-0.3f, 0.3f),
                                                        (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposy" + i] + 1f,
                                                        (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposz" + i] + NextFloat(-0.3f, 0.3f)),
                                                        Quaternion.identity);
                                                    //item.GetComponent<PhotonView>().TransferOwnership(0);
                                                    GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("tumbuhBuah", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, "KeluarRumah");

                                                }
                                                else
                                                    setLahan.Add("lahancangkulumurberbuah" + i, System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumurberbuah" + i].ToString()) + 1);
                                            }
                                        }

                                        
                                    }
                                }
                            }
                            //Set TANEMAN DISIRAM apa ngga pas hari hujan
                            if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["rain"])
                            {
                                setLahan.Add("lahancangkulsiram" + i, true);
                            }
                            else
                            {
                                setLahan.Add("lahancangkulsiram" + i, false);
                            }
                        }
                    }
                }
                PhotonNetwork.CurrentRoom.SetCustomProperties(setLahan);

                System.Random rnd = new System.Random();
                int randomint = rnd.Next(0, 100);
                //SetNexthujan
                ExitGames.Client.Photon.Hashtable setnextrain = new ExitGames.Client.Photon.Hashtable();
                if (PlayerPrefs.GetString("musim") == "Spring" && randomint <= 20)
                    setnextrain.Add("nextrain", true);
                else if (PlayerPrefs.GetString("musim") == "Summer" && randomint <= 50)
                    setnextrain.Add("nextrain", true);
                else if (PlayerPrefs.GetString("musim") == "Fall" && randomint <= 35)
                    setnextrain.Add("nextrain", true);
                else setnextrain.Add("nextrain", false);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setnextrain);

                //SET NPC RESET
                Debug.Log("RESET NPC");
                GameObject.Find("AISpawn").transform.Find("Mika").transform.position = new Vector3(72f,0, 59f);
                LanguageMika.instance.gameObject.SetActive(false);
                LanguageMika.instance.gameObject.SetActive(true);
                LanguageMika.instance.StartCoroutine(LanguageMika.instance.NPCMikaJalan());
                GameObject.Find("AISpawn").transform.Find("Samsul").transform.position = new Vector3(13.4f, 0, 13.6f);
                LanguageSamsul.instance.gameObject.SetActive(false);
                LanguageSamsul.instance.gameObject.SetActive(true);
                LanguageSamsul.instance.StartCoroutine(LanguageSamsul.instance.NPCMikaJalan());
                GameObject.Find("AISpawn").transform.Find("Afifah").transform.position = new Vector3(9.54f, 0, 13.03f);
                LanguageAfifah.instance.gameObject.SetActive(false);
                LanguageAfifah.instance.gameObject.SetActive(true);
                LanguageAfifah.instance.StartCoroutine(LanguageAfifah.instance.NPCMikaJalan());
                GameObject.Find("AISpawn").transform.Find("Otong").transform.position = new Vector3(40.843f, 0.628f, 26.935f);
                LanguageOtong.instance.gameObject.SetActive(false);
                LanguageOtong.instance.gameObject.SetActive(true);
                LanguageOtong.instance.StartCoroutine(LanguageOtong.instance.NPCMikaJalan());
            }

            //Debug.Log("MASUK HARI BARU, BESOK HUJAN ? "+(bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"]);

            PlayerPrefs.SetString("newday", "yes");
        }
        else if(PlayerPrefs.GetString("newday") == "yes" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text != "06" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text != "00") PlayerPrefs.SetString("newday", "no");
    }

    bool luarRumah()
    {
        return (
            PlayerPrefs.GetString("level") != "MasukKandangSapi" &&
            (!PlayerPrefs.GetString("level").Contains("Rumah") || PlayerPrefs.GetString("level").Equals("KeluarRumah")) &&
            PlayerPrefs.GetString("level") != "MasukKandangAyam");
    }

    public void updatelahan()
    {
        if (luarRumah())
        {
            GameObject.Find("Sun").transform.eulerAngles = new Vector3(0f, -30f, 0f);
            GameObject.Find("Sun").transform.Rotate(PlayerPrefs.GetFloat("directionalSun"), 0, 0, Space.Self);
            if (PlayerPrefs.GetString("level") == "KeluarRumah")
            {
                GameObject.Find("bridge").transform.Find("Box051").Find("NamaFarm").GetComponent<TextMesh>().text = "Kebun\n" + (string)PhotonNetwork.CurrentRoom.CustomProperties["mykebun"];
                for (int i = 0; i < PhotonNetwork.CurrentRoom.CustomProperties.Count; i++)
                {
                    if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("lahancangkulnama" + i))
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulnama" + i].ToString() != "")
                        {
                            string lahan = "";
                            string namalahan = "";
                            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("terpacul_" + i)) { lahan = "LahanCangkul"; namalahan = "terpacul_"; }
                            else if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("tanahbibit_" + i)) { lahan = "LahanCangkulBibit"; namalahan = "tanahbibit_"; }

                            GameObject go = null;
                            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("tanahbibit_" + i))
                            {
                                var hasilbagi = (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString()) / (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString());
                                if (hasilbagi >= 0.3f)
                                    lahan = "LahanCangkul" + PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulbuah" + i].ToString();
                            }

                            go = Instantiate(Resources.Load<GameObject>("Images/Lahan/" + lahan), new Vector3((float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposx" + i], (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposy" + i], (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposz" + i]), Quaternion.identity);
                            go.transform.parent = GameObject.Find("SawahSpawn").transform;
                            go.name = namalahan + i;
                            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("tanahbibit_" + i))
                            {
                                var hasilbagi = (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString()) / (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString());
                                Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString() + " / " + PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString());
                                if (go.transform.Find("lahanpohon") != null)
                                    go.transform.Find("lahanpohon").transform.position = new Vector3(go.transform.Find("lahanpohon").transform.position.x, -1.2f + hasilbagi, go.transform.Find("lahanpohon").transform.position.z);
                            }

                            if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulsiram" + i])
                            {
                                go.transform.Find("lahan").gameObject.SetActive(false);
                                go.transform.Find("lahansiram").gameObject.SetActive(true);
                            }
                            else
                            {
                                go.transform.Find("lahan").gameObject.SetActive(true);
                                go.transform.Find("lahansiram").gameObject.SetActive(false);
                            }

                            if(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulseason" + i] != null)
                            if (System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmati" + i].ToString()) > 3 || PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulseason" + i].ToString() != PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString())
                            {
                                if (go.transform.Find("lahanpohon") != null)
                                {
                                    go.transform.Find("lahanpohon").GetComponent<MeshRenderer>().material = Resources.Load("Model/Tools/Material/mandera", typeof(Material)) as Material;
                                }
                            }

                        }
                    }
                }
            }
        }
    }

    public void updatebatu()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (PlayerPrefsX.GetFloatArray("PosLadang2BatuX").Length != 0 && PlayerPrefsX.GetFloatArray("PosLadang2BatuY").Length != 0)
            {
                ExitGames.Client.Photon.Hashtable setLahan = new ExitGames.Client.Photon.Hashtable();
                for (int i = 0; i < PlayerPrefsX.GetFloatArray("PosLadang2BatuX").Length; i++)
                {
                    setLahan.Add("PosLadang2BatuX" + i, PlayerPrefsX.GetFloatArray("PosLadang2BatuX")[i]);
                    setLahan.Add("PosLadang2BatuY" + i, PlayerPrefsX.GetFloatArray("PosLadang2BatuY")[i]);
                    setLahan.Add("PosLadang2BatuNum" + i, PlayerPrefsX.GetFloatArray("PosLadang2BatuNum")[i]);
                    setLahan.Add("PosLadang2BatuTipe" + i, PlayerPrefsX.GetStringArray("PosLadang2BatuTipe")[i]);
                }
                setLahan.Add("PosLadang2BatuLength", PlayerPrefs.GetInt("Ladang2BatuJumlah"));

                PhotonNetwork.CurrentRoom.SetCustomProperties(setLahan);
            }
        }
        if (PlayerPrefs.GetString("level") == "KeluarRumah")
        {
            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuLength"] != 0)
            {
                for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuLength"]; i++)
                {
                    Vector3 pos = new Vector3((float)PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuX" + i], 0.01f, (float)PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuY" + i]);
                    GameObject goBatu = GameObject.Instantiate(Resources.Load<GameObject>("Images/Lahan/Batu/" + PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuTipe" + i].ToString() + "/lahanCangkulBatu" + PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuNum" + i].ToString() + PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuTipe" + i].ToString()), pos, Quaternion.identity);
                    goBatu.transform.parent = GameObject.Find("SawahSpawn").transform;
                    goBatu.name = "Ladang2Batu" + i;
                    goBatu.transform.Find("target").name = "batu" + PhotonNetwork.CurrentRoom.CustomProperties["PosLadang2BatuTipe" + i].ToString();
                    goBatu.layer = 15;
                }

            }
        }
    }

    public void setmusic()
    {
        //NIGHT TIME MUSIC
        if (int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) < 6 || int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) > 19)
        {
            if (GameObject.Find("MyMusic") != null)
            {
                if (GameObject.Find("MyMusic").GetComponent<AudioSource>().clip != Gamesetupcontroller.instance.myclipnight)
                {
                    GameObject.Find("MyMusic").GetComponent<AudioSource>().clip = Gamesetupcontroller.instance.myclipnight;
                    GameObject.Find("MyMusic").GetComponent<AudioSource>().volume = 1f;
                    GameObject.Find("MyMusic").GetComponent<AudioSource>().Play();
                }
            }
        }
        else
        {
            if (GameObject.Find("MyMusic") != null)
            {
                AudioSource audio = GameObject.Find("MyMusic").GetComponent<AudioSource>();
                if (PlayerPrefs.GetString("musim") == "Spring")
                {
                    if (audio.clip != Gamesetupcontroller.instance.myclipspring)
                        audio.clip = Gamesetupcontroller.instance.myclipspring;
                    audio.volume = 1f;
                }
                else if (PlayerPrefs.GetString("musim") == "Summer")
                {
                    if (audio.clip != Gamesetupcontroller.instance.myclipsummer)
                        audio.clip = Gamesetupcontroller.instance.myclipsummer;
                    audio.volume = 0.5f;
                }
                else if (PlayerPrefs.GetString("musim") == "Fall")
                {
                    if (audio.clip != Gamesetupcontroller.instance.myclipfall)
                        audio.clip = Gamesetupcontroller.instance.myclipfall;
                    audio.volume = 1f;
                }
                else if (PlayerPrefs.GetString("musim") == "Winter")
                {
                    if (audio.clip != Gamesetupcontroller.instance.myclipwinter)
                        audio.clip = Gamesetupcontroller.instance.myclipwinter;
                    audio.volume = 1f;
                }

                if (!audio.isPlaying)
                    audio.Play();
            }
        }
    }

    IEnumerator nungguplayerspawn(string itemname)
    {
        yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")")!=null);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("tumbuhBuah", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", itemname, "MasukKandangAyam");
    }

    [PunRPC]
    void mintaposisi()
    {
        if(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")") != null)
        {
            float posisix = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position.x;
            float posisiy = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position.y;
            float posisiz = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position.z;
            float rotatex = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.x;
            float rotatey = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.y;
            float rotatez = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.z;

            photonView.RPC("setposisiawal", RpcTarget.Others, PhotonNetwork.NickName, posisix, posisiy, posisiz, rotatex, rotatey, rotatez);
        }
    }

    [PunRPC]
    void setposisiawal(string namaplayer,float posx, float posy, float posz, float rotx, float roty, float rotz)
    {
        Vector3 vector3pos = new Vector3(posx,posy,posz);
        Vector3 vector3rot = new Vector3(rotx, roty, rotz);
        Debug.Log(namaplayer);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").transform.position = vector3pos;
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").transform.eulerAngles = vector3rot;
    }

    [PunRPC]
    void pindahlevel(string nick, string kelevel)
    {
        if (kelevel == PlayerPrefs.GetString("level")) StartCoroutine(cekpindahlevel(nick));
    }

    [PunRPC]
    void sinkronWaktu(string jam, string detik, float vector3)
    {
        GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = jam;
        GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = detik;
        if (PlayerPrefs.GetString("level") != "MasukRumah" && PlayerPrefs.GetString("level") != "MasukKandangAyam")
        {
            if (GameObject.Find("Sun") != null)
            {
                GameObject.Find("Sun").transform.eulerAngles = new Vector3(0f, -30f, 0f);
                GameObject.Find("Sun").transform.Rotate(vector3, 0, 0, Space.Self);
            }
        }
        PlayerPrefs.SetString("newday", "no");
        PlayerPrefs.SetFloat("directionalSun", vector3);
        RenderSettings.skybox.SetFloat("_Exposure",(float)PhotonNetwork.CurrentRoom.CustomProperties["skyboxfloat"]);
    }
    [PunRPC]
    void updatePlayerUI()
    {
        int playerku = 1;
        foreach (var player in PhotonNetwork.PlayerList)
        {
            string namaPrefab = "";
            if (player.CustomProperties["gender"].ToString() == "cowok") namaPrefab = "japan_hair";
            else namaPrefab = "famale_long_hair";
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(1).Find("player" + playerku).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(1).Find("player" + playerku).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Rambut/" + namaPrefab);
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(1).Find("player" + playerku).Find("namafarm").GetComponent<Text>().text = player.NickName;
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(1).Find("player" + playerku).Find("textstamina").GetComponent<Text>().text = player.CustomProperties["stamina"].ToString();
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(1).Find("player" + playerku).Find("textmoney").GetComponent<Text>().text = player.CustomProperties["money"].ToString();
            playerku++;
        }
        for (; playerku <= 4; playerku++)
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").GetChild(0).GetChild(0).GetChild(1).Find("player" + playerku).gameObject.SetActive(false);
    }
    [PunRPC]
    void ngajakBobo(string ygngajakBobo,string namabed, int bedno)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            if(PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("jumlahMauTidur"))
            setTgl.Add("jumlahMauTidur", (int)PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"]+1);
            else setTgl.Add("jumlahMauTidur", 1);
            setTgl.Add(namabed + bedno, ygngajakBobo);
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);

            if (PlayerPrefs.GetString("level") == "MasukRumah") 
            {
                waitingother.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Menunggu pemain lain untuk tidur  (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
                waitingother2.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Menunggu pemain lain untuk tidur  (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == (int)PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"])
                photonView.RPC("tidursemua",RpcTarget.All);

            GameObject.Find("Canvas").transform.Find("TextNotif").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("TextNotif").GetComponent<Text>().text = ygngajakBobo + " nyuruh kalian untuk tidur (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
        }
        if (PlayerPrefs.GetString("level") == "MasukRumah") 
        {
            if (!PhotonNetwork.IsMasterClient)
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + ygngajakBobo + ")").GetComponent<Rigidbody>().isKinematic = true;
            GameObject.Find("Barang").transform.Find(namabed).GetComponent<bed>().orangtidur.Add(ygngajakBobo);
            
        }
        //Debug.Log(namabed + bedno);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + ygngajakBobo + ")").transform.eulerAngles = new Vector3(-90, 180, 0);
        if (PhotonNetwork.NickName == ygngajakBobo)
        {
            if(namabed=="Bed1") GameObject.Find("CanvasHome").transform.Find("WaitingOtherPlayer").gameObject.SetActive(true);
            else if (namabed == "Bed2") GameObject.Find("CanvasHome").transform.Find("WaitingOtherPlayer2").gameObject.SetActive(true);
        }
        PlayerPrefs.SetString("ygngajakBobo", ygngajakBobo);

        
    }

    [PunRPC]
    void tidursemua()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed11"))
            if (PhotonNetwork.CurrentRoom.CustomProperties["Bed11"].ToString() == PlayerPrefs.GetString("myname")) PlayerPrefs.SetString("respawn", "depanmeja");
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed12"))
            if (PhotonNetwork.CurrentRoom.CustomProperties["Bed12"].ToString() == PlayerPrefs.GetString("myname")) PlayerPrefs.SetString("respawn", "depanmeja2");
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed21"))
            if (PhotonNetwork.CurrentRoom.CustomProperties["Bed21"].ToString() == PlayerPrefs.GetString("myname")) PlayerPrefs.SetString("respawn", "depanmeja3");
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("Bed22"))
            if (PhotonNetwork.CurrentRoom.CustomProperties["Bed22"].ToString() == PlayerPrefs.GetString("myname")) PlayerPrefs.SetString("respawn", "depanmeja4");

        if (PhotonNetwork.IsMasterClient)
        {
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add("jumlahMauTidur", 0);
            setTgl.Add("Bed11", "");
            setTgl.Add("Bed12", "");
            setTgl.Add("Bed21", "");
            setTgl.Add("Bed22", "");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);

            //SET CHICKEN
            PlayerPrefs.SetInt("ChickenFood", (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"]);
            for (int i = 0; i < PlayerPrefs.GetInt("ChickenMax"); i++)
            {
                PlayerPrefs.SetString("box" + (i + 1), PhotonNetwork.CurrentRoom.CustomProperties["box" + (i + 1)].ToString());

                if (PlayerPrefs.GetString("Chicken" + i) != "")
                {
                    PlayerPrefs.SetFloat("ChickenPosX" + i, GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString()).transform.position.x);
                    PlayerPrefs.SetFloat("ChickenPosY" + i, GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString()).transform.position.y);
                    PlayerPrefs.SetFloat("ChickenPosZ" + i, GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString()).transform.position.z);
                }
            }

            //SET SAPI
            PlayerPrefs.SetInt("CowFood", (int)PhotonNetwork.CurrentRoom.CustomProperties["CowFood"]);
            for (int i = 0; i < PlayerPrefs.GetInt("CowMax"); i++)
            {
                PlayerPrefs.SetString("boxcow" + (i + 1), PhotonNetwork.CurrentRoom.CustomProperties["boxcow" + (i + 1)].ToString());

                if (PlayerPrefs.GetString("Cow" + i) != "")
                {
                    PlayerPrefs.SetFloat("CowPosX" + i, GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString()).transform.position.x);
                    PlayerPrefs.SetFloat("CowPosY" + i, GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString()).transform.position.y);
                    PlayerPrefs.SetFloat("CowPosZ" + i, GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString()).transform.position.z);
                }
            }

            if (PlayerPrefs.HasKey("save"))
            {
                ExampleSaveCustom loadsave = new ExampleSaveCustom();
                loadsave.Save();
            }
            
        }

        for(int i=0; i<GameObject.Find("PlayerSpawn").transform.childCount;i++)
        {
            GameObject.Find("PlayerSpawn").transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("PlayerSpawn").transform.GetChild(i).transform.eulerAngles = new Vector3(0, 235, 0);
        }
        GameObject.Find("Barang").transform.Find("Bed1").GetComponent<bed>().orangtidur.Clear();
        GameObject.Find("Barang").transform.Find("Bed2").GetComponent<bed>().orangtidur.Clear();
        PlayerPrefs.SetString("nosave", "");
        PlayerPrefs.SetString("tidur", "");
        PlayerPrefs.SetInt("stamina", PlayerPrefs.GetInt("maxstamina"));
        PlayerPrefs.SetString("newday", "no");
        if (PlayerPrefs.GetString("hari") == "Senin") PlayerPrefs.SetString("hari", "Selasa");
        else if (PlayerPrefs.GetString("hari") == "Selasa") PlayerPrefs.SetString("hari", "Rabu");
        else if (PlayerPrefs.GetString("hari") == "Rabu") PlayerPrefs.SetString("hari", "Kamis");
        else if (PlayerPrefs.GetString("hari") == "Kamis") PlayerPrefs.SetString("hari", "Jumat");
        else if (PlayerPrefs.GetString("hari") == "Jumat") PlayerPrefs.SetString("hari", "Sabtu");
        else if (PlayerPrefs.GetString("hari") == "Sabtu") PlayerPrefs.SetString("hari", "Minggu");
        else if (PlayerPrefs.GetString("hari") == "Minggu") PlayerPrefs.SetString("hari", "Senin");

        
    }

    [PunRPC]
    void keluarBobo(string ygngajakBobo, string namabed, int bedno)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add("jumlahMauTidur", (int)PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"] - 1);
            if (bedno == 2) setTgl.Add(namabed + bedno, "");
            else if (bedno == 1 && PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(namabed + 2))
            {
                if(PhotonNetwork.CurrentRoom.CustomProperties[namabed + 2].ToString() != "")
                {
                    setTgl.Add(namabed + (bedno + 1), "");
                    setTgl.Add(namabed + bedno, PhotonNetwork.CurrentRoom.CustomProperties[namabed + (bedno + 1)].ToString());
                    if(PhotonNetwork.CurrentRoom.CustomProperties[namabed + (bedno + 1)].ToString() == PlayerPrefs.GetString("myname"))
                        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").transform.position = GameObject.Find("Barang").transform.Find(namabed).Find("tempatbobo1").position;
                    else photonView.RPC("pindahposisikasur", PhotonNetwork.CurrentRoom.GetPlayer(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.CurrentRoom.CustomProperties[namabed + (bedno + 1)].ToString() + ")").GetComponent<PhotonView>().ViewID), PhotonNetwork.CurrentRoom.CustomProperties[namabed + (bedno + 1)].ToString(), namabed, bedno);
                }
                else if (bedno == 1) setTgl.Add(namabed + bedno, "");
            }
            else if (bedno == 1) setTgl.Add(namabed + bedno, "");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);

            if (PlayerPrefs.GetString("level") == "MasukRumah") 
            {
                waitingother.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Menunggu pemain lain untuk tidur  (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
                waitingother2.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Menunggu pemain lain untuk tidur  (" + PhotonNetwork.CurrentRoom.CustomProperties["jumlahMauTidur"].ToString() + "/" + PhotonNetwork.CurrentRoom.PlayerCount + ")";
            }
                  

        }


        if (PlayerPrefs.GetString("level") == "MasukRumah")
        {
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + ygngajakBobo + ")").GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("Barang").transform.Find(namabed).GetComponent<bed>().orangtidur.Remove(ygngajakBobo);

        }

    }

    [PunRPC]
    void pindahposisikasur(string ygngajakBobo, string namabed, int bedno)
    {
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + ygngajakBobo + ")").transform.position = GameObject.Find("Barang").transform.Find(namabed).Find("tempatbobo"+bedno).position;
    }

    [PunRPC]
    void gantiWarna(string namaplayer, string gender, int h1, int h2, int h3, int cloth1, int cloth2, int cloth3, int pants1, int pants2, int pants3, int skin1, int skin2, int skin3, string peralatan, string barang)
    {
        StartCoroutine(gantiWarna2(namaplayer, gender, h1, h2, h3, cloth1, cloth2, cloth3, pants1, pants2, pants3, skin1, skin2, skin3, peralatan, barang));
    }

    IEnumerator gantiWarna2(string namaplayer, string gender, int h1, int h2, int h3, int cloth1, int cloth2, int cloth3, int pants1, int pants2, int pants3, int skin1, int skin2, int skin3, string peralatan, string barang)
    {
        Debug.Log("GANTI WARNA: "+namaplayer + " " + gender + " " + h1 + " " + h2 + " " + h3);
        //LOAD HAIR
        yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(namaplayer) != null);
        
        //while (GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body") == null) yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body")!=null);
        int nomormat = 0;
        Color32 hair = new Color32((byte)h1, (byte)h2, (byte)h3, 255);
        GameObject go = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).gameObject;
        //Debug.Log("len : " + GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length);
        if (gender == "cewek")
        {
            for (; nomormat < go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = hair;
            }
        }
        else
        {
            for (; nomormat < go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = hair;
            }
        }

        //LOAD BAJU
        Color32 clothes = new Color32((byte)cloth1, (byte)cloth2, (byte)cloth3, 255);
        nomormat = 0;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Top").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = clothes;

        //LOAD CELANA
        Color32 pants = new Color32((byte)pants1, (byte)pants2, (byte)pants3, 255);
        nomormat = 0;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Bottom").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = pants;

        //LOAD SKIN
        Color32 skin = new Color32((byte)skin1, (byte)skin2, (byte)skin3, 255);
        nomormat = 8;
        go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[0].color = skin;
        go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = skin;

        //LOAD WEAPON
        GameObject myweapon = GameObject.Find("PlayerSpawn");
        myweapon = go.transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
        for (int i = 0; i < myweapon.transform.childCount; i++)
            myweapon.transform.GetChild(i).gameObject.SetActive(false);
        myweapon.transform.Find(peralatan).gameObject.SetActive(true);

        StopCoroutine(gantiWarna2(namaplayer, gender, h1, h2, h3, cloth1, cloth2, cloth3, pants1, pants2, pants3, skin1, skin2, skin3, peralatan, barang));

    }

    [PunRPC]
    void changeweapon(string namaplayer, string peralatan, string barang, string gender)
    {
        //LOAD WEAPON
        GameObject myweapon = GameObject.Find("PlayerSpawn");
        myweapon = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
        for (int i = 0; i < myweapon.transform.childCount; i++)
            myweapon.transform.GetChild(i).gameObject.SetActive(false);
        if(peralatan!="")
        myweapon.transform.Find(peralatan).gameObject.SetActive(true);
    }

    

    public override void OnPlayerLeftRoom(Player otherPlayer)//called whenever a player leave the room
    {
        if (!otherPlayer.NickName.Contains("Player"))
        {
            if(PhotonNetwork.CurrentRoom.CustomProperties["wardrobe"].ToString()==otherPlayer.NickName)
            GameObject.Find("Barang").transform.Find("Wardrobe").GetComponent<PhotonView>().RPC("rpcDipake", RpcTarget.All, false);
            Debug.Log(otherPlayer.NickName);
            Destroy(GameObject.Find("PlayerSpawn").transform.Find("Player ("+otherPlayer.NickName + ")").gameObject);
            GameObject.Find("Canvas").transform.Find("TextNotif").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("TextNotif").GetComponent<Text>().text = otherPlayer.NickName + " keluar dari permainan";
            //if (PhotonNetwork.IsMasterClient && otherPlayer.CustomProperties["setlevel"].ToString()== "Peternakan") GameObject.Find("AISpawn").transform.Find("cow_ai").GetComponent<PhotonView>().RPC("cowaktif", RpcTarget.MasterClient, false);
            GetComponent<PhotonView>().RPC("updatePlayerUI", RpcTarget.All);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.Disconnect();
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();
        GameObject.Find("Canvas").transform.Find("Disconnected").gameObject.SetActive(true);
    }

    

    IEnumerator cekpindahlevel(string nick)
    {
        while (GameObject.Find("PlayerSpawn").transform.Find(nick) == null) yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(nick) != null);
        if(GameObject.Find("PlayerSpawn").transform.Find(nick).GetComponent<Player1>().level==PlayerPrefs.GetString("level")) GameObject.Find("PlayerSpawn").transform.Find(nick).gameObject.SetActive(true);
        Debug.Log("ok");
    }

    public float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    //SET PLAYER MONEY
    public void setmoney(int duitkusekarang)
    {
        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        PlayerPrefs.SetInt("money", duitkusekarang);
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add("money", PlayerPrefs.GetInt("money"));
        PhotonNetwork.LocalPlayer.SetCustomProperties(setProperti);
        GameObject.Find("Canvas").transform.Find("UIkanan").Find("JumlahDuit").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("money");
        GetComponent<PhotonView>().RPC("updatePlayerUI", RpcTarget.All);
    }

    private void OnApplicationQuit()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        //Menghapus List Room
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject.Find("LobbyControllerCustomMatchmaking").GetComponent<PhotonView>().RPC("leftRoom", RpcTarget.Others, PhotonNetwork.CurrentRoom.Name);
        }
        //PhotonNetwork.SendOutgoingCommands();
    }
}

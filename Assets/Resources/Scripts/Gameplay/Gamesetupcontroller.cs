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

            dateskrg.text = PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString();
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
                dateskrg.text = PlayerPrefs.GetInt("tanggal") + " " + PlayerPrefs.GetString("musim") + " " + PlayerPrefs.GetInt("tahun");
                if (PlayerPrefs.GetString("musim") == "Spring") mymusim.sprite = weather[0];
                else if (PlayerPrefs.GetString("musim") == "Summer") mymusim.sprite = weather[1];
                else if (PlayerPrefs.GetString("musim") == "Fall") mymusim.sprite = weather[2];
                else if (PlayerPrefs.GetString("musim") == "Winter") mymusim.sprite = weather[3];

                ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
                setTgl.Add("mykebun", PlayerPrefs.GetString("mykebun"));
                setTgl.Add("tanggal", PlayerPrefs.GetInt("tanggal"));
                setTgl.Add("tahun", PlayerPrefs.GetInt("tahun"));
                setTgl.Add("musim", PlayerPrefs.GetString("musim"));
                setTgl.Add("jam", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text);
                setTgl.Add("detik", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
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

        //NEW DAY
        if (PlayerPrefs.GetString("newday") == "no" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text == "06" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text == "00")
        {
            PlayerPrefs.SetString("ambilduitharian", "no");
            PlayerPrefs.SetFloat("directionalSun",0);

            if (PhotonNetwork.IsMasterClient)
            {

                //Sethujan
                ExitGames.Client.Photon.Hashtable setrain = new ExitGames.Client.Photon.Hashtable();
                setrain.Add("rain",false);
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
                                    Debug.Log("update siram");
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
                                            if(System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString())+1 == System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString()))
                                            {

                                            }
                                        }
                                        //Max UMUR BERBUAH JUGA
                                        else if((bool)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulrenewable" + i])
                                        {
                                            //Max UMUR BERBUAH
                                            if (System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumurberbuah" + i].ToString()) == System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumurberbuah" + i].ToString()))
                                            {
                                                setLahan.Add("lahancangkulumurberbuah" + i, 1);
                                                PhotonNetwork.Instantiate(Path.Combine("Model/Buah", PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulbuah"+i].ToString()), 
                                                    new Vector3((float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposx"+i], (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposy" + i], (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposz" + i]), Quaternion.identity);
                                            }
                                            else 
                                            setLahan.Add("lahancangkulumurberbuah" + i, System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumurberbuah" + i].ToString()) + 1);
                                        }
                                    }

                                    //Set TANEMAN DISIRAM apa ngga pas hari hujan
                                    if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["rain"])
                                    {
                                        setLahan.Add("lahancangkulsiram"+i,true);
                                    }
                                    else
                                    {
                                        setLahan.Add("lahancangkulsiram" + i, false);
                                    }

                                    if (System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmati" + i].ToString()) > 3 || PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulseason" + i].ToString()!= PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString())
                                    {
                                        setLahan.Add("lahancangkulnama" + i, "");
                                        setLahan.Add("lahancangkulbuah" + i, "");
                                    }
                                }
                            }
                        }
                    }
                }
                PhotonNetwork.CurrentRoom.SetCustomProperties(setLahan);
            }

            PlayerPrefs.SetString("newday", "yes");
        }
        else PlayerPrefs.SetString("newday", "no");

        if (PlayerPrefs.GetString("level") != "MasukRumah" && PlayerPrefs.GetString("level") != "MasukKandangAyam")
        {
            GameObject.Find("Sun").transform.eulerAngles = new Vector3(0f, -30f, 0f);
            GameObject.Find("Sun").transform.Rotate(PlayerPrefs.GetFloat("directionalSun"), 0, 0, Space.Self);
            if(PlayerPrefs.GetString("level") == "KeluarRumah")
            {
                GameObject.Find("bridge").transform.Find("Box051").Find("NamaFarm").GetComponent<TextMesh>().text = "Kebun\n"+(string)PhotonNetwork.CurrentRoom.CustomProperties["mykebun"];
                for(int i=0;i< PhotonNetwork.CurrentRoom.CustomProperties.Count; i++)
                {
                    if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("lahancangkulnama" + i))
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulnama"+i].ToString() != "")
                        {
                            string lahan = "";
                            string namalahan = "";
                            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("terpacul_" + i)) { lahan = "LahanCangkul"; namalahan = "terpacul_"; }
                            else if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("tanahbibit_" + i)) { lahan = "LahanCangkulBibit"; namalahan = "tanahbibit_"; }

                            GameObject go = null;
                            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("tanahbibit_" + i))
                            {
                                var hasilbagi = (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString())/ (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString());
                                if (hasilbagi >= 0.3f)
                                    lahan = "LahanCangkul"+ PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulbuah" + i].ToString();
                            }
                                
                            go = Instantiate(Resources.Load<GameObject>("Images/Lahan/" + lahan), new Vector3((float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposx" + i], (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposy" + i], (float)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulposz" + i]), Quaternion.identity);
                            go.transform.parent = GameObject.Find("SawahSpawn").transform;
                            go.name = namalahan + i;
                            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsValue("tanahbibit_" + i))
                            {
                                var hasilbagi = (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString()) / (float)System.Int32.Parse(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString());
                                Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulumur" + i].ToString()+" / "+ PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulmaxumur" + i].ToString());
                                if(go.transform.Find("lahanpohon")!=null)
                                go.transform.Find("lahanpohon").transform.position = new Vector3(go.transform.Find("lahanpohon").transform.position.x,-1.2f+hasilbagi, go.transform.Find("lahanpohon").transform.position.z);
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
                        }
                    }
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

        

        
        setmusic();
        

        GameObject myrespawn = null;
        if (PlayerPrefs.GetString("respawn") == "pintumasukrumah") myrespawn = GameObject.Find("PlayerSpawnPintu");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja") myrespawn = GameObject.Find("BangunTidurSpawn");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja2") myrespawn = GameObject.Find("BangunTidurSpawn2");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja3") myrespawn = GameObject.Find("BangunTidurSpawn3");
        else if (PlayerPrefs.GetString("respawn") == "depanmeja4") myrespawn = GameObject.Find("BangunTidurSpawn4");
        else if (PlayerPrefs.GetString("respawn") == "pintukeluarrumah") myrespawn = GameObject.Find("LuarRumahSpawn");
        else if (PlayerPrefs.GetString("respawn") == "pintumasukkandangayam") myrespawn = GameObject.Find("PlayerSpawnPintu");
        else if (PlayerPrefs.GetString("respawn") == "pintukeluarkandangayam") myrespawn = GameObject.Find("LuarKandangAyamSpawn");
        else {
            myrespawn = GameObject.Find(PlayerPrefs.GetString("respawn"));
        }

        if (GameObject.Find("Player (" + PlayerPrefs.GetString("myname") + ")") == null)
            if (PlayerPrefs.GetString("gender") == "cewek")
            {
                //Debug.Log("GOGO");
                fotoku.texture = cewek;
                if (PhotonNetwork.IsConnectedAndReady)
                    go = PhotonNetwork.Instantiate(Path.Combine("Model/Orang", "Sendagaya_Shino_axe"), myrespawn.transform.position, Quaternion.identity);
                else
                    go = Instantiate(mycharcewe, myrespawn.transform.position, Quaternion.identity);
            }
            else
            {
                fotoku.texture = cowok;
                if (PhotonNetwork.IsConnectedAndReady)
                    go = PhotonNetwork.Instantiate(Path.Combine("Model/Orang", "Sakurada_Fumiriya_axe"), myrespawn.transform.position, Quaternion.identity);
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

        //LOAD HAIR
        Color32 mycolorhair = new Color32((byte)PlayerPrefs.GetInt("warnahairred"), (byte)PlayerPrefs.GetInt("warnahairgreen"), (byte)PlayerPrefs.GetInt("warnahairblue"),255);
        int nomormat = 0;
        if (PlayerPrefs.GetString("gender") == "cewek")
        {
            for (; nomormat < go.transform.Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                go.transform.Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorhair;
            }
        }
        else
        {
            for (; nomormat < go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                go.transform.Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorhair;
            }
        }

        //LOAD BAJU
        Color32 mycolorclothes = new Color32((byte)PlayerPrefs.GetInt("warnaclothesred"), (byte)PlayerPrefs.GetInt("warnaclothesgreen"), (byte)PlayerPrefs.GetInt("warnaclothesblue"), 255);
        nomormat = 3;
        if (PlayerPrefs.GetString("gender") == "cewek") nomormat = 5;
        go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorclothes;

        //LOAD CELANA
        Color32 mycolorcelana = new Color32((byte)PlayerPrefs.GetInt("warnapantsred"), (byte)PlayerPrefs.GetInt("warnapantsgreen"), (byte)PlayerPrefs.GetInt("warnapantsblue"), 255);
        nomormat = 1;
        if (PlayerPrefs.GetString("gender") == "cewek") nomormat = 6;
        go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = mycolorcelana;

        //LOAD SKIN
        Color32 mycolorskin= new Color32((byte)PlayerPrefs.GetInt("warnaskinred"), (byte)PlayerPrefs.GetInt("warnaskingreen"), (byte)PlayerPrefs.GetInt("warnaskinblue"), 255);
        nomormat = 2;
        go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[0].color = mycolorskin;
        if (PlayerPrefs.GetString("gender") == "cewek")
            go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[2].color = mycolorskin;
        if (PlayerPrefs.GetString("gender") == "cewek") go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[7].color = mycolorskin;
        else go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[5].color = mycolorskin;
        if (PlayerPrefs.GetString("gender") == "cewek")
            go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[8].color = mycolorskin;
        else
            go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[1].color = mycolorskin;
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
        GameObject myweapon = new GameObject();
        if (PlayerPrefs.GetString("gender") == "cowok")
            myweapon = go.transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
        else if (PlayerPrefs.GetString("gender") == "cewek")
            myweapon = go.transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
        for (int i = 0; i < myweapon.transform.childCount; i++)
            myweapon.transform.GetChild(i).gameObject.SetActive(false);
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

        //setshowAI sapi
        if(PlayerPrefs.GetString("level") == "Peternakan")
        {
            GameObject.Find("AISpawn").transform.Find("cow_ai").Find("Cow").GetComponent<SkinnedMeshRenderer>().enabled = true;
            GameObject.Find("AISpawn").transform.Find("cow_ai").Find("Cow").GetComponent<MeshCollider>().enabled = true;
            GameObject.Find("AISpawn").transform.Find("cow_ai").GetComponent<PhotonView>().RPC("cowaktif", RpcTarget.MasterClient, true);
        }
        else if(PlayerPrefs.GetString("respawn") == "SpawnPeternakan")
        {
            GameObject.Find("AISpawn").transform.Find("cow_ai").Find("Cow").GetComponent<SkinnedMeshRenderer>().enabled = false;
            GameObject.Find("AISpawn").transform.Find("cow_ai").Find("Cow").GetComponent<MeshCollider>().enabled = false;
            GameObject.Find("AISpawn").transform.Find("cow_ai").GetComponent<PhotonView>().RPC("cowaktif", RpcTarget.MasterClient, false);
        }

        //REQUEST POSISI/ROTATION AWAL MASUK SCENE KE SEMUA PLAYER
       
        photonView.RPC("mintaposisi", RpcTarget.Others);

        transisi.SetActive(true);
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
        for (int i = 0; i < GameObject.Find("PlayerSpawn").transform.childCount; i++)
            if (GameObject.Find("PlayerSpawn").transform.GetChild(i).GetComponent<Player1>().level == PlayerPrefs.GetString("level"))
            {
                //GameObject.Find("PlayerSpawn").transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                GameObject.Find("PlayerSpawn").transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
               // GameObject.Find("PlayerSpawn").transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
                GameObject.Find("PlayerSpawn").transform.GetChild(i).gameObject.SetActive(false);
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

    [PunRPC]
    void mintaposisi()
    {
        float posisix = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position.x;
        float posisiy = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position.y;
        float posisiz = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position.z;
        float rotatex = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.x;
        float rotatey = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.y;
        float rotatez = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.z;

        photonView.RPC("setposisiawal", RpcTarget.Others, PhotonNetwork.NickName, posisix,posisiy,posisiz,rotatex,rotatey,rotatez);
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
            GameObject.Find("Sun").transform.eulerAngles = new Vector3(0f, -30f, 0f);
            GameObject.Find("Sun").transform.Rotate(vector3, 0, 0, Space.Self);
        }
        PlayerPrefs.SetString("newday", "no");
        PlayerPrefs.SetFloat("directionalSun", vector3);
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
        Debug.Log(namaplayer + " " + gender + " " + h1 + " " + h2 + " " + h3);
        //LOAD HAIR
        while (GameObject.Find("PlayerSpawn").transform.Find(namaplayer) == null) yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(namaplayer) != null);
        
        //while (GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body") == null) yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body")!=null);
        int nomormat = 0;
        Color32 hair = new Color32((byte)h1, (byte)h2, (byte)h3, 255);
        GameObject go = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).gameObject;
        //Debug.Log("len : " + GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length);
        if (gender == "cewek")
        {
            for (; nomormat < go.transform.Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                go.transform.Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = hair;
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
        nomormat = 3;
        if (gender == "cewek") nomormat = 5;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = clothes;

        //LOAD CELANA
        Color32 pants = new Color32((byte)pants1, (byte)pants2, (byte)pants3, 255);
        nomormat = 1;
        if (gender == "cewek") nomormat = 6;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = pants;

        //LOAD SKIN
        Color32 skin = new Color32((byte)skin1, (byte)skin2, (byte)skin3, 255);
        nomormat = 2;
        go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[0].color = skin;
        if (gender == "cewek")
            go.transform.Find("Body").GetComponent<SkinnedMeshRenderer>().materials[2].color = skin;
        if (gender == "cewek") go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[7].color = skin;
        else go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[5].color = skin;
        if (gender == "cewek")
            go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[8].color = skin;
        else
            go.transform.Find("Face").GetComponent<SkinnedMeshRenderer>().materials[1].color = skin;

        //LOAD WEAPON
        GameObject myweapon = new GameObject();
        if (gender == "cowok")
            myweapon = go.transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
        if (gender == "cewek")
            myweapon = go.transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
        for (int i = 0; i < myweapon.transform.childCount; i++)
            myweapon.transform.GetChild(i).gameObject.SetActive(false);
        myweapon.transform.Find(peralatan).gameObject.SetActive(true);

        StopCoroutine(gantiWarna2(namaplayer, gender, h1, h2, h3, cloth1, cloth2, cloth3, pants1, pants2, pants3, skin1, skin2, skin3, peralatan, barang));

    }

    [PunRPC]
    void changeweapon(string namaplayer, string peralatan, string barang, string gender)
    {
        //LOAD WEAPON
        GameObject myweapon = new GameObject();
        if (gender == "cowok")
            myweapon = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
        if (gender == "cewek")
            myweapon = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
        for (int i = 0; i < myweapon.transform.childCount; i++)
            myweapon.transform.GetChild(i).gameObject.SetActive(false);
        if(peralatan!="")
        myweapon.transform.Find(peralatan).gameObject.SetActive(true);
    }

    

    public override void OnPlayerLeftRoom(Player otherPlayer)//called whenever a player leave the room
    {
        if (!otherPlayer.NickName.Contains("Player"))
        {
            Debug.Log(otherPlayer.NickName);
            Destroy(GameObject.Find("PlayerSpawn").transform.Find("Player ("+otherPlayer.NickName + ")").gameObject);
            GameObject.Find("Canvas").transform.Find("TextNotif").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("TextNotif").GetComponent<Text>().text = otherPlayer.NickName + " keluar dari permainan";
            if (PhotonNetwork.IsMasterClient && otherPlayer.CustomProperties["setlevel"].ToString()== "Peternakan") GameObject.Find("AISpawn").transform.Find("cow_ai").GetComponent<PhotonView>().RPC("cowaktif", RpcTarget.MasterClient, false);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.Disconnect();
        GameObject.Find("Canvas").transform.Find("Disconnected").gameObject.SetActive(true);
    }

    

    IEnumerator cekpindahlevel(string nick)
    {
        while (GameObject.Find("PlayerSpawn").transform.Find(nick) == null) yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(nick) != null);
        if(GameObject.Find("PlayerSpawn").transform.Find(nick).GetComponent<Player1>().level==PlayerPrefs.GetString("level")) GameObject.Find("PlayerSpawn").transform.Find(nick).gameObject.SetActive(true);
        Debug.Log("ok");
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

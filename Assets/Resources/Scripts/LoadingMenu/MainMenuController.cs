using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviourPunCallbacks
{
    public GameObject mainmenuOBJ;
    public GameObject singleplayerOBJ;
    public GameObject loadgameOBJ;
    public GameObject multiplayerOBJ;
    public GameObject loginmultiplayerOBJ;
    public GameObject earlyOBJ;
    public GameObject permainanbaruOBJ;
    public GameObject loadgamemultiplayerOBJ;
    public GameObject loadInventoryOBJ;
    public GameObject loadShopOBJ;
    public GameObject loadFriendListOBJ;
    public GameObject pilihkarakterOBJ;
    public GameObject lobbyOBJ;
    public GameObject settingOBJ;
    public AudioMixer mixer;

    public GameObject notifwrong;
    public GameObject notifkonek;
    public GameObject notifpurchased;
    public GameObject konfirmlanjut;
    public GameObject transisi;

    public GameObject inputnama;
    public GameObject inputulangtaun;
    public GameObject inputfarm;
    public GameObject inputkucing;
    public GameObject inputkonfirmasi;
    public GameObject inputgender;
    public GameObject inputdandan;

    public Dropdown inputhaircolor;
    public Dropdown inputclothescolor;
    public Dropdown inputpantscolor;
    public Dropdown inputskincolor;
    public Dropdown inputDropdownLanguage;

    public string roomName;
    public string pilihMenu;

    public static MainMenuController instance = null;

    //Warna
    string HitamText;
    string PutihText;
    string BiruText;
    string MerahText;
    string KuningText;
    string HijauText;
    string AbuabuText;
    string PutihCokelatText;
    string CokelatText;
    string CokelatGelapText;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        PlayerPrefs.SetInt("warnahairred", 0);
        PlayerPrefs.SetInt("warnahairgreen", 0);
        PlayerPrefs.SetInt("warnahairblue", 0);

        PlayerPrefs.SetInt("warnaclothesred", 255);
        PlayerPrefs.SetInt("warnaclothesgreen", 255);
        PlayerPrefs.SetInt("warnaclothesblue", 255);

        PlayerPrefs.SetInt("warnapantsred", 0);
        PlayerPrefs.SetInt("warnapantsgreen", 0);
        PlayerPrefs.SetInt("warnapantsblue", 0);

        PlayerPrefs.SetInt("warnaskinred", 255);
        PlayerPrefs.SetInt("warnaskingreen", 255);
        PlayerPrefs.SetInt("warnaskinblue", 255);

        PlayerPrefs.SetInt("tanggal", 1);
        PlayerPrefs.SetString("musim", "Spring");
        PlayerPrefs.SetInt("tahun", 2020);
        PlayerPrefs.SetInt("money", 25000);
        PlayerPrefs.SetInt("maxstamina", 150);
        PlayerPrefs.SetInt("stamina", 150);
        PlayerPrefs.SetInt("levelbag", 1);

        PlayerPrefs.SetFloat("directionalSun",0f);

        PlayerPrefs.SetString("respawn","depanmeja");
        PlayerPrefs.SetString("level","MasukRumah");
        PlayerPrefs.SetString("ambilduitharian", "no");
        PlayerPrefs.SetString("newday", "no");
        PlayerPrefs.SetString("myserver", "asia");
        PlayerPrefs.SetString("buttonNPC", "");

        //SET FRIENDSHIP
        PlayerPrefs.SetInt("SamsulFriendship", 0);
        PlayerPrefs.SetInt("SamsulKenalan", 1);
        PlayerPrefs.SetInt("MikaFriendship", 60);
        PlayerPrefs.SetInt("MikaGift", 1);
        PlayerPrefs.SetInt("AyuFriendship", 0);
        PlayerPrefs.SetInt("AyuKenalan", 1);
        PlayerPrefs.SetInt("AfifahFriendship", 0);
        PlayerPrefs.SetInt("AfifahKenalan", 1);
        PlayerPrefs.SetInt("OtongFriendship", 0);
        PlayerPrefs.SetInt("OtongKenalan", 1);
        PlayerPrefs.SetInt("motorkopiFriendship", 0);
        PlayerPrefs.SetInt("AnggunFriendship", 0);
        PlayerPrefs.SetInt("WindiFriendship", 0);
        PlayerPrefs.SetInt("EmonFriendship", 0);
        PlayerPrefs.SetInt("MiniFriendship", 0);
        PlayerPrefs.SetInt("MiniKenalan", 1);

        PlayerPrefs.DeleteKey("online");
        PlayerPrefs.DeleteKey("mautidur");
        PlayerPrefs.DeleteKey("pindahinTools");
        PlayerPrefs.DeleteKey("pindahinKantong");
        PlayerPrefs.DeleteKey("buttonTidur");
        PlayerPrefs.DeleteKey("buttonSafeBox");
        PlayerPrefs.DeleteKey("buttonPickBale");
        PlayerPrefs.DeleteKey("buttonNPC");
        PlayerPrefs.DeleteKey("buttonChickenFeed");
        PlayerPrefs.DeleteKey("koleksibaju");
        PlayerPrefs.DeleteKey("koleksirambut");
        PlayerPrefs.DeleteKey("koleksicelana");
        PlayerPrefs.DeleteKey("koleksitopi");
        PlayerPrefs.DeleteKey("bajudipakai");
        PlayerPrefs.DeleteKey("rambutdipakai");
        PlayerPrefs.DeleteKey("celanadipakai");
        PlayerPrefs.DeleteKey("topidipakai");

        PlayerPrefs.DeleteKey("buttonChangeClothes");

        for (int i = 0; i < 53; i++)
        {
            if (PlayerPrefs.HasKey("peralatannama" + i))
                    PlayerPrefs.DeleteKey("peralatannama" + i);
            if (PlayerPrefs.HasKey("peralatanjumlah" + i))
                PlayerPrefs.DeleteKey("peralatanjumlah" + i);
        }

        for (int i = 0; i < 11; i++)
        {
            if (PlayerPrefs.HasKey("kantongnama" + i))
                PlayerPrefs.DeleteKey("kantongnama" + i);
            if (PlayerPrefs.HasKey("kantongjumlah" + i))
                PlayerPrefs.DeleteKey("kantongjumlah" + i);
        }

        //Peralatan
        PlayerPrefs.SetString("peralatannama11", "hoe");
        PlayerPrefs.SetInt("peralatanjumlah11", -1);

        PlayerPrefs.SetString("peralatannama12", "axe");
        PlayerPrefs.SetInt("peralatanjumlah12", -1);

        PlayerPrefs.SetString("peralatannama13", "hammer");
        PlayerPrefs.SetInt("peralatanjumlah13", -1);

        PlayerPrefs.SetString("peralatannama14", "sickle");
        PlayerPrefs.SetInt("peralatanjumlah14", -1);

        PlayerPrefs.SetString("peralatannama15", "watering");
        PlayerPrefs.SetInt("peralatanjumlah15", 20);

        PlayerPrefs.SetString("peralatannama16", "peralatanbibit1");
        PlayerPrefs.SetInt("peralatanjumlah16", 5);

        PlayerPrefs.SetString("peralatannama17", "peralatanbibit2");
        PlayerPrefs.SetInt("peralatanjumlah17", 5);

        PlayerPrefs.SetString("peralatannama18", "peralatanbibit3");
        PlayerPrefs.SetInt("peralatanjumlah18", 5);

        PlayerPrefs.SetString("peralatannama19", "peralatanbibit4");
        PlayerPrefs.SetInt("peralatanjumlah19", 5);

        PlayerPrefs.DeleteKey("buttonPickUpItem");
        //Kantong
        PlayerPrefs.SetString("kantongnama1", "Apple-1");
        PlayerPrefs.SetInt("kantongjumlah1", 1);
        PlayerPrefs.SetString("kantongnama2", "Tomat-1");
        PlayerPrefs.SetInt("kantongjumlah2", 1);

        //AYAM
        PlayerPrefs.SetInt("ChickenFood", 10);
        PlayerPrefs.SetInt("ChickenMax", 10);
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("Chicken" + i))
                PlayerPrefs.DeleteKey("Chicken" + i);
            if (PlayerPrefs.HasKey("ChickenHeart" + i))
                PlayerPrefs.DeleteKey("ChickenHeart" + i);
            if (PlayerPrefs.HasKey("ChickenLevel" + i))
                PlayerPrefs.DeleteKey("ChickenLevel" + i);
            if (PlayerPrefs.HasKey("ChickenSick" + i))
                PlayerPrefs.DeleteKey("ChickenSick" + i);
            if (PlayerPrefs.HasKey("ChickenSilver" + i))
                PlayerPrefs.DeleteKey("ChickenSilver" + i);
            if (PlayerPrefs.HasKey("ChickenGold" + i))
                PlayerPrefs.DeleteKey("ChickenGold" + i);
            if (PlayerPrefs.HasKey("ChickenPosX" + i))
                PlayerPrefs.DeleteKey("ChickenPosX" + i);
            if (PlayerPrefs.HasKey("ChickenPosY" + i))
                PlayerPrefs.DeleteKey("ChickenPosY" + i);
            if (PlayerPrefs.HasKey("ChickenPosZ" + i))
                PlayerPrefs.DeleteKey("ChickenPosZ" + i);
        }

        //CREATE AYAM / BEBEK

        for (int i = 0; i < 2; i++)
        {
            PlayerPrefs.SetString("Chicken" + i, "ayam"+i);
            PlayerPrefs.SetInt("ChickenHeart" + i, 45);
            PlayerPrefs.SetString("ChickenLevel" + i, "MasukKandangAyam");
            PlayerPrefs.SetInt("ChickenSick" + i, 0);
            PlayerPrefs.SetInt("ChickenSilver" + i, 0);
            PlayerPrefs.SetInt("ChickenGold" + i, 0);
            PlayerPrefs.SetFloat("ChickenPosX" + i, i);
            PlayerPrefs.SetFloat("ChickenPosY" + i, 1);
            PlayerPrefs.SetFloat("ChickenPosZ" + i, i);
            PlayerPrefs.SetString("ChickenTipe" + i, "Chicken");

            PlayerPrefs.SetString("box" + (i + 1), "");
        }

        for (int i = 2; i < 4; i++)
        {
            PlayerPrefs.SetString("Chicken" + i, "bebek" + i);
            PlayerPrefs.SetInt("ChickenHeart" + i, 75);
            PlayerPrefs.SetString("ChickenLevel" + i, "MasukKandangAyam");
            PlayerPrefs.SetInt("ChickenSick" + i, 0);
            PlayerPrefs.SetInt("ChickenSilver" + i, 0);
            PlayerPrefs.SetInt("ChickenGold" + i, 0);
            PlayerPrefs.SetFloat("ChickenPosX" + i, i);
            PlayerPrefs.SetFloat("ChickenPosY" + i, 1);
            PlayerPrefs.SetFloat("ChickenPosZ" + i, i);
            PlayerPrefs.SetString("ChickenTipe" + i, "Duck");

            PlayerPrefs.SetString("box" + (i + 1), "");
        }

        for (int i = 4; i < PlayerPrefs.GetInt("ChickenMax"); i++)
        {
            PlayerPrefs.SetString("Chicken" + i, "");
            PlayerPrefs.SetInt("ChickenHeart" + i, 0);
            PlayerPrefs.SetString("ChickenLevel" + i, "");
            PlayerPrefs.SetInt("ChickenSick" + i, 0);
            PlayerPrefs.SetInt("ChickenSilver" + i, 0);
            PlayerPrefs.SetInt("ChickenGold" + i, 0);
            PlayerPrefs.SetFloat("ChickenPosX" + i, 0);
            PlayerPrefs.SetFloat("ChickenPosY" + i, 0);
            PlayerPrefs.SetFloat("ChickenPosZ" + i, 0);
            PlayerPrefs.SetString("ChickenTipe" + i, "");

            PlayerPrefs.SetString("box" + (i+1), "");
        }

        //Sapi
        PlayerPrefs.SetInt("CowFood", 5);
        PlayerPrefs.SetInt("CowMax", 10);
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("Cow" + i))
                PlayerPrefs.DeleteKey("Cow" + i);
            if (PlayerPrefs.HasKey("CowHeart" + i))
                PlayerPrefs.DeleteKey("CowHeart" + i);
            if (PlayerPrefs.HasKey("CowLevel" + i))
                PlayerPrefs.DeleteKey("CowLevel" + i);
            if (PlayerPrefs.HasKey("CowSick" + i))
                PlayerPrefs.DeleteKey("CowSick" + i);
            if (PlayerPrefs.HasKey("CowSilver" + i))
                PlayerPrefs.DeleteKey("CowSilver" + i);
            if (PlayerPrefs.HasKey("CowGold" + i))
                PlayerPrefs.DeleteKey("CowGold" + i);
            if (PlayerPrefs.HasKey("CowMilk" + i))
                PlayerPrefs.DeleteKey("CowMilk" + i);
            if (PlayerPrefs.HasKey("CowPosX" + i))
                PlayerPrefs.DeleteKey("CowPosX" + i);
            if (PlayerPrefs.HasKey("CowPosY" + i))
                PlayerPrefs.DeleteKey("CowPosY" + i);
            if (PlayerPrefs.HasKey("CowPosZ" + i))
                PlayerPrefs.DeleteKey("CowPosZ" + i);
        }

        //CREATE SAPI / KAMBING
        PlayerPrefs.SetString("Cow0", "kambing0");
        PlayerPrefs.SetInt("CowHeart0", 5);
        PlayerPrefs.SetString("CowLevel0", "MasukKandangSapi");
        PlayerPrefs.SetInt("CowSick0", 0);
        PlayerPrefs.SetInt("CowSilver0", 0);
        PlayerPrefs.SetInt("CowGold0", 0);
        PlayerPrefs.SetString("CowMilk0", "small");
        PlayerPrefs.SetFloat("CowPosX0", 4);
        PlayerPrefs.SetFloat("CowPosY0", 1);
        PlayerPrefs.SetFloat("CowPosZ0", 4);
        PlayerPrefs.SetString("CowTipe0", "Goat");

        PlayerPrefs.SetString("boxcow1", "");

        PlayerPrefs.SetString("Cow" + 1, "sapi1");
        PlayerPrefs.SetInt("CowHeart" + 1, 0);
        PlayerPrefs.SetString("CowLevel" + 1, "MasukKandangSapi");
        PlayerPrefs.SetInt("CowSick" + 1, 0);
        PlayerPrefs.SetInt("CowSilver" + 1, 0);
        PlayerPrefs.SetInt("CowGold" + 1, 0);
        PlayerPrefs.SetString("CowMilk" + 1, "small");
        PlayerPrefs.SetFloat("CowPosX" + 1, 1);
        PlayerPrefs.SetFloat("CowPosY" + 1, 1);
        PlayerPrefs.SetFloat("CowPosZ" + 1, 4);
        PlayerPrefs.SetString("CowTipe" + 1, "Cow");

        PlayerPrefs.SetString("boxcow" + 2, "");

        for (int i = 2; i < PlayerPrefs.GetInt("CowMax"); i++)
        {
            /*
            PlayerPrefs.SetString("Cow" + i, "sapi"+i);
            PlayerPrefs.SetInt("CowHeart" + i, 0);
            PlayerPrefs.SetString("CowLevel" + i, "MasukKandangSapi");
            PlayerPrefs.SetInt("CowSick" + i, 0);
            PlayerPrefs.SetInt("CowSilver" + i, 0);
            PlayerPrefs.SetInt("CowGold" + i, 0);
            PlayerPrefs.SetInt("CowMilk"+i, 0);
            PlayerPrefs.SetFloat("CowPosX" + i, i);
            PlayerPrefs.SetFloat("CowPosY" + i, 1);
            PlayerPrefs.SetFloat("CowPosZ" + i, 4);
            PlayerPrefs.SetString("CowTipe" + i, "Cow");

            PlayerPrefs.SetString("boxcow" + (i + 1), "");
            */

            PlayerPrefs.SetString("Cow" + i, "");
            PlayerPrefs.SetInt("CowHeart" + i, 0);
            PlayerPrefs.SetString("CowLevel" + i, "");
            PlayerPrefs.SetInt("CowSick" + i, 0);
            PlayerPrefs.SetInt("CowSilver" + i, 0);
            PlayerPrefs.SetInt("CowGold" + i, 0);
            PlayerPrefs.SetString("CowMilk" + i, "");
            PlayerPrefs.SetFloat("CowPosX" + i, 0);
            PlayerPrefs.SetFloat("CowPosY" + i, 0);
            PlayerPrefs.SetFloat("CowPosZ" + i, 0);
            PlayerPrefs.SetString("CowTipe" + i, "");

            PlayerPrefs.SetString("boxcow" + (i + 1), "");
        }

        //SET SHOP IN GAME
        PlayerPrefs.SetInt("buyCow",0);
        PlayerPrefs.SetInt("buyCalf",0);
        PlayerPrefs.SetInt("buyGoat",0);
        PlayerPrefs.SetInt("buyBabyGoat",0);
        PlayerPrefs.SetInt("buyBale",0);
        if(PlayerPrefs.HasKey("EmonSell"))
        PlayerPrefs.DeleteKey("EmonSell");

        if (GameObject.Find("Canvas").transform.Find("Fixed Joystick") != null)
        {
            Destroy(GameObject.Find("Canvas"));
            GameObject.Find("ServerConnection").GetComponent<MyConnection>().ingame = false;
            GameObject.Find("MyMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/backsound1");
            GameObject.Find("MyMusic").GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.HasKey("bahasa") == false)
        {
            PlayerPrefs.SetString("bahasa", "Indonesia");
        }

        
    }

    void Start()
    {
        //SET SKYBOX
        RenderSettings.skybox.SetFloat("_Exposure", 1f);

        //AUTO AMBIL SETTINGAN
        if (PlayerPrefs.HasKey("Music"))
        {
            GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("SliderBGM").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music");
            mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("Music")) * 20);
        }
        if (PlayerPrefs.HasKey("Sound"))
        {
            GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("SliderSFX").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Sound");
            mixer.SetFloat("SoundVol", Mathf.Log10(PlayerPrefs.GetFloat("Sound")) * 20);
        }

        if (PlayerPrefs.HasKey("GraphicQuality"))
        {
            if (PlayerPrefs.GetInt("GraphicQuality") != GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("QualityVideo").GetComponent<Dropdown>().value)
            {
                //QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicQuality"), true);
                GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("QualityVideo").GetComponent<Dropdown>().value = PlayerPrefs.GetInt("GraphicQuality");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Warna
        HitamText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(43);
        PutihText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(44);
        BiruText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(45);
        MerahText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(46);
        KuningText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(47);
        HijauText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(48);
        AbuabuText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(49);
        PutihCokelatText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(56);
        CokelatText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(57);
        CokelatGelapText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(58);

        if (inputhaircolor.transform.Find("Dropdown List") != null)
        {
            if (inputhaircolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: "+PutihText).Find("Item Image").GetComponent<Image>().color == Color.black)
            {
                inputhaircolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: " + PutihText).Find("Item Image").GetComponent<Image>().color = Color.white;
                inputhaircolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 2: "+BiruText).Find("Item Image").GetComponent<Image>().color = Color.blue;
                inputhaircolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 3: "+MerahText).Find("Item Image").GetComponent<Image>().color = Color.red;
                inputhaircolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 4: "+KuningText).Find("Item Image").GetComponent<Image>().color = Color.yellow;
                inputhaircolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 5: "+HijauText).Find("Item Image").GetComponent<Image>().color = Color.green;
                inputhaircolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 6: "+AbuabuText).Find("Item Image").GetComponent<Image>().color = Color.gray;

            }
        }
        if (inputclothescolor.transform.Find("Dropdown List") != null)
        {
            if (inputclothescolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: "+HitamText).Find("Item Image").GetComponent<Image>().color == Color.white)
            {
                inputclothescolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: "+HitamText).Find("Item Image").GetComponent<Image>().color = Color.black;
                inputclothescolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 2: "+BiruText).Find("Item Image").GetComponent<Image>().color = Color.blue;
                inputclothescolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 3: "+MerahText).Find("Item Image").GetComponent<Image>().color = Color.red;
                inputclothescolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 4: "+KuningText).Find("Item Image").GetComponent<Image>().color = Color.yellow;
                inputclothescolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 5: "+HijauText).Find("Item Image").GetComponent<Image>().color = Color.green;
                inputclothescolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 6: "+AbuabuText).Find("Item Image").GetComponent<Image>().color = Color.gray;

            }
        }
        
        if (inputpantscolor.transform.Find("Dropdown List") != null)
        {
            if (inputpantscolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: "+PutihText).Find("Item Image").GetComponent<Image>().color == Color.black)
            {
                inputpantscolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: "+PutihText).Find("Item Image").GetComponent<Image>().color = Color.white;
                inputpantscolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 2: "+BiruText).Find("Item Image").GetComponent<Image>().color = Color.blue;
                inputpantscolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 3: "+MerahText).Find("Item Image").GetComponent<Image>().color = Color.red;
                inputpantscolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 4: "+KuningText).Find("Item Image").GetComponent<Image>().color = Color.yellow;
                inputpantscolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 5: "+HijauText).Find("Item Image").GetComponent<Image>().color = Color.green;
                inputpantscolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 6: "+AbuabuText).Find("Item Image").GetComponent<Image>().color = Color.gray;

            }
        }

        if (inputskincolor.transform.Find("Dropdown List") != null)
        {
            if (inputskincolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: "+PutihCokelatText).Find("Item Image").GetComponent<Image>().color == Color.white)
            {
                inputskincolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 1: "+PutihCokelatText).Find("Item Image").GetComponent<Image>().color = new Color32(250, 223, 209, 255); ;
                inputskincolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 2: "+CokelatText).Find("Item Image").GetComponent<Image>().color = new Color32(229, 197, 180, 255);  
                inputskincolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 3: "+CokelatGelapText).Find("Item Image").GetComponent<Image>().color = new Color32(193, 157, 139, 255);
                inputskincolor.transform.Find("Dropdown List").Find("Viewport").Find("Content").Find("Item 4: "+HitamText).Find("Item Image").GetComponent<Image>().color = new Color32(138, 108, 92, 255);

            }
        }
    }

    void FixedUpdate()
    {
        if (transisi.activeSelf && (int)(255 * transisi.GetComponent<Image>().color.a) < 250)
        {
            int myalpha = (int)(255 * transisi.GetComponent<Image>().color.a)+10;
            transisi.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)myalpha);
            if((int)(255 * transisi.GetComponent<Image>().color.a)>=250) SceneManager.LoadScene("LoadingScreen");
        }

        //Rotate SKYBOX
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.2f);
        
    }

    public void callAudioClicked()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
    }

    public void callAudioWrongClicked()
    {
        AudioSource audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
        audio.Play();
    }

    public void ClickChangeLanguage(Dropdown dropdown)
    {
        if (dropdown.options[dropdown.value].text == "Indonesia")
        {
            PlayerPrefs.SetString("bahasa","Indonesia");
        }
        else if (dropdown.options[dropdown.value].text == "English")
        {
            PlayerPrefs.SetString("bahasa", "Inggris");
        }
        else if (dropdown.options[dropdown.value].text == "Japan")
        {
            PlayerPrefs.SetString("bahasa", "Jepang");
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Language").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>().ChangedLanguge();
        }
    }

    //CHANGE LANGUAGE
    public void GantiBahasa()
    {
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickSinglePlayer()
    {
        callAudioClicked();

        PhotonNetwork.OfflineMode = true;

        mainmenuOBJ.SetActive(false);
        singleplayerOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickMulaiBaruMultiplayer()
    {
        callAudioClicked();

        earlyOBJ.SetActive(false);
        permainanbaruOBJ.SetActive(true);
        loadgamemultiplayerOBJ.SetActive(false);
        multiplayerOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void BackToLoadingMenu()
    {
        callAudioClicked();
        if (singleplayerOBJ.active == true)
        {
            PhotonNetwork.OfflineMode = false;
        }
        else
        {
            PhotonNetwork.LeaveLobby();
        }
        mainmenuOBJ.SetActive(true);
        singleplayerOBJ.SetActive(false);
        loginmultiplayerOBJ.SetActive(false);
        multiplayerOBJ.SetActive(false);
        notifkonek.SetActive(false);
        PlayerPrefs.DeleteKey("online");
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickMultiPlayer()
    {
        callAudioClicked();

        mainmenuOBJ.SetActive(false);
        multiplayerOBJ.SetActive(true);
        notifkonek.SetActive(true);
        MyConnection.Instance.KonekKeMaster();
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickLoginMultiPlayer()
    {
        callAudioClicked();

        mainmenuOBJ.SetActive(false);
        loginmultiplayerOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickBackLoginMultiplayer()
    {
        callAudioClicked();

        loginmultiplayerOBJ.SetActive(false);
        mainmenuOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickPermainanBaru()
    {
        callAudioClicked();

        earlyOBJ.SetActive(false);
        singleplayerOBJ.SetActive(false);
        permainanbaruOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);

    }

    public void ClickCredits()
    {
        callAudioClicked();

        earlyOBJ.SetActive(false);
        singleplayerOBJ.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Credits").gameObject.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickBackCredits()
    {
        callAudioClicked();
        PhotonNetwork.OfflineMode = false;

        earlyOBJ.SetActive(true);
        mainmenuOBJ.SetActive(true);
        notifkonek.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Credits").gameObject.SetActive(false);
        PlayerPrefs.DeleteKey("online");
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.Disconnect();
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickOKNotifWrong()
    {
        callAudioClicked();

        notifwrong.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickOKSetNama()
    {

        if (inputnama.GetComponent<Text>().text == "")
        {
            callAudioWrongClicked();
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().indexText = 62;
            notifwrong.SetActive(true);
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().GetLanguage(62);
        }
        else
        {
            callAudioClicked();
            PlayerPrefs.SetString("myname", inputnama.GetComponent<Text>().text);
            Debug.Log(PlayerPrefs.GetString("myname"));
        }
        
    }
    public void OnChangeTanggal()
    {
        callAudioClicked();
        //Debug.Log("jumlah "+int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text));
        if(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text != null)
        {
            if (int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text) < 1 || inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text == null) inputulangtaun.transform.Find("BotNotif").Find("InputField").GetComponent<InputField>().text = "" + 1;
            if (int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text) > 30) inputulangtaun.transform.Find("BotNotif").Find("InputField").GetComponent<InputField>().text = "" + 30;
        }
    }

    public void OnChangeMusim()
    {
        callAudioClicked();

        if (inputulangtaun.transform.Find("BotNotif").Find("Dropdown").GetComponent<Dropdown>().value == 0)
        {
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().indexText = 18;
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().ChangedLanguge();
        }
        if (inputulangtaun.transform.Find("BotNotif").Find("Dropdown").GetComponent<Dropdown>().value == 1)
        {
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().indexText = 19;
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().ChangedLanguge();
        }
        if (inputulangtaun.transform.Find("BotNotif").Find("Dropdown").GetComponent<Dropdown>().value == 2)
        {
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().indexText = 20;
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().ChangedLanguge();
        }
        if (inputulangtaun.transform.Find("BotNotif").Find("Dropdown").GetComponent<Dropdown>().value == 3)
        {
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().indexText = 21;
            inputulangtaun.transform.Find("BotNotif").Find("TextKeterangan").GetComponent<ChangeLanguage>().ChangedLanguge();
        }
    }

    public void ClickOKSetTanggalUltah()
    {
        if (inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text == "")
        {
            callAudioWrongClicked();
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().indexText = 65;
            notifwrong.SetActive(true);
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().GetLanguage(65);
        }
        else
        {
            callAudioClicked();
            PlayerPrefs.SetInt("mytanggallahir", int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text));
            PlayerPrefs.SetString("mymusimlahir", inputulangtaun.transform.Find("BotNotif").Find("Dropdown").GetComponent<Dropdown>().options[inputulangtaun.transform.Find("BotNotif").Find("Dropdown").GetComponent<Dropdown>().value].text);
            Debug.Log(PlayerPrefs.GetInt("mytanggallahir"));
            Debug.Log(PlayerPrefs.GetString("mymusimlahir"));
        }
        
    }

    public void ClickOKSetNamaKebun()
    {

        if (inputfarm.GetComponent<Text>().text == "")
        {
            callAudioWrongClicked();
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().indexText = 66;
            notifwrong.SetActive(true);
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().GetLanguage(66);
        }
        else
        {
            callAudioClicked();
            PlayerPrefs.SetString("mykebun", inputfarm.GetComponent<Text>().text);
            Debug.Log(PlayerPrefs.GetString("mykebun"));
        }

    }

    public void ClickOKSetNamaKucing()
    {

        if (inputkucing.GetComponent<Text>().text == "")
        {
            callAudioWrongClicked();
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().indexText = 63;
            notifwrong.SetActive(true);
            notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<ChangeLanguage>().GetLanguage(63);
        }
        else
        {
            callAudioClicked();
            PlayerPrefs.SetString("mykucing", inputkucing.GetComponent<Text>().text);
            Debug.Log(PlayerPrefs.GetString("mykucing"));

        }

    }

    public void ClickOKKonfirmasi()
    {
        callAudioClicked();
        PlayerPrefs.SetString("lanjutpilihgender", "yes");
        inputgender.SetActive(true);
    }

    public void ClickNOKonfirmasi()
    {
        callAudioClicked();
        PlayerPrefs.SetString("lanjutpilihgender", "no");
    }

    public void ClickCowok()
    {
        callAudioClicked();
        PlayerPrefs.SetString("gender", "cowok");
        inputgender.SetActive(false);
        inputdandan.SetActive(true);
    }
    public void ClickCewek()
    {
        callAudioClicked();
        PlayerPrefs.SetString("gender", "cewek");
        inputgender.SetActive(false);
        inputdandan.SetActive(true);
    }

    public void ClickLanjutOK()
    {
        callAudioClicked();
        PhotonNetwork.NickName = PlayerPrefs.GetString("myname");
        PlayerPrefs.SetString("hari","Senin");
        PlayerPrefs.SetInt("tanggal",1);
        PlayerPrefs.SetString("musim", "Spring");
        PlayerPrefs.SetInt("tahun", 1);
        PlayerPrefs.SetString("jam", "06");
        PlayerPrefs.SetString("detik", "00");

        //Koleksi Baju
        if (PlayerPrefs.GetString("gender") == "cowok")
        {
            PlayerPrefs.SetString("bajudipakai", "t_shirt_top");
            PlayerPrefs.SetString("rambutdipakai", "japan_hair");
            PlayerPrefs.SetString("celanadipakai", "long_pants_bottom");
            PlayerPrefs.SetString("topidipakai", "conical_hat");

            string[] koleksirambut = { "japan_hair"};
            PlayerPrefsX.SetStringArray("koleksirambut", koleksirambut);
            string[] koleksicelana = { "long_pants_bottom" };
            PlayerPrefsX.SetStringArray("koleksicelana", koleksicelana);
            
        }
        else
        {
            PlayerPrefs.SetString("bajudipakai", "t_shirt_top");
            PlayerPrefs.SetString("rambutdipakai", "long_hair");
            PlayerPrefs.SetString("celanadipakai", "famale_long_pants_bottom");
            PlayerPrefs.SetString("topidipakai", "conical_hat");

            string[] koleksirambut = { "famale_long_hair" };
            PlayerPrefsX.SetStringArray("koleksirambut", koleksirambut);
            string[] koleksicelana = { "famale_long_pants_bottom" };
            PlayerPrefsX.SetStringArray("koleksicelana", koleksicelana);
        }

        string[] koleksitopi = { "conical_hat", "pie_hat" };
        PlayerPrefsX.SetStringArray("koleksitopi", koleksitopi);
        string[] koleksibaju = { "t_shirt_top", "sweeter_top" };
        PlayerPrefsX.SetStringArray("koleksibaju", koleksibaju);


        //Load Batu di Ladang2
        List<Vector2> posisiLadangBatu = new List<Vector2>();
        float[] posX = new float[43];
        float[] posY = new float[43];
        float[] ranNum = new float[43];
        string[] tipeLadang = new string[43];
        for (int i = 0; i < 43; i++)
        {
            tipeLadang[i] = "small";
        }
        for (int i = 0; i < 43; i++)
        {
            float x = 25.5f +(21.5f) - ((1f) * UnityEngine.Random.Range(0, 12));
            float y = 40+(7f) - (1f * UnityEngine.Random.Range(0, 12));

            Vector2 pos = new Vector2();
            pos.x = x;
            pos.y = y;

            bool add = true;
            for(int k=0;k<posisiLadangBatu.Count; k++)
            {
                if(x == posisiLadangBatu[k].x && y == posisiLadangBatu[k].y)
                {
                    add = false;
                }
            }
            if (add)
            {
                posisiLadangBatu.Add(pos);
                float randomNum = UnityEngine.Random.Range(1, 5);
                ranNum[posisiLadangBatu.Count - 1] = randomNum;
                posX[posisiLadangBatu.Count-1] = posisiLadangBatu[posisiLadangBatu.Count-1].x;
                posY[posisiLadangBatu.Count-1] = posisiLadangBatu[posisiLadangBatu.Count-1].y;
                if (i >= 30 && i < 41)
                {
                    tipeLadang[posisiLadangBatu.Count - 1] = "medium";
                }
                else if (i >= 41 && i < 43)
                {
                    tipeLadang[posisiLadangBatu.Count - 1] = "hard";
                }
                else
                {
                    tipeLadang[posisiLadangBatu.Count - 1] = "small";
                }
            }
            else
            {
                i--;
            }
        }

        PlayerPrefsX.SetFloatArray("PosLadang2BatuX", posX);
        PlayerPrefsX.SetFloatArray("PosLadang2BatuY", posY);
        PlayerPrefsX.SetFloatArray("PosLadang2BatuNum", ranNum);
        PlayerPrefsX.SetStringArray("PosLadang2BatuTipe", tipeLadang);
        PlayerPrefs.SetInt("Ladang2BatuJumlah",43);


        CustomMatchmakingLobbyCampaignController.instance.CreateRoomOnClick();

    }

    public void ClickLanjutKonfirmasi()
    {
        callAudioClicked();

        konfirmlanjut.SetActive(true);
    }

    public void ClickLanjutCancel()
    {
        callAudioClicked();
        konfirmlanjut.SetActive(false);
    }

    public void OnChangeHairColor()
    {
        callAudioClicked();
        //Debug.Log("jumlah "+int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text));
        GameObject myChar = null;
        if (PlayerPrefs.GetString("gender") == "cewek")
            myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Hairs").Find("Hair001").gameObject;
        else myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Hair001").gameObject;
        if (inputhaircolor.value == 0)
        {
            for(int nomormat=0; nomormat < myChar.GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.black; 
            }
            inputhaircolor.transform.Find("Image").GetComponent<Image>().color = Color.black;
            PlayerPrefs.SetInt("warnahairred", 0);
            PlayerPrefs.SetInt("warnahairgreen", 0);
            PlayerPrefs.SetInt("warnahairblue", 0);

        }
        else
        if (inputhaircolor.value == 1)
        {
            for (int nomormat = 0; nomormat < myChar.GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.white;
            }
            inputhaircolor.transform.Find("Image").GetComponent<Image>().color = Color.white;
            PlayerPrefs.SetInt("warnahairred", 255);
            PlayerPrefs.SetInt("warnahairgreen", 255);
            PlayerPrefs.SetInt("warnahairblue", 255);
        }
        else
        if (inputhaircolor.value == 2)
        {
            for (int nomormat = 0; nomormat < myChar.GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.blue;
            }
            inputhaircolor.transform.Find("Image").GetComponent<Image>().color = Color.blue;
            PlayerPrefs.SetInt("warnahairred", 0);
            PlayerPrefs.SetInt("warnahairgreen", 0);
            PlayerPrefs.SetInt("warnahairblue", 255);
        }
        else
        if (inputhaircolor.value == 3)
        {
            for (int nomormat = 0; nomormat < myChar.GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.red;
            }
            inputhaircolor.transform.Find("Image").GetComponent<Image>().color = Color.red;
            PlayerPrefs.SetInt("warnahairred", 255);
            PlayerPrefs.SetInt("warnahairgreen", 0);
            PlayerPrefs.SetInt("warnahairblue", 0);
        }
        else
        if (inputhaircolor.value == 4)
        {
            for (int nomormat = 0; nomormat < myChar.GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.yellow;
            }
            inputhaircolor.transform.Find("Image").GetComponent<Image>().color = Color.yellow;
            PlayerPrefs.SetInt("warnahairred", 255);
            PlayerPrefs.SetInt("warnahairgreen", (int)(0.92f * 255));
            PlayerPrefs.SetInt("warnahairblue", (int)(0.016f * 255));
        }
        else
        if (inputhaircolor.value == 5)
        {
            for (int nomormat = 0; nomormat < myChar.GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.green;
            }
            inputhaircolor.transform.Find("Image").GetComponent<Image>().color = Color.green;
            PlayerPrefs.SetInt("warnahairred", 0);
            PlayerPrefs.SetInt("warnahairgreen", 255);
            PlayerPrefs.SetInt("warnahairblue", 0);
        }
        else
        if (inputhaircolor.value == 6)
        {
            for (int nomormat = 0; nomormat < myChar.GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.gray;
            }
            inputhaircolor.transform.Find("Image").GetComponent<Image>().color = Color.gray;
            PlayerPrefs.SetInt("warnahairred", 255 / 2);
            PlayerPrefs.SetInt("warnahairgreen", 255 / 2);
            PlayerPrefs.SetInt("warnahairblue", 255 / 2);
        }
    }

    public void OnChangeClothesColor()
    {
        callAudioClicked();

        //Debug.Log("jumlah "+int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text));
        GameObject myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Body").gameObject;
        int nomormat = 3;
        if (PlayerPrefs.GetString("gender") == "cewek") nomormat = 5;
        if (inputclothescolor.value == 0)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.white;
            PlayerPrefs.SetInt("warnaclothesred", 255);
            PlayerPrefs.SetInt("warnaclothesgreen", 255);
            PlayerPrefs.SetInt("warnaclothesblue", 255);
            inputclothescolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;
        }
        else
        if (inputclothescolor.value == 1)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.black;
            PlayerPrefs.SetInt("warnaclothesred", 0);
            PlayerPrefs.SetInt("warnaclothesgreen", 0);
            PlayerPrefs.SetInt("warnaclothesblue", 0);
            inputclothescolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputclothescolor.value == 2)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.blue;
            PlayerPrefs.SetInt("warnaclothesred", 0);
            PlayerPrefs.SetInt("warnaclothesgreen", 0);
            PlayerPrefs.SetInt("warnaclothesblue", 255);
            inputclothescolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputclothescolor.value == 3)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.red;
            PlayerPrefs.SetInt("warnaclothesred", 255);
            PlayerPrefs.SetInt("warnaclothesgreen", 0);
            PlayerPrefs.SetInt("warnaclothesblue", 0);
            inputclothescolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputclothescolor.value == 4)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.yellow;
            PlayerPrefs.SetInt("warnaclothesred", 255);
            PlayerPrefs.SetInt("warnaclothesgreen", (int)(0.92f * 255));
            PlayerPrefs.SetInt("warnaclothesblue", (int)(0.016f * 255));
            inputclothescolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputclothescolor.value == 5)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.green;
            PlayerPrefs.SetInt("warnaclothesred", 0);
            PlayerPrefs.SetInt("warnaclothesgreen", 255);
            PlayerPrefs.SetInt("warnaclothesblue", 0);
            inputclothescolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputclothescolor.value == 6)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.gray;
            PlayerPrefs.SetInt("warnaclothesred", 255 / 2);
            PlayerPrefs.SetInt("warnaclothesgreen", 255 / 2);
            PlayerPrefs.SetInt("warnaclothesblue", 255 / 2);
            inputclothescolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
    }

    public void OnChangePantsColor()
    {
        callAudioClicked();
        //Debug.Log("jumlah "+int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text));
        GameObject myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Body").gameObject;
        int nomormat = 1;
        if (PlayerPrefs.GetString("gender") == "cewek") nomormat = 6;
        if (inputpantscolor.value == 0)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.black;
            PlayerPrefs.SetInt("warnapantsred", 0);
            PlayerPrefs.SetInt("warnapantsgreen", 0);
            PlayerPrefs.SetInt("warnapantsblue", 0);
            inputpantscolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;
        }
        else
        if (inputpantscolor.value == 1)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.white;
            PlayerPrefs.SetInt("warnapantsred", 255);
            PlayerPrefs.SetInt("warnapantsgreen", 255);
            PlayerPrefs.SetInt("warnapantsblue", 255);
            inputpantscolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputpantscolor.value == 2)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.blue;
            PlayerPrefs.SetInt("warnapantsred", 0);
            PlayerPrefs.SetInt("warnapantsgreen", 0);
            PlayerPrefs.SetInt("warnapantsblue", 255);
            inputpantscolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputpantscolor.value == 3)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.red;
            PlayerPrefs.SetInt("warnapantsred", 255);
            PlayerPrefs.SetInt("warnapantsgreen", 0);
            PlayerPrefs.SetInt("warnapantsblue", 0);
            inputpantscolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputpantscolor.value == 4)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.yellow;
            PlayerPrefs.SetInt("warnapantsred", 255);
            PlayerPrefs.SetInt("warnapantsgreen", (int)(0.92f*255));
            PlayerPrefs.SetInt("warnapantsblue", (int)(0.016f * 255));
            inputpantscolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputpantscolor.value == 5)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.green;
            PlayerPrefs.SetInt("warnapantsred", 0);
            PlayerPrefs.SetInt("warnapantsgreen", 255);
            PlayerPrefs.SetInt("warnapantsblue", 0);
            inputpantscolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
        else
        if (inputpantscolor.value == 6)
        {
            myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = Color.gray;
            PlayerPrefs.SetInt("warnapantsred", 255/2);
            PlayerPrefs.SetInt("warnapantsgreen", 255 / 2);
            PlayerPrefs.SetInt("warnapantsblue", 255 / 2);
            inputpantscolor.transform.Find("Image").GetComponent<Image>().color = myChar.GetComponent<SkinnedMeshRenderer>().materials[nomormat].color;

        }
    }

    public void OnChangeSkinColor()
    {
        callAudioClicked();
        
        //Debug.Log("jumlah "+int.Parse(inputulangtaun.transform.Find("BotNotif").Find("InputField").Find("Text").GetComponent<Text>().text));
        GameObject myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Body").gameObject;
        int nomormat = 2;
        if (inputskincolor.value == 0)
        {
            Color32 mycolor32 = new Color32(255, 255, 255, 255);
            PlayerPrefs.SetInt("warnaskinred", mycolor32.r);
            PlayerPrefs.SetInt("warnaskingreen", mycolor32.g);
            PlayerPrefs.SetInt("warnaskinblue", mycolor32.b);
            myChar.GetComponent<SkinnedMeshRenderer>().materials[0].color = mycolor32;
            myChar.GetComponent<SkinnedMeshRenderer>().materials[2].color = mycolor32;
            inputskincolor.transform.Find("Image").GetComponent<Image>().color = mycolor32;
            myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Face").gameObject;
            if (PlayerPrefs.GetString("gender") == "cewek")
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[8].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[7].color = mycolor32;
            }
            else
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[5].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[1].color = mycolor32;
            }
        }
        else
        if (inputskincolor.value == 1)
        {
            Color32 mycolor32 = new Color32(250, 223, 209, 255);
            PlayerPrefs.SetInt("warnaskinred", mycolor32.r);
            PlayerPrefs.SetInt("warnaskingreen", mycolor32.g);
            PlayerPrefs.SetInt("warnaskinblue", mycolor32.b);
            myChar.GetComponent<SkinnedMeshRenderer>().materials[0].color = mycolor32;
            myChar.GetComponent<SkinnedMeshRenderer>().materials[2].color = mycolor32;
            inputskincolor.transform.Find("Image").GetComponent<Image>().color = mycolor32;
            myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Face").gameObject;
            if (PlayerPrefs.GetString("gender") == "cewek")
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[8].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[7].color = mycolor32;
            }
            else
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[5].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[1].color = mycolor32;
            }

        }
        else
        if (inputskincolor.value == 2)
        {
            Color32 mycolor32 = new Color32(229, 197, 180, 255);
            PlayerPrefs.SetInt("warnaskinred", mycolor32.r);
            PlayerPrefs.SetInt("warnaskingreen", mycolor32.g);
            PlayerPrefs.SetInt("warnaskinblue", mycolor32.b);
            myChar.GetComponent<SkinnedMeshRenderer>().materials[0].color = mycolor32;
            myChar.GetComponent<SkinnedMeshRenderer>().materials[2].color = mycolor32;
            inputskincolor.transform.Find("Image").GetComponent<Image>().color = mycolor32;
            myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Face").gameObject;
            if (PlayerPrefs.GetString("gender") == "cewek")
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[8].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[7].color = mycolor32;
            }
            else
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[5].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[1].color = mycolor32;
            }

        }
        else
        if (inputskincolor.value == 3)
        {
            Color32 mycolor32 = new Color32(193, 157, 139, 255);
            PlayerPrefs.SetInt("warnaskinred", mycolor32.r);
            PlayerPrefs.SetInt("warnaskingreen", mycolor32.g);
            PlayerPrefs.SetInt("warnaskinblue", mycolor32.b);
            myChar.GetComponent<SkinnedMeshRenderer>().materials[0].color = mycolor32;
            myChar.GetComponent<SkinnedMeshRenderer>().materials[2].color = mycolor32;
            inputskincolor.transform.Find("Image").GetComponent<Image>().color = mycolor32;
            myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Face").gameObject;
            if (PlayerPrefs.GetString("gender") == "cewek")
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[8].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[7].color = mycolor32;
            }
            else
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[5].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[1].color = mycolor32;
            }
        }
        else
        if (inputskincolor.value == 4)
        {
            Color32 mycolor32 = new Color32(138, 108, 92, 255);
            PlayerPrefs.SetInt("warnaskinred", mycolor32.r);
            PlayerPrefs.SetInt("warnaskingreen", mycolor32.g);
            PlayerPrefs.SetInt("warnaskinblue", mycolor32.b);
            myChar.GetComponent<SkinnedMeshRenderer>().materials[0].color = mycolor32;
            myChar.GetComponent<SkinnedMeshRenderer>().materials[2].color = mycolor32;
            inputskincolor.transform.Find("Image").GetComponent<Image>().color = mycolor32;
            myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Face").gameObject;
            if (PlayerPrefs.GetString("gender") == "cewek")
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[8].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[7].color = mycolor32;
            }
            else
            {
                myChar.GetComponent<SkinnedMeshRenderer>().materials[5].color = mycolor32;
                myChar.GetComponent<SkinnedMeshRenderer>().materials[1].color = mycolor32;
            }
        }
    }

    public void ClickLoadGame()
    {
        callAudioClicked();

        mainmenuOBJ.SetActive(false);
        loadgameOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickBatalLoadGame()
    {
        callAudioClicked();

        //mainmenuOBJ.SetActive(true);
        loadgameOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickLoadGameLanjut(string loadstate)
    {
        
        for(int i =1;i<=5;i++)
            if (PlayerPrefs.HasKey("online"))
            {
                if (loadstate == "savestate" + i)
                    if (loadgamemultiplayerOBJ.transform.Find("Scroll View").Find("Viewport").Find("Content").Find("Button" + i).Find("Text").gameObject.activeInHierarchy)
                    {
                        callAudioWrongClicked();
                        notifwrong.SetActive(true);
                        ClickChangeLanguage(inputDropdownLanguage);
                        return;
                    }
                if (loadstate == "savestate" + i)
                    if (pilihkarakterOBJ.transform.Find("Scroll View").Find("Viewport").Find("Content").Find("Button" + i).Find("Text").gameObject.activeInHierarchy)
                    {
                        callAudioWrongClicked();
                        notifwrong.SetActive(true);
                        ClickChangeLanguage(inputDropdownLanguage);
                        return;
                    }
            }
            else
            if(loadstate=="savestate"+i)
                if(loadgameOBJ.transform.Find("Scroll View").Find("Viewport").Find("Content").Find("Button"+i).Find("Text").gameObject.activeInHierarchy)
                {
                    callAudioWrongClicked();
                    notifwrong.SetActive(true);
                    ClickChangeLanguage(inputDropdownLanguage);
                    return;
                }
        callAudioClicked();
        PlayerPrefs.SetString("load", loadstate);
        ExampleSaveCustom loadsave = ExampleSaveCustom.instance;
        loadsave.Load(loadstate);

        if(pilihMenu=="Join")
        PhotonNetwork.JoinRoom(roomName);
        else
        OnJoinedRoom();


    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Roomku berhasil dimuat MainMenuController");

        if (PhotonNetwork.CurrentRoom == null)
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("myname");
            CustomMatchmakingLobbyCampaignController.instance.CreateRoomOnClick();
        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("myname");
            if (PhotonNetwork.IsMasterClient)
            {
                ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
                custom.Add("wardrobe", "");
                custom.Add("nanyaNPCAyu", "");
                custom.Add("nanyaNPCMika", "");
                custom.Add("nanyaNPCSamsul", "");
                custom.Add("nanyaNPCAnggun", "");
                custom.Add("nanyaNPCAfifah", "");
                custom.Add("nanyaNPCOtong", "");
                custom.Add("nanyaNPCmotorkopi", "");
                custom.Add("nanyaNPCWindi", "");
                custom.Add("nanyaNPCEmon", "");
                custom.Add("nanyaNPCMini", "");
                custom.Add("nanyaBarangtv", "");
                custom.Add("openGateSekolah", false);
                custom.Add("channelTv", 1);
                custom.Add("nyalaTv", false);
                custom.Add("Cat", "");
                custom.Add("ItemCount", 0);
                custom.Add("ChickenFood", PlayerPrefs.GetInt("ChickenFood"));
                custom.Add("CowFood", PlayerPrefs.GetInt("CowFood"));
                custom.Add("ChickenMax", PlayerPrefs.GetInt("ChickenMax"));
                custom.Add("CowMax", PlayerPrefs.GetInt("CowMax"));
                custom.Add("mykucing", PlayerPrefs.GetString("mykucing"));
                custom.Add("mykebun", PlayerPrefs.GetString("mykebun"));
                custom.Add("tanggal", PlayerPrefs.GetInt("tanggal"));
                custom.Add("hari", PlayerPrefs.GetString("hari"));
                custom.Add("tahun", PlayerPrefs.GetInt("tahun"));
                custom.Add("musim", PlayerPrefs.GetString("musim"));
                custom.Add("jam", "06");
                custom.Add("detik", "00");
                custom.Add("skyboxfloat", 0.7f);

                for (int i=0;i<PlayerPrefs.GetInt("ChickenMax");i++) custom.Add("box"+(i+1), "");
                for(int i=0;i<PlayerPrefs.GetInt("CowMax");i++) custom.Add("boxcow"+(i+1), "");
                PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                GameObject.Find("AISpawn").transform.Find("Cat-8").GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                GameObject.Find("AISpawn").transform.Find("Cat-8").gameObject.name = "Cat-" + PlayerPrefs.GetString("mykucing") + "-8";

                //SPAWN CHICKEN | DUCK
                for (int i = 0; i < PlayerPrefs.GetInt("ChickenMax"); i++)
                {
                    if (PlayerPrefs.GetString("Chicken" + i) != "")
                    {
                        GameObject ayam = PhotonNetwork.Instantiate(Path.Combine("Model/Kandang Ayam/Prefab", PlayerPrefs.GetString("ChickenTipe" + i)), new Vector3(PlayerPrefs.GetFloat("ChickenPosX" + i), PlayerPrefs.GetFloat("ChickenPosY" + i), PlayerPrefs.GetFloat("ChickenPosZ" + i)), Quaternion.identity);
                        ayam.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                        custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Chicken" + i, PlayerPrefs.GetString("ChickenTipe" + i)+ "-" + PlayerPrefs.GetString("Chicken" + i) +"-"+ayam.GetPhotonView().ViewID);
                        custom.Add("ChickenLevel" + i, PlayerPrefs.GetString("ChickenLevel" + i));
                        custom.Add("ChickenHeart" + i, PlayerPrefs.GetInt("ChickenHeart" + i));
                        custom.Add("ChickenSick" + i, PlayerPrefs.GetInt("ChickenSick" + i));
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                        ayam.GetComponent<PhotonView>().RPC("ayamspawn", RpcTarget.All, PlayerPrefs.GetString("ChickenTipe" + i) + "-" + PlayerPrefs.GetString("Chicken" + i), PlayerPrefs.GetString("ChickenLevel" + i));
                    }
                }

                //SPAWN SAPI | KAMBING
                for (int i = 0; i < PlayerPrefs.GetInt("CowMax"); i++)
                {
                    if (PlayerPrefs.GetString("Cow" + i) != "")
                    {
                        Debug.Log("SPAWN SAPI: "+ PlayerPrefs.GetString("Cow" + i));
                        GameObject ayam = PhotonNetwork.Instantiate(Path.Combine("Model/Kandang Sapi/Prefab", PlayerPrefs.GetString("CowTipe" + i)), new Vector3(PlayerPrefs.GetFloat("CowPosX" + i), PlayerPrefs.GetFloat("CowPosY" + i), PlayerPrefs.GetFloat("CowPosZ" + i)), Quaternion.identity);
                        ayam.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
                        custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Cow" + i, PlayerPrefs.GetString("CowTipe" + i) + "-" + PlayerPrefs.GetString("Cow" + i) + "-" + ayam.GetPhotonView().ViewID);
                        custom.Add("CowLevel" + i, PlayerPrefs.GetString("CowLevel" + i));
                        custom.Add("CowMilk" + i, PlayerPrefs.GetString("CowMilk" + i));
                        custom.Add("CowHeart" + i, PlayerPrefs.GetInt("CowHeart" + i));
                        custom.Add("CowSick" + i, PlayerPrefs.GetInt("CowSick" + i));
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                        ayam.GetComponent<PhotonView>().RPC("ayamspawn", RpcTarget.All, PlayerPrefs.GetString("CowTipe" + i) + "-" + PlayerPrefs.GetString("Cow" + i), PlayerPrefs.GetString("CowLevel" + i));
                    }
                }

            }
            else
            {
                GameObject.Find("AISpawn").transform.Find("Cat-8").GetComponent<PhotonView>().RPC("mintareqnama",RpcTarget.MasterClient);
            }
            for (int i = 0; i < GameObject.Find("PlayerSpawn").transform.childCount; i++)
            {
                if ("Player (" + PhotonNetwork.NickName + ")" == GameObject.Find("PlayerSpawn").transform.GetChild(i).name)
                {
                    callAudioWrongClicked();
                    notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Ada pemain yang sama namanya,\nsilahkan ganti karakter lain.";
                    notifwrong.SetActive(true);
                    PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000);
                    return;
                }
            }
            ExitGames.Client.Photon.Hashtable setPlayer = new ExitGames.Client.Photon.Hashtable();
            setPlayer.Add("stamina", PlayerPrefs.GetInt("stamina"));
            setPlayer.Add("gender", PlayerPrefs.GetString("gender"));
            setPlayer.Add("money", PlayerPrefs.GetInt("money"));
            setPlayer.Add("levelbag", PlayerPrefs.GetInt("levelbag"));
            PhotonNetwork.LocalPlayer.SetCustomProperties(setPlayer);
            transisi.SetActive(true);

            loadgameOBJ.SetActive(false);
        }
        if (GameObject.Find("PlayerSpawn").transform.childCount > 0)
            GameObject.Find("PlayerSpawn").transform.GetChild(0).GetComponent<PhotonView>().RPC("OrangJoin", RpcTarget.Others, PlayerPrefs.GetString("myname"));

    }

    //INVENTORY BUTTON
    public void ClickInventoryButton(string tipe)
    {
        callAudioClicked();

        loadInventoryOBJ.SetActive(true);
        StartCoroutine(firedatabase.instance.cekInventory(tipe));
        GantiBahasa();
    }
    public void ClickBatalInventoryButton()
    {
        callAudioClicked();

        loadInventoryOBJ.SetActive(false);
        GantiBahasa();
    }

    

    public void ClickOKPurchaseCompleted()
    {
        callAudioClicked();
        notifpurchased.transform.Find("BotNotif").Find("RawImage").transform.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Images/loading");
        notifpurchased.transform.Find("BotNotif").Find("TextAmount").transform.GetComponent<Text>().text = "";
        notifpurchased.SetActive(false);
    }

    //SHOP BUTTON
    public void ClickShopButton(string tipe)
    {
        callAudioClicked();

        loadShopOBJ.SetActive(true);
        loadShopOBJ.transform.Find("Text").transform.GetComponent<ChangeLanguage>().ChangedLanguge();
        loadShopOBJ.transform.Find("ButtonUang").Find("Text").transform.GetComponent<ChangeLanguage>().ChangedLanguge();
        loadShopOBJ.transform.Find("ButtonBarang").Find("Text").transform.GetComponent<ChangeLanguage>().ChangedLanguge();
        StartCoroutine(firedatabase.instance.cekShop(tipe));
        GantiBahasa();
    }
    public void ClickBatalShopButton()
    {
        callAudioClicked();

        loadShopOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    //FRIENDLIST BUTTON
    public void ClickFriendListButton()
    {
        callAudioClicked();

        loadFriendListOBJ.SetActive(true);
        StartCoroutine(firedatabase.instance.cekFriendList("friend"));
        ClickChangeLanguage(inputDropdownLanguage);
    }
    public void ClickBatalFriendListButton()
    {
        callAudioClicked();

        loadFriendListOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    //FRIENDLIST REQUEST BUTTON
    public void ClickFriendRequestButton()
    {
        callAudioClicked();

        loadFriendListOBJ.SetActive(true);
        StartCoroutine(firedatabase.instance.cekFriendList("request"));
        ClickChangeLanguage(inputDropdownLanguage);
    }

    //HOST BUTTON
    public void ClickHostButton()
    {
        callAudioClicked();
        pilihMenu = "Host";

        loadgamemultiplayerOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickBatalLoadGameMulti()
    {
        callAudioClicked();

        //mainmenuOBJ.SetActive(true);
        loadgamemultiplayerOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickJoinButton()
    {
        callAudioClicked();
        pilihMenu = "Join";

        lobbyOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickBatalJoin()
    {
        callAudioClicked();

        lobbyOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickBatalJoinPilihKarakter()
    {
        callAudioClicked();

        pilihkarakterOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickSettingButton()
    {
        callAudioClicked();

        settingOBJ.SetActive(true);
        ClickChangeLanguage(inputDropdownLanguage);
    }

    public void ClickSettingButtonClose()
    {
        callAudioClicked();

        settingOBJ.SetActive(false);
        ClickChangeLanguage(inputDropdownLanguage);
    }

}

using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public GameObject earlyOBJ;
    public GameObject permainanbaruOBJ;
    public GameObject loadgamemultiplayerOBJ;
    public GameObject pilihkarakterOBJ;
    public GameObject lobbyOBJ;
    public GameObject settingOBJ;
    public AudioMixer mixer;

    public GameObject notifwrong;
    public GameObject notifkonek;
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

    public string roomName;
    public string pilihMenu;

    public static MainMenuController instance = null;

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
        PlayerPrefs.SetInt("money", 5000);
        PlayerPrefs.SetInt("maxstamina", 150);
        PlayerPrefs.SetInt("stamina", 150);
        PlayerPrefs.SetInt("levelbag", 1);

        PlayerPrefs.SetFloat("directionalSun",0f);

        PlayerPrefs.SetString("respawn","depanmeja");
        PlayerPrefs.SetString("level","MasukRumah");
        PlayerPrefs.SetString("ambilduitharian", "no");
        PlayerPrefs.SetString("newday", "no");
        PlayerPrefs.SetString("myserver", "asia");

        PlayerPrefs.DeleteKey("online");
        PlayerPrefs.DeleteKey("mautidur");
        PlayerPrefs.DeleteKey("pindahinTools");
        PlayerPrefs.DeleteKey("pindahinKantong");
        PlayerPrefs.DeleteKey("buttonTidur");
        PlayerPrefs.DeleteKey("buttonSafeBox");

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

        //Kantong
        PlayerPrefs.SetString("kantongnama1", "apple");
        PlayerPrefs.SetInt("kantongjumlah1", 5);

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
        string HitamText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(43);
        string PutihText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(44);
        string BiruText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(45);
        string MerahText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(46);
        string KuningText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(47);
        string HijauText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(48);
        string AbuabuText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(49);
        string PutihCokelatText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(56);
        string CokelatText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(57);
        string CokelatGelapText = inputhaircolor.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(58);

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

    public void ClickSinglePlayer()
    {
        callAudioClicked();

        PhotonNetwork.OfflineMode = true;

        mainmenuOBJ.SetActive(false);
        singleplayerOBJ.SetActive(true);
    }

    public void ClickMulaiBaruMultiplayer()
    {
        callAudioClicked();

        permainanbaruOBJ.SetActive(true);
        loadgamemultiplayerOBJ.SetActive(false);
        multiplayerOBJ.SetActive(false);
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
        multiplayerOBJ.SetActive(false);
        notifkonek.SetActive(false);
        PlayerPrefs.DeleteKey("online");
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }

    public void ClickMultiPlayer()
    {
        callAudioClicked();

        mainmenuOBJ.SetActive(false);
        multiplayerOBJ.SetActive(true);
        notifkonek.SetActive(true);
        MyConnection.Instance.KonekKeMaster();
    }

    public void ClickPermainanBaru()
    {
        callAudioClicked();

        earlyOBJ.SetActive(false);
        singleplayerOBJ.SetActive(false);
        permainanbaruOBJ.SetActive(true);

    }

    public void ClickCredits()
    {
        callAudioClicked();

        earlyOBJ.SetActive(false);
        singleplayerOBJ.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Credits").gameObject.SetActive(true);

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
    }

    public void ClickOKNotifWrong()
    {
        callAudioClicked();

        notifwrong.SetActive(false);
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
        PlayerPrefs.SetInt("tanggal",1);
        PlayerPrefs.SetString("musim", "Spring");
        PlayerPrefs.SetInt("tahun", 1);
        PlayerPrefs.SetString("jam", "06");
        PlayerPrefs.SetString("detik", "00");
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
        GameObject myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Hair001").gameObject;
        if (PlayerPrefs.GetString("gender") == "cewek")
            myChar = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).Find("Hairs").Find("Hair001").gameObject;
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
    }

    public void ClickBatalLoadGame()
    {
        callAudioClicked();

        //mainmenuOBJ.SetActive(true);
        loadgameOBJ.SetActive(false);
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
                        notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Ga ada save-an";
                        notifwrong.SetActive(true);
                        return;
                    }
                if (loadstate == "savestate" + i)
                    if (pilihkarakterOBJ.transform.Find("Scroll View").Find("Viewport").Find("Content").Find("Button" + i).Find("Text").gameObject.activeInHierarchy)
                    {
                        callAudioWrongClicked();
                        notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Ga ada save-an";
                        notifwrong.SetActive(true);
                        return;
                    }
            }
            else
            if(loadstate=="savestate"+i)
                if(loadgameOBJ.transform.Find("Scroll View").Find("Viewport").Find("Content").Find("Button"+i).Find("Text").gameObject.activeInHierarchy)
                {
                        callAudioWrongClicked();
                        notifwrong.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Ga ada save-an";
                    notifwrong.SetActive(true);
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
        Debug.Log("Roomku berhasil dimuat");

        if (PhotonNetwork.CurrentRoom == null)
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("myname");
            CustomMatchmakingLobbyCampaignController.instance.CreateRoomOnClick();
        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("myname");
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
            transisi.SetActive(true);

            loadgameOBJ.SetActive(false);
        }
        if (GameObject.Find("PlayerSpawn").transform.childCount > 0)
            GameObject.Find("PlayerSpawn").transform.GetChild(0).GetComponent<PhotonView>().RPC("OrangJoin", RpcTarget.Others, PlayerPrefs.GetString("myname"));

    }

    //HOST BUTTON
    public void ClickHostButton()
    {
        callAudioClicked();
        pilihMenu = "Host";

        loadgamemultiplayerOBJ.SetActive(true);
    }

    public void ClickBatalLoadGameMulti()
    {
        callAudioClicked();

        //mainmenuOBJ.SetActive(true);
        loadgamemultiplayerOBJ.SetActive(false);
    }

    public void ClickJoinButton()
    {
        callAudioClicked();
        pilihMenu = "Join";

        lobbyOBJ.SetActive(true);
    }

    public void ClickBatalJoin()
    {
        callAudioClicked();

        lobbyOBJ.SetActive(false);
    }

    public void ClickBatalJoinPilihKarakter()
    {
        callAudioClicked();

        pilihkarakterOBJ.SetActive(false);
    }

    public void ClickSettingButton()
    {
        callAudioClicked();

        settingOBJ.SetActive(true);
    }

    public void ClickSettingButtonClose()
    {
        callAudioClicked();

        settingOBJ.SetActive(false);
    }

}

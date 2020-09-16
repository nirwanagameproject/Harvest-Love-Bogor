using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleSaveCustom : MonoBehaviour
{
    public static ExampleSaveCustom instance;

    [System.Serializable]
    public struct Level
    {
        public bool unlocked;
        public bool completed;

        public Level(bool unlocked, bool completed)
        {
            this.unlocked = unlocked;
            this.completed = completed;
        }
    }

    [System.Serializable]
    public class CustomData
    {

        public string gender;
        public string nama;
        public string namafarm;
        public string namakucing;
        public int tgllahir;
        public string musimlahir;
        public int money;
        public int[] warnahair = new int[3];
        public int[] warnaclothes = new int[3];
        public int[] warnapants = new int[3];
        public int[] warnaskin = new int[3];
        public int tanggal;
        public string musim;
        public int tahun;
        public int maxstamina;

        public int levelbag;
        public string[] peralatannama = new string[53];
        public int[] peralatanjumlah = new int[53];

        public float[] ladang2BatuX = new float[43];
        public float[] ladang2BatuY = new float[43];
        public float[] ladang2BatuNum = new float[43];
        public string[] ladang2BatuTipe = new string[43];
        public int ladang2BatuJumlah;

        public string bajudipakai;
        public string celanadipakai;
        public string rambutdipakai;
        public string topidipakai;
        public string[] koleksibaju = new string[50];
        public string[] koleksicelana = new string[50];
        public string[] koleksirambut = new string[50];
        public string[] koleksitopi = new string[50];

        public CustomData()
        {
            gender = "cowok";
            nama = "cowok";
            namafarm = "cowok";
            namakucing = "cowok";
            musimlahir = "cowok";
            musim = "cowok";
            tgllahir = 1;
            money = 1;
            tanggal = 1;
            tahun = 1;
            maxstamina = 1;
            warnahair[0] = 1;
            warnahair[1] = 1;
            warnahair[2] = 1;
            warnaclothes[0] = 1;
            warnaclothes[1] = 1;
            warnaclothes[2] = 1;
            warnapants[0] = 1;
            warnapants[1] = 1;
            warnapants[2] = 1;
            warnaskin[0] = 1;
            warnaskin[1] = 1;
            warnaskin[2] = 1;
        }
    }

    public CustomData customData;
    public bool loadOnStart = true;
    public Texture cowok;
    public Texture cewek;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button12;
    public GameObject button22;
    public GameObject button32;
    public GameObject button42;
    public GameObject button52;
    public GameObject buttonmulti1;
    public GameObject buttonmulti2;
    public GameObject buttonmulti3;
    public GameObject buttonmulti4;
    public GameObject buttonmulti5;
    public GameObject buttonmulticlient1;
    public GameObject buttonmulticlient2;
    public GameObject buttonmulticlient3;
    public GameObject buttonmulticlient4;
    public GameObject buttonmulticlient5;
    public string identifier = "exampleSaveCustom";

    //public static ExampleSaveCustom instance;

    void Start()
    {
        instance = this;
        SaveGame.Encode = false;
        if (loadOnStart)
        {
            for (int i = 1; i <= 5; i++)
                Load("savestate" + i);
        }
    }

    public void SetScore(string score)
    {
        //customData.score = int.Parse(score);
    }

    public void SetHighScore(string highScore)
    {
        //customData.highScore = int.Parse(highScore);
    }

    public void Save()
    {
        if (PlayerPrefs.GetInt("tanggal") < 30)
            PlayerPrefs.SetInt("tanggal", PlayerPrefs.GetInt("tanggal") + 1);
        else
        {
            PlayerPrefs.SetInt("tanggal", 1);
            if (PlayerPrefs.GetString("musim") == "Spring") { PlayerPrefs.SetString("musim", "Summer"); }
            else if (PlayerPrefs.GetString("musim") == "Summer") { PlayerPrefs.SetString("musim", "Fall"); }
            else if (PlayerPrefs.GetString("musim") == "Fall") { PlayerPrefs.SetString("musim", "Winter"); }
            else if (PlayerPrefs.GetString("musim") == "Winter") { PlayerPrefs.SetString("musim", "Spring"); PlayerPrefs.SetInt("tahun", PlayerPrefs.GetInt("tahun") + 1); }
        }
        GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = "06";
        GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = "00";
        string idsave = PlayerPrefs.GetString("save");
        customData = new CustomData();
        customData.warnahair = new int[3];
        customData.warnaclothes = new int[3];
        customData.warnapants = new int[3];
        customData.warnaskin = new int[3];
        customData.gender = PlayerPrefs.GetString("gender");
        customData.nama = PlayerPrefs.GetString("myname");
        customData.namafarm = PlayerPrefs.GetString("mykebun");
        customData.namakucing = PlayerPrefs.GetString("mykucing");
        customData.tgllahir = PlayerPrefs.GetInt("mytanggallahir");
        customData.musimlahir = PlayerPrefs.GetString("mymusimlahir");

        customData.money = PlayerPrefs.GetInt("money");
        customData.warnahair[0] = PlayerPrefs.GetInt("warnahairred");
        customData.warnahair[1] = PlayerPrefs.GetInt("warnahairgreen");
        customData.warnahair[2] = PlayerPrefs.GetInt("warnahairblue");

        customData.warnaclothes[0] = PlayerPrefs.GetInt("warnaclothesred");
        customData.warnaclothes[1] = PlayerPrefs.GetInt("warnaclothesgreen");
        customData.warnaclothes[2] = PlayerPrefs.GetInt("warnaclothesblue");

        customData.warnapants[0] = PlayerPrefs.GetInt("warnapantsred");
        customData.warnapants[1] = PlayerPrefs.GetInt("warnapantsgreen");
        customData.warnapants[2] = PlayerPrefs.GetInt("warnapantsblue");

        customData.warnaskin[0] = PlayerPrefs.GetInt("warnaskinred");
        customData.warnaskin[1] = PlayerPrefs.GetInt("warnaskingreen");
        customData.warnaskin[2] = PlayerPrefs.GetInt("warnaskinblue");

        customData.tanggal = PlayerPrefs.GetInt("tanggal");
        customData.musim = PlayerPrefs.GetString("musim");
        customData.tahun = PlayerPrefs.GetInt("tahun");
        customData.maxstamina = PlayerPrefs.GetInt("maxstamina");

        for (int i = 0; i < customData.peralatannama.Length; i++)
        {
            if(PlayerPrefs.HasKey("peralatannama"+i))
            if(PlayerPrefs.GetString("peralatannama"+i)!="")
            customData.peralatannama[i] = PlayerPrefs.GetString("peralatannama"+i);
        }

        for (int i = 0; i < customData.peralatanjumlah.Length; i++)
        {
            if (PlayerPrefs.HasKey("peralatanjumlah" + i))
                if (PlayerPrefs.GetInt("peralatanjumlah" + i) != 0)
                    customData.peralatanjumlah[i] = PlayerPrefs.GetInt("peralatanjumlah" + i);
        }

        for(int i = 0; i < PlayerPrefsX.GetFloatArray("PosLadang2BatuX").Length; i++)
        {
            customData.ladang2BatuX[i] = PlayerPrefsX.GetFloatArray("PosLadang2BatuX")[i];
            customData.ladang2BatuY[i] = PlayerPrefsX.GetFloatArray("PosLadang2BatuY")[i];
            customData.ladang2BatuNum[i] = PlayerPrefsX.GetFloatArray("PosLadang2BatuNum")[i];
            customData.ladang2BatuTipe[i] = PlayerPrefsX.GetStringArray("PosLadang2BatuTipe")[i];
        }

        customData.koleksibaju = PlayerPrefsX.GetStringArray("koleksibaju");
        customData.koleksicelana = PlayerPrefsX.GetStringArray("koleksicelana");
        customData.koleksirambut = PlayerPrefsX.GetStringArray("koleksirambut");
        customData.koleksitopi = PlayerPrefsX.GetStringArray("koleksitopi");
        customData.bajudipakai = PlayerPrefs.GetString("bajudipakai");
        customData.celanadipakai = PlayerPrefs.GetString("celanadipakai");
        customData.rambutdipakai = PlayerPrefs.GetString("rambutdipakai");
        customData.topidipakai = PlayerPrefs.GetString("topidipakai");

        customData.ladang2BatuJumlah = PlayerPrefs.GetInt("Ladang2BatuJumlah");

        customData.levelbag = PlayerPrefs.GetInt("levelbag");

        if (PhotonNetwork.IsConnected)
        if (PhotonNetwork.IsMasterClient)
        {
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add("tanggal", PlayerPrefs.GetInt("tanggal"));
            setTgl.Add("tahun", PlayerPrefs.GetInt("tahun"));
            setTgl.Add("musim", PlayerPrefs.GetString("musim"));
            setTgl.Add("jam", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text);
            setTgl.Add("detik", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text);
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
        }

        SaveGame.Save<CustomData>(idsave, customData, new SaveGameXmlSerializer());
        PlayerPrefs.SetString("tidur", "");
        //Load(idsave);
    }

    public void Load(string idsave)
    {

        if (System.IO.File.Exists(Application.persistentDataPath + "//" + idsave))
        {
            customData = SaveGame.Load<CustomData>(
            idsave,
            new CustomData(),
            new SaveGameXmlSerializer());

            if (PlayerPrefs.GetString("load") == idsave)
            {
                PlayerPrefs.SetString("gender", customData.gender);
                PlayerPrefs.SetString("myname", customData.nama);
                PlayerPrefs.SetString("mykebun", customData.namafarm);
                PlayerPrefs.SetString("mykucing", customData.namakucing);
                PlayerPrefs.SetInt("mytanggallahir", customData.tgllahir);
                PlayerPrefs.SetString("mymusimlahir", customData.musimlahir);

                PlayerPrefs.SetInt("warnahairred", customData.warnahair[0]);
                PlayerPrefs.SetInt("warnahairgreen", customData.warnahair[1]);
                PlayerPrefs.SetInt("warnahairblue", customData.warnahair[2]);

                PlayerPrefs.SetInt("warnaclothesred", customData.warnaclothes[0]);
                PlayerPrefs.SetInt("warnaclothesgreen", customData.warnaclothes[1]);
                PlayerPrefs.SetInt("warnaclothesblue", customData.warnaclothes[2]);

                PlayerPrefs.SetInt("warnapantsred", customData.warnapants[0]);
                PlayerPrefs.SetInt("warnapantsgreen", customData.warnapants[1]);
                PlayerPrefs.SetInt("warnapantsblue", customData.warnapants[2]);

                PlayerPrefs.SetInt("warnaskinred", customData.warnaskin[0]);
                PlayerPrefs.SetInt("warnaskingreen", customData.warnaskin[1]);
                PlayerPrefs.SetInt("warnaskinblue", customData.warnaskin[2]);

                PlayerPrefs.SetInt("tanggal", customData.tanggal);
                PlayerPrefs.SetString("musim", customData.musim);
                PlayerPrefs.SetInt("tahun", customData.tahun);
                PlayerPrefs.SetInt("money", customData.money);
                PlayerPrefs.SetInt("maxstamina", customData.maxstamina);

                for (int i = 0; i < customData.peralatannama.Length; i++)
                {
                    if (customData.peralatannama[i] != null)
                        PlayerPrefs.SetString("peralatannama" + i, customData.peralatannama[i]);
                    else PlayerPrefs.DeleteKey("peralatannama"+i);
                }

                for (int i = 0; i < customData.peralatanjumlah.Length; i++)
                {
                    if (customData.peralatanjumlah[i] != 0)
                        PlayerPrefs.SetInt("peralatanjumlah" + i, customData.peralatanjumlah[i]);
                    else PlayerPrefs.DeleteKey("peralatanjumlah" + i);
                }

                for(int i=0;i< customData.ladang2BatuTipe.Length; i++)
                {
                    if (customData.ladang2BatuTipe[i] == null)
                    {
                        customData.ladang2BatuTipe[i] = "small";
                    }
                }

                if(customData.ladang2BatuTipe.Length > 0) { 
                    PlayerPrefsX.SetFloatArray("PosLadang2BatuX", customData.ladang2BatuX);
                    PlayerPrefsX.SetFloatArray("PosLadang2BatuY", customData.ladang2BatuY);
                    PlayerPrefsX.SetFloatArray("PosLadang2BatuNum", customData.ladang2BatuNum);
                    PlayerPrefsX.SetStringArray("PosLadang2BatuTipe", customData.ladang2BatuTipe);
                }
                PlayerPrefs.SetString("bajudipakai", customData.bajudipakai);
                PlayerPrefs.SetString("celanadipakai", customData.celanadipakai);
                PlayerPrefs.SetString("rambutdipakai", customData.rambutdipakai);
                PlayerPrefs.SetString("topidipakai", customData.topidipakai);

                PlayerPrefs.SetInt("Ladang2BatuJumlah", customData.ladang2BatuJumlah);

                if (customData.koleksibaju.Length > 0)
                {
                    PlayerPrefsX.SetStringArray("koleksibaju", customData.koleksibaju);
                }
                if (customData.koleksicelana.Length > 0)
                {
                    PlayerPrefsX.SetStringArray("koleksicelana", customData.koleksicelana);
                }
                if (customData.koleksirambut.Length > 0)
                {
                    PlayerPrefsX.SetStringArray("koleksirambut", customData.koleksirambut);
                }
                if (customData.koleksitopi.Length > 0)
                {
                    PlayerPrefsX.SetStringArray("koleksitopi", customData.koleksitopi);
                }

                PlayerPrefs.SetInt("levelbag", customData.levelbag);

                Debug.Log("MASUK LOAD");
                PlayerPrefs.DeleteKey("load");
                return;
            }
            if (idsave == "savestate1")
            {
                //Debug.Log(customData.gender);
                button12.transform.Find("Text").gameObject.SetActive(false);
                button12.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender == "cowok")
                    button12.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button12.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button12.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                button12.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();

                button1.transform.Find("Text").gameObject.SetActive(false);
                button1.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender == "cowok")
                    button1.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button1.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button1.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                button1.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                if (buttonmulti1 != null)
                {
                    buttonmulti1.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulti1.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulti1.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulti1.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulti1.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulti1.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
                if (buttonmulticlient1 != null)
                {
                    buttonmulticlient1.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulticlient1.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulticlient1.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulticlient1.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulticlient1.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulticlient1.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
            }
            else
            if (idsave == "savestate2")
            {
                button22.transform.Find("Text").gameObject.SetActive(false);
                button22.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender == "cowok")
                    button22.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button22.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button22.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                button22.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();

                button2.transform.Find("Text").gameObject.SetActive(false);
                button2.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender == "cowok")
                    button2.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button2.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button2.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                button2.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                if (buttonmulti2 != null)
                {
                    buttonmulti2.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulti2.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulti2.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulti2.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulti2.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulti2.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
                if (buttonmulticlient2 != null)
                {
                    buttonmulticlient2.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulticlient2.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulticlient2.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulticlient2.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulticlient2.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulticlient2.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
            }
            else

            if (idsave == "savestate3")
            {
                button32.transform.Find("Text").gameObject.SetActive(false);
                button32.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender.ToString() == "cowok")
                    button32.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button32.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button32.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama.ToString() + "\nKebun: " + customData.namafarm.ToString();
                button32.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim.ToString() + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();

                button3.transform.Find("Text").gameObject.SetActive(false);
                button3.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender.ToString() == "cowok")
                    button3.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button3.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button3.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama.ToString() + "\nKebun: " + customData.namafarm.ToString();
                button3.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim.ToString() + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                if (buttonmulti3 != null)
                {
                    buttonmulti3.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulti3.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulti3.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulti3.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulti3.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulti3.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
                if (buttonmulticlient3 != null)
                {
                    buttonmulticlient3.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulticlient3.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulticlient3.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulticlient3.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulticlient3.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulticlient3.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
            }
            else

            if (idsave == "savestate4")
            {
                button42.transform.Find("Text").gameObject.SetActive(false);
                button42.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender.ToString() == "cowok")
                    button42.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button42.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button42.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama.ToString() + "\nKebun: " + customData.namafarm.ToString();
                button42.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim.ToString() + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();

                button4.transform.Find("Text").gameObject.SetActive(false);
                button4.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender.ToString() == "cowok")
                    button4.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button4.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button4.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama.ToString() + "\nKebun: " + customData.namafarm.ToString();
                button4.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim.ToString() + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                if (buttonmulti4 != null)
                {
                    buttonmulti4.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulti4.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulti4.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulti4.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulti4.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulti4.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
                if (buttonmulticlient4 != null)
                {
                    buttonmulticlient4.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulticlient4.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulticlient4.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulticlient4.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulticlient4.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulticlient4.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
            }
            else

            if (idsave == "savestate5")
            {
                button52.transform.Find("Text").gameObject.SetActive(false);
                button52.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender.ToString() == "cowok")
                    button52.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button52.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button52.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama.ToString() + "\nKebun: " + customData.namafarm.ToString();
                button52.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim.ToString() + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();

                button5.transform.Find("Text").gameObject.SetActive(false);
                button5.transform.Find("Udahdisave").gameObject.SetActive(true);
                if (customData.gender.ToString() == "cowok")
                    button5.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                else button5.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                button5.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama.ToString() + "\nKebun: " + customData.namafarm.ToString();
                button5.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim.ToString() + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                if (buttonmulti5 != null)
                {
                    buttonmulti5.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulti5.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulti5.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulti5.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulti5.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulti5.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }
                if (buttonmulticlient5 != null)
                {
                    buttonmulticlient5.transform.Find("Text").gameObject.SetActive(false);
                    buttonmulticlient5.transform.Find("Udahdisave").gameObject.SetActive(true);
                    if (customData.gender == "cowok")
                        buttonmulticlient5.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cowok;
                    else buttonmulticlient5.transform.Find("Udahdisave").Find("RawImage").GetComponent<RawImage>().texture = cewek;
                    buttonmulticlient5.transform.Find("Udahdisave").Find("Textnama").GetComponent<Text>().text = "Nama: " + customData.nama + "\nKebun: " + customData.namafarm;
                    buttonmulticlient5.transform.Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: " + customData.tanggal.ToString() + " " + customData.musim + " " + customData.tahun.ToString() + "\nUang: " + customData.money.ToString();
                }

            }

        }

        //scoreInputField.text = customData.score.ToString();
        //highScoreInputField.text = customData.highScore.ToString();
    }

}
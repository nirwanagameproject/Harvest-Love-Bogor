using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ShopInGameController : MonoBehaviour
{
    public static ShopInGameController instance = null;
    private int hargaCow = 50000;
    private int hargaCalf = 35000;
    private int hargaGoat = 40000;
    private int hargaBabyGoat = 25000;
    private int hargaChicken = 15000;
    private int hargaDuck = 20000;
    private int hargaBale = 200;
    private int hargaChickenFeed = 100;
    private int hargaTomato = 750;
    private int hargaCorn = 900;
    private int hargaMilkCowSmall = 1200;
    private int hargaMilkGoatSmall = 1100;
    private int hargaTelorChicken = 600;
    private int hargaTelorDuck = 750;
    private int hargaApple = 600;
    private int hargaPadi = 600;
    private int hargaManggis = 850;
    private int hargaJerukNipis = 700;
    private int hargaKubis = 1400;

    //HARGA JUAL HEWAN
    private int hargaJualCow = 25000;
    private int hargaJualGoat = 20000;
    private int hargaJualChicken = 7500;
    private int hargaJualDuck = 10000;

    //HARGA BIBIT
    private int hargaBibitPadi = 1500;
    private int hargaBibitManggis = 2000;
    private int hargaBibitJerukNipis = 1800;
    private int hargaBibitKubis = 3000;
    public GameObject totalharga;

    void Start()
    {
        instance = this;
    }

    public void tombolUp()
    {
        if(transform.parent.Find("InputField").GetComponent<InputField>().text == "")
        transform.parent.Find("InputField").GetComponent<InputField>().text = "0";
        int totalhargatemp = Int32.Parse(totalharga.GetComponent<Text>().text);
        int quantitytemp = Int32.Parse(transform.parent.Find("InputField").GetComponent<InputField>().text);
        transform.parent.Find("InputField").GetComponent<InputField>().text = ""+(quantitytemp+1);
    }

    public void tombolDown()
    {
        if (transform.parent.Find("InputField").GetComponent<InputField>().text == "")
            transform.parent.Find("InputField").GetComponent<InputField>().text = "0";
        int totalhargatemp = Int32.Parse(totalharga.GetComponent<Text>().text);
        int quantitytemp = Int32.Parse(transform.parent.Find("InputField").GetComponent<InputField>().text);
        if(quantitytemp>0) transform.parent.Find("InputField").GetComponent<InputField>().text = "" + (quantitytemp - 1);
        else transform.parent.Find("InputField").GetComponent<InputField>().text = "0";
    }

    public void gantiJumlah()
    {
        if (transform.parent.Find("InputField").GetComponent<InputField>().text == "")
            transform.parent.Find("InputField").GetComponent<InputField>().text = "0";
        int totalhargatemp = Int32.Parse(totalharga.GetComponent<Text>().text);
        int quantitytemp = Int32.Parse(transform.parent.Find("InputField").GetComponent<InputField>().text);
        if (quantitytemp >= 0)
        {
            if (transform.parent.name == "DairyCow") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyCow") * hargaCow))+(quantitytemp* hargaCow)); PlayerPrefs.SetInt("buyCow", quantitytemp); }
            if (transform.parent.name == "Goat") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyGoat") * hargaGoat)) + (quantitytemp * hargaGoat)); PlayerPrefs.SetInt("buyGoat", quantitytemp); }
            if (transform.parent.name == "Calf") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyCalf") * hargaCalf)) + (quantitytemp * hargaCalf)); PlayerPrefs.SetInt("buyCalf", quantitytemp); }
            if (transform.parent.name == "BabyGoat") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyBabyGoat") * hargaBabyGoat)) + (quantitytemp * hargaBabyGoat)); PlayerPrefs.SetInt("buyBabyGoat", quantitytemp); }
            if (transform.parent.name == "Bale") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyBale") * hargaBale)) + (quantitytemp * hargaBale)); PlayerPrefs.SetInt("buyBale", quantitytemp); }
            if (transform.parent.name == "ChickenFeed") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyChickenFeed") * hargaChickenFeed)) + (quantitytemp * hargaChickenFeed)); PlayerPrefs.SetInt("buyChickenFeed", quantitytemp); }
            if (transform.parent.name == "Chicken") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyChicken") * hargaChicken)) + (quantitytemp * hargaChicken)); PlayerPrefs.SetInt("buyChicken", quantitytemp); }
            if (transform.parent.name == "Duck") { totalharga.GetComponent<Text>().text = "" + ((totalhargatemp - (PlayerPrefs.GetInt("buyDuck") * hargaDuck)) + (quantitytemp * hargaDuck)); PlayerPrefs.SetInt("buyDuck", quantitytemp); }
        }
    }

    public void Kembali()
    {
        transform.parent.gameObject.SetActive(false);
        AudioSource audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
        for (int i = 4; i < GameObject.Find("Canvas").transform.Find("UIkanan").childCount; i++)
            GameObject.Find("Canvas").transform.Find("UIkanan").GetChild(i).gameObject.SetActive(true);
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).childCount; i++)
        {
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("Accept").gameObject.SetActive(false);
        }
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).childCount; i++)
        {
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("health").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("Accept").gameObject.SetActive(false);
        }
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").GetComponent<NPCTalk>().Gajadi(name);
        audio.Play();
    }

    public void KembaliSell()
    {
        transform.parent.gameObject.SetActive(false);
        AudioSource audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
        for (int i = 4; i < GameObject.Find("Canvas").transform.Find("UIkanan").childCount; i++)
            GameObject.Find("Canvas").transform.Find("UIkanan").GetChild(i).gameObject.SetActive(true);
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().mybag.Capacity; i++) GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").Find("tools").GetChild(i).GetComponent<Image>().color = new Color(0.858f, 0.858f, 0.858f, 1);
        GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text = "0";
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").GetComponent<NPCTalk>().Gajadi(name);
        GameObject.Find("Canvas").transform.Find("SeedShopSell").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Bag").Find("BGnotif").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bag").Find("ButtonBack").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(false);
        PlayerPrefs.DeleteKey("EmonSell");
        audio.Play();
    }

    public void ClickChicken()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        PlayerPrefs.SetInt("buyChicken", 0);
        PlayerPrefs.SetInt("buyDuck", 0);
        PlayerPrefs.SetInt("buyBale", 0);

        totalharga.GetComponent<Text>().text = "" + 0;
        transform.parent.Find("ScrollViewChicken").gameObject.SetActive(true);
        transform.parent.Find("ScrollViewDuck").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewItem").gameObject.SetActive(false);
        for (int i = 0; i < transform.parent.Find("ScrollViewChicken").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewChicken").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonChicken").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        transform.parent.Find("ButtonDuck").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        transform.parent.Find("ButtonItem").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
    }

    public void ClickDuck()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        PlayerPrefs.SetInt("buyChicken", 0);
        PlayerPrefs.SetInt("buyDuck", 0);
        PlayerPrefs.SetInt("buyBale", 0);

        totalharga.GetComponent<Text>().text = "" + 0;
        transform.parent.Find("ScrollViewChicken").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewDuck").gameObject.SetActive(true);
        transform.parent.Find("ScrollViewItem").gameObject.SetActive(false);
        for (int i = 0; i < transform.parent.Find("ScrollViewDuck").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewDuck").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonDuck").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        transform.parent.Find("ButtonChicken").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        transform.parent.Find("ButtonItem").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
    }

    public void ClickItemPoultry()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        PlayerPrefs.SetInt("buyChicken", 0);
        PlayerPrefs.SetInt("buyDuck", 0);
        PlayerPrefs.SetInt("buyBale", 0);

        totalharga.GetComponent<Text>().text = "" + 0;
        transform.parent.Find("ScrollViewChicken").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewDuck").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewItem").gameObject.SetActive(true);
        for (int i = 0; i < transform.parent.Find("ScrollViewItem").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewItem").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonItem").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        transform.parent.Find("ButtonChicken").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        transform.parent.Find("ButtonDuck").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
    }

    public void ClickCow()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        PlayerPrefs.SetInt("buyCow", 0);
        PlayerPrefs.SetInt("buyCalf", 0);
        PlayerPrefs.SetInt("buyGoat", 0);
        PlayerPrefs.SetInt("buyBabyGoat", 0);
        PlayerPrefs.SetInt("buyBale", 0);

        totalharga.GetComponent<Text>().text = ""+0;
        transform.parent.Find("ScrollViewCow").gameObject.SetActive(true);
        transform.parent.Find("ScrollViewGoat").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewItem").gameObject.SetActive(false);
        for (int i = 0; i < transform.parent.Find("ScrollViewCow").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewCow").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonCow").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        transform.parent.Find("ButtonGoat").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        transform.parent.Find("ButtonItem").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
    }

    public void ClickGoat()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        PlayerPrefs.SetInt("buyCow", 0);
        PlayerPrefs.SetInt("buyCalf", 0);
        PlayerPrefs.SetInt("buyGoat", 0);
        PlayerPrefs.SetInt("buyBabyGoat", 0);
        PlayerPrefs.SetInt("buyBale", 0);

        totalharga.GetComponent<Text>().text = "" + 0;
        transform.parent.Find("ScrollViewCow").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewGoat").gameObject.SetActive(true);
        transform.parent.Find("ScrollViewItem").gameObject.SetActive(false);
        for (int i = 0; i < transform.parent.Find("ScrollViewGoat").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewGoat").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonCow").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        transform.parent.Find("ButtonGoat").GetComponent<Image>().color = new Color32(188, 163, 112, 255); 
        transform.parent.Find("ButtonItem").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
    }

    public void ClickItem()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        PlayerPrefs.SetInt("buyCow", 0);
        PlayerPrefs.SetInt("buyCalf", 0);
        PlayerPrefs.SetInt("buyGoat", 0);
        PlayerPrefs.SetInt("buyBabyGoat", 0);
        PlayerPrefs.SetInt("buyBale", 0);

        totalharga.GetComponent<Text>().text = "0";
        transform.parent.Find("ScrollViewCow").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewGoat").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewItem").gameObject.SetActive(true);
        for (int i = 0; i < transform.parent.Find("ScrollViewItem").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewItem").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonCow").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        transform.parent.Find("ButtonGoat").GetComponent<Image>().color = new Color32(255, 226, 165, 255); 
        transform.parent.Find("ButtonItem").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
    }

    public void ClickProducts()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        totalharga.GetComponent<Text>().text = "" + 0;
        transform.parent.Find("ScrollViewProduct").gameObject.SetActive(true);
        transform.parent.Find("ScrollViewSeed").gameObject.SetActive(false);
        for (int i = 0; i < transform.parent.Find("ScrollViewProduct").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewProduct").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonProduct").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        transform.parent.Find("ButtonSeed").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
    }

    public void ClickSeed()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        totalharga.GetComponent<Text>().text = "" + 0;
        transform.parent.Find("ScrollViewProduct").gameObject.SetActive(false);
        transform.parent.Find("ScrollViewSeed").gameObject.SetActive(true);
        for (int i = 0; i < transform.parent.Find("ScrollViewSeed").GetChild(0).GetChild(0).childCount; i++)
            transform.parent.Find("ScrollViewSeed").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        transform.parent.Find("ButtonSeed").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        transform.parent.Find("ButtonProduct").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
    }

    public void ClickBuyProduct(string namabuah)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        //BELI TOMATO
        if (transform.parent.parent.parent.parent.name == "ScrollViewProduct")
            {
                int hargabuah = 0;
                if (namabuah == "Tomat") hargabuah = hargaTomato;
                if (namabuah == "Corn") hargabuah = hargaCorn;
                if (namabuah == "milkCowsmall") hargabuah = hargaMilkCowSmall;
                if (namabuah == "milkGoatsmall") hargabuah = hargaMilkGoatSmall;
                if (namabuah == "telorChicken") hargabuah = hargaTelorChicken;
                if (namabuah == "telorDuck") hargabuah = hargaTelorDuck;
                int totalhargabale = 1 * hargabuah;
                if (PlayerPrefs.GetInt("money") < totalhargabale)
                {
                    //GA PUNYA UANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
                }
                else 
                {
                    int jumlahbarangkosong = 0;
                    for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().mybag.Capacity; i++)
                        if (PlayerPrefs.GetString("kantongnama" + i) == "")
                        {
                            jumlahbarangkosong++;
                        }
                    Debug.Log("Barang kosong: " + jumlahbarangkosong);
                    if (jumlahbarangkosong >= 1)
                    {
                        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().mybag.Capacity; i++)
                            if (PlayerPrefs.GetString("kantongnama" + i) == "")
                            {

                                LanguageEmon.instance.StartCoroutine(LanguageEmon.instance.EndBuy());
                                audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                                audio.Play();
                            //SET MONEY PLAYER
                            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Emon1");
                            Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - (1 * hargabuah));
                                GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + (1 * hargabuah);
                                if (i == 0)
                                {
                                    GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", namabuah), GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").rotation);
                                    GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("level"));

                                    PlayerPrefs.SetString("kantongnama0", namabuah + "-" + item.GetPhotonView().ViewID);
                                    PlayerPrefs.SetInt("kantongjumlah0", 1);
                                    GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();
                                    break;
                                }
                                else
                                {
                                    GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", namabuah), GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").rotation);
                                    GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("level"));

                                    PlayerPrefs.SetString("kantongnama" + i, namabuah + "-" + item.GetPhotonView().ViewID);
                                    PhotonNetwork.Destroy(item);
                                    PlayerPrefs.SetInt("kantongjumlah" + i, 1);
                                    GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();
                                    break;
                                }

                            }
                    }
                    else
                    {
                        //GAGAL GA MUAT KANDANG
                        audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                        audio.Play();
                        transform.parent.parent.parent.parent.parent.Find("NotEnoughTas").gameObject.SetActive(true);
                    }
                }
            }
        else if (transform.parent.parent.parent.parent.name == "ScrollViewSeed")
        {
            int hargabuah = 0;
            if (namabuah == "peralatanbibit1") hargabuah = hargaBibitPadi;
            if (namabuah == "peralatanbibit2") hargabuah = hargaBibitManggis;
            if (namabuah == "peralatanbibit3") hargabuah = hargaBibitJerukNipis;
            if (namabuah == "peralatanbibit4") hargabuah = hargaBibitKubis;
            int totalhargabale = 1 * hargabuah;
            if (PlayerPrefs.GetInt("money") < totalhargabale)
            {
                //GA PUNYA UANG
                audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                audio.Play();
                transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
            }
            else
            {
                int jumlahbarangkosong = 0;
                for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().mybag.Capacity; i++)
                    if (PlayerPrefs.GetString("peralatannama" + i) == "")
                    {
                        jumlahbarangkosong++;
                    }
                Debug.Log("Barang kosong: " + jumlahbarangkosong);
                if (jumlahbarangkosong >= 1)
                {
                    for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().mybag.Capacity; i++)
                        if (PlayerPrefs.GetString("peralatannama" + i) == namabuah)
                        {
                            LanguageEmon.instance.StartCoroutine(LanguageEmon.instance.EndBuy());
                            audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                            audio.Play();
                            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Emon1");
                            //SET MONEY PLAYER
                            Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - (1 * hargabuah));
                            GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + (1 * hargabuah);
                            PlayerPrefs.SetString("peralatannama" + i, namabuah);
                            PlayerPrefs.SetInt("peralatanjumlah" + i, PlayerPrefs.GetInt("peralatanjumlah" + i) + 1);
                            GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();
                            GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().nextWeapon();
                            GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().prevWeapon();
                            return;
                        }
                    for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().mybag.Capacity; i++)
                        if (PlayerPrefs.GetString("peralatannama" + i) == "")
                        {

                            LanguageEmon.instance.StartCoroutine(LanguageEmon.instance.EndBuy());
                            audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                            audio.Play();
                            //SET MONEY PLAYER
                            Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - (1 * hargabuah));
                            GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + (1 * hargabuah);
                            PlayerPrefs.SetString("peralatannama" + i, namabuah);
                            PlayerPrefs.SetInt("peralatanjumlah" + i, PlayerPrefs.GetInt("peralatanjumlah" + i)+1);
                            GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();
                            GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().nextWeapon();
                            GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().prevWeapon();
                            break;

                        }
                }
                else
                {
                    //GAGAL GA MUAT KANDANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughTas").gameObject.SetActive(true);
                }
            }
        }
    }

    public void ClickSell()
    {
        int totalharga = 0;
        GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text = "0";
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().mybag.Capacity; i++)
        {
            Debug.Log("harga color: slot "+i+" - nama: "+ PlayerPrefs.GetString("kantongnama" + i));
            if (GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").Find("tools").transform.GetChild(i).GetComponent<Image>().color.r <= 0.514f &&
                GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").Find("tools").transform.GetChild(i).GetComponent<Image>().color.r >= 0.513f)
            {
                GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").Find("tools").GetChild(i).GetComponent<Image>().color = new Color(0.858f, 0.858f, 0.858f, 1);
                string namabuah = PlayerPrefs.GetString("kantongnama" + i);
                int jumlahbuah = PlayerPrefs.GetInt("kantongjumlah" + i);
                int hargabuah = hargajualbuah(namabuah);
                totalharga += (jumlahbuah * hargabuah) + System.Int32.Parse(GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text);
                if (i == 0)
                {
                    if (PlayerPrefs.GetString("kantongnama" + i) != "")
                    {
                        PhotonNetwork.Destroy(GameObject.Find("PlayerSpawn").transform.Find("Player ("+PhotonNetwork.NickName+")").Find("AreaPegang").GetChild(0).gameObject);
                    }
                }
                PlayerPrefs.SetString("kantongnama" + i, "");
                PlayerPrefs.GetInt("kantongjumlah" + i, 0);
            }
        }
        if (totalharga == 0)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Emon2");
            LanguageEmon.instance.StartCoroutine(LanguageEmon.instance.BarangKosongDijual());
            return;
        }
        AudioSource audio = GameObject.Find("Clicked").transform.Find("terimaduit").GetComponent<AudioSource>();
        audio.Play();
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Emon1");
        GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text = "0";
        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money")+totalharga);
        GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();
        LanguageEmon.instance.StartCoroutine(LanguageEmon.instance.EndSell());
        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "+"+totalharga;
    }

    public void ClickSellAnimal(int urutan)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        transform.parent.parent.parent.parent.parent.Find("KonfirmasiJual").gameObject.SetActive(true);
        transform.parent.parent.parent.parent.parent.Find("KonfirmasiJual").Find("BotNotif").Find("NamaHewan").GetComponent<Text>().text = transform.parent.Find("Text").GetComponent<Text>().text;
        int hargajual = 0;
        if(transform.parent.parent.parent.parent.name == "ScrollViewPoultry")
        if(PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString() != "")
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString().Split('-')[0] == "Chicken") hargajual = hargaJualChicken;
            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString().Split('-')[0] == "Duck") hargajual = hargaJualDuck;
            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenSick" + urutan]>=4) hargajual = hargajual-2000;
            PlayerPrefs.SetString("SellAnimal","Chicken");
        }
        if(transform.parent.parent.parent.parent.name == "ScrollViewBarn")
        if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString() != "")
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString().Split('-')[0] == "Cow") hargajual = hargaJualCow;
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString().Split('-')[0] == "Goat") hargajual = hargaJualGoat;
            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowSick" + urutan] >= 4) hargajual = hargajual - 5000;
            PlayerPrefs.SetString("SellAnimal","Cow");
        }
        transform.parent.parent.parent.parent.parent.Find("KonfirmasiJual").Find("BotNotif").Find("HargaJual").GetComponent<Text>().text = ""+ hargajual;
        PlayerPrefs.SetInt("SellUrutanAnimal",urutan);
    }

    public void ClickSellAnimalKonfirm()
    {
        int urutan = PlayerPrefs.GetInt("SellUrutanAnimal");
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        transform.parent.parent.gameObject.SetActive(false);
        int hargajual = 0;
        if(PlayerPrefs.GetString("SellAnimal")== "Chicken")
        if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString() != "")
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString().Split('-')[0] == "Chicken") hargajual = hargaJualChicken;
            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString().Split('-')[0] == "Duck") hargajual = hargaJualDuck;
            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenSick" + urutan] >= 4) hargajual = hargajual - 2000;
            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString().Split('-')[0] == "Chicken" || PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString().Split('-')[0] == "Duck")
                PhotonNetwork.Destroy(GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + urutan].ToString()).gameObject);

            //SPAWN CHICKEN | DUCK
                for (int i = urutan+1; i < PlayerPrefs.GetInt("ChickenMax"); i++)
                {
                    if (PlayerPrefs.GetString("Chicken" + i) != "")
                    {
                        PlayerPrefs.SetString("Chicken" + (i - 1), PhotonNetwork.CurrentRoom.CustomProperties["Chicken"+i].ToString());
                        PlayerPrefs.SetInt("ChickenHeart" + (i - 1), PlayerPrefs.GetInt("ChickenHeart"+i));
                        PlayerPrefs.SetString("ChickenLevel" + (i - 1), PlayerPrefs.GetString("ChickenLevel" + i));
                        PlayerPrefs.SetInt("ChickenSick" + (i - 1), PlayerPrefs.GetInt("ChickenSick" + i));
                        PlayerPrefs.SetInt("ChickenSilver" + (i - 1), PlayerPrefs.GetInt("ChickenSilver" + i));
                        PlayerPrefs.SetInt("ChickenGold" + (i - 1), PlayerPrefs.GetInt("ChickenGold" + i));
                        PlayerPrefs.SetFloat("ChickenPosX" + (i - 1), PlayerPrefs.GetFloat("ChickenPosX" + i));
                        PlayerPrefs.SetFloat("ChickenPosY" + (i - 1), PlayerPrefs.GetFloat("ChickenPosY" + i));
                        PlayerPrefs.SetFloat("ChickenPosZ" + (i - 1), PlayerPrefs.GetFloat("ChickenPosZ" + i));
                        PlayerPrefs.SetString("ChickenTipe" + (i - 1), PlayerPrefs.GetString("ChickenTipe" + i));
                        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Chicken" + (i - 1), PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString());
                        custom.Add("ChickenLevel" + (i - 1), PlayerPrefs.GetString("ChickenLevel" + i));
                        custom.Add("ChickenHeart" + (i - 1), PlayerPrefs.GetInt("ChickenHeart" + i));
                        custom.Add("ChickenSick" + (i - 1), PlayerPrefs.GetInt("ChickenSick" + i));
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);

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
                        custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Chicken" + i, "");
                        custom.Add("ChickenLevel" + i, "");
                        custom.Add("ChickenHeart" + i, 0);
                        custom.Add("ChickenSick" + i, 0);
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                    }
                    else
                    {
                        PlayerPrefs.SetString("Chicken" + (i - 1), "");
                        PlayerPrefs.SetInt("ChickenHeart" + (i - 1), 0);
                        PlayerPrefs.SetString("ChickenLevel" + (i - 1), "");
                        PlayerPrefs.SetInt("ChickenSick" + (i - 1), 0);
                        PlayerPrefs.SetInt("ChickenSilver" + (i - 1), 0);
                        PlayerPrefs.SetInt("ChickenGold" + (i - 1), 0);
                        PlayerPrefs.SetFloat("ChickenPosX" + (i - 1), 0);
                        PlayerPrefs.SetFloat("ChickenPosY" + (i - 1), 0);
                        PlayerPrefs.SetFloat("ChickenPosZ" + (i - 1), 0);
                        PlayerPrefs.SetString("ChickenTipe" + (i - 1), "");
                        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Chicken" + (i - 1), "");
                        custom.Add("ChickenLevel" + (i - 1), "");
                        custom.Add("ChickenHeart" + (i - 1), 0);
                        custom.Add("ChickenSick" + (i - 1), 0);
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                    }
                }
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonJump").GetComponent<buttonController>().clickProfileStatsPoultry();
            }
        if(PlayerPrefs.GetString("SellAnimal")=="Cow")
        if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString() != "")
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString().Split('-')[0] == "Cow") hargajual = hargaJualCow;
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString().Split('-')[0] == "Goat") hargajual = hargaJualGoat;
            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowSick" + urutan] >= 4) hargajual = hargajual - 5000;
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString().Split('-')[0] == "Cow" || PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString().Split('-')[0] == "Goat")
                PhotonNetwork.Destroy(GameObject.Find("AISpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + urutan].ToString()).gameObject);
            //SPAWN Cow | Goat
                for (int i = urutan+1; i < PlayerPrefs.GetInt("CowMax"); i++)
                {
                    if (PlayerPrefs.GetString("Cow" + i) != "")
                    {
                        PlayerPrefs.SetString("Cow" + (i - 1), PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString());
                        PlayerPrefs.SetInt("CowHeart" + (i - 1), PlayerPrefs.GetInt("CowHeart" + i));
                        PlayerPrefs.SetString("CowLevel" + (i - 1), PlayerPrefs.GetString("CowLevel" + i));
                        PlayerPrefs.SetInt("CowSick" + (i - 1), PlayerPrefs.GetInt("CowSick" + i));
                        PlayerPrefs.SetInt("CowSilver" + (i - 1), PlayerPrefs.GetInt("CowSilver" + i));
                        PlayerPrefs.SetInt("CowGold" + (i - 1), PlayerPrefs.GetInt("CowGold" + i));
                        PlayerPrefs.SetString("CowMilk" + (i - 1), PlayerPrefs.GetString("CowMilk" + i));
                        PlayerPrefs.SetFloat("CowPosX" + (i - 1), PlayerPrefs.GetFloat("CowPosX" + i));
                        PlayerPrefs.SetFloat("CowPosY" + (i - 1), PlayerPrefs.GetFloat("CowPosY" + i));
                        PlayerPrefs.SetFloat("CowPosZ" + (i - 1), PlayerPrefs.GetFloat("CowPosZ" + i));
                        PlayerPrefs.SetString("CowTipe" + (i - 1), PlayerPrefs.GetString("CowTipe" + i));
                        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Cow" + (i - 1), PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString());
                        custom.Add("CowLevel" + (i - 1), PlayerPrefs.GetString("CowLevel" + i));
                        custom.Add("CowHeart" + (i - 1), PlayerPrefs.GetInt("CowHeart" + i));
                        custom.Add("CowSick" + (i - 1), PlayerPrefs.GetInt("CowSick" + i));
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);

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
                        custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Cow" + i, "");
                        custom.Add("CowLevel" + i, "");
                        custom.Add("CowHeart" + i, 0);
                        custom.Add("CowSick" + i, 0);
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                    }
                    else
                    {
                        PlayerPrefs.SetString("Cow" + (i - 1), "");
                        PlayerPrefs.SetInt("CowHeart" + (i - 1), 0);
                        PlayerPrefs.SetString("CowLevel" + (i - 1), "");
                        PlayerPrefs.SetInt("CowSick" + (i - 1), 0);
                        PlayerPrefs.SetInt("CowSilver" + (i - 1), 0);
                        PlayerPrefs.SetInt("CowGold" + (i - 1), 0);
                        PlayerPrefs.SetString("CowMilk" + (i - 1), "");
                        PlayerPrefs.SetFloat("CowPosX" + (i - 1), 0);
                        PlayerPrefs.SetFloat("CowPosY" + (i - 1), 0);
                        PlayerPrefs.SetFloat("CowPosZ" + (i - 1), 0);
                        PlayerPrefs.SetString("CowTipe" + (i - 1), "");
                        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add("Cow" + (i - 1), "");
                        custom.Add("CowLevel" + (i - 1), "");
                        custom.Add("CowHeart" + (i - 1), 0);
                        custom.Add("CowSick" + (i - 1), 0);
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                    }
                }
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonJump").GetComponent<buttonController>().clickProfileStatsBarn();
        }
        audio = GameObject.Find("Clicked").transform.Find("terimaduit").GetComponent<AudioSource>();
        audio.Play();
        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") + hargajual);
        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "+" + hargajual;


    }

    public void ClickSellAnimalCancel()
    {
        AudioSource audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
        audio.Play();
        transform.parent.parent.gameObject.SetActive(false);

    }

    public void ClickBuy()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        //BELI BALE
        if (PlayerPrefs.GetInt("buyBale")> 0)
            if (transform.parent.parent.parent.parent.name == "ScrollViewItem")
            {
                int totalhargabale = PlayerPrefs.GetInt("buyBale") * hargaBale;
                if (PlayerPrefs.GetInt("money") < totalhargabale)
                {
                    //GA PUNYA UANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("buyBale") > 0)
                {
                    int muatberapa = 100-(int)PhotonNetwork.CurrentRoom.CustomProperties["CowFood"];
                    if (muatberapa >= PlayerPrefs.GetInt("buyBale"))
                    {
                        audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                        audio.Play();
                        //LANJUT BELI
                        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                        setProperti.Add("CowFood", ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowFood"]+ PlayerPrefs.GetInt("buyBale")));
                        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
                        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
                        LanguageSamsul.instance.StartCoroutine(LanguageSamsul.instance.EndBuy());
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - (PlayerPrefs.GetInt("buyBale") * hargaBale));
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + (PlayerPrefs.GetInt("buyBale") * hargaBale);
                    }
                    else
                    {
                        //GAGAL GA MUAT KANDANG
                        audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                        audio.Play();
                        transform.parent.parent.parent.parent.parent.Find("NotEnoughRuang").gameObject.SetActive(true);
                    }
                }
            }
        //BELI CHICKEN FEED
        if (PlayerPrefs.GetInt("buyChickenFeed") > 0)
            if (transform.parent.parent.parent.parent.name == "ScrollViewItem")
            {
                int totalhargabale = PlayerPrefs.GetInt("buyChickenFeed") * hargaChickenFeed;
                if (PlayerPrefs.GetInt("money") < totalhargabale)
                {
                    //GA PUNYA UANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Mini4");
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("buyChickenFeed") > 0)
                {
                    int muatberapa = 100 - (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"];
                    if (muatberapa >= PlayerPrefs.GetInt("buyChickenFeed"))
                    {
                        audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                        audio.Play();
                        //LANJUT BELI
                        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                        setProperti.Add("ChickenFood", ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenFood"] + PlayerPrefs.GetInt("buyChickenFeed")));
                        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
                        LanguageMini.instance.StartCoroutine(LanguageMini.instance.EndBuy());
                        //SET MONEY PLAYER
                        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Mini1");
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - (PlayerPrefs.GetInt("buyChickenFeed") * hargaChickenFeed));
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + (PlayerPrefs.GetInt("buyChickenFeed") * hargaChickenFeed);
                    }
                    else
                    {
                        //GAGAL GA MUAT KANDANG
                        audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                        audio.Play();
                        transform.parent.parent.parent.parent.parent.Find("NotEnoughRuang").gameObject.SetActive(true);
                    }
                }
            }

        //BELI SAPI
        if ((PlayerPrefs.GetInt("buyCow") + PlayerPrefs.GetInt("buyCalf"))>0)
        if (transform.parent.parent.parent.parent.name == "ScrollViewCow")
        {
            int totalhargasapi = PlayerPrefs.GetInt("buyCow")*hargaCow;
            int totalhargabayisapi = PlayerPrefs.GetInt("buyCalf")*hargaCalf;
            if (PlayerPrefs.GetInt("money") < (totalhargasapi + totalhargabayisapi))
            {
                //GA PUNYA UANG
                audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                audio.Play();
                transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
            }
            else if(PlayerPrefs.GetInt("buyCow")>0 || PlayerPrefs.GetInt("buyCalf")>0)
            {
                int jumlahsapi = 0;
                for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; i++)
                {
                    if(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i]!=null)
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Cow"+i].ToString() != "") jumlahsapi++;
                }
                int muatberapa = (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]-jumlahsapi;
                if (muatberapa >= (PlayerPrefs.GetInt("buyCow")+ PlayerPrefs.GetInt("buyCalf")))
                {
                    audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                    audio.Play();
                    //LANJUT BELI
                    GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
                    LanguageSamsul.instance.StartCoroutine(LanguageSamsul.instance.BeliSapi(false));
                }
                else
                {
                    //GAGAL GA MUAT KANDANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughRuang").gameObject.SetActive(true);
                }
            }
        }

        //BELI KAMBING
        if ((PlayerPrefs.GetInt("buyGoat") + PlayerPrefs.GetInt("buyBabyGoat")) > 0)
            if (transform.parent.parent.parent.parent.name == "ScrollViewGoat")
            {
                int totalhargasapi = PlayerPrefs.GetInt("buyGoat") * hargaGoat;
                int totalhargabayisapi = PlayerPrefs.GetInt("buyBabyGoat") * hargaBabyGoat;
                if (PlayerPrefs.GetInt("money") < (totalhargasapi + totalhargabayisapi))
                {
                    //GA PUNYA UANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("buyGoat") > 0 || PlayerPrefs.GetInt("buyBabyGoat") > 0)
                {
                    int jumlahsapi = 0;
                    for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; i++)
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] != null)
                            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString() != "") jumlahsapi++;
                    }
                    int muatberapa = (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"] - jumlahsapi;
                    if (muatberapa >= (PlayerPrefs.GetInt("buyGoat") + PlayerPrefs.GetInt("buyBabyGoat")))
                    {
                        audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                        audio.Play();
                        //LANJUT BELI
                        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
                        LanguageSamsul.instance.StartCoroutine(LanguageSamsul.instance.BeliSapi(false));
                    }
                    else
                    {
                        //GAGAL GA MUAT KANDANG
                        audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                        audio.Play();
                        transform.parent.parent.parent.parent.parent.Find("NotEnoughRuang").gameObject.SetActive(true);
                    }
                }
            }

        //BELI AYAM
        if (PlayerPrefs.GetInt("buyChicken") > 0)
            if (transform.parent.parent.parent.parent.name == "ScrollViewChicken")
            {
                int totalhargasapi = PlayerPrefs.GetInt("buyChicken") * hargaChicken;
                if (PlayerPrefs.GetInt("money") < (totalhargasapi))
                {
                    //GA PUNYA UANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("buyChicken") > 0)
                {
                    int jumlahsapi = 0;
                    for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenMax"]; i++)
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i] != null)
                            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString() != "") jumlahsapi++;
                    }
                    int muatberapa = (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenMax"] - jumlahsapi;
                    if (muatberapa >= PlayerPrefs.GetInt("buyChicken"))
                    {
                        audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                        audio.Play();
                        //LANJUT BELI
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Mini1");
                        LanguageMini.instance.StartCoroutine(LanguageMini.instance.BeliSapi(false));
                    }
                    else
                    {
                        //GAGAL GA MUAT KANDANG
                        audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                        audio.Play();
                        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Mini4");
                        transform.parent.parent.parent.parent.parent.Find("NotEnoughRuang").gameObject.SetActive(true);
                    }
                }
            }

        //BELI BEBEK
        if (PlayerPrefs.GetInt("buyDuck") > 0)
            if (transform.parent.parent.parent.parent.name == "ScrollViewDuck")
            {
                int totalhargasapi = PlayerPrefs.GetInt("buyDuck") * hargaDuck;
                if (PlayerPrefs.GetInt("money") < (totalhargasapi))
                {
                    //GA PUNYA UANG
                    audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                    audio.Play();
                    transform.parent.parent.parent.parent.parent.Find("NotEnoughMoney").gameObject.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("buyDuck") > 0)
                {
                    int jumlahsapi = 0;
                    for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenMax"]; i++)
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i] != null)
                            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString() != "") jumlahsapi++;
                    }
                    int muatberapa = (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenMax"] - jumlahsapi;
                    if (muatberapa >= PlayerPrefs.GetInt("buyDuck"))
                    {
                        audio = GameObject.Find("Clicked").transform.Find("ngasihduit").GetComponent<AudioSource>();
                        audio.Play();
                        //LANJUT BELI
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Mini1");
                        LanguageMini.instance.StartCoroutine(LanguageMini.instance.BeliSapi(false));
                    }
                    else
                    {
                        //GAGAL GA MUAT KANDANG
                        audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
                        audio.Play();
                        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Mini4");
                        transform.parent.parent.parent.parent.parent.Find("NotEnoughRuang").gameObject.SetActive(true);
                    }
                }
            }
    }

    public void UdahKasihNama()
    {
        if (transform.parent.Find("InputField").GetComponent<InputField>().text == "")
        {
            transform.parent.parent.parent.Find("NotFullName").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("buyCow") > 0 || PlayerPrefs.GetInt("buyGoat") > 0)
        {
            //SPAWN SAPI | KAMBING
            for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; i++)
            {
                if (PlayerPrefs.GetInt("buyCow") > 0)
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] == null)
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaCow);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaCow;
                        createSapiDiKandang(i);
                        break;
                    }
                    else
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString() == "")
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaCow);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaCow;
                        createSapiDiKandang(i);
                        break;
                    }

                if (PlayerPrefs.GetInt("buyGoat") > 0)
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] == null)
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaGoat);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaGoat;
                        createKambingDiKandang(i);
                        break;
                    }
                    else
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString() == "")
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaGoat);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaGoat;
                        createKambingDiKandang(i);
                        break;
                    }

            }
        }
        else if (PlayerPrefs.GetInt("buyChicken") > 0 || PlayerPrefs.GetInt("buyDuck") > 0)
        {
            //SPAWN CHICKEN | DUCK
            for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenMax"]; i++)
            {
                if (PlayerPrefs.GetInt("buyChicken") > 0)
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i] == null)
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaChicken);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaChicken;
                        createChickenDiKandang(i);
                        break;
                    }
                    else
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString() == "")
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaChicken);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaChicken;
                        createChickenDiKandang(i);
                        break;
                    }

                if (PlayerPrefs.GetInt("buyDuck") > 0)
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i] == null)
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaDuck);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaDuck;
                        createDuckDiKandang(i);
                        break;
                    }
                    else
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString() == "")
                    {
                        //SET MONEY PLAYER
                        Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaDuck);
                        GameObject.Find("Canvas").transform.Find("UIkanan").Find("BGCoin").Find("pluscoin").GetComponent<Text>().text = "-" + hargaDuck;
                        createDuckDiKandang(i);
                        break;
                    }

            }
        }


    }

    void createDuckDiKandang(int i)
    {
        string namaAnimal = transform.parent.Find("InputField").GetComponent<InputField>().text;
        System.Random rnd = new System.Random();
        GameObject ayam = PhotonNetwork.Instantiate(Path.Combine("Model/Kandang Ayam/Prefab", "Duck"), new Vector3(rnd.Next(2, 11), 0.1f, rnd.Next(2, 6)), Quaternion.identity);
        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("Chicken" + i, "Duck" + "-" + namaAnimal + "-" + ayam.GetPhotonView().ViewID);
        custom.Add("ChickenLevel" + i, "MasukKandangAyam");
        custom.Add("ChickenHeart" + i, 0);
        custom.Add("ChickenSick" + i, 0);
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        ayam.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.MasterClient);
        ayam.GetComponent<PhotonView>().RPC("ayamspawn", RpcTarget.All, "Duck" + "-" + namaAnimal, "MasukKandangAyam");
        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(false);
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
        PlayerPrefs.SetInt("buyDuck", PlayerPrefs.GetInt("buyDuck") - 1);
        if (PlayerPrefs.GetInt("buyDuck") > 0)
        {
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageMini.instance.StartCoroutine(LanguageMini.instance.BeliSapi(true));
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageMini.instance.StartCoroutine("EndBuy");
        }
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
    }

    void createChickenDiKandang(int i)
    {
        string namaAnimal = transform.parent.Find("InputField").GetComponent<InputField>().text;
        System.Random rnd = new System.Random();
        GameObject ayam = PhotonNetwork.Instantiate(Path.Combine("Model/Kandang Ayam/Prefab", "Chicken"), new Vector3(rnd.Next(2, 11), 0.1f, rnd.Next(2, 6)), Quaternion.identity);
        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("Chicken" + i, "Chicken" + "-" + namaAnimal + "-" + ayam.GetPhotonView().ViewID);
        custom.Add("ChickenLevel" + i, "MasukKandangAyam");
        custom.Add("ChickenHeart" + i, 0);
        custom.Add("ChickenSick" + i, 0);
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        ayam.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.MasterClient);
        ayam.GetComponent<PhotonView>().RPC("ayamspawn", RpcTarget.All, "Chicken" + "-" + namaAnimal, "MasukKandangAyam");
        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(false);
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
        PlayerPrefs.SetInt("buyChicken", PlayerPrefs.GetInt("buyChicken") - 1);
        if (PlayerPrefs.GetInt("buyChicken") > 0)
        {
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageMini.instance.StartCoroutine(LanguageMini.instance.BeliSapi(true));
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageMini.instance.StartCoroutine("EndBuy");
        }
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
    }

    void createSapiDiKandang(int i)
    {
        string namaAnimal = transform.parent.Find("InputField").GetComponent<InputField>().text;
        System.Random rnd = new System.Random();
        GameObject ayam = PhotonNetwork.Instantiate(Path.Combine("Model/Kandang Sapi/Prefab", "Cow"), new Vector3(rnd.Next(2, 11), 0.1f, rnd.Next(2, 6)), Quaternion.identity);
        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("Cow" + i, "Cow" + "-" + namaAnimal + "-" + ayam.GetPhotonView().ViewID);
        custom.Add("CowLevel" + i, "MasukKandangSapi");
        custom.Add("CowMilk" + i, "");
        custom.Add("CowHeart" + i, 0);
        custom.Add("CowSick" + i, 0);
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        ayam.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.MasterClient);
        ayam.GetComponent<PhotonView>().RPC("ayamspawn", RpcTarget.All, "Cow" + "-" + namaAnimal, "MasukKandangSapi");
        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(false);
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
        PlayerPrefs.SetInt("buyCow", PlayerPrefs.GetInt("buyCow") - 1);
        if (PlayerPrefs.GetInt("buyCow") > 0 || PlayerPrefs.GetInt("buyCalf") > 0)
        {
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageSamsul.instance.StartCoroutine(LanguageSamsul.instance.BeliSapi(true));
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageSamsul.instance.StartCoroutine("EndBuy");
        }
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
    }

    void createKambingDiKandang(int i)
    {
        string namaAnimal = transform.parent.Find("InputField").GetComponent<InputField>().text;
        System.Random rnd = new System.Random();
        GameObject ayam = PhotonNetwork.Instantiate(Path.Combine("Model/Kandang Sapi/Prefab", "Goat"), new Vector3(rnd.Next(2, 11), 0.1f, rnd.Next(2, 6)), Quaternion.identity);
        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("Cow" + i, "Goat" + "-" + namaAnimal + "-" + ayam.GetPhotonView().ViewID);
        custom.Add("CowLevel" + i, "MasukKandangSapi");
        custom.Add("CowMilk" + i, "");
        custom.Add("CowHeart" + i, 0);
        custom.Add("CowSick" + i, 0);
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        ayam.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.MasterClient);
        ayam.GetComponent<PhotonView>().RPC("ayamspawn", RpcTarget.All, "Goat" + "-" + namaAnimal, "MasukKandangSapi");
        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(false);
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
        PlayerPrefs.SetInt("buyGoat", PlayerPrefs.GetInt("buyGoat") - 1);
        if (PlayerPrefs.GetInt("buyGoat") > 0 || PlayerPrefs.GetInt("buyBabyGoat") > 0)
        {
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageSamsul.instance.StartCoroutine(LanguageSamsul.instance.BeliSapi(true));
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(false);
            LanguageSamsul.instance.StartCoroutine("EndBuy");
        }
        transform.parent.Find("InputField").GetComponent<InputField>().text = "";
    }

    public void ClickOk()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        transform.parent.parent.gameObject.SetActive(false);
    }

    public int hargajualbuah(string namabuah)
    {
        int hargabuah = 0;
        if (namabuah.Contains("Tomat")) hargabuah = hargaTomato-150;
        if (namabuah.Contains("Corn")) hargabuah = hargaCorn-100;
        if (namabuah.Contains("milkCowsmall")) hargabuah = hargaMilkCowSmall-200;
        if (namabuah.Contains("milkGoatsmall")) hargabuah = hargaMilkGoatSmall-250;
        if (namabuah.Contains("telorChicken")) hargabuah = hargaTelorChicken-100;
        if (namabuah.Contains("telorDuck")) hargabuah = hargaTelorDuck-100;
        if (namabuah.Contains("Apple")) hargabuah = hargaApple;
        if (namabuah.Contains("Padi")) hargabuah = hargaPadi;
        if (namabuah.Contains("Manggis")) hargabuah = hargaManggis;
        if (namabuah.Contains("Lime")) hargabuah = hargaJerukNipis;
        if (namabuah.Contains("Cabbage")) hargabuah = hargaKubis;
        return hargabuah;
    }

}

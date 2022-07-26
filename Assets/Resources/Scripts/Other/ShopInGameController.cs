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
    public int hargaCow = 50000;
    public int hargaCalf = 35000;
    public int hargaGoat = 40000;
    public int hargaBabyGoat = 25000;
    public int hargaBale = 500;
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
        }
    }

    public void Kembali()
    {
        transform.parent.gameObject.SetActive(false);
        AudioSource audio = GameObject.Find("ClickedWrong").GetComponent<AudioSource>();
        for (int i = 4; i < GameObject.Find("Canvas").transform.Find("UIkanan").childCount; i++)
            GameObject.Find("Canvas").transform.Find("UIkanan").GetChild(i).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").GetComponent<NPCTalk>().Gajadi(name);
        audio.Play();
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

    public void ClickBuy()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        //BELI BALE
        if(PlayerPrefs.GetInt("buyBale")> 0)
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
        if((PlayerPrefs.GetInt("buyCow") + PlayerPrefs.GetInt("buyCalf"))>0)
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
    }

    public void UdahKasihNama()
    {
        if (transform.parent.Find("InputField").GetComponent<InputField>().text == "")
        {
            transform.parent.parent.parent.Find("NotFullName").gameObject.SetActive(true);
        }
        else
        //SPAWN SAPI | KAMBING
        for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; i++)
        {
            if(PlayerPrefs.GetInt("buyCow")>0)
                if(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] == null)
                {
                    //SET MONEY PLAYER
                    Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaCow);
                    createSapiDiKandang(i);
                    break;
                }
                else
                if (PhotonNetwork.CurrentRoom.CustomProperties["Cow"+i].ToString() == "")
                {
                    //SET MONEY PLAYER
                    Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaCow);
                    createSapiDiKandang(i);
                    break;
                }

            if (PlayerPrefs.GetInt("buyGoat") > 0)
                if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] == null)
                {
                    //SET MONEY PLAYER
                    Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaGoat);
                    createKambingDiKandang(i);
                    break;
                }
                else
                if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString() == "")
                {
                    //SET MONEY PLAYER
                    Gamesetupcontroller.instance.setmoney(PlayerPrefs.GetInt("money") - hargaGoat);
                    createKambingDiKandang(i);
                    break;
                }

        }
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

}

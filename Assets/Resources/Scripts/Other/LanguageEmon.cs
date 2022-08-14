using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageEmon : MonoBehaviour
{
    public static LanguageEmon instance = null;
    public List<string> bahasaID;
    public List<string> bahasaUS;
    public List<string> bahasaJP;
    public string answer = "";
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        bahasa();

    }

    private void bahasa()
    {

        //Translate Bahasa Indonesia
        bahasaID = new List<string>();
        bahasaID.Add("Hai "); //0
        bahasaID.Add("Aku dengar kamu yang punya kebun baru itu ya? Perkenalkan, aku Samsul peternak sapi dan kambing."); //1
        bahasaID.Add("Sapi dan Kambing disini memang selalu aku rawat dengan baik. Jangan lupa perhatikan ternakmu."); //2
        bahasaID.Add("Apa kamu ingin membeli sesuatu ?"); //3
        bahasaID.Add("Beli"); //4
        bahasaID.Add("Jual"); //5
        bahasaID.Add("Pilih-pilih aja dulu produknya bos, semua seger-seger loh"); //6
        bahasaID.Add("Silahkan pilih produk mana yang ingin kamu jual"); //7
        bahasaID.Add("Ehh, barang yang ingin kamu jual kosong"); //8
        bahasaID.Add("Kasih nama hewan yang lain juga ya"); //9
        bahasaID.Add("Tararengkyu bos udah beli disini"); //10
        bahasaID.Add("Tararengkyu bos udah jual produk disini"); //11

        //Translate Bahasa Inggris
        bahasaUS = new List<string>();
        bahasaUS.Add("Hello "); //0
        bahasaUS.Add("I heard you own the abandoned farm right? Well, I'm Samsul the cattle and goat breeder here."); //1
        bahasaUS.Add("I always take good care of the cows and goats here. Watch out your livestock carefully."); //2
        bahasaUS.Add("Do you want to buy something ?"); //3
        bahasaUS.Add("Buy"); //4
        bahasaUS.Add("Sell"); //5
        bahasaUS.Add("Choose the product what you want boss, everything is fresh"); //6
        bahasaUS.Add("Please choose which product you want to sell"); //7
        bahasaUS.Add("Ehh, your product is empty"); //8
        bahasaUS.Add("Let's give name to another one"); //9
        bahasaUS.Add("Thank you very much for buying boss"); //10
        bahasaUS.Add("Thank you very much for selling boss"); //11

        //Translate Bahasa Jepang
        bahasaJP = new List<string>();
        bahasaJP.Add("こんにちは "); //0
        bahasaJP.Add("あなたは新しい庭を所有していると聞きましたよね？紹介します、私は牛と山羊のブリーダーであるサムスルです。"); //1
        bahasaJP.Add("私はいつもここで牛と山羊の世話をしています。家畜に注意してください。"); //2
        bahasaJP.Add("何か買いたいですか？"); //3
        bahasaJP.Add("買う"); //4
        bahasaJP.Add("売る"); //5
        bahasaJP.Add("上司が望む製品を選択してください。すべてが新鮮です"); //6
        bahasaJP.Add("売りたい商品を選んでください"); //7
        bahasaJP.Add("素晴らしい、名前を付けましょう"); //8
        bahasaJP.Add("別のものに名前を付けましょう"); //9
        bahasaJP.Add("購入していただきありがとうございます"); //10
        bahasaJP.Add("上司を売ってくれてありがとう"); //11

    }

    [PunRPC]
    void talkSamaanHaiDulu(int indexsatu, int indexdua)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(indexsatu, name) + PhotonNetwork.NickName + ", " + ChangeLanguage.instance.GetLanguageNPC(indexdua, name), true);
    }

    [PunRPC]
    void talkSamaan(int indexsatu)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(indexsatu, name), true);
    }

    [PunRPC]
    void endPercakapanSemua()
    {
        endPercakapan();
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);

    }

    [PunRPC]
    void setWidthTextDialog(float width)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<RectTransform>().sizeDelta = new Vector2(width, GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<RectTransform>().sizeDelta.y);
    }

    [PunRPC]
    void setActiveGameobject(string namaobject,bool aktifga)
    {
        GameObject.Find("Canvas").transform.Find(namaobject).gameObject.SetActive(aktifga);
    }

    [PunRPC]
    void setActiveGameobjectChild(string parentobject,string namaobject, bool aktifga)
    {
        GameObject.Find("Canvas").transform.Find(parentobject).Find(namaobject).gameObject.SetActive(aktifga);
    }

    public IEnumerator NPCMikaJalan()
    {
        yield return new WaitUntil(() => PhotonNetwork.IsConnectedAndReady && PhotonNetwork.InRoom);

        yield return new WaitUntil(() => PhotonNetwork.IsMasterClient);
        //DAILY EVENT
        Debug.Log("SAMSUL JALAN 1");
        GetComponent<NPC>().pos.x = 11.35f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 6.78f;
        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 7.37f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 0.5f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "Peternakan");
        transform.position = new Vector3(8.037f, 0, 20.119f);
        GetComponent<NPC>().pos.x = 7.507f;
        GetComponent<NPC>().pos.y = 0.5f;
        GetComponent<NPC>().pos.z = 11.28f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name + "Jualan", false);
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        StartCoroutine(randomJalanDepanRumahSamsul());
        
    }

    IEnumerator randomJalanDiKamar()
    {
        System.Random rnd = new System.Random();
        int val = rnd.Next(10, 15); // range 0.0 to 1.0
        GetComponent<NPC>().pos.x = val;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 10;

        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        yield return new WaitForSeconds(5f);
        StartCoroutine(randomJalanDiKamar());
    }

    IEnumerator randomJalanDepanRumahSamsul()
    {
        System.Random rnd = new System.Random();
        int val = rnd.Next(2, 14); // range 0.0 to 1.0
        GetComponent<NPC>().pos.x = val;
        GetComponent<NPC>().pos.y = 0.5f;
        GetComponent<NPC>().pos.z = rnd.Next(10, 14);

        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitForDone(10f, () => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        yield return new WaitForSeconds(5f);
        if(int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) >= 9 &&
            int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) <= 12)
        {
            //MASUK RUMAH SAMSUL
            GetComponent<NPC>().pos.x = 8.037f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 20f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "MasukRumahSamsul");
            transform.position = new Vector3(7.37f, 0, 0.5f);
            GetComponent<NPC>().pos.x = 12.01f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 4f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 13.03f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 1.63f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            transform.eulerAngles = new Vector3(0,-90,0);
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name+"Jualan", true);
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        }
        else if(int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) >= 6 &&
            int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) < 9)
        {
            StartCoroutine(randomJalanDepanRumahSamsul());
        }
    }

    void lagiNanya()
    {
        Gamesetupcontroller.instance.minFoV = true;
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();

        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + name);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("NamaNPC").GetComponent<Text>().text = name;
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);

        if (PhotonNetwork.IsMasterClient)
        {
            GameObject.Find(name).GetComponent<PhotonView>().RPC("melihatYgNanya", RpcTarget.All, name, PhotonNetwork.NickName);
            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
            custom.Add("nanyaNPC" + name, PhotonNetwork.LocalPlayer.NickName);
            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        }
        
    }

    void endPercakapan()
    {
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(true);

        Gamesetupcontroller.instance.maxFoV = true;

        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan(true);
        GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, PlayerPrefs.GetString("buttonNPC"), false);

        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("nanyaNPC" + PlayerPrefs.GetString("buttonNPC"), "");
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        PlayerPrefs.DeleteKey("buttonNPC");
    }

    //NANYA BIASA
    public IEnumerator nanyaFriendship()
    {
        //SET BUTTON
        GameObject button1 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button1").Find("Text").gameObject;
        GameObject button2 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button2").Find("Text").gameObject;
        GameObject button3 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").Find("Text").gameObject;
        MyDialogBag myDialogBag = GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>();
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = true;
        if (PlayerPrefs.GetInt(name + "Friendship") < 20)
        {
            //NANYA JUALAN
            GetComponent<NPC>().sedangditanya = true;
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button1").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button2").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("ButtonTurnOff").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(3, name), true);

            button1.GetComponent<Text>().text = button1.GetComponent<ChangeLanguage>().GetLanguageNPC(4,name);
            makeAnswerPas(button1);
            button2.GetComponent<Text>().text = button2.GetComponent<ChangeLanguage>().GetLanguageNPC(5,name);
            makeAnswerPas(button2);
            button3.GetComponent<Text>().text = button3.GetComponent<ChangeLanguage>().GetLanguage(107);
            makeAnswerPas(button3);
            Debug.Log("JAWABAN BUTTON 1 : "+ button1.GetComponent<ChangeLanguage>().GetLanguageNPC(4, name));
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes")
            {
                answer = "";
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(6, name), false);
                yield return new WaitForSeconds(2f);
                GameObject.Find("Canvas").transform.Find("SeedShop").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("SeedShop").Find("BGnotif").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
                for (int i = 4; i < GameObject.Find("Canvas").transform.Find("UIkanan").childCount; i++)
                    GameObject.Find("Canvas").transform.Find("UIkanan").GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                answer = "";
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(7, name), true);
                yield return new WaitForSeconds(2f);
                PlayerPrefs.SetInt("EmonSell",1);
                GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
                for (int i = 4; i < GameObject.Find("Canvas").transform.Find("UIkanan").childCount; i++)
                    GameObject.Find("Canvas").transform.Find("UIkanan").GetChild(i).gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("SeedShopSell").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("Bag").Find("BGnotif").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("Bag").Find("ButtonBack").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
            }
            
        }
        else if (PlayerPrefs.GetInt(name+"Friendship") < 40)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(21, name), false);
            button1.GetComponent<Text>().text = ChangeLanguage.instance.GetLanguageNPC(29, name);
            makeAnswerPas(button1);
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes") myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(2, name), false);
            else if (answer == "no")
            {
                System.Random rnd = new System.Random();
                int randomInt = rnd.Next(3, 5);
                myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(randomInt, name), false);
            }
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
        else if (PlayerPrefs.GetInt(name + "Friendship") < 60)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(22, name), false);
            button1.GetComponent<Text>().text = ChangeLanguage.instance.GetLanguageNPC(30, name);
            makeAnswerPas(button1);
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes") myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(26, name), false);
            else if (answer == "no")
            {
                System.Random rnd = new System.Random();
                int randomInt = rnd.Next(27, 29);
                myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(randomInt, name), false);
            }
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
        else if (PlayerPrefs.GetInt(name + "Friendship") < 80)
        {
            button1.GetComponent<Text>().text = ChangeLanguage.instance.GetLanguageNPC(31, name);
            makeAnswerPas(button1);
            
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(23, name), false);
            Debug.Log("JAWABAN: "+button1.GetComponent<Text>().text+" - "+ ChangeLanguage.instance.GetLanguageNPC(31, name));
            
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes") myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(26, name), false);
            else if (answer == "no")
            {
                System.Random rnd = new System.Random();
                int randomInt = rnd.Next(27, 29);
                myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(randomInt, name), false);
            }
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
        else if (PlayerPrefs.GetInt(name + "Friendship") <= 100)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(24, name), false);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
    }

    public IEnumerator BeliSapi(bool kedua)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        int talking = 8;
        if (kedua) talking = 9;
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
        ChangeLanguage.instance.GetLanguageNPC(talking, name), true);
        yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("LivestockShop").Find("GiveName").GetChild(2).gameObject.SetActive(true);
    }

    public IEnumerator BarangKosongDijual()
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
        ChangeLanguage.instance.GetLanguageNPC(8, name), true);
        yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
    }

    public IEnumerator EndSell()
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
        ChangeLanguage.instance.GetLanguageNPC(11, name), true);
        yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
    }

    public IEnumerator EndBuy()
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
        ChangeLanguage.instance.GetLanguageNPC(10, name), true);
        yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("SeedShop").Find("ScrollViewProduct").GetChild(0).GetChild(0).childCount; i++)
            GameObject.Find("Canvas").transform.Find("SeedShop").Find("ScrollViewProduct").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("SeedShop").Find("ScrollViewSeed").GetChild(0).GetChild(0).childCount; i++)
            GameObject.Find("Canvas").transform.Find("SeedShop").Find("ScrollViewSeed").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        PlayerPrefs.SetInt("buyCow", 0);
        PlayerPrefs.SetInt("buyCalf", 0);
        PlayerPrefs.SetInt("buyGoat", 0);
        PlayerPrefs.SetInt("buyBabyGoat", 0);
        PlayerPrefs.SetInt("buyBale", 0);
    }

    [PunRPC]
    void EatGiftRpc(string namaplayer,string level)
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("eating").GetComponent<AudioSource>();
        audio.transform.position = GameObject.Find("PlayerSpawn").transform.Find("Player ("+namaplayer+")").transform.position;
        audio.Play();
        StartCoroutine(PlusStamina(namaplayer, level));
        if (PhotonNetwork.IsMasterClient)StartCoroutine(EatGift(namaplayer,level));
    }

    IEnumerator EatGift(string namaplayer, string level)
    {
        GameObject item = PhotonNetwork.Instantiate(System.IO.Path.Combine("Model/Item/Prefab", "cake"), GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").rotation);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + namaplayer + ")", item.name, level);
        yield return new WaitForSeconds(5f);
        PhotonNetwork.Destroy(item);
    }
    IEnumerator PlusStamina(string namaplayer, string level)
    {
        GameObject.Find("Clicked").transform.Find("Heart").gameObject.SetActive(true);
        GameObject.Find("Clicked").transform.Find("Heart").transform.position = GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").transform.position;
        yield return new WaitForSeconds(2f);
        GameObject.Find("Clicked").transform.Find("Heart").gameObject.SetActive(false);
    }

    void makeAnswerPas(GameObject button1)
    {
        if(button1.GetComponent<Text>().preferredWidth > 150)
        button1.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(button1.GetComponent<Text>().preferredWidth + 5f, button1.transform.parent.GetComponent<RectTransform>().sizeDelta.y);
        else button1.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, button1.transform.parent.GetComponent<RectTransform>().sizeDelta.y);
    }
}

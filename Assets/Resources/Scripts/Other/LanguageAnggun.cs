﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageAnggun : MonoBehaviour
{
    public static LanguageAnggun instance = null;
    public List<string> bahasaID;
    public List<string> bahasaUS;
    public List<string> bahasaJP;
    public GameObject tas;
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
        bahasaID.Add("Boleh kakak upgrade tas jadi keren nambah 2 slot loh. Cuma 2500 koin saja"); //0
        bahasaID.Add("Boleh kakak upgrade tas jadi keren nambah 4 slot loh. Cuma 10000 koin saja"); //1
        bahasaID.Add("Nah kan cakep tuh bisa nampung banyak barang"); //2
        bahasaID.Add("Maaf uang kamu kurang"); //3
        bahasaID.Add("Beli"); //4
        bahasaID.Add("Jual"); //5
        bahasaID.Add("Silahkan pilih sapi atau kambing mana yang kamu suka"); //6
        bahasaID.Add("Silahkan pilih sapi atau kambing mana yang ingin kamu jual"); //7
        bahasaID.Add("Mantap, jangan lupa beri nama biar kamu tidak lupa"); //8
        bahasaID.Add("Kasih nama hewan yang lain juga ya"); //9
        bahasaID.Add("Makasih udah beli disini, nanti aku akan antarkan ke kandangmu"); //10

        //Translate Bahasa Inggris
        bahasaUS = new List<string>();
        bahasaUS.Add("It's time to upgrade the bag to cool bag, add 2 slots. Only cost 2500 coins"); //0
        bahasaUS.Add("It's time to upgrade the bag to cool bag, add 4 slots. Only cost 10000 coins"); //1
        bahasaUS.Add("Great, you look amazing and then you can bring more item"); //2
        bahasaUS.Add("Sorry, your money isn't enough"); //3
        bahasaUS.Add("Buy"); //4
        bahasaUS.Add("Sell"); //5
        bahasaUS.Add("Please choose which cow or goat you like"); //6
        bahasaUS.Add("Please choose which cow or goat you want to sell"); //7
        bahasaUS.Add("Awesome, let's give the name"); //8
        bahasaUS.Add("Let's give name to another one"); //9
        bahasaUS.Add("Thanks for buying, later I will deliver it to your farm"); //10

        //Translate Bahasa Jepang
        bahasaJP = new List<string>();
        bahasaJP.Add("バッグをクールバッグにアップグレードし、2 つのスロットを追加します。たった 2500 コイン"); //0
        bahasaJP.Add("バッグをクールバッグにアップグレードし、4 つのスロットを追加します。たった 10000 コイン"); //1
        bahasaJP.Add("素晴らしいです、あなたは素晴らしく見えます、そしてあなたはより多くのアイテムを持ってくることができます"); //2
        bahasaJP.Add("すみません、あなたのお金は十分ではありません"); //3
        bahasaJP.Add("買う"); //4
        bahasaJP.Add("売る"); //5
        bahasaJP.Add("好きな牛や山羊を選んでください"); //6
        bahasaJP.Add("販売したい牛や山羊を選んでください"); //7
        bahasaJP.Add("素晴らしい、名前を付けましょう"); //8
        bahasaJP.Add("別のものに名前を付けましょう"); //9
        bahasaJP.Add("購入していただきありがとうございます、後であなたの農場に配達します"); //10

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
        //MUTERIN TAS

        //MASIH DI PASAR
        GetComponent<NPC>().pos.x = 4.15f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 16.99f;
        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 4.26f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 19.94f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 7.3f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 19.84f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 7.25f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 16.95f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(5f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");

        StartCoroutine(NPCMikaJalan());

    }

    IEnumerator randomJalanDiKamar()
    {
        System.Random rnd = new System.Random();
        int val = rnd.Next(10, 15); // range 0.0 to 1.0
        GetComponent<NPC>().pos.x = val;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 10;
        if(tas.activeSelf)
        tas.SetActive(false);

        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        yield return new WaitForSeconds(5f);
        if (int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) == 6 &&
            PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() != "Sabtu" &&
            PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() != "Minggu")
        {
            Material newMat = Resources.Load("Model/MainMenu/Material/" + name + "/BajuPulangSekolah", typeof(Material)) as Material;
            if (transform.GetChild(0).Find("Body").GetComponent<SkinnedMeshRenderer>().material != newMat)
                transform.GetChild(0).Find("Body").GetComponent<SkinnedMeshRenderer>().material = newMat;
            StartCoroutine(NPCMikaJalan());
        }
        else
            StartCoroutine(randomJalanDiKamar());
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
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button1").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button2").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("ButtonTurnOff").gameObject.SetActive(false);
        button1.GetComponent<Text>().text = button1.GetComponent<ChangeLanguage>().GetLanguageNPC(4,name);
        makeAnswerPas(button1);
        button3.GetComponent<Text>().text = button3.GetComponent<ChangeLanguage>().GetLanguage(107);
        makeAnswerPas(button3);

        if (PlayerPrefs.GetInt(name + "Friendship") < 20)
        {
            int asklevelbag = 0;
            if (PlayerPrefs.GetInt("levelbag") == 1) asklevelbag = 0;
            else if (PlayerPrefs.GetInt("levelbag") == 2) asklevelbag = 1;
            else if (PlayerPrefs.GetInt("levelbag") == 3) asklevelbag = 2;
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(asklevelbag, name), false);
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes")
            {
                Debug.Log("LEVEL BAG: "+ PlayerPrefs.GetInt("levelbag"));
                answer = "";
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                if (PlayerPrefs.GetInt("money") >= 2500 && PlayerPrefs.GetInt("levelbag")==1)
                {
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(2, name), false);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 2500);
                    PlayerPrefs.SetInt("levelbag", PlayerPrefs.GetInt("levelbag") + 1);
                    ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                    setProperti.Add("money", PlayerPrefs.GetInt("money"));
                    setProperti.Add("levelbag", PlayerPrefs.GetInt("levelbag"));
                    PhotonNetwork.LocalPlayer.SetCustomProperties(setProperti);
                    GameObject.Find("Canvas").transform.Find("UIkanan").Find("JumlahDuit").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("money");
                    GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().UpdateBagSlot();
                    Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("updatePlayerUI", RpcTarget.All);
                    Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("updateBagLevel", RpcTarget.All, PhotonNetwork.NickName);
                }
                else if (PlayerPrefs.GetInt("money") >= 10000 && PlayerPrefs.GetInt("levelbag") == 2)
                {
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(2, name), false);
                    PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 10000);
                    PlayerPrefs.SetInt("levelbag", PlayerPrefs.GetInt("levelbag") + 1);
                    ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                    setProperti.Add("money", PlayerPrefs.GetInt("money"));
                    setProperti.Add("levelbag", PlayerPrefs.GetInt("levelbag"));
                    PhotonNetwork.LocalPlayer.SetCustomProperties(setProperti);
                    GameObject.Find("Canvas").transform.Find("UIkanan").Find("JumlahDuit").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("money");
                    GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().UpdateBagSlot();
                    Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("updatePlayerUI", RpcTarget.All);
                    Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("updateBagLevel", RpcTarget.All, PhotonNetwork.NickName);
                }
                else
                {
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(3, name), false);
                }
                
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



    [PunRPC]
    void DrinkRPC(string namaplayer,string level)
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("eating").GetComponent<AudioSource>();
        audio.transform.position = GameObject.Find("PlayerSpawn").transform.Find("Player ("+namaplayer+")").transform.position;
        audio.Play();
        StartCoroutine(PlusStamina(namaplayer, level));
        if (PhotonNetwork.IsMasterClient)StartCoroutine(EatGift(namaplayer,level));
    }

    IEnumerator EatGift(string namaplayer, string level)
    {
        GameObject item = PhotonNetwork.Instantiate(System.IO.Path.Combine("Model/Item/Prefab", "coffee"), GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").rotation);
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
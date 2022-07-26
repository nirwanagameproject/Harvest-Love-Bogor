using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class NPCTalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
    }

    // Update is called once per frame
    public void Gajadi(string namaNPC)
    {
        if (PlayerPrefs.HasKey("buttonNPC"))
        {
            GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(true);

            Gamesetupcontroller.instance.maxFoV = true;

            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
            GameObject.Find(PlayerPrefs.GetString("buttonNPC")).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, PlayerPrefs.GetString("buttonNPC"), false);

            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
            custom.Add("nanyaNPC" + PlayerPrefs.GetString("buttonNPC"), "");
            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
            PlayerPrefs.DeleteKey("buttonNPC");
        }else if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.CurrentRoom.CustomProperties["nanyaBarangtv"].ToString())
        {
            GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").gameObject.SetActive(true);

            Gamesetupcontroller.instance.maxFoV = true;

            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("ButtonTurnOff").gameObject.SetActive(false);

            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
            custom.Add("nanyaBarangtv", "");
            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
            PlayerPrefs.DeleteKey("buttonTV");
        }
        
    }

    public void ClickYes(string namaNPC)
    {
        if (PlayerPrefs.GetString("buttonNPC") == "Mika") LanguageMika.instance.answer = "yes";
        if (PlayerPrefs.GetString("buttonNPC") == "Samsul") LanguageSamsul.instance.answer = "yes";

        //NONTON TV NEXT
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.CurrentRoom.CustomProperties["nanyaBarangtv"].ToString())
        {
            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
            television tvku = new television();
            if(((int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"]+1)<= tvku.maxchannel)
            custom.Add("channelTv", (int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"]+1);
            else custom.Add("channelTv", 1);
            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);

            if((int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"]==3) GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(ChangeLanguage.instance.GetLanguage(129), true);
            GameObject.Find("Barang").transform.Find("tv").GetComponent<PhotonView>().RPC("setTvChannel", RpcTarget.All, "tv", PhotonNetwork.NickName);

        }

    }

    public void ClickNo(string namaNPC)
    {
        if (PlayerPrefs.GetString("buttonNPC") == "Mika") LanguageMika.instance.answer = "no";
        if (PlayerPrefs.GetString("buttonNPC") == "Samsul") LanguageMika.instance.answer = "no";

        //NONTON TV PREV
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.CurrentRoom.CustomProperties["nanyaBarangtv"].ToString())
        {
            television tvku = new television();
            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
            if (((int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"] - 1) >= 1)
                custom.Add("channelTv", (int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"] - 1);
            else custom.Add("channelTv", tvku.maxchannel);
            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);

            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"] == 3) GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(ChangeLanguage.instance.GetLanguage(129), true);
            GameObject.Find("Barang").transform.Find("tv").GetComponent<PhotonView>().RPC("setTvChannel", RpcTarget.All, "tv", PhotonNetwork.NickName);
        }
    }

    public void ClickTurnOff(string namaNPC)
    {
        //NONTON TV TURN OFF
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.CurrentRoom.CustomProperties["nanyaBarangtv"].ToString())
        {
            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
            custom.Add("nyalaTv", false);
            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);

            Gajadi("tv");

            GameObject.Find("Barang").transform.Find("tv").GetComponent<PhotonView>().RPC("setTvChannel", RpcTarget.All, "tv", PhotonNetwork.NickName);
        }
    }


}

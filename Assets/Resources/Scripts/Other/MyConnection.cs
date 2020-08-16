using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyConnection : MonoBehaviourPunCallbacks
{
    public string LoginUrl = "https://digixkoin.com/";
    //public static string LoginUrl= "http://192.168.0.103/";
    List<float> startTime;
    public static int pos;
    List<int> myping;
    public bool ingame;

    private static MyConnection instance = null;
    public static MyConnection Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        //mykoinsemua.SetActive(false);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {



    }

    public void KonekKeMaster()
    {
        //PlayerPrefs.DeleteKey("myserver");
        pos = 0;
        myping = new List<int>();
        if (PlayerPrefs.HasKey("myserver"))
        {
            pos = 2;
            if (PlayerPrefs.GetString("myserver") == "asia")
            {
                PhotonNetwork.Disconnect();
                //PhotonNetwork.PhotonServerSettings.AppSettings.Server = "128.199.218.209";
                if (!PhotonNetwork.IsConnectedAndReady)
                    PhotonNetwork.ConnectUsingSettings();
            }
            else if (PlayerPrefs.GetString("myserver") == "us")
            {
                PhotonNetwork.Disconnect();
                //PhotonNetwork.PhotonServerSettings.AppSettings.Server = "128.199.218.209";
                if (!PhotonNetwork.IsConnectedAndReady)
                    PhotonNetwork.ConnectUsingSettings();
            }
        }
        else
        {
            if (PhotonNetwork.IsConnected)
                PhotonNetwork.Disconnect();
            //PhotonNetwork.PhotonServerSettings.AppSettings.Server = "128.199.218.209";
            if (!PhotonNetwork.IsConnectedAndReady)
                PhotonNetwork.ConnectUsingSettings(); //Connects to Photon master servers
        }
    }

    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.OfflineMode)
        {
            myping.Add(PhotonNetwork.GetPing());
            Debug.Log("Ping Network : " + PhotonNetwork.GetPing());
            Debug.Log(pos);
            if(pos > 2)
            {
                pos = 4;
            }
            //Debug.Log(PhotonNetwork.PhotonServerSettings.AppSettings.Server);
            /*if (PhotonNetwork.PhotonServerSettings.AppSettings.Server == "128.199.218.209") { PlayerPrefs.SetString("myserver", "asia"); MyConnection.Instance.LoginUrl = "https://128.199.218.209/"; }
            else if (PhotonNetwork.PhotonServerSettings.AppSettings.Server == "128.199.218.209") { PlayerPrefs.SetString("myserver", "us"); MyConnection.Instance.LoginUrl = "https://128.199.218.209/"; }
            */
            if (pos == 1)
            {
                if (myping[0] < myping[1])
                {
                    PhotonNetwork.Disconnect();
                    //PhotonNetwork.PhotonServerSettings.AppSettings.Server = "128.199.218.209";
                    if (!PhotonNetwork.IsConnectedAndReady)
                        PhotonNetwork.ConnectUsingSettings();
                    pos++;

                }
                else
                {
                    pos++;
                }

            }

            if (pos == 0)
            {
                PhotonNetwork.Disconnect();
                //PhotonNetwork.PhotonServerSettings.AppSettings.Server = "128.199.218.209";
                if (!PhotonNetwork.IsConnectedAndReady)
                    PhotonNetwork.ConnectUsingSettings();
                pos++;
            }

            if (pos == 2)
            {
                //LoadingMenu.Instance.loadingawal();
                GameObject.Find("Canvas").transform.Find("NotifKoneksi").gameObject.SetActive(false);
                CustomMatchmakingLobbyCampaignController.instance.FirstConnect();
                PlayerPrefs.SetString("online", "yes");
                pos++;
            }
            if (pos == 4)
            {
                //LoadingMenu.Instance.loadingawal();
                if (!PhotonNetwork.IsConnectedAndReady)
                    PhotonNetwork.ConnectUsingSettings();
                GameObject.Find("Canvas").transform.Find("NotifKoneksi").gameObject.SetActive(false);
                CustomMatchmakingLobbyCampaignController.instance.FirstConnect2();
                PlayerPrefs.SetString("online", "yes");
                pos++;
            }
        }

        CustomMatchmakingLobbyCampaignController.instance.konekMaster = true;
        Debug.Log("Server Location : " + PlayerPrefs.GetString("myserver"));

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(cause.ToString());
        if (cause.ToString().Equals("ClientTimeout") && !ingame)
        {
            MainMenuController.instance.notifkonek.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Koneksi bermasalah";
            MainMenuController.instance.callAudioWrongClicked();
            Invoke("notifsetactive", 3f);
        }
        else if (cause.ToString().Equals("ClientTimeout") && ingame)
        {
            GameObject.Find("Canvas").transform.Find("Disconnected").gameObject.SetActive(true);
        }
    }



    public void notifsetactive()
    {
        MainMenuController.instance.BackToLoadingMenu();
        MainMenuController.instance.notifkonek.transform.Find("BotNotif").Find("Text").GetComponent<Text>().text = "Menyambungkan ke server...";
    }

    public void quitgame()
    {

        Application.Quit();

    }
}
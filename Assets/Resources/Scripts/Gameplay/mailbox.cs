using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mailbox : MonoBehaviour
{
    public GameObject mymail;
    public GameObject transisi;
    public GameObject cubeaction;
    
    public string mysave;
    public string respawn;
    public int cek;

    // Start is called before the first frame update
    void Start()
    {
        cek = 1;
        transisi = GameObject.Find("Canvas").transform.Find("Transisi").gameObject;

        if (PlayerPrefs.GetString("ambilduitharian") == "yes")
            mymail.transform.Find("Button1").Find("Udahdisave").Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/mailopen");
        mymail.transform.Find("Button1").Find("Udahdisave").Find("Texttgl").GetComponent<Text>().text = "Tgl: "+ PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        
        Collider[] mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));
        bool enterPlayer = mycolliderPlayer.Length != 0;

        if (enterPlayer && (cek == 1 || cek==3))
        {
            for (int i = 0; i < mycolliderPlayer.Length; i++)
            {
                if (!PhotonNetwork.IsConnected || mycolliderPlayer[i].GetComponent<PhotonView>().IsMine)
                {
                    cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                    cubeaction.SetActive(true);

                    PlayerPrefs.SetString("buttonMailbox", name);
                    if (cek > 2) cek = 1;
                    else cek++;

                }
            }
        }
        else
        if (!enterPlayer && cek == 3)
        {
            cubeaction.SetActive(false);
            PlayerPrefs.DeleteKey("buttonMailbox");
            if (cek > 2) cek = 1;
            else cek++;
        }
        else
        if (!enterPlayer && cek == 2) cek = 3;
        else if (enterPlayer && cek == 3) cek = 1;
        
        

    }

    void Update()
    {
        if (GameObject.Find("CanvasFarm").GetComponent<AdManager>().berhasil != "")
        {
            if (GameObject.Find("CanvasFarm").GetComponent<AdManager>().berhasil == "gapencet")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
                audio.Play();
                Debug.Log("no");
                GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").gameObject.SetActive(true);
                GameObject.Find("CanvasFarm").transform.Find("MohonTunggu").gameObject.SetActive(false);
                GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").Find("BotNotif").Find("Text").GetComponent<Text>().text = "Kamu belum mengklik iklannya\nJadi belum dapet bonus\nSilahkan klik lagi iklannya.";
            }
            else if (GameObject.Find("CanvasFarm").GetComponent<AdManager>().berhasil == "pencet")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("dapetduitsound").GetComponent<AudioSource>();
                audio.Play();
                Debug.Log("yes");

                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 20000);
                PlayerPrefs.SetString("ambilduitharian", "yes");

                GameObject.Find("CanvasFarm").transform.Find("MohonTunggu").gameObject.SetActive(false);
                GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").gameObject.SetActive(true);
                GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").Find("BotNotif").Find("Text").GetComponent<Text>().text = "Selamat!\nKamu dapet uang Rp 20.000\nDapatkan lagi besok yaaa..";
                GameObject.Find("CanvasFarm").transform.Find("MyMail").Find("Scroll View").Find("Viewport").Find("Content").Find("Button1").Find("Udahdisave").Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/mailopen");
            }
            Text myduit = GameObject.Find("Canvas").transform.Find("UIkanan").Find("JumlahDuit").GetComponent<Text>();
            myduit.text = "" + PlayerPrefs.GetInt("money");
            GameObject.Find("CanvasFarm").GetComponent<AdManager>().berhasil ="";
        }
    }

    public void ClickExit()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("CanvasFarm").transform.Find("MyMail").gameObject.SetActive(false);
    }


    public void ClickTampilinSurat(int buttonno)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        if (buttonno == 1)
        {
            if(PlayerPrefs.GetString("ambilduitharian")=="no")
            GameObject.Find("CanvasFarm").transform.Find("KonfirmAds").gameObject.SetActive(true);
            else
            {
                GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").gameObject.SetActive(true);
                GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").Find("BotNotif").Find("Text").GetComponent<Text>().text = "Kamu sudah mengambil bonus harian,\nbesok lagi ya..";
            }
        }
        
    }

    public void ClickGajadiKlikIklan()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("CanvasFarm").transform.Find("KonfirmAds").gameObject.SetActive(false);
    }

    public void ClickOpenAds()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("CanvasFarm").transform.Find("KonfirmAds").gameObject.SetActive(false);
        GameObject.Find("CanvasFarm").transform.Find("MohonTunggu").gameObject.SetActive(true);
        GameObject.Find("CanvasFarm").GetComponent<AdManager>().selesai = false;
        GameObject.Find("CanvasFarm").GetComponent<AdManager>().RequestInterstitial();
    }

    public void CloseDapetDuit()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").gameObject.SetActive(false);
    }

    public void CloseTunggu()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("CanvasFarm").transform.Find("DapetDuitAds").gameObject.SetActive(false);
        GameObject.Find("CanvasFarm").transform.Find("MohonTunggu").gameObject.SetActive(false);
        if(GameObject.Find("CanvasFarm").GetComponent<AdManager>().interstitial.IsLoaded())
        GameObject.Find("CanvasFarm").GetComponent<AdManager>().interstitial.Destroy();
        GameObject.Find("CanvasFarm").GetComponent<AdManager>().selesai = false;
        GameObject.Find("CanvasFarm").GetComponent<AdManager>().RequestInterstitial();
    }

}

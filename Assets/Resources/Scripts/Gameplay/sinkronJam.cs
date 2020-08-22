using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sinkronJam : MonoBehaviour
{
    public Text jamtextJam;
    public Text jamtextDetik;
    // Start is called before the first frame update
    void Start()
    {
        jamtextJam = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>();
        jamtextDetik = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>();
        if (!PhotonNetwork.IsConnected || PhotonNetwork.IsMasterClient )
            InvokeRepeating("jalanDetik",5f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void jalanDetik()
    {
        //yield return new WaitForSeconds(5);
        if(jamtextDetik!=null)
        if (int.Parse(jamtextDetik.text) < 50)
        {
            jamtextDetik.text = (int.Parse(jamtextDetik.text) + 10).ToString();
        }
        else
        {
            jamtextDetik.text = "00";
            if ((int.Parse(jamtextJam.text) + 1) < 10)
                jamtextJam.text = "0" + (int.Parse(jamtextJam.text) + 1).ToString();
            else
            {
                    if((int.Parse(jamtextJam.text) + 1)>23) jamtextJam.text = "00";
                    else jamtextJam.text = (int.Parse(jamtextJam.text) + 1).ToString();
            }
        }

        if (int.Parse(jamtextJam.text)==6 && int.Parse(jamtextDetik.text)==0)
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

            PlayerPrefs.SetString("ambilduitharian", "no");

            Image mymusim = GameObject.Find("Canvas").transform.Find("UIKiri").Find("Weather").GetComponent<Image>();
            Text dateskrg = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDate").GetComponent<Text>();

            dateskrg.text = PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString();
            if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Spring") mymusim.sprite = Gamesetupcontroller.instance.weather[0];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Summer") mymusim.sprite = Gamesetupcontroller.instance.weather[1];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Fall") mymusim.sprite = Gamesetupcontroller.instance.weather[2];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Winter") mymusim.sprite = Gamesetupcontroller.instance.weather[3];
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString();
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString();
        }

        float jumlahdsun = ((((int.Parse(jamtextJam.text)-6)) * 15f) + ((int.Parse(jamtextDetik.text))) * 0.25f);
        if(int.Parse(jamtextJam.text)>=5 && int.Parse(jamtextJam.text) < 18)
        PlayerPrefs.SetFloat("directionalSun", jumlahdsun);
        else PlayerPrefs.SetFloat("directionalSun", 355);

        //NIGHT TIME MUSIC
        Gamesetupcontroller.instance.setmusic();

        if (PlayerPrefs.GetString("level") != "MasukRumah" && PlayerPrefs.GetString("level") != "MasukKandangAyam")
        {
            if (GameObject.Find("Sun") != null)
            {
                GameObject.Find("Sun").transform.eulerAngles = new Vector3(0f, -30f, 0f);
                GameObject.Find("Sun").transform.Rotate(PlayerPrefs.GetFloat("directionalSun"), 0, 0, Space.Self);
                //GameObject.Find("Sun").transform.Rotate(0, 0, 0, Space.Self);
            }
        }
        if (PhotonNetwork.IsConnected)
        {
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add("tanggal", PlayerPrefs.GetInt("tanggal"));
            setTgl.Add("tahun", PlayerPrefs.GetInt("tahun"));
            setTgl.Add("musim", PlayerPrefs.GetString("musim"));
            setTgl.Add("jam", jamtextJam.text);
            setTgl.Add("detik", jamtextDetik.text);
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
        }
        PlayerPrefs.SetString("newday", "no");
        //Debug.Log(PlayerPrefs.GetFloat("directionalSun"));
        if (PhotonNetwork.IsConnected)
            Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("sinkronWaktu", RpcTarget.Others, jamtextJam.text, jamtextDetik.text, PlayerPrefs.GetFloat("directionalSun"));

        
        //StartCoroutine(jalanDetik());
    }

    
}

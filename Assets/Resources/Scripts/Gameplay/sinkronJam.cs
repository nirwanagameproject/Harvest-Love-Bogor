using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sinkronJam : MonoBehaviour
{
    public static sinkronJam instance = null;
    public Text jamtextJam;
    public Text jamtextDetik;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
            RenderSettings.skybox.SetFloat("_Exposure", 0.2f);

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
                if (PlayerPrefs.GetString("hari") == "Senin") PlayerPrefs.SetString("hari", "Selasa");
                else if (PlayerPrefs.GetString("hari") == "Selasa") PlayerPrefs.SetString("hari", "Rabu");
                else if (PlayerPrefs.GetString("hari") == "Rabu") PlayerPrefs.SetString("hari", "Kamis");
                else if (PlayerPrefs.GetString("hari") == "Kamis") PlayerPrefs.SetString("hari", "Jumat");
                else if (PlayerPrefs.GetString("hari") == "Jumat") PlayerPrefs.SetString("hari", "Sabtu");
                else if (PlayerPrefs.GetString("hari") == "Sabtu") PlayerPrefs.SetString("hari", "Minggu");
                else if (PlayerPrefs.GetString("hari") == "Minggu") PlayerPrefs.SetString("hari", "Senin");

                ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
                setTgl.Add("tanggal", PlayerPrefs.GetInt("tanggal"));
                setTgl.Add("tahun", PlayerPrefs.GetInt("tahun"));
                setTgl.Add("musim", PlayerPrefs.GetString("musim"));
                setTgl.Add("hari", PlayerPrefs.GetString("hari"));
                setTgl.Add("jam", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text);
                setTgl.Add("detik", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
            }

            PlayerPrefs.SetString("ambilduitharian", "no");

            Image mymusim = GameObject.Find("Canvas").transform.Find("UIKiri").Find("Weather").GetComponent<Image>();
            Text dateskrg = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDate").GetComponent<Text>();

            string hariskrg = "";
            if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Senin") hariskrg = ChangeLanguage.instance.GetLanguage(108);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Selasa") hariskrg = ChangeLanguage.instance.GetLanguage(109);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Rabu") hariskrg = ChangeLanguage.instance.GetLanguage(110);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Kamis") hariskrg = ChangeLanguage.instance.GetLanguage(111);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Jumat") hariskrg = ChangeLanguage.instance.GetLanguage(112);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Sabtu") hariskrg = ChangeLanguage.instance.GetLanguage(113);
            else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Minggu") hariskrg = ChangeLanguage.instance.GetLanguage(114);
            dateskrg.text = hariskrg + ", " + PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() + " " + PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString();
            if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Spring") mymusim.sprite = Gamesetupcontroller.instance.weather[0];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Summer") mymusim.sprite = Gamesetupcontroller.instance.weather[1];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Fall") mymusim.sprite = Gamesetupcontroller.instance.weather[2];
            else if (PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString() == "Winter") mymusim.sprite = Gamesetupcontroller.instance.weather[3];
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString();
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString();

            if (PlayerPrefs.GetString("level") == "KeluarRumah")
            {
                GameObject.Find("SawahSpawn").name = "SawahSpawnCadangan";
                Destroy(GameObject.Find("SawahSpawnCadangan"), 0.1f);
                GameObject newsawah = new GameObject();
                newsawah.name = "SawahSpawn";
            }

            Gamesetupcontroller.instance.newday();
            Gamesetupcontroller.instance.updatebatu();
            Gamesetupcontroller.instance.updatelahan();
        }
        if (PlayerPrefs.GetString("newday") == "yes" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text != "06" && GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text != "00") PlayerPrefs.SetString("newday", "no");

        float jumlahdsun = ((((int.Parse(jamtextJam.text)-6)) * 15f) + ((int.Parse(jamtextDetik.text))) * 0.25f);
        if(int.Parse(jamtextJam.text)>=5 && int.Parse(jamtextJam.text) < 18)
        PlayerPrefs.SetFloat("directionalSun", jumlahdsun);
        else PlayerPrefs.SetFloat("directionalSun", 355);

        Debug.Log("EXPOSURE: "+ RenderSettings.skybox.GetFloat("_Exposure"));
        if(RenderSettings.skybox.GetFloat("_Exposure")==1)
            RenderSettings.skybox.SetFloat("_Exposure", 0.7f);
        else
        if (int.Parse(jamtextJam.text) >= 19)
            RenderSettings.skybox.SetFloat("_Exposure", 0.2f);
        else
        if (int.Parse(jamtextJam.text) >= 12)
            RenderSettings.skybox.SetFloat("_Exposure", RenderSettings.skybox.GetFloat("_Exposure") - 0.011f);
        else
            RenderSettings.skybox.SetFloat("_Exposure", RenderSettings.skybox.GetFloat("_Exposure") + 0.011f);

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
            setTgl.Add("skyboxfloat", RenderSettings.skybox.GetFloat("_Exposure"));
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
        }
        
        //Debug.Log(PlayerPrefs.GetFloat("directionalSun"));
        if (PhotonNetwork.IsConnected)
            Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("sinkronWaktu", RpcTarget.Others, jamtextJam.text, jamtextDetik.text, PlayerPrefs.GetFloat("directionalSun"));

        
        //StartCoroutine(jalanDetik());
    }

    
}

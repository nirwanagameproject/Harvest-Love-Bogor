using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class koleksi : MonoBehaviour
{
    public GameObject peralatan;
    public string namakoleksi;
    public GameObject namajudul;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void selectTools(int slot)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        string tipeitem="";
        if (namakoleksi == "Baju") tipeitem = "Top";

        if (PlayerPrefs.GetString("gender") == "cewek")
        {
            PlayerPrefs.SetString("bajudipakai", PlayerPrefsX.GetStringArray("koleksibaju")[slot]);
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").GetComponent<Player1>().LoadGantiBaju();

            gameObject.SetActive(false);

        }
        else
        {
            PlayerPrefs.SetString("bajudipakai", PlayerPrefsX.GetStringArray("koleksibaju")[slot]);
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").GetComponent<Player1>().LoadGantiBaju();

            gameObject.SetActive(false);
        }
    }

    public void openKoleksi(string namakoleksiku)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        gameObject.SetActive(true);
        namakoleksi = namakoleksiku;
        namajudul.GetComponent<Text>().text = "Koleksi "+namakoleksi;
        for (int i = 0; i < PlayerPrefsX.GetStringArray("koleksi"+namakoleksi.ToLower()).Length; i++)
        {
            peralatan.transform.GetChild(i).transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + namakoleksi + "/" + PlayerPrefsX.GetStringArray("koleksi" + namakoleksi.ToLower())[i]);
            peralatan.transform.GetChild(i).transform.Find("Image").GetComponent<Image>().enabled = true;
        }
    }

    public void tutupKoleksi()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        gameObject.SetActive(false);
    }


}

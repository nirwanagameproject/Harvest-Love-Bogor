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
        if (namakoleksi == "Baju") tipeitem = "Top";else
        if (namakoleksi == "Celana") tipeitem = "Bottom";else
        if (namakoleksi == "Rambut") tipeitem = "Hair";else
        if (namakoleksi == "Topi") tipeitem = "Body";

       
        PlayerPrefs.SetString(namakoleksi.ToLower() + "dipakai", PlayerPrefsX.GetStringArray("koleksi"+ namakoleksi.ToLower())[slot]);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").GetComponent<Player1>().LoadGantiBaju();

        gameObject.SetActive(false);

        
    }

    public void openKoleksi(string namakoleksiku)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        gameObject.SetActive(true);
        namakoleksi = namakoleksiku;
        namajudul.GetComponent<Text>().text = "Koleksi "+namakoleksi;
        for (int i = 0; i < peralatan.transform.childCount; i++)
        {
            if(i<PlayerPrefsX.GetStringArray("koleksi" + namakoleksi.ToLower()).Length)
            {
                peralatan.transform.GetChild(i).transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + namakoleksi + "/" + PlayerPrefsX.GetStringArray("koleksi" + namakoleksi.ToLower())[i]);
                peralatan.transform.GetChild(i).transform.Find("Image").GetComponent<Image>().enabled = true;
            }else
            {
                peralatan.transform.GetChild(i).transform.Find("Image").GetComponent<Image>().enabled = false;
            }
        }
    }

    public void tutupKoleksi()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        gameObject.SetActive(false);
    }

    public void TutupWardrobe()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        Gamesetupcontroller.instance.maxFoVClothes = true;

        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(true);

        GameObject.Find("CanvasHome").transform.Find("Dandan").gameObject.SetActive(false);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Karakter").gameObject.SetActive(false);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Aksesoris").gameObject.SetActive(false);

        Color32 mycolor = new Color32(255, 221, 150, 255);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("ButtonKarakter").GetComponent<Image>().color = mycolor;
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("ButtonAksesoris").GetComponent<Image>().color = Color.white;
        PlayerPrefs.DeleteKey("buttonChangeClothes");
        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("wardrobe", "");
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);

    }

    public void KlikKarakter()
    {
        Color32 mycolor = new Color32(255, 221, 150, 255);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("ButtonKarakter").GetComponent<Image>().color = mycolor;
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Karakter").gameObject.SetActive(true);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("ButtonAksesoris").GetComponent<Image>().color = Color.white;
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Aksesoris").gameObject.SetActive(false);
    }

    public void KlikAksesoris()
    {
        Color32 mycolor = new Color32(255, 221, 150, 255);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("ButtonAksesoris").GetComponent<Image>().color = mycolor;
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Aksesoris").gameObject.SetActive(true);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("ButtonKarakter").GetComponent<Image>().color = Color.white;
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Karakter").gameObject.SetActive(false);
    }


}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLanguage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("bahasa") != null)
        {
            if (PlayerPrefs.GetString("bahasa") == "Indonesia") {
                GetComponent<Dropdown>().value = 0;
            }
            else if (PlayerPrefs.GetString("bahasa") == "Inggris")
            {
                GetComponent<Dropdown>().value = 1;
            }
            else if (PlayerPrefs.GetString("bahasa") == "Jepang")
            {
                GetComponent<Dropdown>().value = 2;
            }

        }
    }

    public void ClickChangeLanguage(Dropdown dropdown)
    {
        if (dropdown.options[dropdown.value].text == "Indonesia")
        {
            PlayerPrefs.SetString("bahasa", "Indonesia");
        }
        else if (dropdown.options[dropdown.value].text == "English")
        {
            PlayerPrefs.SetString("bahasa", "Inggris");
        }
        else if (dropdown.options[dropdown.value].text == "Japan")
        {
            PlayerPrefs.SetString("bahasa", "Jepang");
        }

        Debug.Log("GANTI BAHASA: " + dropdown.options[dropdown.value].text);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Language").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Language")[i].name == "TextDate")
            {
                Text dateskrg = GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDate").GetComponent<Text>();
                string hariskrg = "";
                if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Senin") hariskrg = ChangeLanguage.instance.GetLanguage(108);
                else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Selasa") hariskrg = ChangeLanguage.instance.GetLanguage(109);
                else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Rabu") hariskrg = ChangeLanguage.instance.GetLanguage(110);
                else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Kamis") hariskrg = ChangeLanguage.instance.GetLanguage(111);
                else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Jumat") hariskrg = ChangeLanguage.instance.GetLanguage(112);
                else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Sabtu") hariskrg = ChangeLanguage.instance.GetLanguage(113);
                else if (PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Minggu") hariskrg = ChangeLanguage.instance.GetLanguage(114);
                dateskrg.text = hariskrg + ", " + PhotonNetwork.CurrentRoom.CustomProperties["tanggal"].ToString() + " " + Gamesetupcontroller.instance.musimText(PhotonNetwork.CurrentRoom.CustomProperties["musim"].ToString()) + " " + PhotonNetwork.CurrentRoom.CustomProperties["tahun"].ToString();
            }
            else
                GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>().ChangedLanguge();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

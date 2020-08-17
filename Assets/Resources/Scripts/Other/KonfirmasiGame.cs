using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KonfirmasiGame : ChangeLanguage
{
    // Start is called before the first frame update
    void Start()
    {
        string namaku = PlayerPrefs.GetString("myname");
        string namakebunku = PlayerPrefs.GetString("mykebun");
        string namakucingku = PlayerPrefs.GetString("mykucing");
        int namatgllahir = PlayerPrefs.GetInt("mytanggallahir");
        string namamusimlahir = PlayerPrefs.GetString("mymusimlahir");

        GetComponent<ChangeLanguage>().GetLanguage(22);
        string namaText = GetComponent<ChangeLanguage>().textTranslate;
        GetComponent<ChangeLanguage>().GetLanguage(34);
        string kebunText = GetComponent<ChangeLanguage>().textTranslate;
        GetComponent<ChangeLanguage>().GetLanguage(38);
        string ultahText = GetComponent<ChangeLanguage>().textTranslate;
        GetComponent<ChangeLanguage>().GetLanguage(35);
        string kucingText = GetComponent<ChangeLanguage>().textTranslate;
        GetComponent<ChangeLanguage>().GetLanguage(39);
        string konfirmText = GetComponent<ChangeLanguage>().textTranslate;
        string ubahKonfirmasi = namaText + ": " + namaku + "\n" + kebunText + ": " + namakebunku + "\n" + ultahText + ": " + namatgllahir + " " + namamusimlahir + "\n" + kucingText + ": " + namakucingku + "\n\n" + konfirmText;
        Debug.Log(ubahKonfirmasi);
        GetComponent<Text>().text = ubahKonfirmasi;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

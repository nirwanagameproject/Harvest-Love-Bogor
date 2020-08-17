using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dropdown dropdown = GetComponent<Dropdown>();

        //HItam
        string teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(43);
        dropdown.options[1].text = teks;

        //Putih
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(44);
        dropdown.options[0].text = teks;
        //Biru
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(45);
        dropdown.options[2].text = teks;

        //Merah
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(46);
        dropdown.options[3].text = teks;

        //Kuning
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(47);
        dropdown.options[4].text = teks;

        //Hijau
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(48);
        dropdown.options[5].text = teks;

        //Abu-abu
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(49);
        dropdown.options[6].text = teks;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

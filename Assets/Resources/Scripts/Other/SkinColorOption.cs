using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColorOption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dropdown dropdown = GetComponent<Dropdown>();

        //Putih
        string teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(44);
        dropdown.options[0].text = teks;
        
        //Putih Cokelat
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(56);
        dropdown.options[1].text = teks;

        //Cokelat
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(57);
        dropdown.options[2].text = teks;

        //Cokelat Gelap
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(58);
        dropdown.options[3].text = teks;

        //Hitam
        teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(43);
        dropdown.options[4].text = teks;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

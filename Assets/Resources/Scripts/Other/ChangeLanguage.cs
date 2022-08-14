using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
    public static ChangeLanguage instance = null;
    public int indexText;
    public string textTranslate;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ChangedLanguge();
    }

    public void ChangedLanguge()
    {
        if (PlayerPrefs.GetString("bahasa") == "Indonesia")
        {
            if(GetComponent<TextMesh>()!=null)
                GetComponent<TextMesh>().text = Language.instance.bahasaID[indexText];
            else GetComponent<Text>().text = Language.instance.bahasaID[indexText];
        }
        else if (PlayerPrefs.GetString("bahasa") == "Inggris")
        {
            if (GetComponent<TextMesh>() != null)
                GetComponent<TextMesh>().text = Language.instance.bahasaUS[indexText];
            else GetComponent<Text>().text = Language.instance.bahasaUS[indexText];
            
        }
        else if (PlayerPrefs.GetString("bahasa") == "Jepang")
        {
            if (GetComponent<TextMesh>() != null)
                GetComponent<TextMesh>().text = Language.instance.bahasaJP[indexText];
            else GetComponent<Text>().text = Language.instance.bahasaJP[indexText];
        }
    }
    public string GetLanguage(int indexCari)
    {
        if (PlayerPrefs.GetString("bahasa") == "Indonesia")
        {
            textTranslate = Language.instance.bahasaID[indexCari];
        }
        else if (PlayerPrefs.GetString("bahasa") == "Inggris")
        {
            textTranslate = Language.instance.bahasaUS[indexCari];

        }
        else if (PlayerPrefs.GetString("bahasa") == "Jepang")
        {
            textTranslate = Language.instance.bahasaJP[indexCari];
        }
        return textTranslate;
    }

    public string GetLanguageNPC(int indexCari,string namanpc)
    {
        string tekstranslate = "";
        if (PlayerPrefs.GetString("bahasa") == "Indonesia")
        {
            if (namanpc.Equals("Mika"))
                tekstranslate = LanguageMika.instance.bahasaID[indexCari];
            else if (namanpc.Equals("Samsul"))
                tekstranslate = LanguageSamsul.instance.bahasaID[indexCari];
            else if (namanpc.Equals("Afifah"))
                tekstranslate = LanguageAfifah.instance.bahasaID[indexCari];
            else if (namanpc.Equals("Otong"))
                tekstranslate = LanguageOtong.instance.bahasaID[indexCari];
            else if (namanpc.Equals("motorkopi"))
                tekstranslate = LanguageMotorKopi.instance.bahasaID[indexCari];
            else if (namanpc.Equals("Anggun"))
                tekstranslate = LanguageAnggun.instance.bahasaID[indexCari];
            else if (namanpc.Equals("Windi"))
                tekstranslate = LanguageWindi.instance.bahasaID[indexCari];
            else if (namanpc.Equals("Emon"))
                tekstranslate = LanguageEmon.instance.bahasaID[indexCari];
            else if (namanpc.Equals("Mini"))
                tekstranslate = LanguageMini.instance.bahasaID[indexCari];
        }
        else if (PlayerPrefs.GetString("bahasa") == "Inggris")
        {
            if (namanpc.Equals("Mika"))
                tekstranslate = LanguageMika.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("Samsul"))
                tekstranslate = LanguageSamsul.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("Afifah"))
                tekstranslate = LanguageAfifah.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("Otong"))
                tekstranslate = LanguageOtong.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("motorkopi"))
                tekstranslate = LanguageMotorKopi.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("Anggun"))
                tekstranslate = LanguageAnggun.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("Windi"))
                tekstranslate = LanguageWindi.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("Emon"))
                tekstranslate = LanguageEmon.instance.bahasaUS[indexCari];
            else if (namanpc.Equals("Mini"))
                tekstranslate = LanguageMini.instance.bahasaUS[indexCari];
        }
        else if (PlayerPrefs.GetString("bahasa") == "Jepang")
        {
            if (namanpc.Equals("Mika"))
                tekstranslate = LanguageMika.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("Samsul"))
                tekstranslate = LanguageSamsul.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("Afifah"))
                tekstranslate = LanguageAfifah.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("Otong"))
                tekstranslate = LanguageOtong.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("motorkopi"))
                tekstranslate = LanguageMotorKopi.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("Anggun"))
                tekstranslate = LanguageAnggun.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("Windi"))
                tekstranslate = LanguageWindi.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("Emon"))
                tekstranslate = LanguageEmon.instance.bahasaJP[indexCari];
            else if (namanpc.Equals("Mini"))
                tekstranslate = LanguageMini.instance.bahasaJP[indexCari];
        }
        return tekstranslate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

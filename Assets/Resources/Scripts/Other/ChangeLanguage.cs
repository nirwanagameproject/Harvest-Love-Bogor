using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
    public int indexText;
    public string textTranslate;
    // Start is called before the first frame update
    void Start()
    {
        ChangedLanguge();
    }

    public void ChangedLanguge()
    {
        if (PlayerPrefs.GetString("bahasa") == "Indonesia")
        {
            GetComponent<Text>().text = Language.instance.bahasaID[indexText];
        }
        else if (PlayerPrefs.GetString("bahasa") == "Inggris")
        {
            GetComponent<Text>().text = Language.instance.bahasaUS[indexText];
            
        }
        else if (PlayerPrefs.GetString("bahasa") == "Jepang")
        {
            GetComponent<Text>().text = Language.instance.bahasaJP[indexText];
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

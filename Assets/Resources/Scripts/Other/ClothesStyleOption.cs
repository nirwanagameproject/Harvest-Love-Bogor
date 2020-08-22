using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesStyleOption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dropdown dropdown = GetComponent<Dropdown>();

        //Baju1
        string teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(54);
        dropdown.options[0].text = teks;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

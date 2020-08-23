using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairStyleOption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dropdown dropdown = GetComponent<Dropdown>();

        //Rambut1
        string teks = dropdown.transform.Find("Label").gameObject.GetComponent<ChangeLanguage>().GetLanguage(51);
        dropdown.options[0].text = teks;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

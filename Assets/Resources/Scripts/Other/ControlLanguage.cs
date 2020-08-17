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

    // Update is called once per frame
    void Update()
    {
        
    }
}

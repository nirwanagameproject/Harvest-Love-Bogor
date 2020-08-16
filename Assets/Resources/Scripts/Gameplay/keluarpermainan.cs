using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keluarpermainan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void keluargame()
    {
        PlayerPrefs.SetString("level", "MenuAwal");
        PlayerPrefs.SetString("masuk", "");
        GameObject.Find("Gamesetup").GetComponent<Gamesetupcontroller>().transisi.SetActive(true);
    }
}

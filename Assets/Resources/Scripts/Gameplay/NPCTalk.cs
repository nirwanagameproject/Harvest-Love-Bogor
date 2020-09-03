using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class NPCTalk : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Gajadi()
    {
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(true);

        Camera.main.fieldOfView += 20;

        GameObject.Find("Canvas").transform.Find("DialogName").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan();
    }

}

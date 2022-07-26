using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class forbiddenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(GameObject.Find("gate").transform.GetChild(0).GetChild(0).GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(GameObject.Find("gate").transform.GetChild(0).GetChild(1).GetComponent<Collider>(), GetComponent<Collider>());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            if (collision.collider.GetComponent<PhotonView>() != null && PhotonNetwork.IsConnected)
            {
                if (!collision.collider.GetComponent<PhotonView>().IsMine)
                {
                    return;
                }
                else
                {
                    collision.collider.transform.position = GameObject.Find("SpawnSchool").transform.position;
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = true;
                    GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/Otong");
                    GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("NamaNPC").GetComponent<Text>().text = "Otong";

                    GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();

                    GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(false);

                    GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(2, "Otong"), false);
                    GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                    if(GameObject.Find("AISpawn").transform.Find("Otong").GetComponent<NPC>().level=="Perkampungan_1")
                    {
                        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
                    }else GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(false);
                    StartCoroutine(tutupDialogForbidden());
                }
            }
            Debug.Log("FORBIDDEN DOOR: "+collision.collider.name);

        }
    }

    IEnumerator tutupDialogForbidden()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
    }
}

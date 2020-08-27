using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public string level;
    public string respawn;
    public bool pintu;
    public GameObject transisi;
    // Start is called before the first frame update
    void Start()
    {
        transisi = GameObject.Find("Canvas").transform.Find("Transisi").gameObject;
        PlayerPrefs.DeleteKey("masuk");
        Debug.Log("masuk " + level);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetString("level") == level && transisi.activeSelf && (int)(255 * transisi.GetComponent<Image>().color.a) < 255 && PlayerPrefs.HasKey("masuk"))
        {
            if ((int)(255 * transisi.GetComponent<Image>().color.a) >= 240)
            {
                //transisi.SetActive(false);
                
                PlayerPrefs.DeleteKey("masuk");
                AudioSource audio = GameObject.Find("Clicked").transform.Find("closedoor").GetComponent<AudioSource>();
                Debug.Log(pintu);
                if (!audio.isPlaying && PlayerPrefs.GetString("level") != "MenuAwal" && pintu) audio.Play();
                SceneManager.LoadSceneAsync("LoadingScreen");
            }
            else
            {
                int myalpha = (int)(255 * transisi.GetComponent<Image>().color.a) + 10;
                transisi.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)myalpha);
            }
        }
    }

    public void DestroyAllGameObjects()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            Destroy(GameObjects[i]);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            GC.Collect();
            Gamesetupcontroller.instance.HapusObjek(collision.collider.gameObject.name);
            if (collision.collider.GetComponent<PhotonView>() != null && PhotonNetwork.IsConnected)
            {
                if (!collision.collider.GetComponent<PhotonView>().IsMine)
                {
                    return;
                }
                else
                {
                    PhotonNetwork.Destroy(collision.collider.GetComponent<PhotonView>());
                    Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("pindahlevel", RpcTarget.Others, collision.collider.name,level);
                }
            }
            if (!PhotonNetwork.IsConnected) Destroy(collision.collider.gameObject);
            transisi.SetActive(true);
            collision.collider.gameObject.SetActive(false);
            AudioSource audio = GameObject.Find("Clicked").transform.Find("opendoor").GetComponent<AudioSource>();
            if (!audio.isPlaying && PlayerPrefs.GetString("level") != "MenuAwal" && pintu) audio.Play();
            PlayerPrefs.SetString("level", level);
            PlayerPrefs.SetString("respawn", respawn);
            ExitGames.Client.Photon.Hashtable setlevel = new ExitGames.Client.Photon.Hashtable();
            setlevel.Add("setlevel", level);
            PhotonNetwork.SetPlayerCustomProperties(setlevel);
            PlayerPrefs.SetString("masuk", "");
            Debug.Log("masuk");
        }
    }
}

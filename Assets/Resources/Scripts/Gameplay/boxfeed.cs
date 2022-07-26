using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class boxfeed : MonoBehaviour
{
    public bool terisi;
    public GameObject makanan; 
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties[name] != null)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() != "")
            {
                Debug.Log("NAMA FEED: "+ PhotonNetwork.CurrentRoom.CustomProperties[name].ToString());
                terisi = true;
                makanan = GameObject.Find("ItemSpawn").transform.Find(PhotonNetwork.CurrentRoom.CustomProperties[name].ToString()).gameObject;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties[name] != null)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() != "")
            {
                if (makanan != null)
                {
                    float jarak = Vector3.Distance(makanan.transform.position,transform.position);
                    if (jarak > 0.5f)
                    {
                        Debug.Log("BOX KELUAR1: " + name);
                        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
                        custom.Add(name, "");
                        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                        terisi = false;
                        makanan = null;
                    }
                }
                
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag.Equals("Buah") && collision.collider.name.Contains("Feed"))
        {
            if (collision.collider.GetComponent<PhotonView>() != null)
            {
                if (!collision.collider.GetComponent<PhotonView>().IsMine)
                {
                    return;
                }
                else
                {
                    if (PhotonNetwork.CurrentRoom.CustomProperties[name] != null)
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties[name].ToString()=="")
                        {
                            Debug.Log("BOX TERISI: "+name);
                            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
                            custom.Add(name, collision.collider.name);
                            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
                            terisi = true;
                            makanan = GameObject.Find("ItemSpawn").transform.Find(collision.collider.name).gameObject;
                        }
                    }
                }
            }
        }
    }
}

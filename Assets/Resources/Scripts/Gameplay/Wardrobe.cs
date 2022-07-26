using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Wardrobe : MonoBehaviour
{
    public GameObject cubeaction;
    public string level;
    bool munculcubeaction = false;
    bool enterPlayer = false;
    Collider[] mycolliderPlayer;

    // Start is called before the first frame update
    void Start()
    {

        
            
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {

        mycolliderPlayer = Physics.OverlapSphere(transform.position, 0.5f, LayerMask.GetMask("Player"));

        for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PlayerPrefs.GetString("myname") + ")") { enterPlayer = true; break; }

        if (enterPlayer && PhotonNetwork.CurrentRoom.CustomProperties["wardrobe"].Equals(""))
        {
            for (int k = 0; k < mycolliderPlayer.Length; k++)
            {
                if (mycolliderPlayer[k].GetComponent<PhotonView>().IsMine)
                {
                    if (cubeaction == null)
                        cubeaction = CariGameObject.FindInActiveObjectByName("CubeAction");
                    cubeaction.SetActive(true);
                    cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                    munculcubeaction = true;
                    PlayerPrefs.SetString("buttonChangeClothes", name);
                }
            }
        }
        else if (munculcubeaction)
        {
            cubeaction.SetActive(false);
            munculcubeaction = false;
            PlayerPrefs.DeleteKey("buttonChangeClothes");
        }
        else if(PhotonNetwork.LocalPlayer.NickName==PhotonNetwork.CurrentRoom.CustomProperties["wardrobe"].ToString())
        {
            mycolliderPlayer = Physics.OverlapSphere(transform.position, 0.5f, LayerMask.GetMask("Player"));
            for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PhotonNetwork.CurrentRoom.CustomProperties["wardrobe"] + ")") { enterPlayer = true; break; }
            if (!enterPlayer)
            {
                GameObject.Find("CanvasHome").transform.Find("Dandan").Find("PilihKoleksi").GetComponent<koleksi>().TutupWardrobe();
            }
        }
        enterPlayer = false;

        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Barrel : MonoBehaviour
{
    bool munculcubeaction = false;
    bool enterPlayer = false;
    public GameObject cubeaction;
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
        mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));

        for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PlayerPrefs.GetString("myname") + ")") { enterPlayer = true; break; }

        if (enterPlayer && PlayerPrefs.GetString("kantongnama0") == "" && PlayerPrefs.GetString("buttonPickUpItem") == "")
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
                    PlayerPrefs.SetString("buttonChickenFeed", name);
                }
            }
        }
        else if (munculcubeaction)
        {
            cubeaction.SetActive(false);
            munculcubeaction = false;
            PlayerPrefs.DeleteKey("buttonChickenFeed");
        }

        enterPlayer = false;        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Barrel : MonoBehaviour
{
    public int cek;
    public GameObject cubeaction;
    
    // Start is called before the first frame update
    void Start()
    {
        cek = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {

        Collider[] mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));
        bool enterPlayer = mycolliderPlayer.Length != 0;

        if (enterPlayer)
        {
            for (int i = 0; i < mycolliderPlayer.Length; i++)
            {
                if (mycolliderPlayer[i].GetComponent<PhotonView>().IsMine)
                {
                    if (!PlayerPrefs.HasKey("buttonChickenFeed"))
                    {
                        cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                        cubeaction.SetActive(true);
                    }
                    PlayerPrefs.SetString("buttonChickenFeed", name);
                        
                    break;
                }
                else
                {
                    if (PlayerPrefs.HasKey("buttonChickenFeed") && i == mycolliderPlayer.Length-1)
                    {
                        cubeaction.SetActive(false);
                        PlayerPrefs.DeleteKey("buttonChickenFeed");
                    }
                }
            }
        }
        else
        if (!enterPlayer)
            {
                cubeaction.SetActive(false);
                PlayerPrefs.DeleteKey("buttonChickenFeed");
            }
        
        
        

        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Wardrobe : MonoBehaviour
{
    public GameObject cubeaction;
    public string level;

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
        if (cubeaction != null)
        {
            Collider[] mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));
            bool enterPlayer = mycolliderPlayer.Length != 0;

            if (enterPlayer && (!PlayerPrefs.HasKey("buttonChangeClothes") || PlayerPrefs.GetString("buttonChangeClothes") ==name))
            {
                for (int i = 0; i < mycolliderPlayer.Length; i++)
                {
                    if (mycolliderPlayer[i].GetComponent<PhotonView>().IsMine)
                    {
                        if (!PlayerPrefs.HasKey("buttonChangeClothes"))
                        {
                            cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                            cubeaction.SetActive(true);
                        }
                        PlayerPrefs.SetString("buttonChangeClothes", name);

                        break;
                    }
                    else
                    {
                        if (PlayerPrefs.HasKey("buttonChangeClothes") && i == mycolliderPlayer.Length - 1)
                        {
                            cubeaction.SetActive(false);
                            PlayerPrefs.DeleteKey("buttonChangeClothes");
                        }
                    }
                }
                cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            }
            else
            if (!enterPlayer && PlayerPrefs.HasKey("buttonChangeClothes") && PlayerPrefs.GetString("buttonChangeClothes") ==name)
            {
                cubeaction.SetActive(false);
                PlayerPrefs.DeleteKey("buttonChangeClothes");
            }
        }

        

    }

}

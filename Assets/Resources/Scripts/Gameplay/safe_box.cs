using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class safe_box : MonoBehaviour
{
    public GameObject konfirmtidur;
    public GameObject konfirmsave;
    public GameObject transisi;
    public GameObject cubeaction;
    
    public string mysave;
    public string respawn;
    public int cek;

    // Start is called before the first frame update
    void Start()
    {
        cek = 1;
        transisi = GameObject.Find("Canvas").transform.Find("Transisi").gameObject;
        if(name=="Bed1")
        konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut").gameObject;
        else konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut2").gameObject;
        konfirmsave = GameObject.Find("CanvasHome").transform.Find("KonfirmasiSave").gameObject;
        PlayerPrefs.DeleteKey("tidur");
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerPrefs.HasKey("mautidur"))
        {
            Collider[] mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));
            bool enterPlayer = mycolliderPlayer.Length != 0;

            if (enterPlayer && (cek == 1 || cek==3))
            {
                for (int i = 0; i < mycolliderPlayer.Length; i++)
                {
                    if (!PhotonNetwork.IsConnected || mycolliderPlayer[i].GetComponent<PhotonView>().IsMine)
                    {
                        cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
                        cubeaction.SetActive(true);

                        PlayerPrefs.SetString("buttonSafeBox", konfirmtidur.name);
                        if (cek > 2) cek = 1;
                        else cek++;
                        /*konfirmtidur.SetActive(true);
                        mycolliderPlayer[i].GetComponent<Player1>().Inputs.JoystickX = 0;
                        mycolliderPlayer[i].GetComponent<Player1>().Inputs.JoystickZ = 0;
                        mycolliderPlayer[i].GetComponent<Player1>().Inputs.pmrPos = mycolliderPlayer[i].GetComponent<Player1>().transform.position;

                        mycolliderPlayer[i].GetComponent<Controller>().enabled = false;*/
                    }
                }
            }
            else
            if (!enterPlayer && cek == 3)
            {
                cubeaction.SetActive(false);
                PlayerPrefs.DeleteKey("buttonSafeBox");
                if (cek > 2) cek = 1;
                else cek++;
            }
            else
            if (!enterPlayer && cek == 2) cek = 3;
            else if (enterPlayer && cek == 3) cek = 1;
        }
        

    }

    public void ClickExit()
    {
        konfirmtidur.SetActive(false);
        GameObject.Find("CanvasHome").transform.Find("SaveGame").gameObject.SetActive(false);
        GameObject.Find("PlayerSpawn").transform.Find("Player ("+PlayerPrefs.GetString("myname")+")").GetComponent<Controller>().enabled = true;
    }


    public void ClickTampilinKonfirmTidur(string savestate)
    {

        konfirmsave.SetActive(true);
        

        PlayerPrefs.SetString("save",savestate);
        
    }
}

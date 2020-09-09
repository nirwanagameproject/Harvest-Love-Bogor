using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class NPC : MonoBehaviour
{
    public int cek;
    public GameObject cubeaction;
    public string level;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        cek = 1;
        anim = GetComponent<Animator>();

        
            
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.IsConnectedAndReady && PhotonNetwork.InRoom )
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.CustomProperties["Ayu"]==null)
        {
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add("Ayu", "pulang1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
        }
    }
    
    void FixedUpdate()
    {
        if (cubeaction != null)
        {
            Collider[] mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));
            bool enterPlayer = mycolliderPlayer.Length != 0;

            if (enterPlayer && (!PlayerPrefs.HasKey("buttonNPC") || PlayerPrefs.GetString("buttonNPC")==name))
            {
                for (int i = 0; i < mycolliderPlayer.Length; i++)
                {
                    if (mycolliderPlayer[i].GetComponent<PhotonView>().IsMine)
                    {
                        if (!PlayerPrefs.HasKey("buttonNPC"))
                        {
                            cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                            cubeaction.SetActive(true);
                        }
                        PlayerPrefs.SetString("buttonNPC", name);

                        break;
                    }
                    else
                    {
                        if (PlayerPrefs.HasKey("buttonNPC") && i == mycolliderPlayer.Length - 1)
                        {
                            cubeaction.SetActive(false);
                            PlayerPrefs.DeleteKey("buttonNPC");
                        }
                    }
                }
                cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
            }
            else
            if (!enterPlayer && PlayerPrefs.HasKey("buttonNPC") && PlayerPrefs.GetString("buttonNPC")==name)
            {
                cubeaction.SetActive(false);
                PlayerPrefs.DeleteKey("buttonNPC");
            }
        }

        if (name == "Ayu" && PhotonNetwork.IsMasterClient && PhotonNetwork.InRoom)
        {
            Vector3 pos = new Vector3();

            if (int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) >= 7)
            {
                pos.x = 56;
                pos.y = 0;
                pos.z = 57;

                if (Vector3.Distance(pos, transform.position) <= 0.1)
                {
                    GetComponent<Animator>().SetFloat("Speed", 0);
                    transform.position = pos;
                    ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
                    setTgl = new ExitGames.Client.Photon.Hashtable();
                    setTgl.Add("Ayu", "");
                    PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
                }
                else
                if (PhotonNetwork.CurrentRoom.CustomProperties["Ayu"].ToString() == "pulang1")
                {
                    float step = 1 * Time.deltaTime; // calculate distance to move
                    transform.position = Vector3.MoveTowards(transform.position, pos, step);
                    Vector3 direction = pos - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 3f);
                    GetComponent<Animator>().SetFloat("Speed", 0.5f);
                }
                
            }
        }
        

    }

}

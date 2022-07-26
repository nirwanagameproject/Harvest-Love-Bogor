using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class NPC : MonoBehaviour
{
    public GameObject cubeaction;
    public string level;
    private Animator anim;
    bool munculcubeaction = false;
    bool enterPlayer = false;
    public bool sedangditanya = false;
    Collider[] mycolliderPlayer;
    public Vector3 pos = new Vector3();
    Coroutine NPCcoroutine;
            
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (name == "Mika")StartCoroutine(LanguageMika.instance.NPCMikaJalan());
        if (name == "Samsul")StartCoroutine(LanguageSamsul.instance.NPCMikaJalan());
        if (name == "Afifah")StartCoroutine(LanguageAfifah.instance.NPCMikaJalan());
        if (name == "motorkopi")StartCoroutine(LanguageMotorKopi.instance.NPCMikaJalan());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        float jauhcube = 1f;
        float tinggicube = 2f;
        if (name == "Samsul")if(Vector3.Distance(transform.position, new Vector3(13.03f, 0, 1.63f)) < 1 && level=="MasukRumahSamsul") jauhcube = 3f;
        if (name == "motorkopi")jauhcube = 2.3f;
        mycolliderPlayer = Physics.OverlapSphere(transform.position, jauhcube, LayerMask.GetMask("Player"));

        for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PlayerPrefs.GetString("myname") + ")") { enterPlayer = true; break; }

        if (enterPlayer && PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC"+name].Equals(""))
        {
            
            for (int k = 0; k < mycolliderPlayer.Length; k++)
            {
                if (mycolliderPlayer[k].GetComponent<PhotonView>().IsMine)
                {
                    if (level == PlayerPrefs.GetString("level"))
                    {
                        if (cubeaction == null)
                            cubeaction = CariGameObject.FindInActiveObjectByName("CubeAction");
                        cubeaction.SetActive(true);
                        cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + tinggicube, transform.position.z);
                        munculcubeaction = true;
                        if(PlayerPrefs.GetString("buttonNPC")=="")
                        PlayerPrefs.SetString("buttonNPC", name);
                    }
                }
            }
        }
        else if (munculcubeaction)
        {
            cubeaction.SetActive(false);
            munculcubeaction = false;
            if (PhotonNetwork.CurrentRoom != null)
                if (PhotonNetwork.LocalPlayer.NickName != PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC" + name].ToString())
                    if (PlayerPrefs.GetString("buttonNPC") == name) PlayerPrefs.DeleteKey("buttonNPC");
        }
        else if (PhotonNetwork.CurrentRoom!=null)
        {
            if(PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC" + name]!=null)
            if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC" + name].ToString())
            {
                if (!enterPlayer)
                {
                    GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").GetComponent<NPCTalk>().Gajadi(name);
                }
            }
        }
        enterPlayer = false;

        //NPC MIKA
        if ((name == "motorkopi" || name == "Samsul" || name == "Mika" || name == "Afifah" || name == "Otong") && PhotonNetwork.IsMasterClient && PhotonNetwork.InRoom)
        {
            string namaNPC = name;
            if(pos!=null && PhotonNetwork.CurrentRoom.CustomProperties[namaNPC]!=null)
            jalanNPC(pos, namaNPC);
        }
    }

    

    void jalanNPC(Vector3 pos, string namaNPC)
    {  
        if(PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC" + namaNPC]!=null)
        if (PhotonNetwork.CurrentRoom.CustomProperties[namaNPC].ToString() == "jalan1" && Mathf.Abs(transform.position.x - pos.x) <= 0.1f && Mathf.Abs(transform.position.z - pos.z) <= 0.1f)
        {
            if(namaNPC!="motorkopi")GetComponent<Animator>().SetFloat("Speed", 0);
            transform.position = pos;
            if(PhotonNetwork.CurrentRoom.CustomProperties[namaNPC].ToString() != "")
            {
                ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
                setTgl.Add(namaNPC, "");
                PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
            }
            if (PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC" + namaNPC].ToString() != "" && !sedangditanya)
            {
                if(namaNPC!="motorkopi")GetComponent<Animator>().SetFloat("Speed", 0);
                sedangditanya = true;
                NPCcoroutine = StartCoroutine(timeoutNanya(5f, namaNPC));
            }
        }
        else if (PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC"+namaNPC].ToString() != "" && !sedangditanya)
        {
            if(namaNPC!="motorkopi")GetComponent<Animator>().SetFloat("Speed", 0);
            sedangditanya = true;
            NPCcoroutine = StartCoroutine(timeoutNanya(5f,namaNPC));
        }
        else 
        if (PhotonNetwork.CurrentRoom.CustomProperties[namaNPC].ToString() == "jalan1" && !sedangditanya)
        {
            int kecepatan = 1;
            if(namaNPC=="motorkopi") kecepatan = 2;
            float step = kecepatan * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, pos, step);
            Vector3 direction = pos - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 3f);
            if(namaNPC!="motorkopi")GetComponent<Animator>().SetFloat("Speed", 0.4f);
        }
    }

    IEnumerator timeoutNanya(float waktu,string namaNPC)
    {
        Debug.Log("TIMEOUT NANYA yg nanya: " + PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC" + namaNPC].ToString());
        yield return new WaitForSeconds(waktu);
        foreach (var player in PhotonNetwork.PlayerList)
        {
            for (int mulai = 0; mulai < GameObject.Find("PlayerSpawn").transform.childCount; mulai++)
            {
                if (PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPC" + namaNPC].ToString()==player.NickName)
                {
                    GetComponent<PhotonView>().RPC("tutupDialogTimeout", player);
                    break;
                }
            }
        }
        sedangditanya = false;
    }

    [PunRPC]
    void refreshTiemout(float waktu, string namaNPC, bool lanjut)
    {
        if(NPCcoroutine!=null)StopCoroutine(NPCcoroutine);
        if (lanjut) NPCcoroutine = StartCoroutine(timeoutNanya(waktu, namaNPC));
        else sedangditanya = false;
    }

    [PunRPC]
    void tutupDialogTimeout()
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").GetComponent<NPCTalk>().Gajadi(name);
    }

    [PunRPC]
    void gantiLevel(string newlevel)
    {
        level = newlevel;
    }

    [PunRPC]
    void melihatYgNanya(string namaNPC, string namaPlayer)
    {
        GameObject.Find(namaNPC).transform.LookAt(GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaPlayer + ")").transform);
        GameObject.Find(namaNPC).transform.eulerAngles = new Vector3(0, GameObject.Find(namaNPC).transform.eulerAngles.y, 0);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaPlayer + ")").transform.LookAt(GameObject.Find(namaNPC).transform);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaPlayer + ")").transform.eulerAngles = new Vector3(0, GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaPlayer + ")").transform.eulerAngles.y, 0);
    }

}

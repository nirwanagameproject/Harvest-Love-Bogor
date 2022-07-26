using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buah : MonoBehaviour
{
    public string level;
    public bool destroying;
    public bool picked;
    bool munculcubeaction = false;
    bool enterPlayer = false;
    public GameObject cubeaction;
    Collider[] mycolliderPlayer;

    void Awake()
    {
        if(tag=="Buah")
        transform.parent = GameObject.Find("ItemSpawn").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        cubeaction = CariGameObject.FindInActiveObjectByName("CubeAction");
        ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
        setValue.Add("ItemCount", (int)PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"] + 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mycolliderPlayer = Physics.OverlapSphere(transform.position, 0.5f, LayerMask.GetMask("Player"));
       
        for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PlayerPrefs.GetString("myname") + ")") { enterPlayer = true; break; }

        if (enterPlayer && !picked && PlayerPrefs.GetString("kantongnama0") == "" && PlayerPrefs.GetString("level") == GetComponent<Buah>().level)
        {
            for (int k = 0; k < mycolliderPlayer.Length; k++)
            {
                if (!PhotonNetwork.IsConnected || mycolliderPlayer[k].GetComponent<PhotonView>().IsMine)
                {
                    if(cubeaction==null)
                    cubeaction = CariGameObject.FindInActiveObjectByName("CubeAction");
                    cubeaction.SetActive(true);
                    cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    munculcubeaction = true;
                    PlayerPrefs.SetString("buttonPickUpItem", name);
                }
            }
        }
        else if(munculcubeaction)
        {
            cubeaction.SetActive(false);
            munculcubeaction = false;
            PlayerPrefs.DeleteKey("buttonPickUpItem");
        }
        
        if (GetComponent<PhotonView>().IsMine && GetComponent<Rigidbody>().isKinematic == false && !destroying)
        {
            //Invoke("destroyself",5f);
            destroying = true;
        }

        enterPlayer = false;

        if (PlayerPrefs.GetString("level") == GetComponent<Buah>().level)
        {
            /*if(GameObject.Find("Terrain")!=null)
            if(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")")!=null)
            if(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").gameObject.activeInHierarchy)
            GetComponent<Rigidbody>().useGravity = true;*/
        }
        else
        {
            foreach (var player in PhotonNetwork.PlayerList)
            {
                for (int mulai = 0; mulai < GameObject.Find("PlayerSpawn").transform.childCount; mulai++)
                {
                    if (GameObject.Find("PlayerSpawn").transform.GetChild(mulai).name.Equals("Player (" + player.NickName + ")") &&
                        GameObject.Find("PlayerSpawn").transform.GetChild(mulai).GetComponent<Player1>().level == GetComponent<Buah>().level)
                    {
                        if(GetComponent<PhotonView>().Owner.NickName!= player.NickName)
                        GetComponent<PhotonView>().TransferOwnership(player);
                        break;
                    }
                }
            }
            if (GetComponent<Rigidbody>().useGravity == true)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Collider>().isTrigger = true;
            } 
        }
    }

    void destroyself()
    {
        string[] splitString = name.Split(new string[] { "tomat" }, System.StringSplitOptions.None);
        int bbale = System.Convert.ToInt32(splitString[1]);

        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("deleteBale", RpcTarget.All, bbale);

        ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
        setValue.Add("ItemCount", (int)PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"] - 1);
        PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);

        
        PhotonNetwork.Destroy(gameObject);
    }
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buah : MonoBehaviour
{
    public string level;
    public bool destroying;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<PhotonView>().IsMine && GetComponent<Rigidbody>().isKinematic == false && !destroying)
        {
            Invoke("destroyself",5f);
            destroying = true;
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

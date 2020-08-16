using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bale : MonoBehaviour
{
    public string level;
    public bool destroying;
    public int cek;
    public int drop;
    public bool feed;
    public GameObject cubeaction;
    Collider[] mycolliderPlayer;
    // Start is called before the first frame update
    void Start()
    {
        feed = true;
        drop = 0;
        cek = 1;
        cubeaction = GameObject.Find("CubeAction");
        PlayerPrefs.DeleteKey("buttonPickBale");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (feed)
        {
            if (drop == 1)
            {
                for (int i = 0; i < transform.Find("modelbale").childCount; i++)
                {
                    mycolliderPlayer = Physics.OverlapSphere(transform.Find("modelbale").GetChild(i).position, 1f, LayerMask.GetMask("Player"));
                    bool enterPlayer = mycolliderPlayer.Length != 0;

                    if (enterPlayer && (cek == 1 || cek == 3))
                    {
                        for (int k = 0; k < mycolliderPlayer.Length; k++)
                        {
                            if (!PhotonNetwork.IsConnected || mycolliderPlayer[k].GetComponent<PhotonView>().IsMine)
                            {
                                cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                                cubeaction.SetActive(true);

                                PlayerPrefs.SetString("buttonPickBale", name);
                                if (cek > 2) cek = 1;
                                else cek++;

                            }
                        }
                    }
                    else
                    if (!enterPlayer && cek == 3)
                    {
                        cubeaction.SetActive(false);
                        PlayerPrefs.DeleteKey("buttonPickBale");
                        if (cek > 2) cek = 1;
                        else cek++;
                    }
                    else
                    if (!enterPlayer && cek == 2) cek = 3;
                    else if (enterPlayer && cek == 3) cek = 1;
                }
            }
            if (GetComponent<PhotonView>().IsMine && GetComponent<Rigidbody>().isKinematic == false && !destroying)
            {
                Invoke("destroyself", 5f);
                destroying = true;
            }

            if (GetComponent<Rigidbody>().isKinematic == false)
                for (int i = 0; i < transform.Find("modelbale").childCount; i++)
                {
                    mycolliderPlayer = Physics.OverlapSphere(transform.Find("modelbale").GetChild(i).position, 0.3f, LayerMask.GetMask("chickenbox"));
                    bool enterPlayer = mycolliderPlayer.Length != 0;

                    if (enterPlayer)
                    {

                        CancelInvoke("destroyself");
                        if ((System.Convert.ToBoolean(PhotonNetwork.CurrentRoom.CustomProperties[mycolliderPlayer[0].name]) == false))
                        {
                            GetComponent<Rigidbody>().isKinematic = true;
                            transform.position = mycolliderPlayer[0].transform.position;
                            //transform.parent = mycolliderPlayer[0].transform;
                            transform.eulerAngles = new Vector3(90, 0, 90);
                            //transform.name = "Item";

                            ExitGames.Client.Photon.Hashtable setMakanan = new ExitGames.Client.Photon.Hashtable();
                            setMakanan.Add(mycolliderPlayer[0].name, true);
                            PhotonNetwork.CurrentRoom.SetCustomProperties(setMakanan);
                            Debug.Log(mycolliderPlayer[0].name);

                            i = transform.Find("modelbale").childCount;
                            if (PlayerPrefs.GetString("buttonPickBale") == name)
                            {
                                PlayerPrefs.DeleteKey("buttonPickBale");
                            }
                            feed = false;
                        }
                    }
                }
        }
    }

    void destroyself()
    {
        string[] splitString = name.Split(new string[] { "bale" }, System.StringSplitOptions.None);
        int bbale = System.Convert.ToInt32(splitString[1]);

        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("deleteBale", RpcTarget.All, bbale);

        ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
        setValue.Add("ItemCount", (int)PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"] - 1);
        PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);

        PhotonNetwork.Destroy(gameObject);
    }
}

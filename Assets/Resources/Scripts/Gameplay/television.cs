using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.Video;

public class television : MonoBehaviour
{
    public GameObject cubeaction;
    public string level;
    bool munculcubeaction = false;
    bool enterPlayer = false;
    Collider[] mycolliderPlayer;
    public int channel;
    public int maxchannel = 5;

    // Start is called before the first frame update
    void Start()
    {
        channel = (int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"];
        if (channel > 0 && (bool)PhotonNetwork.CurrentRoom.CustomProperties["nyalaTv"])
        {
            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"] == 3)
            {
                if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"])
                {
                    GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv32");
                }
                else if (!(bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"])
                {
                    GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv31");
                }
            }
            else
                GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv" + channel);
            GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));

        for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PlayerPrefs.GetString("myname") + ")") { enterPlayer = true; break; }

        if (enterPlayer && PhotonNetwork.CurrentRoom.CustomProperties["nanyaBarangtv"].Equals(""))
        {
            for (int k = 0; k < mycolliderPlayer.Length; k++)
            {
                if (mycolliderPlayer[k].GetComponent<PhotonView>().IsMine)
                {
                    if (cubeaction == null)
                        cubeaction = CariGameObject.FindInActiveObjectByName("CubeAction");
                    cubeaction.SetActive(true);
                    cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    munculcubeaction = true;
                    PlayerPrefs.SetString("buttonTV", name);
                }
            }
        }
        else if (munculcubeaction)
        {
            cubeaction.SetActive(false);
            munculcubeaction = false;
            PlayerPrefs.DeleteKey("buttonTV");
        }
        else if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.CurrentRoom.CustomProperties["nanyaBarangtv"].ToString())
        {
            mycolliderPlayer = Physics.OverlapSphere(transform.position, 0.5f, LayerMask.GetMask("Player"));
            for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PhotonNetwork.CurrentRoom.CustomProperties["nanyaBarangtv"] + ")") { enterPlayer = true; break; }
            if (!enterPlayer)
            {
                GameObject.Find("CanvasHome").transform.Find("Dandan").Find("PilihKoleksi").GetComponent<koleksi>().TutupWardrobe();
            }
        }
        enterPlayer = false;

    }

    [PunRPC]
    void turnOnTv(string namatv,string namaPlayer)
    {
        GameObject.Find("Barang").transform.Find("tv").Find("samsungtv").Find("Plane").GetComponent<MeshRenderer>().material = Resources.Load("Model/Rumah/Material/VideoMaterial", typeof(Material)) as Material;
        if ((int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"] == 3)
        {
            if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"])
            {
                GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv32");
            }
            else if (!(bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"])
            {
                GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv31");
            }
        }
        else
            GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv" + channel);
        GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().Play();
    }

    [PunRPC]
    void setTvChannel(string namatv, string namaPlayer)
    {
        Debug.Log("PINDAH NEXT CHANNEL");
        if (!(bool)PhotonNetwork.CurrentRoom.CustomProperties["nyalaTv"])
        {
            GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().Stop();
            GameObject.Find("Barang").transform.Find("tv").Find("samsungtv").Find("Plane").GetComponent<MeshRenderer>().material = Resources.Load("Model/Rumah/Material/tv0", typeof(Material)) as Material;
        }
        else
        {
            channel = (int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"];
            if ((int)PhotonNetwork.CurrentRoom.CustomProperties["channelTv"] == 3)
            {
                if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"])
                {
                    GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv32");
                }
                else if (!(bool)PhotonNetwork.CurrentRoom.CustomProperties["nextrain"])
                {
                    GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv31");
                }
            }else
            GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().clip = Resources.Load<VideoClip>("Model/Rumah/Material/tv" + channel);
            GameObject.Find("Barang").transform.Find("tv").Find("layar").GetComponent<VideoPlayer>().Play();
        }
        
    }

}

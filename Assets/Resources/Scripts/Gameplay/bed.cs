using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bed : MonoBehaviour
{
    public GameObject konfirmtidur;
    public GameObject konfirmsave;
    public GameObject transisi;
    public GameObject cubeaction;
    
    public string mysave;
    public string respawn;
    public int cek;

    public List<string> orangtidur;
    // Start is called before the first frame update
    void Start()
    {
        cek = 1;
        transisi = GameObject.Find("Canvas").transform.Find("Transisi").gameObject;
        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (name == "Bed1")
                    konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut").gameObject;
                else konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut2").gameObject;
            }
            else
            {
                if (name == "Bed1")
                    konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjutClient").gameObject;
                else konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjutClient2").gameObject;
            }
        }else
        {
            if (name == "Bed1")
                konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut").gameObject;
            else konfirmtidur = GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut2").gameObject;
        }
        
        if(name == "Bed1")
        konfirmsave = GameObject.Find("CanvasHome").transform.Find("KonfirmasiSave").gameObject;
        else konfirmsave = GameObject.Find("CanvasHome").transform.Find("KonfirmasiSave2").gameObject;
        PlayerPrefs.DeleteKey("tidur");
    }


    void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.collider.tag.Equals("Player"))
        {
            if (!PhotonNetwork.IsConnected || collision.collider.GetComponent<PhotonView>().IsMine && !PlayerPrefs.HasKey("mautidur"))
            {
                konfirmtidur.SetActive(true);
                collision.collider.GetComponent<Player1>().Inputs.JoystickX = 0;
                collision.collider.GetComponent<Player1>().Inputs.JoystickZ = 0;
                collision.collider.GetComponent<Player1>().Inputs.pmrPos = collision.collider.GetComponent<Player1>().transform.position;

                collision.collider.GetComponent<Controller>().enabled = false;
            }
            
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PlayerPrefs.HasKey("mautidur"))
        {

            Collider[] mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));
            bool enterPlayer = mycolliderPlayer.Length != 0;

            if (enterPlayer)
            {
                for (int i = 0; i < mycolliderPlayer.Length; i++)
                {
                    if (mycolliderPlayer[i].GetComponent<PhotonView>().IsMine)
                    {
                        if (!PlayerPrefs.HasKey("buttonTidur"))
                        {
                            cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                            cubeaction.SetActive(true);
                        }
                        PlayerPrefs.SetString("buttonTidur", konfirmtidur.name);

                        break;
                    }
                    else
                    {
                        if (PlayerPrefs.HasKey("buttonTidur") && i == mycolliderPlayer.Length - 1)
                        {
                            cubeaction.SetActive(false);
                            PlayerPrefs.DeleteKey("buttonTidur");
                        }
                    }
                }
            }
            else
            if (!enterPlayer)
            {
                cubeaction.SetActive(false);
                PlayerPrefs.DeleteKey("buttonTidur");
            }
        }
        

        if ((int)(255 * transisi.GetComponent<Image>().color.a) < 255 && PlayerPrefs.HasKey("tidur"))
        {
            konfirmtidur.SetActive(false);
            konfirmsave.SetActive(false);
            GameObject.Find("CanvasHome").transform.Find("SaveGame").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("Transisi").gameObject.SetActive(true);
            if ((int)(255 * transisi.GetComponent<Image>().color.a) >= 240)
            {
                //transisi.SetActive(false);
                Debug.Log("tidur");
                PlayerPrefs.SetString("level", "MasukRumah");
                if (PhotonNetwork.IsConnected && PlayerPrefs.HasKey("nosave") && !PlayerPrefs.HasKey("save"))
                {
                    if (PlayerPrefs.GetInt("tanggal") < 30)
                        PlayerPrefs.SetInt("tanggal", PlayerPrefs.GetInt("tanggal") + 1);
                    else
                    {
                        PlayerPrefs.SetInt("tanggal", 1);
                        if (PlayerPrefs.GetString("musim") == "Spring") { PlayerPrefs.SetString("musim", "Summer"); }
                        else if (PlayerPrefs.GetString("musim") == "Summer") { PlayerPrefs.SetString("musim", "Fall"); }
                        else if (PlayerPrefs.GetString("musim") == "Fall") { PlayerPrefs.SetString("musim", "Winter"); }
                        else if (PlayerPrefs.GetString("musim") == "Winter") { PlayerPrefs.SetString("musim", "Spring"); PlayerPrefs.SetInt("tahun", PlayerPrefs.GetInt("tahun") + 1); }
                    }
                    GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text ="06";
                    GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text ="00";

                    if (PhotonNetwork.IsMasterClient)
                    {
                        ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
                        setTgl.Add("tanggal", PlayerPrefs.GetInt("tanggal"));
                        setTgl.Add("tahun", PlayerPrefs.GetInt("tahun"));
                        setTgl.Add("musim", PlayerPrefs.GetString("musim"));
                        setTgl.Add("jam", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text);
                        setTgl.Add("detik", GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text);
                        PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
                    }
                    

                    PlayerPrefs.DeleteKey("nosave");
                }
                else
                
                    PlayerPrefs.SetString("respawn", respawn);
                PlayerPrefs.DeleteKey("tidur");
                PlayerPrefs.DeleteKey("mautidur");
                if(PlayerPrefs.HasKey("save")) PlayerPrefs.DeleteKey("save");
                SceneManager.LoadSceneAsync("LoadingScreen");
            }
            else
            {
                int myalpha = (int)(255 * transisi.GetComponent<Image>().color.a) + 10;
                transisi.GetComponent<Image>().color = new Color32(0, 0, 0, (byte)myalpha);
            }
        }
    }

    public void ClickNo()
    {
        if (PhotonNetwork.IsConnected)
        {
            konfirmtidur.SetActive(false);
            GameObject.Find("CanvasHome").transform.Find("SaveGame").gameObject.SetActive(false);
            GameObject.Find("CanvasHome").transform.Find("SaveGame2").gameObject.SetActive(false);
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Controller>().enabled = true;

        }
        else
        {
            konfirmtidur.SetActive(false);
            GameObject.Find("CanvasHome").transform.Find("SaveGame").gameObject.SetActive(false);
            GameObject.Find("CanvasHome").transform.Find("SaveGame2").gameObject.SetActive(false);
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Controller>().enabled = true;

        }
    }

    public void ClickYes()
    {
        //PlayerPrefs.SetString("tidur", "");
        
        //konfirmtidur.SetActive(false);
        if(name == "Bed1")
        GameObject.Find("CanvasHome").transform.Find("SaveGame").gameObject.SetActive(true);
        else GameObject.Find("CanvasHome").transform.Find("SaveGame2").gameObject.SetActive(true);

    }

    public void ClickYesNoSave()
    {
        if(PhotonNetwork.IsConnected)
            {
                
            if (orangtidur.Count < 2)
            {
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut").gameObject.SetActive(false);
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut2").gameObject.SetActive(false);
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjutClient").gameObject.SetActive(false);
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjutClient2").gameObject.SetActive(false);
                PlayerPrefs.SetString("mautidur","yes");

                int tempattidur=1;
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(name+"1") || PhotonNetwork.CurrentRoom.CustomProperties[name+1].ToString()=="")
                {
                    tempattidur = 1;
                    GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position = gameObject.transform.Find("tempatbobo1").position;
                }
                else if (!PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(name + "2") || PhotonNetwork.CurrentRoom.CustomProperties[name + 2].ToString() == "")
                {
                    tempattidur = 2;
                    GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position = gameObject.transform.Find("tempatbobo2").position;
                }
                //Debug.Log("nama bed "+name);
                Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("ngajakBobo", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName,name, tempattidur);
            }else
            {
                GameObject.Find("Canvas").transform.Find("TextNotif").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("TextNotif").GetComponent<Text>().text = "Kasur penuh";
            }

        }
        else
        {
            if (PlayerPrefs.GetInt("tanggal") < 30)
                PlayerPrefs.SetInt("tanggal", PlayerPrefs.GetInt("tanggal") + 1);
            else
            {
                PlayerPrefs.SetInt("tanggal", 1);
                if (PlayerPrefs.GetString("musim") == "Spring") { PlayerPrefs.SetString("musim", "Summer"); }
                else if (PlayerPrefs.GetString("musim") == "Summer") { PlayerPrefs.SetString("musim", "Fall"); }
                else if (PlayerPrefs.GetString("musim") == "Fall") { PlayerPrefs.SetString("musim", "Winter"); }
                else if (PlayerPrefs.GetString("musim") == "Winter") { PlayerPrefs.SetString("musim", "Spring"); PlayerPrefs.SetInt("tahun", PlayerPrefs.GetInt("tahun") + 1); }
            }
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextJam").GetComponent<Text>().text = "06";
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextDetik").GetComponent<Text>().text = "00";
            PlayerPrefs.SetString("tidur", "");
        }
    }

    public void ClickTampilinKonfirmTidur(string savestate)
    {

        konfirmsave.SetActive(true);
        

        PlayerPrefs.SetString("save",savestate);
        
    }


    public void ClickNoKonfirm()
    {
        //PlayerPrefs.SetString("tidur", "");
        PlayerPrefs.DeleteKey("save");

        konfirmsave.SetActive(false);


    }

    public void ClickYesKonfirm()
    {
        if (PhotonNetwork.IsConnected)
        {

            if (orangtidur.Count < 2)
            {
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut").gameObject.SetActive(false);
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut2").gameObject.SetActive(false);
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjutClient").gameObject.SetActive(false);
                GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjutClient2").gameObject.SetActive(false);
                PlayerPrefs.SetString("mautidur", "yes");

                int tempattidur = 1;
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(name + "1") || PhotonNetwork.CurrentRoom.CustomProperties[name + 1].ToString() == "")
                {
                    tempattidur = 1;
                    GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position = gameObject.transform.Find("tempatbobo1").position;
                }
                else if (!PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(name + "2") || PhotonNetwork.CurrentRoom.CustomProperties[name + 2].ToString() == "")
                {
                    tempattidur = 2;
                    GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.position = gameObject.transform.Find("tempatbobo2").position;
                }
                //Debug.Log("nama bed "+name);
                Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("ngajakBobo", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, name, tempattidur);
            }
            else
            {
                GameObject.Find("Canvas").transform.Find("TextNotif").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("TextNotif").GetComponent<Text>().text = "Kasur penuh";
            }

        }
        else
        {
            ExampleSaveCustom loadsave = new ExampleSaveCustom();
            loadsave.Save();

            konfirmtidur.SetActive(false);
            konfirmsave.SetActive(false);
        }
        

    }

    public void ClickBatalWaitingOtherPlayer()
    {
        konfirmsave.SetActive(false);
        GameObject.Find("CanvasHome").transform.Find("SaveGame").gameObject.SetActive(false);
        GameObject.Find("CanvasHome").transform.Find("SaveGame2").gameObject.SetActive(false);
        PlayerPrefs.DeleteKey("mautidur");
        PlayerPrefs.DeleteKey("save");
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Controller>().enabled = true;
        GameObject.Find("CanvasHome").transform.Find("KonfirmasiLanjut").gameObject.SetActive(false);
        if(name=="Bed1")
        GameObject.Find("CanvasHome").transform.Find("WaitingOtherPlayer").gameObject.SetActive(false);
        else GameObject.Find("CanvasHome").transform.Find("WaitingOtherPlayer2").gameObject.SetActive(false);
        int tempattidur = 0;
        for (int i = 0; i < orangtidur.Count; i++)
            if (orangtidur[i] == PlayerPrefs.GetString("myname")) tempattidur = i+1;
        Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("keluarBobo", RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, name, tempattidur);

    }
}

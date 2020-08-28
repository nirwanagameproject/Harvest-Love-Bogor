using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    public Player1 Player;
    public static int itemjatuh;
    // Start is called before the first frame update
    void Start()
    {
        itemjatuh = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickJump()
    {
        Controller.instance.jump = true;
    }

    public void clickAction()
    {
        if (PlayerPrefs.HasKey("buttonTidur"))
        {
            FindInActiveObjectByName(PlayerPrefs.GetString("buttonTidur")).SetActive(true);
        }
        else if (PlayerPrefs.HasKey("buttonSafeBox"))
        {
            AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
            audio.Play();

            GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru("Apa isi dalam kotak peralatan ?", false);
            GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("SafeBox").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("buttonMailbox"))
        {
            AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
            audio.Play();

            GameObject.Find("CanvasFarm").transform.Find("MyMail").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("buttonChickenFeed"))
        {
            if (PlayerPrefs.GetString("kantongnama0") == "")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
                audio.Play();

                PlayerPrefs.SetString("kantongnama0", "bale");
                PlayerPrefs.SetInt("kantongjumlah0", 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();

                GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Poultry", "Bale"), GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").rotation);
                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("level"));

            }
        }
        else if (PlayerPrefs.HasKey("buttonPickBale"))
        {
            if (PlayerPrefs.GetString("kantongnama0") == "")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
                audio.Play();

                PlayerPrefs.SetString("kantongnama0", "bale");
                PlayerPrefs.SetInt("kantongjumlah0", 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();

                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("pickBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("buttonPickBale"), PlayerPrefs.GetString("level"));

                ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
                setValue.Add("ItemCount", (int)PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"] - 1);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);
            }
        }
        else
        {
            if (PlayerPrefs.GetString("kantongnama0") == "bale")
            {
                ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
                setValue.Add("ItemCount", (int)PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"] + 1);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);

                string nama = PlayerPrefs.GetString("kantongnama0");
                PlayerPrefs.SetString("kantongnama0", "");
                PlayerPrefs.SetInt("kantongjumlah0", PlayerPrefs.GetInt("kantongjumlah0") - 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();

                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("dropBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", nama);

            }
        }
    }

    public void clickPacul()
    {
        if (PlayerPrefs.GetString("peralatannama0") != "")
            if (GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                Controller.instance.pacul = true;
                string action="";
                if (PlayerPrefs.GetString("peralatannama0") == "watering") action = "watering";
                if(PhotonNetwork.IsConnected)
                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("gunaintools",RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")",PlayerPrefs.GetString("peralatannama0"),action, PlayerPrefs.GetInt("peralatanjumlah0"));
                else
                {
                    AudioSource audio = GameObject.Find("Clicked").transform.Find(PlayerPrefs.GetString("peralatannama0") + "sound").GetComponent<AudioSource>();
                    audio.transform.position = Camera.main.transform.position;
                    audio.Play();
                }
            }
    }

    public void clickBag()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().StartCoroutine("intro1");
    }

    public void tutupBag()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        if(PlayerPrefs.HasKey("pindahinTools")) GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").GetChild(PlayerPrefs.GetInt("pindahinTools")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        if(PlayerPrefs.HasKey("pindahinKantong")) GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").Find("tools").GetChild(PlayerPrefs.GetInt("pindahinKantong")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        PlayerPrefs.DeleteKey("pindahinTools");
        PlayerPrefs.DeleteKey("pindahinKantong");

        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().buka = 3;
        AudioSource audio2 = GameObject.Find("TextDialogue").GetComponent<AudioSource>();
        audio2.Stop();
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan();
    }

    public void clickPengaturan()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("Pengaturan").gameObject.SetActive(true);
    }

    public void tutupPengaturan()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("Pengaturan").gameObject.SetActive(false);
    }

    public void clickExitGame()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("ConfirmQuitGame").gameObject.SetActive(true);
    }

    public void tutupExitGame()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("ConfirmQuitGame").gameObject.SetActive(false);
    }

    public void clickconfirmExitGame()
    {
        PlayerPrefs.SetString("level", "MenuAwal");
        PlayerPrefs.SetString("masuk", "");
        GameObject.Find("Gamesetup").GetComponent<Gamesetupcontroller>().transisi.SetActive(true);
    }
    

    public void tutupSafeBox()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        if (PlayerPrefs.HasKey("pindahinTools")) GameObject.Find("Canvas").transform.Find("SafeBox").Find("BGAtas").Find("tools").GetChild(PlayerPrefs.GetInt("pindahinTools")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        if (PlayerPrefs.HasKey("pindahinKantong")) GameObject.Find("Canvas").transform.Find("SafeBox").Find("BGBawah").Find("tools").GetChild(PlayerPrefs.GetInt("pindahinKantong")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        PlayerPrefs.DeleteKey("pindahinTools");
        PlayerPrefs.DeleteKey("pindahinKantong");

        GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("SafeBox").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().buka = 3;
        AudioSource audio2 = GameObject.Find("TextDialogue").GetComponent<AudioSource>();
        audio2.Stop();
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan();
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}

using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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
        Joystick joystick = GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<Joystick>();
        joystick.enabled = false;
        joystick.enabled = true;

        if (PlayerPrefs.HasKey("buttonTidur"))
        {
            FindInActiveObjectByName(PlayerPrefs.GetString("buttonTidur")).SetActive(true);
        }
        else if (PlayerPrefs.HasKey("buttonSafeBox"))
        {
            AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
            audio.Play();

            GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(ChangeLanguage.instance.GetLanguage(116), false);
            GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("Bag").Find("ButtonBack").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("SafeBox").gameObject.SetActive(true);
            string[] splitstring = GameObject.Find("Canvas").transform.Find("SafeBox").Find("BGBawah").Find("Text").GetComponent<Text>().text.Split('(');
            GameObject.Find("Canvas").transform.Find("SafeBox").Find("BGBawah").Find("Text").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(115) + " ("+ splitstring[1];
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("Text").Find("TextContinue").GetComponent<Text>().text = "";
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = true;

            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Language").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>() != null)
                    GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>().ChangedLanguge();
            }
        }
        else if (PlayerPrefs.HasKey("buttonMailbox"))
        {
            AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
            audio.Play();

            GameObject.Find("CanvasFarm").transform.Find("MyMail").gameObject.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("buttonNPC"))
        {
            TanyaNPC(PlayerPrefs.GetString("buttonNPC"));
            
            AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
            audio.Play();
        }
        else if (PlayerPrefs.HasKey("buttonTV"))
        {
            nontonTV(PlayerPrefs.GetString("buttonTV"));
            
            AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
            audio.Play();
        }
        else if (PlayerPrefs.HasKey("buttonChangeClothes"))
        {
            OpenWardrobe();

            AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
            audio.Play();
        }
        else if (PlayerPrefs.HasKey("buttonChickenFeed"))
        {
            if (PlayerPrefs.GetString("kantongnama0") == "" && (int)PhotonNetwork.CurrentRoom.CustomProperties[PlayerPrefs.GetString("buttonChickenFeed").Split('-')[1] + "Food"]>0)
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
                audio.Play();

                string[] splitnama = PlayerPrefs.GetString("buttonChickenFeed").Split('-');
                GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", "Feed"+splitnama[1]), GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").rotation);
                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("level"));

                PlayerPrefs.SetString("kantongnama0", "Feed" + splitnama[1]+"-"+item.GetPhotonView().ViewID);
                PlayerPrefs.SetInt("kantongjumlah0", 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();

                //SET JUMLAH PAKAN
                ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
                int jumlah = ((int)PhotonNetwork.CurrentRoom.CustomProperties[splitnama[1] + "Food"]) - 1;
                setValue.Add(splitnama[1] + "Food", jumlah);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);
                GameObject.Find("Barang").transform.Find("Pakan").Find("JumlahPakan").GetComponent<TextMesh>().text = PhotonNetwork.CurrentRoom.CustomProperties[splitnama[1] + "Food"].ToString();
            }
            else
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("ClickedWrong").GetComponent<AudioSource>();
                audio.Play();
            }
        }
        else if (PlayerPrefs.HasKey("buttonPickUpItem"))
        {
            if (PlayerPrefs.GetString("kantongnama0") == "")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
                audio.Play();

                PlayerPrefs.SetString("kantongnama0", PlayerPrefs.GetString("buttonPickUpItem"));
                PlayerPrefs.SetInt("kantongjumlah0", 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();

                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("pickItem", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("buttonPickUpItem"), PlayerPrefs.GetString("level"));

                ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
                setValue.Add("ItemCount", (int)PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"] - 1);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);
            }
        }
        else if (PlayerPrefs.HasKey("buttonMilking"))
        {
            if (PlayerPrefs.GetString("kantongnama0") == "")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("milking").GetComponent<AudioSource>();
                audio.Play();

                int mulai = 0;
                for(mulai = 0; mulai < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; mulai++)
                {
                    if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + mulai].ToString() == PlayerPrefs.GetString("buttonMilking"))
                        break;
                }
                string susu = "small";
                if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowHeart" + mulai] < 3)
                    susu = "small";
                else if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowHeart" + mulai] < 6)
                    susu = "medium";
                else if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowHeart" + mulai] <= 10)
                    susu = "large";

                string[] splitnama = PlayerPrefs.GetString("buttonMilking").Split('-');
                PlayerPrefs.SetString("kantongnama0", "milk" + splitnama[0] + susu);
                PlayerPrefs.SetInt("kantongjumlah0", 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();
                
                GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", "milk"+ splitnama[0] + susu), GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").rotation);
                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("level"));

                ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
                setValue.Add("CowMilk"+mulai, "");
                PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);
            }
        }
        else if (PlayerPrefs.HasKey("buttonPickUpHewan"))
        {
            if (PlayerPrefs.GetString("kantongnama0") == "")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
                audio.Play();

                PlayerPrefs.SetString("kantongnama0", PlayerPrefs.GetString("buttonPickUpHewan"));
                PlayerPrefs.SetInt("kantongjumlah0", 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();

                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("pickHewan", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("buttonPickUpHewan"), PlayerPrefs.GetString("level"));

            }
        }
        else if (PlayerPrefs.HasKey("buttonPickBale"))
        {
            if (PlayerPrefs.GetString("kantongnama0") == "")
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
                audio.Play();

                PlayerPrefs.SetString("kantongnama0", PlayerPrefs.GetString("buttonPickBale"));
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
            if (PlayerPrefs.GetString("kantongnama0") != "")
            {
                ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
                setValue.Add("ItemCount", (int)PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"] + 1);
                PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);

                string nama = PlayerPrefs.GetString("kantongnama0");
                PlayerPrefs.SetString("kantongnama0", "");
                PlayerPrefs.SetInt("kantongjumlah0", PlayerPrefs.GetInt("kantongjumlah0") - 1);
                GameObject.Find("Canvas").transform.Find("Bag").GetComponent<bag>().reloadBag();

                if(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").GetChild(0).GetComponent<Cat>()!=null) GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("dropHewan", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", nama);
                else GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("dropBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", nama);

            }
        }
    }

    public void clickPacul()
    {
        if (PlayerPrefs.GetString("peralatannama0") != "")
            if (GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                    Controller.instance.pacul = true;
                    string action = "";
                    if (PlayerPrefs.GetString("peralatannama0") == "watering") action = "watering";
                    if (PhotonNetwork.IsConnected)
                        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("gunaintools", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("peralatannama0"), action, PlayerPrefs.GetInt("peralatanjumlah0"));
                    else
                    {
                        if (PlayerPrefs.GetString("peralatannama0") == "watering" && PlayerPrefs.GetInt("peralatanjumlah0") == 0)
                        {

                        }
                        else
                        {
                            AudioSource audio = GameObject.Find("Clicked").transform.Find(PlayerPrefs.GetString("peralatannama0") + "sound").GetComponent<AudioSource>();
                            audio.transform.position = Camera.main.transform.position;
                            audio.Play();
                        }
                    }
          
            }
    }

    public void clickBag()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("Text").Find("TextContinue").GetComponent<Text>().text = "";
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = true;
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().StartCoroutine("intro1");

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Language").Length; i++)
        {
            if(GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>()!=null)
            GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>().ChangedLanguge();
        }
    }

    public void tutupBag()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        if(PlayerPrefs.HasKey("pindahinTools")) GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").GetChild(PlayerPrefs.GetInt("pindahinTools")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        if(PlayerPrefs.HasKey("pindahinKantong")) GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").Find("tools").GetChild(PlayerPrefs.GetInt("pindahinKantong")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        PlayerPrefs.DeleteKey("pindahinTools");
        PlayerPrefs.DeleteKey("pindahinKantong");

        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("Text").Find("TextContinue").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(0);
        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().buka = 3;
        AudioSource audio2 = GameObject.Find("TextDialogue").GetComponent<AudioSource>();
        audio2.Stop();
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan(false);
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

    public void clickProfileStats()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonFarm").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonNeighbor").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonCow").gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.Find("ProfileStatus").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").gameObject.SetActive(true);

        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonFarm").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonNeighbor").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonChicken").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonCow").GetComponent<Image>().color = new Color32(255, 226, 165, 255);

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Language").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>() != null)
                GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>().ChangedLanguge();
        }
    }

    public void clickProfileStatsPoultry()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("ProfileStatus").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonFarm").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonNeighbor").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonChicken").GetComponent<Image>().color = new Color32(188, 163, 112, 255); 
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonCow").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        
        for(int i=0;i< 20; i++)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i] != null)
            {
                if(PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString() != "")
                {
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(true);
                    //FOTO
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("Avatar").GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/Barang/" + PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString().Split('-')[0]);
                    //NAMA
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("Text").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["Chicken" + i].ToString().Split('-')[1];
                    //HEART
                    for (int j = 0; j < ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenHeart" + i] / 10); j++)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("heart").GetChild(j).gameObject.SetActive(true);
                    }
                    for (int j = ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenHeart" + i] / 10); j < 10; j++)
                    {
                        if (GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("heart").GetChild(j).gameObject.activeSelf)
                            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("heart").GetChild(j).gameObject.SetActive(false);
                    }
                    //SICK OR NO
                    if ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenSick" + i] <= 1)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().color = new Color32(71, 168, 58, 255);
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(147);
                    }
                    else if ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenSick" + i] == 2)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().color = new Color32(205, 136, 28, 255);
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(148);
                    }
                    else if ((int)PhotonNetwork.CurrentRoom.CustomProperties["ChickenSick" + i] == 3)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().color = Color.red;
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(149);
                    }
                }
                else GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);

            }
            else GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Language").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>() != null)
                GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>().ChangedLanguge();
        }
    }

    public void clickProfileStatsBarn()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("ProfileStatus").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonFarm").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonNeighbor").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonCow").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonChicken").GetComponent<Image>().color = new Color32(255, 226, 165, 255);

        for (int i = 0; i < 20; i++)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i] != null)
            {
                if(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString() != "")
                {
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(true);
                    //FOTO
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("Avatar").GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/Barang/" + PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString().Split('-')[0]);
                    //NAMA
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("Text").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString().Split('-')[1];
                    //HEART
                    for (int j = 0; j < ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowHeart" + i] / 10); j++)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("heart").GetChild(j).gameObject.SetActive(true);
                    }
                    for (int j = ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowHeart" + i] / 10); j < 10; j++)
                    {
                        if (GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("heart").GetChild(j).gameObject.activeSelf)
                            GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("heart").GetChild(j).gameObject.SetActive(false);
                    }
                    //SICK OR NO
                    if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowSick" + i] <= 1)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().color = new Color32(71, 168, 58, 255);
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(147);
                    }
                    else if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowSick" + i] == 2)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().color = new Color32(205, 136, 28, 255);
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(148);
                    }
                    else if ((int)PhotonNetwork.CurrentRoom.CustomProperties["CowSick" + i] == 3)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().color = Color.red;
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).Find("health").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(149);
                    }
                }
                else GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);

            }
            else GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Language").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>() != null)
                GameObject.FindGameObjectsWithTag("Language")[i].GetComponent<ChangeLanguage>().ChangedLanguge();
        }
    }

    public void clickProfileStatsNeighbor()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();

        GameObject.Find("Canvas").transform.Find("ProfileStatus").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewBarn").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("Scroll View Farm").gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonFarm").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonCow").GetComponent<Image>().color = new Color32(255, 226, 165, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonNeighbor").GetComponent<Image>().color = new Color32(188, 163, 112, 255);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonChicken").GetComponent<Image>().color = new Color32(255, 226, 165, 255);

    }

    public void clickProfileNPC(string namaNPC)
    {
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").GetChild(0).GetChild(0).Find(namaNPC).GetComponent<Image>().color = new Color32(188, 219, 219, 255);
        for(int i=1;i< GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").GetChild(0).GetChild(0).childCount; i++)
        {
            if(GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").GetChild(0).GetChild(0).GetChild(i).name!=namaNPC)
                GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").GetChild(0).GetChild(0).GetChild(i).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        }
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").GetChild(0).GetChild(0).GetChild(0).Find("Avatar").GetComponent<RawImage>().texture = Resources.Load<Texture>("Images/Avatar/" + namaNPC);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").GetChild(0).GetChild(0).GetChild(0).Find("Text").GetComponent<Text>().text = namaNPC;
        string deskripsiteks = "";
        if (namaNPC == "Mika") deskripsiteks = ChangeLanguage.instance.GetLanguage(150);
        else if (namaNPC == "Ayu") deskripsiteks = ChangeLanguage.instance.GetLanguage(151);
        else if (namaNPC == "Samsul") deskripsiteks = ChangeLanguage.instance.GetLanguage(152);
        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewNeighbor").GetChild(0).GetChild(0).GetChild(0).Find("DeskripsiText").GetComponent<Text>().text = deskripsiteks;
    }

    public void tutupProfileStats()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        if(PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPCMini"].ToString()==PhotonNetwork.LocalPlayer.NickName ||
            PhotonNetwork.CurrentRoom.CustomProperties["nanyaNPCSamsul"].ToString() == PhotonNetwork.LocalPlayer.NickName)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").GetComponent<NPCTalk>().Gajadi(name);
            for (int i = 0; i < GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).childCount; i++)
            {
                GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("Accept").gameObject.SetActive(false);
            }
        }
        GameObject.Find("Canvas").transform.Find("ProfileStatus").gameObject.SetActive(false);
    }


    public void tutupSafeBox()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("closemenu").GetComponent<AudioSource>();
        audio.Play();

        if (PlayerPrefs.HasKey("pindahinTools"))
        {
            for (int i = 0; i < GameObject.Find("Canvas").transform.Find("SafeBox").Find("BGBawah").Find("tools").childCount; i++) GameObject.Find("Canvas").transform.Find("SafeBox").Find("BGBawah").Find("tools").GetChild(i).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
            for (int i = 0; i < GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").childCount; i++) GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").GetChild(i).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        }
        if (PlayerPrefs.HasKey("pindahinKantong")) GameObject.Find("Bag").transform.Find("SafeBox").Find("BGAtas").Find("tools").GetChild(PlayerPrefs.GetInt("pindahinKantong")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
        PlayerPrefs.DeleteKey("pindahinTools");
        PlayerPrefs.DeleteKey("pindahinKantong");

        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("Text").Find("TextContinue").GetComponent<Text>().text = ChangeLanguage.instance.GetLanguage(0);
        GameObject.Find("Canvas").transform.Find("Bag").Find("BGBawah").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bag").Find("ButtonBack").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Bag").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("SafeBox").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().buka = 3;
        AudioSource audio2 = GameObject.Find("TextDialogue").GetComponent<AudioSource>();
        audio2.Stop();
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan(false);
    }

    void TanyaNPC(string namaNPC)
    {
        Gamesetupcontroller.instance.minFoV = true;
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();

        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(false);
        

        GameObject.Find(namaNPC).GetComponent<PhotonView>().RPC("melihatYgNanya", RpcTarget.All, namaNPC, PhotonNetwork.NickName);

        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + PlayerPrefs.GetString("buttonNPC"));
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("NamaNPC").GetComponent<Text>().text = PlayerPrefs.GetString("buttonNPC");
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("ButtonTurnOff").gameObject.SetActive(false);
        if (namaNPC == "Mika") LanguageMika.instance.StartCoroutine(LanguageMika.instance.nanyaFriendship());
        if (namaNPC == "Samsul") LanguageSamsul.instance.StartCoroutine(LanguageSamsul.instance.nanyaFriendship());
        if (namaNPC == "Afifah") LanguageAfifah.instance.StartCoroutine(LanguageAfifah.instance.nanyaFriendship());
        if (namaNPC == "Otong") LanguageOtong.instance.StartCoroutine(LanguageOtong.instance.nanyaFriendship());
        if (namaNPC == "motorkopi") LanguageOtong.instance.StartCoroutine(LanguageMotorKopi.instance.nanyaFriendship());
        if (namaNPC == "Anggun") LanguageAnggun.instance.StartCoroutine(LanguageAnggun.instance.nanyaFriendship());
        if (namaNPC == "Windi") LanguageWindi.instance.StartCoroutine(LanguageWindi.instance.nanyaFriendship());
        if (namaNPC == "Emon") LanguageEmon.instance.StartCoroutine(LanguageEmon.instance.nanyaFriendship());
        if (namaNPC == "Mini") LanguageMini.instance.StartCoroutine(LanguageMini.instance.nanyaFriendship());

        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("nanyaNPC"+ namaNPC, PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
    }

    void nontonTV(string namatv)
    {
        Gamesetupcontroller.instance.minFoV = true;
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();

        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(false);

        
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("NamaNPC").GetComponent<Text>().text = "";
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(ChangeLanguage.instance.GetLanguage(126), true);

        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button1").Find("Text").GetComponent<Text>().text =
            ChangeLanguage.instance.GetLanguage(127);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button2").Find("Text").GetComponent<Text>().text =
            ChangeLanguage.instance.GetLanguage(128);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("ButtonTurnOff").gameObject.SetActive(true);

        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("nanyaBarangtv", PhotonNetwork.LocalPlayer.NickName);
        custom.Add("nyalaTv", true);
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);

        GameObject.Find("Barang").transform.Find(namatv).GetComponent<PhotonView>().RPC("turnOnTv", RpcTarget.All, namatv,PhotonNetwork.NickName);
    }

    void OpenWardrobe()
    {
        Gamesetupcontroller.instance.minFoVClothes = true;
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();

        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(false);

        GameObject.Find("CanvasHome").transform.Find("Dandan").gameObject.SetActive(true);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Karakter").gameObject.SetActive(true);
        GameObject.Find("CanvasHome").transform.Find("Dandan").Find("Aksesoris").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = true;

        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles = new Vector3(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.x,
            -90f,
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + PhotonNetwork.NickName + ")").transform.eulerAngles.z);

        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("wardrobe", PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
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

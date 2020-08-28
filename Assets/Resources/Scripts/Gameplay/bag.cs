using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bag : MonoBehaviour
{
    public List<Alltools> mybag;
    public GameObject peralatan;
    public GameObject barang;
    // Start is called before the first frame update
    void Awake()
    {
        peralatan = transform.Find("BGAtas").Find("tools").gameObject;
        barang = transform.Find("BGBawah").Find("tools").gameObject;

        if (PlayerPrefs.GetInt("levelbag") == 1)
        {
            mybag = new List<Alltools>(3);
            for(int i = 0; i < mybag.Capacity; i++)
            {
                peralatan.transform.GetChild(i).gameObject.SetActive(true);
                barang.transform.GetChild(i).gameObject.SetActive(true);
            }
        }else if (PlayerPrefs.GetInt("levelbag") == 2)
        {
            mybag = new List<Alltools>(6);
            for (int i = 0; i < mybag.Capacity; i++)
            {
                peralatan.transform.GetChild(i).gameObject.SetActive(true);
                barang.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("levelbag") == 3)
        {
            mybag = new List<Alltools>(11);
            for (int i = 0; i < mybag.Capacity; i++)
            {
                peralatan.transform.GetChild(i).gameObject.SetActive(true);
                barang.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        reloadBag();
        
    }

    public void reloadBag()
    {
        for (int i = 0; i < mybag.Capacity; i++)
        {
            if (PlayerPrefs.HasKey("peralatannama" + i) && PlayerPrefs.GetString("peralatannama" + i) != "")
            {
                Alltools newtools = new Alltools();
                newtools.slot = i;
                newtools.name = PlayerPrefs.GetString("peralatannama" + i);
                newtools.jumlah = PlayerPrefs.GetInt("peralatanjumlah" + i);
                newtools.resource = "Images/Peralatan/" + PlayerPrefs.GetString("peralatannama" + i);
                //mybag.Insert(i,newtools);
                peralatan.transform.GetChild(i).Find("Image").GetComponent<Image>().enabled = true;
                peralatan.transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(newtools.resource);
                if (PlayerPrefs.GetInt("peralatanjumlah" + i) == -1) peralatan.transform.GetChild(i).Find("Text").GetComponent<Text>().text = "";
                else if (PlayerPrefs.GetInt("peralatanjumlah" + i) > 0) peralatan.transform.GetChild(i).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah" + i);
            }

            if (PlayerPrefs.HasKey("kantongnama" + i) && PlayerPrefs.GetString("kantongnama" + i) != "")
            {
                Alltools newtools = new Alltools();
                newtools.slot = i;
                newtools.name = PlayerPrefs.GetString("kantongnama" + i);
                newtools.jumlah = PlayerPrefs.GetInt("kantongjumlah" + i);
                newtools.resource = "Images/Barang/" + PlayerPrefs.GetString("kantongnama" + i);
                //mybag.Insert(i,newtools);
                barang.transform.GetChild(i).Find("Image").GetComponent<Image>().enabled = true;
                barang.transform.GetChild(i).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(newtools.resource);
                if (PlayerPrefs.GetInt("kantongjumlah" + i) == -1) barang.transform.GetChild(i).Find("Text").GetComponent<Text>().text = "";
                else if (PlayerPrefs.GetInt("kantongjumlah" + i) > 0) barang.transform.GetChild(i).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("kantongjumlah" + i);
            }else if(PlayerPrefs.GetString("kantongnama" + i) == "")
            {
                barang.transform.GetChild(i).Find("Image").GetComponent<Image>().enabled = false;
                barang.transform.GetChild(i).Find("Text").GetComponent<Text>().text = "";
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void selectTools(int slot)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        if (PlayerPrefs.HasKey("pindahinTools"))
        {
            if (PlayerPrefs.GetInt("pindahinTools") < 11)
            {
                peralatan = GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").gameObject;
                peralatan.transform.GetChild(PlayerPrefs.GetInt("pindahinTools")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
            }
            else
            {
                peralatan = GameObject.Find("Canvas").transform.Find("SafeBox").transform.Find("BGBawah").Find("tools").gameObject;
                peralatan.transform.GetChild(PlayerPrefs.GetInt("pindahinTools") - 11).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
            }


            Alltools newtools = new Alltools();
            newtools.slot = slot;
            newtools.name = PlayerPrefs.GetString("peralatannama" + slot);
            newtools.jumlah = PlayerPrefs.GetInt("peralatanjumlah" + slot);
            newtools.resource = "Images/Peralatan/" + PlayerPrefs.GetString("peralatannama" + slot);

            Alltools sebelumtools = new Alltools();
            sebelumtools.slot = PlayerPrefs.GetInt("pindahinTools");
            sebelumtools.name = PlayerPrefs.GetString("peralatannama" + sebelumtools.slot);
            sebelumtools.jumlah = PlayerPrefs.GetInt("peralatanjumlah" + sebelumtools.slot);
            sebelumtools.resource = "Images/Peralatan/" + PlayerPrefs.GetString("peralatannama" + sebelumtools.slot);

            if (sebelumtools.name != "")
            {
                if (slot < 11)
                {
                    peralatan = GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").gameObject;
                    peralatan.transform.GetChild(slot).Find("Image").GetComponent<Image>().enabled = true;
                    peralatan.transform.GetChild(slot).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(sebelumtools.resource);
                    if (PlayerPrefs.GetInt("peralatanjumlah" + sebelumtools.slot) == -1) peralatan.transform.GetChild(slot).Find("Text").GetComponent<Text>().text = "";
                    else if (PlayerPrefs.GetInt("peralatanjumlah" + sebelumtools.slot) > 0) peralatan.transform.GetChild(slot).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah" + sebelumtools.slot);
                }
                else
                {
                    peralatan = GameObject.Find("Canvas").transform.Find("SafeBox").transform.Find("BGBawah").Find("tools").gameObject;
                    peralatan.transform.GetChild(slot - 11).Find("Image").GetComponent<Image>().enabled = true;
                    peralatan.transform.GetChild(slot - 11).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(sebelumtools.resource);
                    if (PlayerPrefs.GetInt("peralatanjumlah" + sebelumtools.slot) == -1) peralatan.transform.GetChild(slot - 11).Find("Text").GetComponent<Text>().text = "";
                    else if (PlayerPrefs.GetInt("peralatanjumlah" + sebelumtools.slot) > 0) peralatan.transform.GetChild(slot - 11).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah" + sebelumtools.slot);
                }
            }
            else
            {
                if (slot < 11)
                {
                    peralatan = GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").gameObject;
                    peralatan.transform.GetChild(slot).Find("Image").GetComponent<Image>().enabled = false;
                    peralatan.transform.GetChild(slot).Find("Text").GetComponent<Text>().text = "";
                }
                else
                {
                    peralatan = GameObject.Find("Canvas").transform.Find("SafeBox").transform.Find("BGBawah").Find("tools").gameObject;
                    peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Image").GetComponent<Image>().enabled = false;
                    peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Text").GetComponent<Text>().text = "";
                }
            }

            if (sebelumtools.slot < 11)
            {
                peralatan = GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").gameObject;
            }
            else
            {
                peralatan = GameObject.Find("Canvas").transform.Find("SafeBox").transform.Find("BGBawah").Find("tools").gameObject;
            }

            if (newtools.name != "")
            {
                if (sebelumtools.slot < 11)
                {
                    peralatan.transform.GetChild(sebelumtools.slot).Find("Image").GetComponent<Image>().enabled = true;
                    peralatan.transform.GetChild(sebelumtools.slot).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(newtools.resource);
                    if (PlayerPrefs.GetInt("peralatanjumlah" + slot) == -1) peralatan.transform.GetChild(sebelumtools.slot).Find("Text").GetComponent<Text>().text = "";
                    else if (PlayerPrefs.GetInt("peralatanjumlah" + slot) > 0) peralatan.transform.GetChild(sebelumtools.slot).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah" + slot);
                }
                else
                {
                    peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Image").GetComponent<Image>().enabled = true;
                    peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(newtools.resource);
                    if (PlayerPrefs.GetInt("peralatanjumlah" + slot) == -1) peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Text").GetComponent<Text>().text = "";
                    else if (PlayerPrefs.GetInt("peralatanjumlah" + slot) > 0) peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah" + slot);
                }
            }
            else
            {
                if (sebelumtools.slot < 11)
                {
                    peralatan.transform.GetChild(sebelumtools.slot).Find("Image").GetComponent<Image>().enabled = false;
                    peralatan.transform.GetChild(sebelumtools.slot).Find("Text").GetComponent<Text>().text = "";
                }
                else
                {
                    peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Image").GetComponent<Image>().enabled = false;
                    peralatan.transform.GetChild(sebelumtools.slot - 11).Find("Text").GetComponent<Text>().text = "";
                }

            }

            PlayerPrefs.SetString("peralatannama" + slot, sebelumtools.name);
            PlayerPrefs.SetInt("peralatanjumlah" + slot, sebelumtools.jumlah);
            PlayerPrefs.SetString("peralatannama" + sebelumtools.slot, newtools.name);
            PlayerPrefs.SetInt("peralatanjumlah" + sebelumtools.slot, newtools.jumlah);

            if ((newtools.slot == 0 && sebelumtools.name != "") || (sebelumtools.slot == 0 && newtools.name != ""))
            {
                GameObject myweapon = new GameObject();
                if(PlayerPrefs.GetString("gender") == "cowok")
                    myweapon = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
                else if (PlayerPrefs.GetString("gender") == "cewek")
                    myweapon = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
                for (int i = 0; i < myweapon.transform.childCount; i++)
                    myweapon.transform.GetChild(i).gameObject.SetActive(false);
                myweapon.transform.Find(PlayerPrefs.GetString("peralatannama0")).gameObject.SetActive(true);

                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().enabled = true;
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().enabled = true;
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Peralatan/" + PlayerPrefs.GetString("peralatannama0"));
                if (PlayerPrefs.GetInt("peralatanjumlah0") == -1) GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "";
                else if (PlayerPrefs.GetInt("peralatanjumlah0") > 0) GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah0");

                Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("changeweapon", RpcTarget.Others, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("barangnama0"), PlayerPrefs.GetString("gender"));
            }
            else if ((newtools.slot == 0 && sebelumtools.name == "") || (sebelumtools.slot == 0 && newtools.name == ""))
            {
                GameObject myweapon = new GameObject();
                if (PlayerPrefs.GetString("gender") == "cowok")
                    myweapon = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
                else if (PlayerPrefs.GetString("gender") == "cewek")
                    myweapon = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
                for (int i = 0; i < myweapon.transform.childCount; i++)
                    myweapon.transform.GetChild(i).gameObject.SetActive(false);

                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().enabled = false;
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().enabled = false;

                Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("changeweapon", RpcTarget.Others, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("barangnama0"), PlayerPrefs.GetString("gender"));
            }

            PlayerPrefs.DeleteKey("pindahinTools");
            PlayerPrefs.DeleteKey("nonaktifdialog");
        }
        else
        {
            if (slot < 11)
            {
                peralatan = GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").gameObject;
                peralatan.transform.GetChild(slot).GetComponent<Image>().color = new Color32(131, 255, 255, 255);
            }
            else
            {
                peralatan = GameObject.Find("Canvas").transform.Find("SafeBox").transform.Find("BGBawah").Find("tools").gameObject;
                peralatan.transform.GetChild(slot - 11).GetComponent<Image>().color = new Color32(131, 255, 255, 255);
            }

            if(!PlayerPrefs.HasKey("nonaktifdialog"))
            MyDialogBag.instance.percakapanDeskripsi(PlayerPrefs.GetString("peralatannama" + slot));
            PlayerPrefs.SetInt("pindahinTools", slot);
        }

    }

    public void selectBarang(int slot)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        if (PlayerPrefs.HasKey("pindahinKantong"))
        {
            barang.transform.GetChild(PlayerPrefs.GetInt("pindahinKantong")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);


            Alltools newtools = new Alltools();
            newtools.slot = slot;
            newtools.name = PlayerPrefs.GetString("kantongnama" + slot);
            newtools.jumlah = PlayerPrefs.GetInt("kantongjumlah" + slot);
            newtools.resource = "Images/Barang/" + PlayerPrefs.GetString("kantongnama" + slot);

            Alltools sebelumtools = new Alltools();
            sebelumtools.slot = PlayerPrefs.GetInt("pindahinKantong");
            sebelumtools.name = PlayerPrefs.GetString("kantongnama" + sebelumtools.slot);
            sebelumtools.jumlah = PlayerPrefs.GetInt("kantongjumlah" + sebelumtools.slot);
            sebelumtools.resource = "Images/Barang/" + PlayerPrefs.GetString("kantongnama" + sebelumtools.slot);

            if (sebelumtools.name != "")
            {
                barang.transform.GetChild(slot).Find("Image").GetComponent<Image>().enabled = true;
                barang.transform.GetChild(slot).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(sebelumtools.resource);
                if (PlayerPrefs.GetInt("kantongjumlah" + sebelumtools.slot) == -1) barang.transform.GetChild(slot).Find("Text").GetComponent<Text>().text = "";
                else if (PlayerPrefs.GetInt("kantongjumlah" + sebelumtools.slot) > 0) barang.transform.GetChild(slot).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("kantongjumlah" + sebelumtools.slot);
            }
            else
            {
                barang.transform.GetChild(slot).Find("Image").GetComponent<Image>().enabled = false;
                barang.transform.GetChild(slot).Find("Text").GetComponent<Text>().text = "";
            }

            if (newtools.name != "")
            {
                barang.transform.GetChild(sebelumtools.slot).Find("Image").GetComponent<Image>().enabled = true;
                barang.transform.GetChild(sebelumtools.slot).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(newtools.resource);
                if (PlayerPrefs.GetInt("kantongjumlah" + slot) == -1) barang.transform.GetChild(sebelumtools.slot).Find("Text").GetComponent<Text>().text = "";
                else if (PlayerPrefs.GetInt("kantongjumlah" + slot) > 0) barang.transform.GetChild(sebelumtools.slot).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("kantongjumlah" + slot);
            }
            else
            {
                barang.transform.GetChild(sebelumtools.slot).Find("Image").GetComponent<Image>().enabled = false;
                barang.transform.GetChild(sebelumtools.slot).Find("Text").GetComponent<Text>().text = "";
            }

            PlayerPrefs.SetString("kantongnama" + slot, sebelumtools.name);
            PlayerPrefs.SetInt("kantongjumlah" + slot, sebelumtools.jumlah);
            PlayerPrefs.SetString("kantongnama" + sebelumtools.slot, newtools.name);
            PlayerPrefs.SetInt("kantongjumlah" + sebelumtools.slot, newtools.jumlah);

            if (newtools.slot == 0 && sebelumtools.name != "")
            {
               // GameObject myweapon = Gamesetupcontroller.instance.go.transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
               // for (int i = 0; i < myweapon.transform.childCount; i++)
                //    myweapon.transform.GetChild(i).gameObject.SetActive(false);
                //myweapon.transform.Find(PlayerPrefs.GetString("peralatannama0")).gameObject.SetActive(true);
               // Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("changeweapon", RpcTarget.Others, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("kantongnama0"));
            }
            else if (newtools.slot == 0 && sebelumtools.name == "")
            {
                //GameObject myweapon = Gamesetupcontroller.instance.go.transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
                //for (int i = 0; i < myweapon.transform.childCount; i++)
                //    myweapon.transform.GetChild(i).gameObject.SetActive(false);
                //Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("changeweapon", RpcTarget.Others, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("kantongnama0"));
            }

            PlayerPrefs.DeleteKey("pindahinKantong");
        }
        else
        {
            barang.transform.GetChild(slot).GetComponent<Image>().color = new Color32(131, 255, 255, 255);
            MyDialogBag.instance.percakapanDeskripsi(PlayerPrefs.GetString("kantongnama" + slot));
            PlayerPrefs.SetInt("pindahinKantong", slot);
        }

    }

    public void nextWeapon()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("clicktools").GetComponent<AudioSource>();
        audio.Play();

        int swapped = mybag.Capacity - 1;
        for (int i=0;i< mybag.Capacity-1; i++)
        {
            PlayerPrefs.SetString("nonaktifdialog", "yes");
            selectTools(0);
            selectTools(swapped);
            swapped--;
        }
        
    }

    public void prevWeapon()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("clicktools").GetComponent<AudioSource>();
        audio.Play();

        for (int i = 0; i < mybag.Capacity - 1; i++)
        {
            PlayerPrefs.SetString("nonaktifdialog", "yes");
            selectTools(mybag.Capacity-1);
            selectTools(i);
        }
    }

}

public class Alltools
{
    public int slot;
    public string name;
    public int jumlah;
    public string resource;
}
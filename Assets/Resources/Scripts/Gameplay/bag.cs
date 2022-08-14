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
        UpdateBagSlot();
    }
    public void UpdateBagSlot()
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
                string[] namaitem = PlayerPrefs.GetString("kantongnama" + i).Split('-');
                newtools.name = namaitem[0];
                Debug.Log(newtools.name);
                newtools.jumlah = PlayerPrefs.GetInt("kantongjumlah" + i);
                newtools.resource = "Images/Barang/" + namaitem[0];
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
                GameObject myweapon = GameObject.Find("PlayerSpawn");
                myweapon = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
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
                GameObject myweapon = GameObject.Find("PlayerSpawn");
                myweapon = GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
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

    public void selectAllBarang()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("openmenu").GetComponent<AudioSource>();
        audio.Play();
        int diselect = 0;
        for (int slot = 0; slot < mybag.Capacity; slot++)
            if (barang.transform.GetChild(slot).GetComponent<Image>().color.r <= 0.859f &&
                    barang.transform.GetChild(slot).GetComponent<Image>().color.r >= 0.857f)
            {
                barang.transform.GetChild(slot).GetComponent<Image>().color = new Color32(131, 255, 255, 255);
                string namabuah = PlayerPrefs.GetString("kantongnama" + slot);
                int jumlahbuah = PlayerPrefs.GetInt("kantongjumlah" + slot);
                int hargabuah = ShopInGameController.instance.hargajualbuah(namabuah);
                int totalharga = (jumlahbuah * hargabuah) + System.Int32.Parse(GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text);
                GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text = "" + totalharga;
            }
            else diselect++;
        if (diselect == mybag.Capacity)
            for (int slot = 0; slot < mybag.Capacity; slot++)
            {
                barang.transform.GetChild(slot).GetComponent<Image>().color = new Color(0.858f, 0.858f, 0.858f, 1);
                string namabuah = PlayerPrefs.GetString("kantongnama" + slot);
                int jumlahbuah = PlayerPrefs.GetInt("kantongjumlah" + slot);
                int hargabuah = ShopInGameController.instance.hargajualbuah(namabuah);
                int totalharga = System.Int32.Parse(GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text) - (jumlahbuah * hargabuah);
                GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text = "" + totalharga;
            }
    }

    public void selectBarang(int slot)
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        if (PlayerPrefs.HasKey("EmonSell"))
        {
            if (barang.transform.GetChild(slot).GetComponent<Image>().color.r <= 0.859f &&
                barang.transform.GetChild(slot).GetComponent<Image>().color.r >= 0.857f)
            {
                barang.transform.GetChild(slot).GetComponent<Image>().color = new Color32(131, 255, 255, 255);
                string namabuah = PlayerPrefs.GetString("kantongnama" + slot);
                int jumlahbuah = PlayerPrefs.GetInt("kantongjumlah" + slot);
                int hargabuah = ShopInGameController.instance.hargajualbuah(namabuah);
                int totalharga = (jumlahbuah * hargabuah) + System.Int32.Parse(GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text);
                GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text = "" + totalharga;
                return;
            }
            else
            {
                barang.transform.GetChild(slot).GetComponent<Image>().color = new Color(0.858f, 0.858f, 0.858f, 1);
                string namabuah = PlayerPrefs.GetString("kantongnama" + slot);
                int jumlahbuah = PlayerPrefs.GetInt("kantongjumlah" + slot);
                int hargabuah = ShopInGameController.instance.hargajualbuah(namabuah);
                int totalharga = System.Int32.Parse(GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text) - (jumlahbuah * hargabuah);
                GameObject.Find("Canvas").transform.Find("SeedShopSell").Find("BGBawah").Find("TotalHarga").GetComponent<Text>().text = "" + totalharga;
                return;

            }
            
        }
        if (PlayerPrefs.HasKey("pindahinKantong"))
        {
            barang.transform.GetChild(PlayerPrefs.GetInt("pindahinKantong")).GetComponent<Image>().color = new Color32(219, 219, 219, 255);


            Alltools newtools = new Alltools();
            newtools.slot = slot;
            string[] namaitem = PlayerPrefs.GetString("kantongnama" + slot).Split('-');
            newtools.name = PlayerPrefs.GetString("kantongnama" + slot);
            newtools.jumlah = PlayerPrefs.GetInt("kantongjumlah" + slot);
            newtools.resource = "Images/Barang/" + namaitem[0];

            

            Alltools sebelumtools = new Alltools();
            sebelumtools.slot = PlayerPrefs.GetInt("pindahinKantong");
            string[] namaitem2 = PlayerPrefs.GetString("kantongnama" + sebelumtools.slot).Split('-');
            sebelumtools.name = PlayerPrefs.GetString("kantongnama" + sebelumtools.slot);
            sebelumtools.jumlah = PlayerPrefs.GetInt("kantongjumlah" + sebelumtools.slot);
            sebelumtools.resource = "Images/Barang/" + namaitem2[0];

            Debug.Log("NAMA ITEM: " + namaitem[0]);
            if (namaitem[0].Contains("Cat") || namaitem[0].Contains("Chicken") || namaitem[0].Contains("Duck")
                || namaitem[0].Contains("Goat") || namaitem[0].Contains("Cow") || namaitem2[0].Contains("Cat") || namaitem2[0].Contains("Chicken") || namaitem2[0].Contains("Duck")
                || namaitem2[0].Contains("Goat") || namaitem2[0].Contains("Cow"))
            {
                audio = GameObject.Find("Clicked").transform.Find("ClickedWrong").GetComponent<AudioSource>();
                audio.Play();
                PlayerPrefs.DeleteKey("pindahinKantong");
                return;
            }

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

            if ((newtools.slot == 0 && sebelumtools.name != "") || (sebelumtools.slot==0 && newtools.name!=""))
            {
                string resourceprefab = "";
                if (sebelumtools.slot == 0 && newtools.name != "")
                {
                    resourceprefab = namaitem[0];
                    if(sebelumtools.name!="")
                    PhotonNetwork.Destroy(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").Find("Item").GetComponent<PhotonView>());
                }
                else if (newtools.slot == 0 && sebelumtools.name != "")
                {
                    resourceprefab = namaitem2[0];
                    if(newtools.name!="")
                    PhotonNetwork.Destroy(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").Find("Item").GetComponent<PhotonView>());
                }
                GameObject item = PhotonNetwork.Instantiate(Path.Combine("Model/Item/Prefab", resourceprefab), GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").rotation);
                //item.GetComponent<PhotonView>().TransferOwnership(0);
                GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + PlayerPrefs.GetString("myname") + ")", item.name, PlayerPrefs.GetString("level"));
            }
            else if (newtools.slot == 0 && sebelumtools.name == "")
            {
                if (newtools.name != "")
                {
                    PhotonNetwork.Destroy(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").Find("Item").GetComponent<PhotonView>());
                }
            }
            else if (sebelumtools.slot == 0 && newtools.name == "")
            {
                if (sebelumtools.name != "")
                {
                    PhotonNetwork.Destroy(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").Find("AreaPegang").Find("Item").GetComponent<PhotonView>());
                }
            }

            PlayerPrefs.DeleteKey("pindahinKantong");
        }
        else
        {
            Debug.Log("KANTONG PENCET: "+ PlayerPrefs.GetString("kantongnama" + slot));
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
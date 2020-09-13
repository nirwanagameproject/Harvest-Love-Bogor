using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kotakperalatan : MonoBehaviour
{
    public List<Alltools> mybag;
    public GameObject peralatan;
    public int mypage;
    public int maxpage;
    // Start is called before the first frame update
    void Start()
    {
        peralatan = transform.Find("BGBawah").Find("tools").gameObject;

        mybag = new List<Alltools>(42);
        for (int i = 0; i < 14; i++)
        {
            peralatan.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = 11; i < mybag.Capacity+11; i++)
        {
            if (PlayerPrefs.HasKey("peralatannama" + i) && PlayerPrefs.GetString("peralatannama" + i) != "")
            {
                Alltools newtools = new Alltools();
                newtools.slot = i;
                newtools.name = PlayerPrefs.GetString("peralatannama" + i);
                newtools.jumlah = PlayerPrefs.GetInt("peralatanjumlah" + i);
                newtools.resource = "Images/Peralatan/" + PlayerPrefs.GetString("peralatannama" + i);
                //mybag.Insert(i,newtools);
                peralatan.transform.GetChild(i-11).Find("Image").GetComponent<Image>().enabled = true;
                peralatan.transform.GetChild(i-11).Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(newtools.resource);
                if(PlayerPrefs.GetInt("peralatanjumlah" + i)==-1)peralatan.transform.GetChild(i-11).Find("Text").GetComponent<Text>().text = "";
                else if(PlayerPrefs.GetInt("peralatanjumlah" + i)>0)peralatan.transform.GetChild(i-11).Find("Text").GetComponent<Text>().text = "X "+ PlayerPrefs.GetInt("peralatanjumlah" + i);
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
                peralatan = transform.Find("BGBawah").Find("tools").gameObject;
                peralatan.transform.GetChild(PlayerPrefs.GetInt("pindahinTools")-11).GetComponent<Image>().color = new Color32(219, 219, 219, 255);
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
                    peralatan = transform.Find("BGBawah").Find("tools").gameObject;
                    peralatan.transform.GetChild(slot-11).Find("Image").GetComponent<Image>().enabled = true;
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
                    peralatan.transform.GetChild(sebelumtools.slot).Find("Image").GetComponent<Image>().enabled = false;
                    peralatan.transform.GetChild(sebelumtools.slot).Find("Text").GetComponent<Text>().text = "";
                }
                else
                {
                    peralatan = GameObject.Find("Canvas").transform.Find("SafeBox").transform.Find("BGBawah").Find("tools").gameObject;
                    peralatan.transform.GetChild(slot-11).Find("Image").GetComponent<Image>().enabled = false;
                    peralatan.transform.GetChild(slot-11).Find("Text").GetComponent<Text>().text = "";
                }
            }

            if (sebelumtools.slot < 11)
            {
                peralatan = GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").gameObject;
            }
            else
            {
                peralatan = transform.Find("BGBawah").Find("tools").gameObject;
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
                    peralatan.transform.GetChild(sebelumtools.slot-11).Find("Image").GetComponent<Image>().enabled = true;
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
                }else
                {
                    peralatan.transform.GetChild(sebelumtools.slot-11).Find("Image").GetComponent<Image>().enabled = false;
                    peralatan.transform.GetChild(sebelumtools.slot-11).Find("Text").GetComponent<Text>().text = "";
                }
                    
            }

            PlayerPrefs.SetString("peralatannama" + slot,sebelumtools.name);
            PlayerPrefs.SetInt("peralatanjumlah" + slot,sebelumtools.jumlah);
            PlayerPrefs.SetString("peralatannama" + sebelumtools.slot, newtools.name);
            PlayerPrefs.SetInt("peralatanjumlah" + sebelumtools.slot, newtools.jumlah);

            if ((newtools.slot == 0 && sebelumtools.name!="") || (sebelumtools.slot == 0 && newtools.name != ""))
            {
                GameObject myweapon = Gamesetupcontroller.instance.go.transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
                for (int i = 0; i < myweapon.transform.childCount; i++)
                    myweapon.transform.GetChild(i).gameObject.SetActive(false);
                myweapon.transform.Find(PlayerPrefs.GetString("peralatannama0")).gameObject.SetActive(true);

                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().enabled = true;
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().enabled = true;
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Peralatan/" + PlayerPrefs.GetString("peralatannama0"));
                if (PlayerPrefs.GetInt("peralatanjumlah0") == -1) GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "";
                else if (PlayerPrefs.GetInt("peralatanjumlah0") > 0) GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah0");

                Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("changeweapon", RpcTarget.Others, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("barangnama0"));
            } 
            else if ((newtools.slot == 0 && sebelumtools.name == "") || (sebelumtools.slot == 0 && newtools.name == ""))
            {
                GameObject myweapon = Gamesetupcontroller.instance.go.transform.Find("Armature").Find("Hips").Find("Spine").Find("Chest").Find("Right shoulder").Find("Right arm").Find("Right elbow").Find("Right wrist").Find("weapon").gameObject;
                for (int i = 0; i < myweapon.transform.childCount; i++)
                    myweapon.transform.GetChild(i).gameObject.SetActive(false);

                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Image").GetComponent<Image>().enabled = false;
                GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().enabled = false;

                Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("changeweapon", RpcTarget.Others, "Player (" + PlayerPrefs.GetString("myname") + ")", PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("barangnama0"));
            }

            PlayerPrefs.DeleteKey("pindahinTools");
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
                peralatan = transform.Find("BGBawah").Find("tools").gameObject;
                peralatan.transform.GetChild(slot-11).GetComponent<Image>().color = new Color32(131, 255, 255, 255);
            }

            
            MyDialogBag.instance.percakapanDeskripsi(PlayerPrefs.GetString("peralatannama"+slot));
            PlayerPrefs.SetInt("pindahinTools", slot);
        }
        
    }

    public void nextKotak()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("clicktools").GetComponent<AudioSource>();
        audio.Play();

        if (mypage + 1 <= maxpage) mypage++;
        else mypage = 1;
        transform.Find("BGBawah").Find("Text").GetComponent<Text>().text = "Kotak Penyimpanan (" + mypage+"/"+ maxpage+")";
        peralatan = transform.Find("BGBawah").Find("tools").gameObject;

        for (int i = 0; i < mybag.Capacity; i++)
        {
            peralatan.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = (mypage-1)*14; i < mypage * 14; i++)
        {
            peralatan.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void prevKotak()
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("clicktools").GetComponent<AudioSource>();
        audio.Play();

        if (mypage -1 >= 1) mypage--;
        else mypage = maxpage;
        transform.Find("BGBawah").Find("Text").GetComponent<Text>().text = "Kotak Penyimpanan (" + mypage + "/" + maxpage + ")";
        peralatan = transform.Find("BGBawah").Find("tools").gameObject;

        for (int i = 0; i < mybag.Capacity; i++)
        {
            peralatan.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = (mypage - 1) * 14; i < mypage * 14; i++)
        {
            peralatan.transform.GetChild(i).gameObject.SetActive(true);
        }
    }


}

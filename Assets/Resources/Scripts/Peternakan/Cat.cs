using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject cubeaction;
    public string level;
    private Animator anim;
    bool munculcubeaction = false;
    bool enterPlayer = false;
    public bool sedangditanya = false;
    public bool picked;
    Collider[] mycolliderPlayer;
    public Vector3 pos = new Vector3();
    public Coroutine NPCcoroutine;
    public bool CR_running = false;
    AudioSource idle1;
    AudioSource idle2;
    AudioSource idle3;
    AudioSource idle4;
    AudioSource idle5;
    AudioSource fly1;
    AudioSource fly2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (PhotonNetwork.OfflineMode) GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);

        tag = "NPChewan";
        NPCcoroutine = StartCoroutine("randomJalan");
        if (name.Contains("Duck") || name.Contains("Chicken"))
        {
            if (transform.parent == null)
                transform.parent = GameObject.Find("AISpawn").transform;
            if (!PhotonNetwork.IsMasterClient)
            {
                GetComponent<PhotonView>().RPC("mintareqnama", RpcTarget.MasterClient);
            }
            if (PhotonNetwork.IsConnectedAndReady)
                if(name.Split('-').Length<3)
                name = name + "-"+GetComponent<PhotonView>().ViewID;
            idle1 = transform.GetChild(0).Find("Audio").Find("idle1").GetComponent<AudioSource>();
            idle2 = transform.GetChild(0).Find("Audio").Find("idle2").GetComponent<AudioSource>();
            fly1 = transform.GetChild(0).Find("Audio").Find("fly1").GetComponent<AudioSource>();
            fly2 = transform.GetChild(0).Find("Audio").Find("fly2").GetComponent<AudioSource>();

        }
        else if (name.Contains("Cat"))
        {
            if(transform.parent==null)
            transform.parent = GameObject.Find("AISpawn").transform;
            if (PhotonNetwork.IsConnectedAndReady)
            name = "Cat-"+PhotonNetwork.CurrentRoom.CustomProperties["mykucing"].ToString()+"-8";
            idle1 = transform.GetChild(0).Find("Audio").Find("idle1").GetComponent<AudioSource>();
            idle2 = transform.GetChild(0).Find("Audio").Find("idle2").GetComponent<AudioSource>();
            idle3 = transform.GetChild(0).Find("Audio").Find("idle3").GetComponent<AudioSource>();
            idle4 = transform.GetChild(0).Find("Audio").Find("idle4").GetComponent<AudioSource>();
            idle5 = transform.GetChild(0).Find("Audio").Find("idle5").GetComponent<AudioSource>();
        }else if (name.Contains("Goat") || name.Contains("Cow"))
        {
            transform.parent = GameObject.Find("AISpawn").transform;
            if (!PhotonNetwork.IsMasterClient)
            {
                GetComponent<PhotonView>().RPC("mintareqnama", RpcTarget.MasterClient);
            }
            if (PhotonNetwork.IsConnectedAndReady)
                if (name.Split('-').Length < 3)
                    name = name + "-" + GetComponent<PhotonView>().ViewID;
            idle1 = transform.GetChild(0).Find("Audio").Find("idle1").GetComponent<AudioSource>();
            idle2 = transform.GetChild(0).Find("Audio").Find("idle2").GetComponent<AudioSource>();
            idle3 = transform.GetChild(0).Find("Audio").Find("idle3").GetComponent<AudioSource>();
            idle4 = transform.GetChild(0).Find("Audio").Find("idle4").GetComponent<AudioSource>();
            idle5 = transform.GetChild(0).Find("Audio").Find("idle5").GetComponent<AudioSource>();
        }
        else if (name.Split('-')[0].Equals("Samsul"))
        {
            idle1 = transform.GetChild(0).Find("Audio").Find("idle1").GetComponent<AudioSource>();
            idle2 = transform.GetChild(0).Find("Audio").Find("idle2").GetComponent<AudioSource>();
            idle3 = transform.GetChild(0).Find("Audio").Find("idle3").GetComponent<AudioSource>();
            idle4 = transform.GetChild(0).Find("Audio").Find("idle4").GetComponent<AudioSource>();
            idle5 = transform.GetChild(0).Find("Audio").Find("idle5").GetComponent<AudioSource>();
        }else if (name.Split('-')[0].Equals("Eko"))
        {
            idle1 = transform.GetChild(0).Find("Audio").Find("idle1").GetComponent<AudioSource>();
            idle2 = transform.GetChild(0).Find("Audio").Find("idle2").GetComponent<AudioSource>();
            fly1 = transform.GetChild(0).Find("Audio").Find("fly1").GetComponent<AudioSource>();
            fly2 = transform.GetChild(0).Find("Audio").Find("fly2").GetComponent<AudioSource>();
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //PERAS SUSU
        mycolliderPlayer = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));

        for (int j = 0; j < mycolliderPlayer.Length; j++) if (mycolliderPlayer[j].name == "Player (" + PlayerPrefs.GetString("myname") + ")") { enterPlayer = true; break; }

        bool masukCow = true;
        string[] tipehewan = {"",""};

        if (transform.Find("GameObject") != null)
        if (name.Contains("-") && (name.Contains("Goat") || name.Contains("Cow")))
        {
            tipehewan = name.Split('-');
            if(PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]!=null)
            for (int i = 0; i < (int)PhotonNetwork.CurrentRoom.CustomProperties["CowMax"]; i++)
            {
                if(PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i]!=null)
                if (PhotonNetwork.CurrentRoom.CustomProperties["Cow" + i].ToString() == name)
                {
                    if (PhotonNetwork.CurrentRoom.CustomProperties["CowMilk" + i].ToString() == "")
                        masukCow = false;
                    break;
                }
            }
        }else if(name.Split('-')[0] == "Samsul" || name.Split('-')[0] == "Eko") masukCow = false;

        if (enterPlayer && !picked && PlayerPrefs.GetString("kantongnama0") == "" && PlayerPrefs.GetString("level") == GetComponent<Cat>().level
            && masukCow)
        {
            for (int k = 0; k < mycolliderPlayer.Length; k++)
            {
                if (!PhotonNetwork.IsConnected || mycolliderPlayer[k].GetComponent<PhotonView>().IsMine)
                {
                    if (cubeaction == null)
                        cubeaction = CariGameObject.FindInActiveObjectByName("CubeAction");
                    cubeaction.SetActive(true);
                    cubeaction.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    munculcubeaction = true;
                    
                    if(tipehewan[0]=="Cow" || tipehewan[0] == "Goat")
                    PlayerPrefs.SetString("buttonMilking", name);
                    else PlayerPrefs.SetString("buttonPickUpHewan", name);
                }
            }
        }
        else if (munculcubeaction)
        {
            if (cubeaction == null)
                cubeaction = CariGameObject.FindInActiveObjectByName("CubeAction");
            cubeaction.SetActive(false);
            munculcubeaction = false;
            tipehewan = name.Split('-');
            if (tipehewan[0] == "Cow" || tipehewan[0] == "Goat")
                PlayerPrefs.DeleteKey("buttonMilking");
            else PlayerPrefs.DeleteKey("buttonPickUpHewan");
        }

        enterPlayer = false;

        //PhotonNetwork.InRoom
        if ((name.Contains("Cat") || name.Contains("Duck") || name.Contains("Chicken") || name.Contains("Cow") || name.Contains("Goat")) && GetComponent<PhotonView>().IsMine)
        {
            string namaNPC = name;
            if(PhotonNetwork.CurrentRoom!=null)
            if (pos != null && PhotonNetwork.CurrentRoom.CustomProperties[namaNPC] != null)
            {
                jalanNPC(pos, namaNPC);
            }
        }else if(name.Split('-')[0] == "Samsul" || name.Split('-')[0] == "Eko")
        {
            if (pos != null)
            {
                jalanNPC(pos, name);
            }
        }

        if (PlayerPrefs.GetString("level") == GetComponent<Cat>().level && GetComponent<PhotonView>().IsMine)
        {
            if (GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")") != null)
            {
                if (GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").gameObject.activeInHierarchy)
                {
                    if (!CR_running && !picked) { StopAllCoroutines(); NPCcoroutine = StartCoroutine("randomJalan"); }

                    if (GetComponent<PhotonView>().Owner == null && PhotonNetwork.IsMasterClient)
                        GetComponent<PhotonView>().TransferOwnership(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().Owner);
                    if (GetComponent<PhotonView>().Owner != null)
                        if (GetComponent<PhotonView>().Owner.NickName != GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().Owner.NickName)
                            GetComponent<PhotonView>().TransferOwnership(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<PhotonView>().Owner);
                    if (GetComponent<Rigidbody>().useGravity == false)
                    {
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                        GetComponent<Rigidbody>().useGravity = true;
                    }
                }
            }
            else
            {
                if (GetComponent<Rigidbody>().useGravity == true)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
        else if (PlayerPrefs.GetString("level") != GetComponent<Cat>().level)
        {
            if (GetComponent<PhotonView>().IsMine) 
            {
                bool adaplayer = false;
                for (int mulai = 0; mulai < GameObject.Find("PlayerSpawn").transform.childCount; mulai++)
                {
                    if (GameObject.Find("PlayerSpawn").transform.GetChild(mulai).GetComponent<Player1>().level == GetComponent<Cat>().level)
                    {
                        adaplayer = true;
                        if (GetComponent<PhotonView>().Owner.NickName != GameObject.Find("PlayerSpawn").transform.GetChild(mulai).GetComponent<PhotonView>().Owner.NickName)
                        {
                            GetComponent<PhotonView>().TransferOwnership(GameObject.Find("PlayerSpawn").transform.GetChild(mulai).GetComponent<PhotonView>().Owner);
                            pos.x = transform.position.x;
                            pos.y = transform.position.y;
                            pos.z = transform.position.z;
                            StopCoroutine(NPCcoroutine); CR_running = false;
                            if (PhotonNetwork.CurrentRoom.CustomProperties[name] != null)
                                if (PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1")
                            {
                                ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                                setProperti.Add(name, "");
                                PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
                            }
                                
                            GetComponent<PhotonView>().RPC("gantipemilik", GameObject.Find("PlayerSpawn").transform.GetChild(mulai).GetComponent<PhotonView>().Owner);
                        }
                        break;
                    }
                }
                if (!adaplayer)
                {
                    StopCoroutine(NPCcoroutine); CR_running = false;
                    if (PhotonNetwork.CurrentRoom.CustomProperties[name] != null)
                        if (PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1")
                        {
                            ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                            setProperti.Add(name, "");
                            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
                        }

                }
                else if (!CR_running) { StopAllCoroutines(); NPCcoroutine = StartCoroutine("randomJalan"); }
            }
            
            if (GetComponent<Rigidbody>().useGravity == true)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().useGravity = false;
            }

            if(GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                Debug.Log("ZERO VELOCITY: "+name);
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        if (PlayerPrefs.GetString("level") == GetComponent<Cat>().level)
        {
            if(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")")!=null)
                if(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").gameObject.activeInHierarchy)
                    if (GetComponent<Rigidbody>().useGravity == false)
                    {
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                        GetComponent<Rigidbody>().useGravity = true;
                    }
        }

        if (GameObject.Find("PlayerSpawn").transform.childCount>0 && GetComponent<Rigidbody>().isKinematic == true && !picked)
            GameObject.Find("AISpawn").transform.Find(name).GetComponent<Rigidbody>().isKinematic = false;

    }

    [PunRPC]
    void gantipemilik()
    {
        CR_running = false;
    }

    [PunRPC]
    void ayamspawn(string namaayam, string levelayam)
    {
        name = namaayam;
        level = levelayam;
    }

    [PunRPC]
    void mintareqnama()
    {
        GetComponent<PhotonView>().RPC("ayamspawn", RpcTarget.Others, name, level);
    }

    void jalanNPC(Vector3 pos, string namaNPC)
    {
        if(PhotonNetwork.CurrentRoom.CustomProperties[namaNPC]!=null && GetComponent<PhotonView>().IsMine)
        if (PhotonNetwork.CurrentRoom.CustomProperties[namaNPC].ToString() == "jalan1" && Mathf.Abs(transform.position.x - pos.x) <= 0.5f && Mathf.Abs(transform.position.z - pos.z) <= 0.5f)
        {

            anim.SetBool("isWalking", false);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add(namaNPC, "");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
        }
        else
        if (PhotonNetwork.CurrentRoom.CustomProperties[namaNPC].ToString() == "jalan1" && !picked)
        {
            
            float step = 1 * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x,transform.position.y,pos.z), step);
            Vector3 direction = pos - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 3f);
            anim.SetBool("isWalking", true);
        }
    }

    IEnumerator randomJalan()
    {
        yield return new WaitUntil(() => PhotonNetwork.IsConnectedAndReady && PhotonNetwork.InRoom);
        CR_running = true;
        if (!GetComponent<PhotonView>().IsMine) yield break;
        System.Random rnd = new System.Random();
        int val = rnd.Next(0, 5); // range 0.0 to 1.0
        val -= 2;
        GetComponent<Cat>().pos.x = transform.position.x+val;
        GetComponent<Cat>().pos.y = transform.position.y;
        val = rnd.Next(0, 5);
        val -= 2;
        GetComponent<Cat>().pos.z = transform.position.z + val;

        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        if (CR_running == false) yield break;
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        System.Random rnd2 = new System.Random();
        GetComponent<PhotonView>().RPC("randomSound",RpcTarget.All,"idle", rnd2.Next(0, 100));
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name]!=null);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitForDone(2f, () => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        if(PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() != "" && name.Contains("Duck") || name.Contains("Chicken") || name.Contains("Cat"))
        {
            GetComponent<PhotonView>().RPC("randomSound", RpcTarget.All, "fly", rnd2.Next(0, 100));
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, rnd.Next(2, 7), GetComponent<Rigidbody>().velocity.z);
        }
        yield return new WaitForDone(2f, () => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        if (PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() != "")
        {
            val *= -1;
            GetComponent<Cat>().pos.x = transform.position.x + val;
            GetComponent<Cat>().pos.y = transform.position.y;
            GetComponent<Cat>().pos.z = transform.position.z + val;
            GetComponent<PhotonView>().RPC("randomSound", RpcTarget.All, "idle", rnd2.Next(0, 100));
        }
        yield return new WaitForSeconds(1f);
        if (PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() != "")
        {
            val = rnd.Next(0, 2);
            val *= -1;
            GetComponent<Cat>().pos.x = transform.position.x + val;
            GetComponent<Cat>().pos.y = transform.position.y;
            GetComponent<Cat>().pos.z = transform.position.z + val;
        }
        val = rnd.Next(0, 19);
        yield return new WaitForSeconds(val);
        StopAllCoroutines();
        NPCcoroutine = StartCoroutine("randomJalan");
    }

    [PunRPC]
    void randomSound(string action, int val2)
    {
        if(transform.GetChild(0).gameObject.activeInHierarchy)
        if (name.Contains("Duck") || name.Contains("Chicken") || name.Contains("Eko"))
        {
            if (action == "idle")
            {
                if (val2 < 30) idle1.Play();
                else if (val2 < 60) idle2.Play();
                else { idle1.Stop(); idle2.Stop(); }
            }
            else if (action == "fly")
            {
                if (val2 < 30) fly1.Play();
                else if (val2 < 60) fly2.Play();
                else { fly1.Stop(); fly2.Stop(); }
            }
        }else if (name.Contains("Cat") || name.Contains("Cow") || name.Contains("Goat") || name.Contains("Samsul"))
        {
            if (val2 < 10) idle1.Play();
            else if (val2 < 20) idle2.Play();
            else if (val2 < 30) idle3.Play();
            else if (val2 < 40) idle4.Play();
            else if (val2 < 50) idle5.Play();
            else { idle1.Stop(); idle2.Stop(); idle3.Stop(); idle4.Stop(); idle5.Stop(); }
        }
    }
}

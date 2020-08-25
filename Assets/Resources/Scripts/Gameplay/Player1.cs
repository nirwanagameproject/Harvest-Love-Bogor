using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviourPunCallbacks, IPunObservable
{
    [HideInInspector]
    public InputStr Inputs;

    public struct InputStr
    {
        public float LookX;
        public float LookZ;
        public float RunX;
        public float RunZ;
        public float JoystickX;
        public float JoystickXAttack;
        public float JoystickZ;
        public float JoystickZAttack;
        public Vector3 pmrPos;
        public Vector3 pmrRot;
        public bool Jump;
        public bool moving;
        public bool dead;
        public bool attacking;
        public bool attackingDPS;
        public bool Angkat;
        public string boxname;
        public bool angkatbox;
        public bool Crack;
        public bool EnterVehicle;
        public bool movingWithVehicle;
        public bool movingwithJoystick;
        public bool movingwithJoystick2;
        public bool movingwithNebeng;

    }

    protected bool Grounded;
    [SerializeField]
    public int maxWater;
    public int Speed;
    public string level;
    public bool destroy;
    public Player1 instance;
    bool walkingsound;

    public bool RotateAroundPlayer = true;
    private float rotSpeed = 5.0f;
    private Vector3 camOffset;
    private float smoothFactor = 0.5f;
    float xRot = 0f;
    float yRot = 0f;
    float h = 0f;
    float v = 0f;

    float diffX = 0;
    float diffY = 0;
    float diffZ = 0;

    void Awake()
    {
        instance = this;
        DontDestroyChildOnLoad(this.transform.gameObject);
        if (GetComponent<Controller>() != null && GetComponent<PhotonView>()!=null)
            if (!GetComponent<PhotonView>().IsMine && PhotonNetwork.IsConnected) Destroy(GetComponent<Controller>());
            else level = PlayerPrefs.GetString("level");
        
    }

    public void DontDestroyChildOnLoad(GameObject child)
    {
        if (instance.transform.parent != null)
        {
            if (instance.transform.parent.name != "TerrainLoadingMenu")
            {
                Transform parentTransform = child.transform;

                // If this object doesn't have a parent then its the root transform.
                while (parentTransform.parent != null)
                {
                    // Keep going up the chain.

                    parentTransform = parentTransform.parent;
                }
                GameObject.DontDestroyOnLoad(parentTransform.gameObject);
            }
        }
    }


    void Start()
    {
        /*if (!CustomMatchmakingLobbyCampaignController.instance.testjoin)
        {*/

            Speed = 4;
            Debug.Log("create player");

            if (PhotonNetwork.IsConnected)
                name = "Player (" + GetComponent<PhotonView>().Owner.NickName + ")";
            if (GameObject.Find("PlayerSpawn") != null)
            {
                transform.parent = GameObject.Find("PlayerSpawn").transform;
            }

            if (PhotonNetwork.IsConnected)
                if (GetComponent<PhotonView>().IsMine)
                {
                    Gamesetupcontroller.instance.GetComponent<PhotonView>().RPC("gantiWarna", RpcTarget.Others, name, GetComponent<PhotonView>().Owner.CustomProperties["gender"].ToString(),
                        (int)GetComponent<PhotonView>().Owner.CustomProperties["hairred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["hairgreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["hairblue"],
                        (int)GetComponent<PhotonView>().Owner.CustomProperties["clothred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["clothgreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["clothblue"],
                        (int)GetComponent<PhotonView>().Owner.CustomProperties["pantsred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["pantsgreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["pantsblue"],
                        (int)GetComponent<PhotonView>().Owner.CustomProperties["skinred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["skingreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["skinblue"],
                        PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("barangnama0"));
                }

        //}


        Vector3 pos = new Vector3();
        pos.x = transform.position.x - 3;
        pos.z = transform.position.z - 3;
        pos.y = transform.position.y + 3;

        //Camera.main.transform.position = pos;
        //Camera.main.transform.LookAt(pos);
        //Camera.main.transform.LookAt(transform);

        Camera.main.transform.RotateAround(transform.position,
                                 Camera.main.transform.up,
                                 0 * 360f * rotSpeed * Time.deltaTime);

        Camera.main.transform.RotateAround(transform.position,
                                 Camera.main.transform.right,
                                 0 * 360f * rotSpeed * Time.deltaTime);
        Camera.main.transform.LookAt(transform);

        diffX = 2.772013f;
        diffY = -3.644201f;
        diffZ = 2.456768f;

        camOffset = Camera.main.transform.position - transform.position;

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsConnected)
            if (GetComponent<PhotonView>().IsMine)
            {
                GetComponent<PhotonView>().RPC("gantiWarna", newPlayer, name, GetComponent<PhotonView>().Owner.CustomProperties["gender"].ToString(),
                    (int)GetComponent<PhotonView>().Owner.CustomProperties["hairred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["hairgreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["hairblue"],
                    (int)GetComponent<PhotonView>().Owner.CustomProperties["clothred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["clothgreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["clothblue"],
                    (int)GetComponent<PhotonView>().Owner.CustomProperties["pantsred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["pantsgreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["pantsblue"],
                    (int)GetComponent<PhotonView>().Owner.CustomProperties["skinred"], (int)GetComponent<PhotonView>().Owner.CustomProperties["skingreen"], (int)GetComponent<PhotonView>().Owner.CustomProperties["skinblue"],
                    PlayerPrefs.GetString("peralatannama0"), PlayerPrefs.GetString("barangnama0"));
            }
    }

    [PunRPC]
    void gantiWarna(string namaplayer, string gender, int h1, int h2, int h3, int cloth1, int cloth2, int cloth3, int pants1, int pants2, int pants3, int skin1, int skin2, int skin3, string peralatan, string barang)
    {
        /*if (!CustomMatchmakingLobbyCampaignController.instance.testjoin)
        {*/
            StartCoroutine(gantiWarna2(namaplayer, gender, h1, h2, h3, cloth1, cloth2, cloth3, pants1, pants2, pants3, skin1, skin2, skin3, peralatan, barang));
        //}
    }

    IEnumerator gantiWarna2(string namaplayer, string gender, int h1, int h2, int h3, int cloth1, int cloth2, int cloth3, int pants1, int pants2, int pants3, int skin1, int skin2, int skin3, string peralatan, string barang)
    {
        Debug.Log(namaplayer + " " + gender + " " + h1 + " " + h2 + " " + h3);
        //LOAD HAIR
        while (GameObject.Find("PlayerSpawn").transform.Find(namaplayer)==null) yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(namaplayer) != null);
        
        //while (GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body") == null) yield return new WaitUntil(() => GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body")!=null);
        int nomormat = 0;
        Color32 hair = new Color32((byte)h1, (byte)h2, (byte)h3, 255);
        Debug.Log("len : " + GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length);
        for (; nomormat < GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials.Length; nomormat++)
        {
            GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Hairs").Find("Hair001").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = hair;
        }

        //LOAD BAJU
        Color32 clothes = new Color32((byte)cloth1, (byte)cloth2, (byte)cloth3, 255);
        nomormat = 6;
        if (gender == "cewek") nomormat = 5;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = clothes;

        //LOAD CELANA
        Color32 pants = new Color32((byte)pants1, (byte)pants2, (byte)pants3, 255);
        nomormat = 4;
        if (gender == "cewek") nomormat = 6;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body").GetComponent<SkinnedMeshRenderer>().materials[nomormat].color = pants;

        //LOAD SKIN
        Color32 skin = new Color32((byte)skin1, (byte)skin2, (byte)skin3, 255);
        nomormat = 2;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body").GetComponent<SkinnedMeshRenderer>().materials[0].color = skin;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Body").GetComponent<SkinnedMeshRenderer>().materials[2].color = skin;
        if (gender == "cewek") GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Face").GetComponent<SkinnedMeshRenderer>().materials[7].color = skin;
        else GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Face").GetComponent<SkinnedMeshRenderer>().materials[5].color = skin;
        GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Face").GetComponent<SkinnedMeshRenderer>().materials[8].color = skin;

        //LOAD WEAPON
        GameObject myweapon = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
        for (int i = 0; i < myweapon.transform.childCount; i++)
            myweapon.transform.GetChild(i).gameObject.SetActive(false);
        myweapon.transform.Find(peralatan).gameObject.SetActive(true);

        StopCoroutine(gantiWarna2(namaplayer, gender, h1, h2, h3, cloth1, cloth2, cloth3, pants1, pants2, pants3, skin1, skin2, skin3, peralatan, barang));

    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RotateAroundPlayer = true;
        }
        
        if (Input.GetMouseButton(0) && RotateAroundPlayer)
        {
            h = rotSpeed * Input.GetAxis("Mouse X")* rotSpeed;
            v = rotSpeed * Input.GetAxis("Mouse Y")* rotSpeed;

            if (Camera.main.transform.eulerAngles.x-v <= 5.1f || Camera.main.transform.eulerAngles.x-v >= 79.9f)
                v = 0;

            Quaternion camTurnAngle = Quaternion.AngleAxis(h, Vector3.up);
            Quaternion camTurnAngle2 = Quaternion.AngleAxis(v, Vector3.right);

            camOffset = camTurnAngle * camTurnAngle2 * camOffset;


            Camera.main.transform.RotateAround(transform.position,
                                     Camera.main.transform.up,
                                     h);

            Camera.main.transform.RotateAround(transform.position,
                                     Camera.main.transform.right,
                                     -v);

            diffX = transform.position.x - Camera.main.transform.position.x;
            diffY = transform.position.y - Camera.main.transform.position.y;
            diffZ = transform.position.z - Camera.main.transform.position.z;

        }

        Vector3 pos = new Vector3();
        pos.x = transform.position.x - diffX;
        pos.y = transform.position.y - diffY;
        pos.z = transform.position.z - diffZ;

        Camera.main.transform.position = pos;

        Camera.main.transform.LookAt(transform);

        Vector3 newPos = transform.position + camOffset;

        //Camera.main.transform.position = newPos;
        //Camera.main.transform.LookAt(transform);
     }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (photonView.IsMine || !PhotonNetwork.IsConnected)
        {
        

            for(int i = 0; i < GameObject.Find("ItemSpawn").transform.childCount; i++)
            {
                if(GameObject.Find("ItemSpawn").transform.GetChild(i).GetComponent<Bale>()!=null)
                if (PlayerPrefs.GetString("level") == GameObject.Find("ItemSpawn").transform.GetChild(i).GetComponent<Bale>().level)
                {
                        GameObject.Find("ItemSpawn").transform.GetChild(i).gameObject.SetActive(true);
                }
                else GameObject.Find("ItemSpawn").transform.GetChild(i).gameObject.SetActive(false);
            }
            

        }

        if (Inputs.Jump)
        {
            if (PhotonNetwork.IsConnected)
                photonView.RPC("jump", RpcTarget.Others);
            Inputs.Jump = false;
            Grounded = Physics.OverlapSphere(transform.position, 0.3f, LayerMask.GetMask("Ground")).Length != 0;
            if (Grounded)
            {
                AudioSource audio = GameObject.Find("Clicked").transform.Find("jumping").GetComponent<AudioSource>();
                audio.Play();
                GetComponent<Animator>().SetBool("JumpStart", true);
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 6f, GetComponent<Rigidbody>().velocity.z);
            }
        }
        else
        {
            if (GetComponent<Rigidbody>().velocity.y > 3f) GetComponent<Animator>().SetBool("JumpEnd", true);
        }
        if (Inputs.attacking && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            Inputs.attacking = false;

        }

        if (Inputs.moving)
        {
            float mydistance = Vector3.Distance(Inputs.pmrPos, new Vector3(transform.position.x, Inputs.pmrPos.y, transform.position.z));
            if (mydistance > 0.01f)
            {
                GetComponent<Animator>().SetFloat("Speed", mydistance*12);
                Inputs.pmrPos.y = transform.position.y;
                Collider[] air = Physics.OverlapSphere(transform.position, 0.02f, LayerMask.GetMask("pond"));
                bool deketpond = air.Length != 0;

                if (deketpond) Speed = 2;
                else Speed = 4;

                transform.position = Vector3.MoveTowards(transform.position, Inputs.pmrPos, Speed * Time.deltaTime);
                transform.LookAt(Inputs.pmrPos);
                float kcepatan= 1f;
                if (kcepatan - mydistance*6 < 0.1f) kcepatan = 0.1f;
                else kcepatan = 1f - mydistance * 6;

                if (PhotonNetwork.IsConnected)
                {
                    if (photonView.IsMine)
                        if (!walkingsound)
                            StartCoroutine(suarakaki(kcepatan));
                }else if (!walkingsound) StartCoroutine(suarakaki(kcepatan));


            }
            else
            {
                
                GetComponent<Animator>().SetFloat("Speed", 0f);
                transform.position = Inputs.pmrPos;
                Inputs.moving = false;
            }

        }
        if (Inputs.JoystickX != 0 && Inputs.JoystickZ != 0 
            && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hoe")
             && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("WaterFill")
              && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("WaterPlant"))
        {
            float angle = Mathf.Atan2(Inputs.JoystickX, Inputs.JoystickZ) * Mathf.Rad2Deg;

            Vector3 dir =  Camera.main.transform.forward * Inputs.JoystickZ + Camera.main.transform.right * Inputs.JoystickX;

            Vector3 myvector = transform.position + dir * Speed * Time.deltaTime;
            if (Inputs.movingWithVehicle)
                myvector = new Vector3(transform.position.x + Inputs.JoystickX * Speed * 15 * Time.deltaTime, transform.position.y, transform.position.z + Inputs.JoystickZ * 15 * Speed * Time.deltaTime);

            Inputs.pmrPos = myvector;
            if (Vector3.Distance(Inputs.pmrPos, transform.position) > 0)
            {
                Vector3 pmrFront = new Vector3(Inputs.pmrPos.x, transform.position.y, Inputs.pmrPos.z);
                Quaternion tempRot = transform.rotation;

                transform.LookAt(new Vector3(Inputs.pmrPos.x, transform.position.y, Inputs.pmrPos.z));
                Inputs.pmrRot = transform.eulerAngles;

                Inputs.moving = true;
                Inputs.movingwithJoystick2 = true;
            }
        }
        else
        {
            GetComponent<Animator>().SetFloat("Speed", 0f);
            Inputs.moving = false;
        }
    }

    IEnumerator suarakaki(float kcepatan)
    {
        //Debug.Log(kcepatan);
        walkingsound = true;
        Collider[] air = Physics.OverlapSphere(transform.position, 0.02f, LayerMask.GetMask("pond"));
        bool deketpond = air.Length != 0;
        
        AudioSource audio = GameObject.Find("Clicked").transform.Find("walking").GetComponent<AudioSource>();
        if (deketpond) audio.clip = Resources.Load<AudioClip>("Audio/walkwater");
        else audio.clip = Resources.Load<AudioClip>("Audio/walking2"); 

        if(!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump_Start")
            && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump_Air")
            && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump_End"))
        audio.Play();
        yield return new WaitForSeconds(kcepatan);
        
        walkingsound = false;
    }

    [PunRPC]
    void jump()
    {
        Grounded = Physics.OverlapSphere(transform.position, 0.3f, LayerMask.GetMask("Ground")).Length != 0;
        if (Grounded)
        {
            GetComponent<Animator>().SetBool("JumpStart", true);
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 6f, GetComponent<Rigidbody>().velocity.z);
        }
    }


    [PunRPC]
    void gunaintools(string namaplayer, string alat,string action)
    {
        if (GameObject.Find("PlayerSpawn").transform.Find(namaplayer).gameObject.activeInHierarchy)
        {
            AudioSource audio = null;
            if(alat.Contains("peralatanbibit")) audio = GameObject.Find("Clicked").transform.Find("peralatanbibit" + "sound").GetComponent<AudioSource>();
            else audio = GameObject.Find("Clicked").transform.Find(alat + "sound").GetComponent<AudioSource>();
            audio.transform.position = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).transform.position;
            audio.Play();

            Collider[] air =  Physics.OverlapSphere(transform.position, 0.35f, LayerMask.GetMask("pond"));
            bool deketpond = air.Length != 0;
            if(deketpond)if (air[0].name == "river")
            {
                air = Physics.OverlapSphere(transform.position, 0f, LayerMask.GetMask("pond"));
                deketpond = air.Length != 0;
            }

            if (photonView.IsMine)
            {
                PlayerPrefs.SetInt("stamina", PlayerPrefs.GetInt("stamina") - 2);
                GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextStamina").GetComponent<Text>().text = "" + PlayerPrefs.GetInt("stamina");
            }

            //WATERING
            if (namaplayer == name && deketpond && action == "watering")
            {
                GetComponent<Animator>().SetBool("WaterFillStart", true);
                audio.Stop();
                audio = GameObject.Find("Clicked").transform.Find("fillwater" + "sound").GetComponent<AudioSource>();
                audio.transform.position = GameObject.Find("PlayerSpawn").transform.Find(namaplayer).transform.position;
                audio.Play();
                if (photonView.IsMine)
                {
                    PlayerPrefs.SetInt("peralatanjumlah0", maxWater);
                    GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah0");
                    GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").GetChild(0).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah0");

                }
            }
            else
            if (namaplayer == name && action == "watering")
            {
                Debug.Log(PlayerPrefs.GetInt("peralatanjumlah0"));
                if (PlayerPrefs.GetInt("peralatanjumlah0") > 0)
                {
                    GameObject myweapon = transform.Find("Root").Find("J_Bip_C_Hips").Find("J_Bip_C_Spine").Find("J_Bip_C_Chest").Find("J_Bip_C_UpperChest").Find("J_Bip_R_Shoulder").Find("J_Bip_R_UpperArm").Find("J_Bip_R_LowerArm").Find("J_Bip_R_Hand").Find("weapon").gameObject;
                    myweapon.transform.Find("watering").Find("airkeluar").GetComponent<ParticleSystem>().Play();
                
                if (photonView.IsMine)
                {
                    PlayerPrefs.SetInt("peralatanjumlah0", PlayerPrefs.GetInt("peralatanjumlah0") - 1);
                    GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonToolsAxe").Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah0");
                    GameObject.Find("Canvas").transform.Find("Bag").Find("BGAtas").Find("tools").GetChild(0).Find("Text").GetComponent<Text>().text = "X " + PlayerPrefs.GetInt("peralatanjumlah0");
                    
                }
                
                    GetComponent<Animator>().SetBool("WaterPlantStart", true);
                    Collider[] lahantani = Physics.OverlapSphere(GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("AreaPacul").transform.position, 0.1f, LayerMask.GetMask("ditanam"));

                    if (alat == "watering" && Physics.OverlapSphere(GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("AreaPacul").transform.position, 0.1f, LayerMask.GetMask("lahantani")).Length != 0
                     && lahantani.Length != 0)
                    {
                        if (photonView.IsMine)
                        {
                            GameObject mylahanbaru = lahantani[0].transform.parent.gameObject;
                            GameObject go = lahantani[0].transform.parent.gameObject;

                            if (go.name.Contains("terpacul") || go.name.Contains("tanahbibit"))
                            {
                                go.transform.Find("lahan").gameObject.SetActive(false);
                                go.transform.Find("lahansiram").gameObject.SetActive(true);
                            }
                            else return;

                            Collider[] dalemlahan = Physics.OverlapSphere(go.transform.position, 0.03f, LayerMask.GetMask("lahantani"));
                            bool benergadidalem = dalemlahan.Length != 0;
                            if (benergadidalem)
                            {
                                string namalahan = "";
                                string lahan = "";

                                ExitGames.Client.Photon.Hashtable setLahan = new ExitGames.Client.Photon.Hashtable();
                                string[] splitArray = go.name.Split(char.Parse("_"));
                                setLahan.Add("lahancangkulsiram" + splitArray[1], true);
                                PhotonNetwork.CurrentRoom.SetCustomProperties(setLahan);

                                namalahan = go.name;
                                GetComponent<PhotonView>().RPC("paculan", RpcTarget.Others, namaplayer, Int32.Parse(splitArray[1]), go.GetComponent<customgrid>().truepos.x, go.GetComponent<customgrid>().truepos.y, go.GetComponent<customgrid>().truepos.z, lahan, namalahan, "yes");
                                //Destroy(mylahanbaru);
                            }

                        }
                    }
                }

            }
            else if (alat.Contains("peralatanbibit")) GetComponent<Animator>().SetBool("WaterPlantStart", true);
            else GetComponent<Animator>().SetBool("HoeStart", true);

            //CANGKUL
            if (alat == "hoe" && Physics.OverlapSphere(GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("AreaPacul").transform.position, 0.1f, LayerMask.GetMask("lahantani")).Length != 0
                 && Physics.OverlapSphere(GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("AreaPacul").transform.position, 0.1f, LayerMask.GetMask("ditanam")).Length == 0)
            {
                if (photonView.IsMine)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>("Images/Lahan/LahanCangkul"), GameObject.Find("PlayerSpawn").transform.Find(namaplayer).Find("AreaPacul").transform.position, Quaternion.identity);
                    go.GetComponent<customgrid>().gridding();
                    go.transform.parent = GameObject.Find("SawahSpawn").transform;
                    
                    Collider[] dalemlahan = Physics.OverlapSphere(go.transform.position, 0.03f, LayerMask.GetMask("lahantani"));
                    bool benergadidalem = dalemlahan.Length != 0;
                    if (benergadidalem)
                    {
                        ExitGames.Client.Photon.Hashtable setLahan = new ExitGames.Client.Photon.Hashtable();
                        int i = 0;
                        for (; i < i + 1; i++)
                        {
                            if (PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulnama" + i] == null || PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulnama" + i].ToString() == "")
                            {
                                setLahan.Add("lahancangkulnama" + i, "terpacul_"+i);
                                setLahan.Add("lahancangkulsiram" + i, false);
                                setLahan.Add("lahancangkulposx" + i, go.GetComponent<customgrid>().truepos.x);
                                setLahan.Add("lahancangkulposy" + i, go.GetComponent<customgrid>().truepos.y);
                                setLahan.Add("lahancangkulposz" + i, go.GetComponent<customgrid>().truepos.z);
                                break;
                            }

                        }
                        go.name = "terpacul_" + i;
                        PhotonNetwork.CurrentRoom.SetCustomProperties(setLahan);

                        GetComponent<PhotonView>().RPC("paculan", RpcTarget.Others, namaplayer, i, go.GetComponent<customgrid>().truepos.x, go.GetComponent<customgrid>().truepos.y, go.GetComponent<customgrid>().truepos.z, "LahanCangkul", "terpacul_","no");
                    }
                    else
                    {
                        Destroy(go);
                    }
                    
                }
                
            }

            //BIBIT
            if (alat.Contains("peralatanbibit"))
            {
                if (photonView.IsMine)
                {
                    

                    List<Vector3> directional = new List<Vector3>();
                    Vector3 tengah = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    Vector3 ataskanan = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                    Vector3 ataskiri = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
                    Vector3 bawahkiri = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                    Vector3 bawahkanan = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
                    directional.Add(tengah);
                    directional.Add(ataskanan);
                    directional.Add(ataskiri);
                    directional.Add(bawahkiri);
                    directional.Add(bawahkanan);

                    Vector3 atas = new Vector3(transform.position.x+1f, transform.position.y, transform.position.z+1f);
                    Vector3 bawah = new Vector3(transform.position.x-1f, transform.position.y, transform.position.z - 1f);
                    Vector3 kanan = new Vector3(transform.position.x+1f, transform.position.y, transform.position.z - 1f);
                    Vector3 kiri = new Vector3(transform.position.x-1f, transform.position.y, transform.position.z + 1f);
                    directional.Add(atas);
                    directional.Add(bawah);
                    directional.Add(kanan);
                    directional.Add(kiri);

                    for(int j = 0; j < directional.Count; j++)
                    {
                        Collider[] lahantani = Physics.OverlapSphere(directional[j], 0.02f, LayerMask.GetMask("ditanam"));
                        if (Physics.OverlapSphere(directional[j], 0.1f, LayerMask.GetMask("lahantani")).Length != 0
                         && lahantani.Length != 0)
                        {
                            if (photonView.IsMine)
                            {
                                GameObject mylahanbaru = lahantani[0].transform.parent.gameObject;
                                GameObject go = null;
                                Debug.Log("berhasil ga = " + mylahanbaru.name);
                                if (mylahanbaru.name.Contains("terpacul")) go = Instantiate(Resources.Load<GameObject>("Images/Lahan/LahanCangkulBibit"), mylahanbaru.transform.position, Quaternion.identity);
                                else continue;
                                go.GetComponent<customgrid>().gridding();
                                go.transform.parent = GameObject.Find("SawahSpawn").transform;

                                Collider[] dalemlahan = Physics.OverlapSphere(go.transform.position, 0.03f, LayerMask.GetMask("lahantani"));
                                bool benergadidalem = dalemlahan.Length != 0;
                                if (benergadidalem)
                                {
                                    string namalahan = "";
                                    string lahan = "";
                                    string namabuah = "";
                                    bool renewable = false;
                                    int maxumur= 10;
                                    int maxumurberbuah = 10;
                                    string season = "";

                                    lahan = "LahanCangkulBibit";
                                    namalahan = "tanahbibit_";

                                    if (alat.Contains("peralatanbibit1"))
                                    {
                                        namabuah = "Tomat";
                                        renewable = true;
                                        maxumur = 2;
                                        maxumurberbuah = 3;
                                        season = "Spring";
                                    }

                                    ExitGames.Client.Photon.Hashtable setLahan = new ExitGames.Client.Photon.Hashtable();
                                    string[] splitArray = mylahanbaru.name.Split(char.Parse("_"));
                                    setLahan.Add("lahancangkulnama" + splitArray[1], namalahan + splitArray[1]);
                                    setLahan.Add("lahancangkulbuah" + splitArray[1], namabuah);

                                    setLahan.Add("lahancangkulumurberbuah" + splitArray[1], maxumurberbuah);
                                    setLahan.Add("lahancangkulmaxumurberbuah" + splitArray[1], maxumurberbuah);

                                    setLahan.Add("lahancangkulumur" + splitArray[1], 1);
                                    setLahan.Add("lahancangkulmaxumur" + splitArray[1], maxumur);

                                    setLahan.Add("lahancangkulrenewable" + splitArray[1], renewable);
                                    setLahan.Add("lahancangkulseason" + splitArray[1], season);
                                    setLahan.Add("lahancangkulmati" + splitArray[1], 1);
                                    setLahan.Add("lahancangkulposx" + splitArray[1], go.GetComponent<customgrid>().truepos.x);
                                    setLahan.Add("lahancangkulposy" + splitArray[1], go.GetComponent<customgrid>().truepos.y);
                                    setLahan.Add("lahancangkulposz" + splitArray[1], go.GetComponent<customgrid>().truepos.z);
                                            
                                    go.name = namalahan + splitArray[1];
                                    PhotonNetwork.CurrentRoom.SetCustomProperties(setLahan);

                                    if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulsiram" + splitArray[1]])
                                    {
                                        go.transform.Find("lahan").gameObject.SetActive(false);
                                        go.transform.Find("lahansiram").gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        go.transform.Find("lahan").gameObject.SetActive(true);
                                        go.transform.Find("lahansiram").gameObject.SetActive(false);
                                    }

                                    GetComponent<PhotonView>().RPC("paculan", RpcTarget.Others, namaplayer, Int32.Parse(splitArray[1]), go.GetComponent<customgrid>().truepos.x, go.GetComponent<customgrid>().truepos.y, go.GetComponent<customgrid>().truepos.z, lahan, namalahan, "no");
                                    Debug.Log("destroy = " + mylahanbaru.name);
                                    DestroyImmediate(mylahanbaru);
                                }
                                else
                                {
                                    DestroyImmediate(go);
                                }
                            }
                        }

                        //GameObject go = Instantiate(Resources.Load<GameObject>("Images/Lahan/LahanCangkulBibit"), directional[i], Quaternion.identity);
                        //go.GetComponent<customgrid>().gridding();
                        //go.transform.parent = GameObject.Find("SawahSpawn").transform;
                    }
                    
                }

            }
        }
    }

    [PunRPC]
    public void OrangJoin(string newPlayer)
    {
        GameObject.Find("Canvas").transform.Find("TextNotif").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("TextNotif").GetComponent<Text>().text = newPlayer + " bergabung dalam permainan";
    }

    [PunRPC]
    void paculan(string namaplayer, int i, float x, float y, float z,string lahan,string namalahan, string siram)
    {
        if (namaplayer == name && gameObject.activeInHierarchy && siram=="no")
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("Images/Lahan/"+lahan), new Vector3(x,y,z), Quaternion.identity);
            go.transform.parent = GameObject.Find("SawahSpawn").transform;
            go.name = namalahan + i;
            if(lahan!= "LahanCangkul") DestroyImmediate(GameObject.Find("SawahSpawn").transform.Find("terpacul_"+i).gameObject);

            if ((bool)PhotonNetwork.CurrentRoom.CustomProperties["lahancangkulsiram" + i])
            {
                go.transform.Find("lahan").gameObject.SetActive(false);
                go.transform.Find("lahansiram").gameObject.SetActive(true);
            }
            else
            {
                go.transform.Find("lahan").gameObject.SetActive(true);
                go.transform.Find("lahansiram").gameObject.SetActive(false);
            }
        }
        else if (namaplayer == name && gameObject.activeInHierarchy && siram=="yes")
        {
            GameObject go = GameObject.Find("SawahSpawn").transform.Find(namalahan).gameObject;
            go.transform.Find("lahan").gameObject.SetActive(false);
            go.transform.Find("lahansiram").gameObject.SetActive(true);
        }
    }

    [PunRPC]
    void addBale(string NamePlayer, string namaobjitem, string mylevel)
    {
        GameObject go = GameObject.Find(namaobjitem);
        go.GetComponent<Rigidbody>().isKinematic = true;

        go.transform.parent = GameObject.Find("PlayerSpawn").transform.Find(NamePlayer).Find("AreaPegang").transform;
        //go.transform.rotation = GameObject.Find("PlayerSpawn").transform.Find(NamePlayer).rotation;
        go.name = "Item";

        if (go.GetComponent<Bale>() != null)
        go.GetComponent<Bale>().level = mylevel;

    }

    [PunRPC]
    void pickBale(string NamePlayer, string namaobjitem, string mylevel)
    {
        GameObject go = GameObject.Find(namaobjitem);

        string[] splitString = go.name.Split(new string[] { "bale" }, System.StringSplitOptions.None);
        int bbale = System.Convert.ToInt32(splitString[1]);

        int banyakBale = System.Convert.ToInt32((PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"]));

        for (int n = bbale; n <= banyakBale; n++)
        {
            GameObject.Find("ItemSpawn").transform.Find("bale" + n).name = "bale" + (n - 1);
        }

        go.GetComponent<Rigidbody>().isKinematic = true;

        go.transform.parent = GameObject.Find("PlayerSpawn").transform.Find(NamePlayer).Find("AreaPegang").transform;
        go.transform.position = GameObject.Find("PlayerSpawn").transform.Find(NamePlayer).Find("AreaPegang").transform.position;
        go.transform.eulerAngles = GameObject.Find("PlayerSpawn").transform.Find(NamePlayer).Find("AreaPegang").transform.eulerAngles;
        //go.transform.rotation = GameObject.Find("PlayerSpawn").transform.Find(NamePlayer).rotation;
        go.name = "Item";

        go.GetComponent<Bale>().drop = 0;
        go.GetComponent<Bale>().CancelInvoke("destroyself");
        go.GetComponent<Bale>().cek = 1;
        go.GetComponent<Bale>().destroying = false;

        PlayerPrefs.DeleteKey("buttonPickBale");

        

        if (go.GetComponent<Bale>() != null)
            go.GetComponent<Bale>().level = mylevel;

    }
    [PunRPC]
    void deleteBale(int bbale)
    {
        Debug.Log(bbale);
        int banyakBale = System.Convert.ToInt32((PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"]));

        for (int n = bbale; n <= banyakBale; n++)
        {
            GameObject.Find("ItemSpawn").transform.Find("bale" + n).name = "bale" + (n - 1);
        }
        if (PlayerPrefs.GetString("buttonPickBale") == "bale" + bbale)
        {
            PlayerPrefs.DeleteKey("buttonPickBale");
        }
        banyakBale = System.Convert.ToInt32((PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"]));
        for (int n = 1; n <= banyakBale-1; n++)
        {
            GameObject.Find("ItemSpawn").transform.Find("bale" + (n)).GetComponent<Bale>().cek = 1;
        }
    }
    [PunRPC]
    void dropBale(string namaPlayer, string namabarang)
    {
        int jumlahPakan = 0;
        for (int n = 0; n < 10;n++)
        {
            if (System.Convert.ToBoolean(PhotonNetwork.CurrentRoom.CustomProperties["box" + n]))
            {
                jumlahPakan++;
            }
        }
        GameObject goob = GameObject.Find("PlayerSpawn").transform.Find(namaPlayer).Find("AreaPegang").Find("Item").gameObject;
        goob.GetComponent<Bale>().drop = 1;
        GameObject.Find("PlayerSpawn").transform.Find(namaPlayer).Find("AreaPegang").Find("Item").parent = GameObject.Find("ItemSpawn").transform;
        GameObject.Find("ItemSpawn").transform.Find("Item").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.Find("ItemSpawn").transform.Find("Item").name = namabarang + PhotonNetwork.CurrentRoom.CustomProperties["ItemCount"].ToString();
        ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
        int i = 0;
        for (; i < i + 1; i++)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["ItemDrop" + i] == null || PhotonNetwork.CurrentRoom.CustomProperties["ItemDrop" + i].ToString() == "")
            {
                setValue.Add("ItemDrop" + i, i);
                break;
            }

        }
        PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Inputs.RunX);
            stream.SendNext(Inputs.RunZ);
            stream.SendNext(Inputs.moving);
            stream.SendNext(Inputs.Crack);
            stream.SendNext(Inputs.pmrPos.x);
            stream.SendNext(Inputs.pmrPos.y);
            stream.SendNext(Inputs.pmrPos.z);
            stream.SendNext(Inputs.pmrRot.x);
            stream.SendNext(Inputs.pmrRot.y);
            stream.SendNext(Inputs.pmrRot.z);
            //stream.SendNext(name);
            //stream.SendNext(transform.parent.name);
            stream.SendNext(Inputs.LookX);
            stream.SendNext(Inputs.LookZ);
            stream.SendNext(Inputs.Angkat);
            stream.SendNext(Inputs.boxname);
            stream.SendNext(Inputs.angkatbox);
            stream.SendNext(Inputs.JoystickX);
            stream.SendNext(Inputs.JoystickZ);
            stream.SendNext(Inputs.JoystickXAttack);
            stream.SendNext(Inputs.JoystickZAttack);
            stream.SendNext(level);

        }
        else
        {
            Inputs.RunX = (float)stream.ReceiveNext();
            Inputs.RunZ = (float)stream.ReceiveNext();
            Inputs.moving = (bool)stream.ReceiveNext();
            Inputs.Crack = (bool)stream.ReceiveNext();
            Inputs.pmrPos.x = (float)stream.ReceiveNext();
            Inputs.pmrPos.y = (float)stream.ReceiveNext();
            Inputs.pmrPos.z = (float)stream.ReceiveNext();
            Inputs.pmrRot.x = (float)stream.ReceiveNext();
            Inputs.pmrRot.y = (float)stream.ReceiveNext();
            Inputs.pmrRot.z = (float)stream.ReceiveNext();
            //name = (string)stream.ReceiveNext();
            //transform.parent = GameObject.Find((string)stream.ReceiveNext()).transform;
            Inputs.LookX = (float)stream.ReceiveNext();
            Inputs.LookZ = (float)stream.ReceiveNext();
            Inputs.Angkat = (bool)stream.ReceiveNext();
            Inputs.boxname = (string)stream.ReceiveNext();
            Inputs.angkatbox = (bool)stream.ReceiveNext();
            Inputs.JoystickX = (float)stream.ReceiveNext();
            Inputs.JoystickZ = (float)stream.ReceiveNext();
            Inputs.JoystickXAttack = (float)stream.ReceiveNext();
            Inputs.JoystickZAttack = (float)stream.ReceiveNext();
            level = (string)stream.ReceiveNext();


            
        }
    }

}

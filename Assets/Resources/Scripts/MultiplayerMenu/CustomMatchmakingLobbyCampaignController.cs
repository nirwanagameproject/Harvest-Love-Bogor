using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomMatchmakingLobbyCampaignController : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //private GameObject lobbyConnectButton; //button used for joining a Lobby.
    [SerializeField]
    private GameObject lobbyPanel; //panel for displaying lobby.
    [SerializeField]
    private GameObject notifpanel; //panel for displaying lobby.
    /*[SerializeField]
    private GameObject mainPanel; //panel for displaying the main menu
    [SerializeField]
    private GameObject loginPanel; //panel for displaying the main menu
    [SerializeField]
    private InputField playerNameInput; //Input field so player can change their NickName

    [SerializeField]
    private GameObject notifpanel; //panel for displaying the main menu
    [SerializeField]
    private GameObject loadingpanel; //panel for displaying the main menu
    */

    private string roomName; //string for saving room name
    private int roomSize; //int for saving room size

    public List<RoomInfo> roomListings; //list of current rooms
    public List<RoomInfo> tempRoomListings;
    [SerializeField]
    private Transform roomsContainer; //container for holding all the room listings
    public Transform tempRoomsContainer;
    [SerializeField]
    private GameObject roomListingPrefab; //prefab for displayer each room in the lobby

    public bool exitlobby;

    public float waktu;
    public bool sudahjoin;
    public bool sudahroom;
    public bool testjoin;
    public bool mulaites;
    public bool awalites;
    public bool methodJoinAwal;
    public bool methodLeftAwal;
    public bool konekMaster;
    public string namaRoom;
    public int indexku;
    public List<bool> redejoin;
    public List<bool> rederoom;
    public int awals;

    public static CustomMatchmakingLobbyCampaignController instance = null;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        sudahjoin = false;
        sudahroom = false;
        konekMaster = false;
        testjoin = true;
        mulaites = false;
        awalites = false;
        methodJoinAwal = true;
        methodLeftAwal = true;
        redejoin = new List<bool>();
        rederoom = new List<bool>();
        awals = 0;
        //Debug.Log("MY USERNAME" + PlayerPrefs.GetString("Username"));
        //PhotonNetwork.NickName = PlayerPrefs.GetString("Username");

        //FirstConnect();
    }

    public void Update()
    {
        /*waktu += Time.deltaTime;

        if(waktu >= 3)
        {
            if (redejoin != null)
            {
                Debug.Log(redejoin.Count);
                bool sudh = false;
                for (int i = 0; i < redejoin.Count; i++)
                {
                    if (redejoin.Count > 0)
                    {
                        Debug.Log("Join Ruang"+ redejoin[i]);
                        Debug.Log("Sudah Join : " + sudahjoin);
                        if((konekMaster && sudahjoin && !awalites && methodJoinAwal))
                        {
                            Debug.Log("Berhasil Join Ruang");
                            PhotonNetwork.JoinRoom(tempRoomListings[i].Name);
                            methodJoinAwal = false;
                        }
                        if ((konekMaster && sudahjoin && PhotonNetwork.IsConnectedAndReady && redejoin[i]))
                        {
                            Debug.Log("Berhasil Join Ruang");
                            PhotonNetwork.JoinRoom(tempRoomListings[i].Name);
                        }
                        if (sudahroom && !awalites && methodLeftAwal)
                        {
                            Debug.Log("Berhasil Left Ruang");
                            TinggalkanRuangan(i);
                            methodLeftAwal = false;
                        }
                        if ((sudahroom && PhotonNetwork.IsConnectedAndReady && rederoom[i]) )
                        {
                            Debug.Log("Berhasil Left Ruang");
                            TinggalkanRuangan(i);
                        }
                        sudh = true;
                    }
                }
                if (sudh)
                {
                    awals = 0;
                }
            }
            waktu = 0;
        }*/
    }


    private IEnumerator GabungRuangan(int i)
    {
        yield return new WaitForSeconds(0.01f);
        PhotonNetwork.JoinRoom(tempRoomListings[i].Name);
    }

    private void TinggalkanRuangan(int i)
    {
        //yield return new WaitForSeconds(0.75f);
        if (!PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                Debug.Log("Room Name :" + PhotonNetwork.CurrentRoom.Name);
                Debug.Log("Room List Name :" + tempRoomListings[i].Name);
                Debug.Log("Room Stat :" + PhotonNetwork.CurrentRoom.CustomProperties["online"]);
                if (PhotonNetwork.CurrentRoom.Name == tempRoomListings[i].Name && !(bool)PhotonNetwork.CurrentRoom.CustomProperties["online"])
                {
                    Debug.Log("Room Status :" + tempRoomListings[i].Name);

                    tempRoomListings.RemoveAt(i);
                    if (awals != 0)
                    {
                        DestroyImmediate(roomsContainer.GetChild(i).gameObject);
                    }
                }
            }
            PhotonNetwork.LeaveRoom();
        }
    }

    public void FirstConnect() //Callback function for when the first connection is established successfully.
    {
        PhotonNetwork.GameVersion = "v1.0";
        //PhotonNetwork.AutomaticallySyncScene = true; //Makes it so whatever scene the master client has loaded is the scene all other clients will load
        //lobbyConnectButton.SetActive(true); //activate button for connecting to lobby
        //loadingpanel.SetActive(false);
        roomListings = new List<RoomInfo>(); //initializing roomListing
        tempRoomListings = new List<RoomInfo>(); //initializing roomListing

        roomName = "";
        roomSize = 4;
        ClearRoomListings();
        roomListings.Clear();

        notifpanel.SetActive(false);

        //check for player name saved to player prefs
        if (PlayerPrefs.HasKey("NickName"))
        {
            if (PlayerPrefs.GetString("NickName") == "")
            {
                PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000); //random player name when not set
            }
            else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString("NickName"); //get saved player name
                PhotonNetwork.LocalPlayer.CustomProperties["character"] = PlayerPrefs.GetString("Character"); //get saved player name
            }
        }
        else
        {
            PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000); //random player name when not set
        }

        if (PhotonNetwork.IsConnectedAndReady)
            PhotonNetwork.JoinLobby(); //First tries to join a lobby
    }

    public void FirstConnect2() //Callback function for when the first connection is established successfully.
    {
        PhotonNetwork.GameVersion = "v1.0";
        //PhotonNetwork.AutomaticallySyncScene = true; //Makes it so whatever scene the master client has loaded is the scene all other clients will load
        //lobbyConnectButton.SetActive(true); //activate button for connecting to lobby
        //loadingpanel.SetActive(false);

        Debug.Log("Mulai Baru");

        roomName = "";
        roomSize = 4;

        mulaites = false;

        ClearRoomListings();
        roomListings.Clear();

        notifpanel.SetActive(false);

        //check for player name saved to player prefs
        if (PlayerPrefs.HasKey("NickName"))
        {
            if (PlayerPrefs.GetString("NickName") == "")
            {
                PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000); //random player name when not set
            }
            else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString("NickName"); //get saved player name
                PhotonNetwork.LocalPlayer.CustomProperties["character"] = PlayerPrefs.GetString("Character"); //get saved player name
            }
        }
        else
        {
            PhotonNetwork.NickName = "Player " + UnityEngine.Random.Range(0, 1000); //random player name when not set
        }

        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinLobby(); //First tries to join a lobby
        }
    }


    void ClearRoomListings()
    {
        for (int i = roomsContainer.childCount - 1; i >= 0; i--) //loop through all child object of the playersContainer, removing each child
        {

            DestroyImmediate(roomsContainer.GetChild(i).gameObject);
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Sukses Konek ke Master");
        konekMaster = true;
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby berhasil dimuat");
        if (sudahjoin == false)
        {

        }
        else
        {
            redejoin[awals] = true;
        }
        sudahjoin = true;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room berhasil dimuat");
        if (sudahroom == false)
        {

        }
        else
        {
            rederoom[awals] = true;
            awals++;
        }
        sudahroom = true;
        Debug.Log("Room berhasil dimuat (finish)");
    }

    public override void OnJoinRoomFailed(short returnCode,string message)
    {
        Debug.Log(message);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Player meninggalkan room");
        /*for(int i = 0; i < redejoin.Count; i++)
        {
            redejoin[i] = false;
            rederoom[i] = false;
        }
        awalites = true;
        konekMaster = false;*/
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);

        Debug.Log("Meninggalkan Online Multiplayer");
        sudahjoin = false;
        sudahroom = false;
        konekMaster = false;
        testjoin = true;
        mulaites = false;
        awalites = false;
        methodJoinAwal = true;
        methodLeftAwal = true;
        redejoin.Clear();
        rederoom.Clear();
        awals = 0;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) //Once in lobby this function is called every time there is an update to the room list
    {
        int tempIndex;

        foreach (RoomInfo room in roomList) //loop through each room in room list
        {
            if(room.PlayerCount == 0)
            {
                Debug.Log("Batal "+ GameObject.Find("Canvas").transform.Find("JoinGamePilihKarakter").gameObject.active);
                if (GameObject.Find("Canvas").transform.Find("JoinGamePilihKarakter").gameObject.active == true)
                {
                    GameObject.Find("Canvas").transform.Find("JoinGamePilihKarakter").gameObject.SetActive(false);
                }
                tempIndex = roomListings.FindIndex(ByName(room.Name));
                roomListings.RemoveAt(tempIndex);
                DestroyImmediate(roomsContainer.GetChild(tempIndex).gameObject);
            }
            if (room.CustomProperties.ContainsKey("campaign"))
            {
                if ((int)room.CustomProperties["campaign"] == 2020)
                {

                    if (roomListings != null) //try to find existing room listing
                    {
                        tempIndex = roomListings.FindIndex(ByName(room.Name));
                    }
                    else
                    {
                        tempIndex = -1;
                    }
                    if (room.PlayerCount > 0) //add room listing because it is new
                    {
                        //roomListings.Add(room);
                        ListRoom(room);

                        // Debug.Log("CREATE ROOM");
                    }
                    else
                    {
                        roomListings.RemoveAt(tempIndex);
                        DestroyImmediate(roomsContainer.GetChild(tempIndex).gameObject);
                    }
                    if (tempIndex != -1) //remove listing because it has been closed
                    {
                        if ((roomsContainer.childCount) != 0)
                        {
                            //roomListings.RemoveAt(tempIndex);
                            //DestroyImmediate(roomsContainer.GetChild(tempIndex).gameObject);
                        }
                        //Debug.Log("DESTROY ROOM");
                    }
                }
            }



        }
    }


    static System.Predicate<RoomInfo> ByName(string name) //predicate function for seach through room list
    {
        return delegate (RoomInfo room)
        {
            return room.Name == name;
        };
    }

    void ListRoom(RoomInfo room) //displays new room listing for the current room
    {
        if (room.IsOpen && room.IsVisible && (int)room.CustomProperties["campaign"] == 2020)
        {
            bool cocok = false;
            for(int i = 0; i < roomListings.Count; i++)
            {
                if(roomListings[i].Name == room.Name)
                {
                    cocok = true;
                    roomsContainer.GetChild(i).GetComponent<RoomButton>().SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
                }
            }
            if (!cocok)
            {
                GameObject tempListing = Instantiate(roomListingPrefab, roomsContainer);
                RoomButton tempButton = tempListing.GetComponent<RoomButton>();
                tempButton.SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
                roomListings.Add(room);
            }
            /*for (int i = 0; i < roomListings.Count; i++)
            {
                tempRoomListings.Add(roomListings[i]);
                redejoin.Add(false);
                rederoom.Add(false);
            }
            if (!mulaites)
            {
                ClearRoomListings();
                roomListings.Clear();

                mulaites = true;
            }*/
        }
    }

    public void RoomNameInputChanged(string nameIn) //input function for changing room name. paired to room name input field
    {
        roomName = nameIn;
    }
    public void OnRoomSizeInputChanged(string sizeIn) //input function for changing room size. paired to room size input field
    {
        roomSize = int.Parse(sizeIn);
    }

    //Permainan Baru
    public void CreateRoomOnClick() //function paired to the create room button
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        PhotonNetwork.NickName = PlayerPrefs.GetString("myname");

        if (PhotonNetwork.NetworkClientState.ToString() != "JoiningLobby")
        {
            if (roomName == "" || roomName == null) roomName = "Kebun "+PlayerPrefs.GetString("mykebun")+" - "+PlayerPrefs.GetString("myname") + " (" + PlayerPrefs.GetInt("tanggal")+" "+PlayerPrefs.GetString("musim")+" "+PlayerPrefs.GetInt("tahun")+")";
            Debug.Log("Creating room now " + roomName + "-" + PhotonNetwork.NickName);

            //PhotonNetwork.CreateRoom(chosenLevel, true, true, 10, customPropertiesToSet, customPropertiesForLobby);

            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = false, MaxPlayers = (byte)roomSize, BroadcastPropsChangeToAll = true };
            //TypedLobby typedLobby = new TypedLobby() { Name = "campaign", Type = LobbyType.Default };
            roomOps.CustomRoomPropertiesForLobby = new string[] { "campaign", "ai", "tanggal", "musim", "tahun", "jam", "detik" };
            roomOps.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "campaign", 2020 } , { "tanggal", PlayerPrefs.GetInt("tanggal") }, { "musim", PlayerPrefs.GetString("musim") }, { "tahun", PlayerPrefs.GetInt("tahun") }
            , { "jam", PlayerPrefs.GetString("jam") }, { "detik", PlayerPrefs.GetString("detik") }};
            PhotonNetwork.CreateRoom(roomName, roomOps); //attempting to create a new room

            if (PhotonNetwork.CurrentRoom == null)
            {
                notifpanel.SetActive(true);
                notifpanel.transform.Find("BotNotif").transform.Find("NotifTunggu").gameObject.SetActive(true);
                notifpanel.transform.Find("BotNotif").transform.Find("IsiNotif").gameObject.SetActive(false);
                notifpanel.transform.Find("BotNotif").transform.Find("Button").gameObject.SetActive(false);
            }
        }

    }

    public override void OnCreateRoomFailed(short returnCode, string message) //create room will fail if room already exists
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
        notifpanel.SetActive(true);
        notifpanel.transform.Find("BotNotif").transform.Find("NotifTunggu").gameObject.SetActive(false);
        notifpanel.transform.Find("BotNotif").transform.Find("ButtonOK").gameObject.SetActive(false);
        notifpanel.transform.Find("BotNotif").transform.Find("IsiNotif").GetComponent<Text>().text = "Gagal membuat room, coba lagi nanti.";
        notifpanel.transform.Find("BotNotif").transform.Find("IsiNotif").gameObject.SetActive(true);
        notifpanel.transform.Find("BotNotif").transform.Find("Button").gameObject.SetActive(true);
    }

    public void gagalOKcreateroom()
    {
        notifpanel.transform.Find("BotNotif").transform.Find("NotifTunggu").gameObject.SetActive(true);
        notifpanel.transform.Find("BotNotif").transform.Find("IsiNotif").gameObject.SetActive(false);
        notifpanel.transform.Find("BotNotif").transform.Find("Button").gameObject.SetActive(false);
        notifpanel.SetActive(false);
    }



    public void MatchmakingCancelOnClick() //Paired to the cancel button. Used to go back to the main menu
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();
        //lobbyPanel.SetActive(false);
        //PhotonNetwork.LeaveLobby();
        //PhotonNetwork.Disconnect();
        MyConnection.Instance.ingame = false;

        SceneManager.LoadScene("Campaign");
    }

    public void NotifOnClickOK() //Paired to the cancel button. Used to go back to the main menu
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        notifpanel.transform.Find("BotNotif").transform.Find("NotifTunggu").gameObject.SetActive(true);
        notifpanel.transform.Find("BotNotif").transform.Find("IsiNotif").gameObject.SetActive(false);
        notifpanel.transform.Find("BotNotif").transform.Find("Button").gameObject.SetActive(false);
        notifpanel.SetActive(false);
    }

}
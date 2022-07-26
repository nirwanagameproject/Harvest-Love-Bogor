using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{

    [SerializeField]
    private Text nameText; //display for room name
    [SerializeField]
    private Text sizeText; //display for room size

    public GameObject notifpanel;

    private string roomName; //string for saving room name
    private int roomSize; //int for saving room size
    private int playerCount;

    void Awake()
    {
        notifpanel = GameObject.Find("Canvas").transform.Find("JoinGamePilihKarakter").gameObject;
    }

    public void JoinRoomOnClick() //paired the button that is the room listing. joins the player a room by its name
    {
        MainMenuController.instance.roomName = roomName;
        notifpanel.SetActive(true);
        CustomMatchmakingLobbyCampaignController.instance.testjoin = false;
        MainMenuController.instance.GantiBahasa();
    }

    public void SetRoom(string nameInput, int sizeInput, int countInput) //public function called in CMM lobby contoller for each new room listing created
    {
        roomName = nameInput;
        roomSize = sizeInput;
        playerCount = countInput;
        nameText.text = nameInput;
        sizeText.text = countInput + "/" + sizeInput;
    }
}

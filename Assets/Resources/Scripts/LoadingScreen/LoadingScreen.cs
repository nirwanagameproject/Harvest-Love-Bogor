using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadingScreen : MonoBehaviourPunCallbacks
{

    public Text textloading;

    private AsyncOperation async = null; // When assigned, load is in progress.
    private IEnumerator LoadALevel(string levelName)
    {
        async = SceneManager.LoadSceneAsync(levelName);
        yield return async;
    }

    private IEnumerator TextLoading()
    {
        yield return new WaitForSeconds(0.5f);
        if(textloading.text== "Loading") textloading.text = "Loading.";
        else if(textloading.text== "Loading.") textloading.text = "Loading..";
        else if(textloading.text== "Loading..") textloading.text = "Loading...";
        else if(textloading.text== "Loading...") textloading.text = "Loading";
        StartCoroutine(TextLoading());
    }

    void Start()
    {
        //if (PlayerPrefs.HasKey("ActScene"))
        //    PhotonNetwork.AutomaticallySyncScene = false;
        //completedPlayer = 0;
        if (GameObject.Find("Canvas") != null)
        {
            GameObject transisi = GameObject.Find("Canvas").transform.Find("Transisi").gameObject;
            transisi.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        }
        Debug.Log("level : "+PlayerPrefs.GetString("level"));

        Input.ResetInputAxes();
        if(GameObject.Find("Canvas") != null)
        {
            GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();
        }
        if (PlayerPrefs.GetString("level") == "KeluarRumah") StartCoroutine(LoadALevel("GameplayFarm"));
        else if (PlayerPrefs.GetString("level") == "MasukRumah") StartCoroutine(LoadALevel("GameplayHome"));
        else if (PlayerPrefs.GetString("level") == "MasukKandangAyam") StartCoroutine(LoadALevel("GameplayChickenHouse"));
        else if (PlayerPrefs.GetString("level") == "MenuAwal")
        {
            
            GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

            for (int i = 0; i < GameObjects.Length; i++)
            {
                if (GameObjects[i].name != "PhotonMono" && GameObjects[i].name != "[Debug Updater]" && GameObjects[i].tag != "Transisi")
                    Destroy(GameObjects[i]);
            }
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
            //Menghapus List Room
            /*
            if (PhotonNetwork.IsConnected)
            {
                Debug.Log("Offline Room");
                for (int i = 0; i < CustomMatchmakingLobbyCampaignController.instance.roomListings.Count; i++)
                {
                    if (PhotonNetwork.CurrentRoom.Name == CustomMatchmakingLobbyCampaignController.instance.roomListings[i].Name)
                    {

                        ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable();
                        hash.Add("online", false);
                        PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
                    }
                }
            }*/

            StartCoroutine(LoadALevel("LoadingMenu"));
            
        }
        else
        {
            StartCoroutine(LoadALevel(PlayerPrefs.GetString("level")));
        }
        StartCoroutine(TextLoading());
    }

    void FixedUpdate()
    {
        //loadAmountText.text = ((int)(PhotonNetwork.LevelLoadingProgress * 100) + " %");
        //progressBar.fillAmount = PhotonNetwork.LevelLoadingProgress;
        
    }

    /*IEnumerator LoadLevelAsync()
    {
        //if (PlayerPrefs.HasKey("ActScene")) PhotonNetwork.LoadLevel(PlayerPrefs.GetString("ActScene"));
        //if (PlayerPrefs.HasKey("ActScene")) PhotonNetwork.LoadLevel("Act3");
        //else PhotonNetwork.LoadLevel(1);
        while (SceneManager.LevelLoadingProgress < 1)
        {
            yield return new WaitForEndOfFrame();
        }

    }*/
}

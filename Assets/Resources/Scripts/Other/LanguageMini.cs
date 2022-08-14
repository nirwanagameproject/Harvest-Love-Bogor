using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageMini : MonoBehaviour
{
    public static LanguageMini instance = null;
    public List<string> bahasaID;
    public List<string> bahasaUS;
    public List<string> bahasaJP;
    public string answer = "";
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        bahasa();

    }

    private void bahasa()
    {

        //Translate Bahasa Indonesia
        bahasaID = new List<string>();
        bahasaID.Add("Hai "); //0
        bahasaID.Add("Ada yang bisa aku bantu? oh kamu yang punya kebun itu ya. Aku Mini, anaknya pak eko penjual ternak ayam"); //1
        bahasaID.Add("Bapakku sudah tiada dan ibuku di desa lain, jadi aku sendiri yang mengurus ayam-ayam disini"); //2
        bahasaID.Add("Silahkan jika ingin membeli sesuatu ?"); //3
        bahasaID.Add("Beli"); //4
        bahasaID.Add("Jual"); //5
        bahasaID.Add("Silahkan pilih ayam atau bebek mana yang kamu suka"); //6
        bahasaID.Add("Silahkan pilih sapi atau kambing mana yang ingin kamu jual"); //7
        bahasaID.Add("Mantap, jangan lupa beri nama biar kamu tidak lupa"); //8
        bahasaID.Add("Kasih nama hewan yang lain juga ya"); //9
        bahasaID.Add("Makasih udah beli disini, nanti aku akan antarkan ke kandangmu"); //10
        bahasaID.Add("Tiap senin, rabu, jumat aku selalu pergi ke pasar untuk beli kebutuhan"); //11

        //Translate Bahasa Inggris
        bahasaUS = new List<string>();
        bahasaUS.Add("Hello "); //0
        bahasaUS.Add("Is there anything I can help? oh you who own the farm huh. I'm Mini, Mr. Eko's daughter who the chicken seller"); //1
        bahasaUS.Add("I always take good care of the cows and goats here. Watch out your livestock carefully."); //2
        bahasaUS.Add("Do you want to buy something ?"); //3
        bahasaUS.Add("Buy"); //4
        bahasaUS.Add("Sell"); //5
        bahasaUS.Add("Please choose which chicken or duck you like"); //6
        bahasaUS.Add("Please choose which chicken or duck you want to sell"); //7
        bahasaUS.Add("Awesome, let's give the name"); //8
        bahasaUS.Add("Let's give name to another one"); //9
        bahasaUS.Add("Thanks for buying, later I will deliver it to your farm"); //10
        bahasaUS.Add("Every Monday, Wednesday, Friday I always go to the market to buy daily needs"); //11

        //Translate Bahasa Jepang
        bahasaJP = new List<string>();
        bahasaJP.Add("こんにちは "); //0
        bahasaJP.Add("何かお手伝いできることはありますか？ああ、農場を所有しているあなた。鶏肉売りのエコさんの娘、ミニです"); //1
        bahasaJP.Add("私はいつもここで牛と山羊の世話をしています。家畜に注意してください。"); //2
        bahasaJP.Add("何か買いたいですか？"); //3
        bahasaJP.Add("買う"); //4
        bahasaJP.Add("売る"); //5
        bahasaJP.Add("お好きなチキン・ダックをお選びください"); //6
        bahasaJP.Add("販売したいチキンまたはアヒルを選択してください"); //7
        bahasaJP.Add("素晴らしい、名前を付けましょう"); //8
        bahasaJP.Add("別のものに名前を付けましょう"); //9
        bahasaJP.Add("購入していただきありがとうございます、後であなたの農場に配達します"); //10
        bahasaJP.Add("毎週月曜日、水曜日、金曜日、私はいつも日用品を買いに市場に行きます"); //11

    }

    [PunRPC]
    void talkSamaanHaiDulu(int indexsatu, int indexdua)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(indexsatu, name) + PhotonNetwork.NickName + ", " + ChangeLanguage.instance.GetLanguageNPC(indexdua, name), true);
    }

    [PunRPC]
    void talkSamaan(int indexsatu)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(indexsatu, name), true);
    }

    [PunRPC]
    void endPercakapanSemua()
    {
        endPercakapan();
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);

    }

    [PunRPC]
    void setWidthTextDialog(float width)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<RectTransform>().sizeDelta = new Vector2(width, GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<RectTransform>().sizeDelta.y);
    }

    [PunRPC]
    void setActiveGameobject(string namaobject,bool aktifga)
    {
        GameObject.Find("Canvas").transform.Find(namaobject).gameObject.SetActive(aktifga);
    }

    [PunRPC]
    void setActiveGameobjectChild(string parentobject,string namaobject, bool aktifga)
    {
        GameObject.Find("Canvas").transform.Find(parentobject).Find(namaobject).gameObject.SetActive(aktifga);
    }

    public IEnumerator NPCMikaJalan()
    {
        yield return new WaitUntil(() => PhotonNetwork.IsConnectedAndReady && PhotonNetwork.InRoom);

        yield return new WaitUntil(() => PhotonNetwork.IsMasterClient);
        //DAILY EVENT
        Debug.Log(name+" JALAN 1");
        GetComponent<NPC>().pos.x = 6.63f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 7.7f;
        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name + "Jualan", false);
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 6.65f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 1.86f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 4.84f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 0.23f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");

        //PINDAH KE PETERNAKAN
        GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "Peternakan");
        transform.position = new Vector3(26.92f, 0.2685457f, 21.91f);
        GetComponent<NPC>().pos.x = 25.825f;
        GetComponent<NPC>().pos.y = 0.2685457f;
        GetComponent<NPC>().pos.z = 20.794f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 25.228f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 20.156f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 27.15f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 13.75f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        GetComponent<NPC>().pos.x = 23.43f;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 11.2f;
        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        if(PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString()=="Senin" ||
            PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Rabu" ||
            PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "jumat")
        {
            GetComponent<NPC>().pos.x = 26.17f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 15.67f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 19.33f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 23.61f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 18.74f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 37.61f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");

            //PINDAH KE PERSIMPANGAN JALAN MAU KE PASAR
            GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "PersimpanganJalan");
            transform.position = new Vector3(7.15f, 0, -5.61f);
            GetComponent<NPC>().pos.x = 8.88f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 6.67f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 21.4f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 8.52f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");

            //PINDAH KE PASAR
            GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "Toko");
            transform.position = new Vector3(0, 0, 13.04f);
            GetComponent<NPC>().pos.x = 7.83f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 16.96f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            yield return new WaitUntil(() => int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) >= 12);

            //PULANG KE RUMAH DARI PASAR
            GetComponent<NPC>().pos.x = 4.7f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 14.96f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 0.37f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 12.84f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");

            //PINDAH KE PERSIMPANGAN JALAN LAGI
            GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "PersimpanganJalan");
            transform.position = new Vector3(21.89f, 0, 9.29f);
            GetComponent<NPC>().pos.x = 9.02f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 6.99f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 8.02f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = -5.32f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            //PINDAH KE PETERNAKAN LAGI
            GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "Peternakan");
            transform.position = new Vector3(19.16f, 0, 37.79f);
            GetComponent<NPC>().pos.x = 21.28f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 23.81f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 25.01f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 20.85f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 26.15f;
            GetComponent<NPC>().pos.y = 0.2f;
            GetComponent<NPC>().pos.z = 21.33f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 27.65f;
            GetComponent<NPC>().pos.y = 0.2f;
            GetComponent<NPC>().pos.z = 22.36f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            //PINDAH KE RUMAH EKO
            GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "RumahEko");
            transform.position = new Vector3(4.84f, 0, 0);
            GetComponent<NPC>().pos.x = 6.69f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 2.36f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 6.69f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 10.33f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            StartCoroutine(randomJalanDiKamar());
            //transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else
        {
            StartCoroutine(randomJalanDepanRumahMini());
        }
        //setProperti = new ExitGames.Client.Photon.Hashtable();
        //setProperti.Add(name + "Jualan", false);
        //PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        //StartCoroutine(randomJalanDepanRumahMini());
        
    }

    IEnumerator randomJalanDiKamar()
    {
        System.Random rnd = new System.Random();
        int val = rnd.Next(4, 8); // range 0.0 to 1.0
        GetComponent<NPC>().pos.x = val;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 10.33f;

        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        yield return new WaitForSeconds(5f);
        StartCoroutine(randomJalanDiKamar());
    }

    IEnumerator randomJalanDepanRumahMini()
    {
        System.Random rnd = new System.Random();
        int val = rnd.Next(22, 31); // range 0.0 to 1.0
        GetComponent<NPC>().pos.x = val;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = rnd.Next(11, 14);

        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitForDone(10f, () => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
        yield return new WaitForSeconds(5f);
        if(int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) >= 10 &&
            int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) <= 12)
        {
            //OTW RUMAH EKO
            GetComponent<NPC>().pos.x = 25.01f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 20.85f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 26.15f;
            GetComponent<NPC>().pos.y = 0.2f;
            GetComponent<NPC>().pos.z = 21.33f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 27.65f;
            GetComponent<NPC>().pos.y = 0.2f;
            GetComponent<NPC>().pos.z = 22.36f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            //PINDAH KE RUMAH EKO
            GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "RumahEko");
            transform.position = new Vector3(4.84f, 0, 0);
            GetComponent<NPC>().pos.x = 9.23f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 1.8f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            GetComponent<NPC>().pos.x = 9.23f;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 3.25f;
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "jalan1");
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties[name].ToString() == "");
            transform.eulerAngles = new Vector3(0,-90,0);
            setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name+"Jualan", true);
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        }
        else if(int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) >= 6 &&
            int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString()) < 10)
        {
            StartCoroutine(randomJalanDepanRumahMini());
        }
    }

    void lagiNanya()
    {
        Gamesetupcontroller.instance.minFoV = true;
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<FixedJoystick>().ResetAxis();

        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + name);
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("NamaNPC").GetComponent<Text>().text = name;
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);

        if (PhotonNetwork.IsMasterClient)
        {
            GameObject.Find(name).GetComponent<PhotonView>().RPC("melihatYgNanya", RpcTarget.All, name, PhotonNetwork.NickName);
            ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
            custom.Add("nanyaNPC" + name, PhotonNetwork.LocalPlayer.NickName);
            PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        }
        
    }

    void endPercakapan()
    {
        GameObject.Find("Canvas").transform.Find("Fixed Joystick").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("UIKiri").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").gameObject.SetActive(true);

        Gamesetupcontroller.instance.maxFoV = true;

        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().exitpercakapan(true);
        GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, PlayerPrefs.GetString("buttonNPC"), false);

        ExitGames.Client.Photon.Hashtable custom = new ExitGames.Client.Photon.Hashtable();
        custom.Add("nanyaNPC" + PlayerPrefs.GetString("buttonNPC"), "");
        PhotonNetwork.CurrentRoom.SetCustomProperties(custom);
        PlayerPrefs.DeleteKey("buttonNPC");
    }

    //NANYA BIASA
    public IEnumerator nanyaFriendship()
    {
        //SET BUTTON
        GameObject button1 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button1").Find("Text").gameObject;
        GameObject button2 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button2").Find("Text").gameObject;
        GameObject button3 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").Find("Text").gameObject;
        MyDialogBag myDialogBag = GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>();
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = true;
        if (PlayerPrefs.GetInt(name + "Kenalan") == 1)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName +", "+ ChangeLanguage.instance.GetLanguageNPC(1, name), false);
            PlayerPrefs.SetInt(name + "Kenalan", 0);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
        }else
        if (PlayerPrefs.GetInt(name + "Friendship") < 20)
        {
            //NANYA JUALAN
            if ((bool)PhotonNetwork.CurrentRoom.CustomProperties[name + "Jualan"])
            {
                GetComponent<NPC>().sedangditanya = true;
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("ButtonTurnOff").gameObject.SetActive(false);
                GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(3, name), true);
                button1.GetComponent<Text>().text = button1.GetComponent<ChangeLanguage>().GetLanguageNPC(4,name);
                makeAnswerPas(button1);
                button2.GetComponent<Text>().text = button2.GetComponent<ChangeLanguage>().GetLanguageNPC(5,name);
                makeAnswerPas(button2);
                button3.GetComponent<Text>().text = button3.GetComponent<ChangeLanguage>().GetLanguage(107);
                makeAnswerPas(button3);
                Debug.Log("JAWABAN BUTTON 1 : "+ button1.GetComponent<ChangeLanguage>().GetLanguageNPC(4, name));
                yield return new WaitUntil(() => answer != "");
                if (answer == "yes")
                {
                    answer = "";
                    GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(6, name), false);
                    yield return new WaitForSeconds(2f);
                    GameObject.Find("Canvas").transform.Find("PoultryShop").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
                    for (int i = 4; i < GameObject.Find("Canvas").transform.Find("UIkanan").childCount; i++)
                        GameObject.Find("Canvas").transform.Find("UIkanan").GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    answer = "";
                    GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(7, name), true);
                    yield return new WaitForSeconds(2f);
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").gameObject.SetActive(true);
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonFarm").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonNeighbor").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ButtonCow").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
                    GameObject.Find("Canvas").transform.Find("ButtonBwhKanan").Find("ButtonJump").GetComponent<buttonController>().clickProfileStatsPoultry();
                    GameObject.Find("Canvas").transform.Find("UIkanan").gameObject.SetActive(true);
                    for (int i = 4; i < GameObject.Find("Canvas").transform.Find("UIkanan").childCount; i++)
                        GameObject.Find("Canvas").transform.Find("UIkanan").GetChild(i).gameObject.SetActive(false);
                    for (int i = 0; i < GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).childCount; i++)
                    {
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("health").gameObject.SetActive(false);
                        GameObject.Find("Canvas").transform.Find("ProfileStatus").Find("ScrollViewPoultry").GetChild(0).GetChild(0).GetChild(i).Find("Accept").gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                if(PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString()=="Senin" ||
                PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "Rabu" ||
                PhotonNetwork.CurrentRoom.CustomProperties["hari"].ToString() == "jumat")
                {
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(11, name), false);
                }
                else
                {
                    GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                    ChangeLanguage.instance.GetLanguageNPC(2, name), false);
                }
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt(name+"Friendship") < 40)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(21, name), false);
            button1.GetComponent<Text>().text = ChangeLanguage.instance.GetLanguageNPC(29, name);
            makeAnswerPas(button1);
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes") myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(2, name), false);
            else if (answer == "no")
            {
                System.Random rnd = new System.Random();
                int randomInt = rnd.Next(3, 5);
                myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(randomInt, name), false);
            }
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
        else if (PlayerPrefs.GetInt(name + "Friendship") < 60)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(22, name), false);
            button1.GetComponent<Text>().text = ChangeLanguage.instance.GetLanguageNPC(30, name);
            makeAnswerPas(button1);
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes") myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(26, name), false);
            else if (answer == "no")
            {
                System.Random rnd = new System.Random();
                int randomInt = rnd.Next(27, 29);
                myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(randomInt, name), false);
            }
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
        else if (PlayerPrefs.GetInt(name + "Friendship") < 80)
        {
            button1.GetComponent<Text>().text = ChangeLanguage.instance.GetLanguageNPC(31, name);
            makeAnswerPas(button1);
            
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(23, name), false);
            Debug.Log("JAWABAN: "+button1.GetComponent<Text>().text+" - "+ ChangeLanguage.instance.GetLanguageNPC(31, name));
            
            yield return new WaitUntil(() => answer != "");
            if (answer == "yes") myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(26, name), false);
            else if (answer == "no")
            {
                System.Random rnd = new System.Random();
                int randomInt = rnd.Next(27, 29);
                myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(randomInt, name), false);
            }
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
        else if (PlayerPrefs.GetInt(name + "Friendship") <= 100)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(24, name), false);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
    }

    public IEnumerator BeliSapi(bool kedua)
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        int talking = 8;
        if (kedua) talking = 9;
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
        ChangeLanguage.instance.GetLanguageNPC(talking, name), true);
        yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(true);
    }

    public IEnumerator EndBuy()
    {
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().gabisadipencet = false;
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
        ChangeLanguage.instance.GetLanguageNPC(10, name), true);
        yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
        GameObject.Find("Canvas").transform.Find("DialogBG").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").GetChild(2).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("PoultryShop").Find("GiveName").gameObject.SetActive(false);
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("PoultryShop").Find("ScrollViewItem").GetChild(0).GetChild(0).childCount; i++)
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("ScrollViewItem").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("PoultryShop").Find("ScrollViewDuck").GetChild(0).GetChild(0).childCount; i++)
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("ScrollViewDuck").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        for (int i = 0; i < GameObject.Find("Canvas").transform.Find("PoultryShop").Find("ScrollViewChicken").GetChild(0).GetChild(0).childCount; i++)
            GameObject.Find("Canvas").transform.Find("PoultryShop").Find("ScrollViewChicken").GetChild(0).GetChild(0).GetChild(i).Find("InputField").GetComponent<InputField>().text = "";
        PlayerPrefs.SetInt("buyChicken", 0);
        PlayerPrefs.SetInt("buyDuck", 0);
        PlayerPrefs.SetInt("buyBale", 0);
    }

    [PunRPC]
    void EatGiftRpc(string namaplayer,string level)
    {
        AudioSource audio = GameObject.Find("Clicked").transform.Find("eating").GetComponent<AudioSource>();
        audio.transform.position = GameObject.Find("PlayerSpawn").transform.Find("Player ("+namaplayer+")").transform.position;
        audio.Play();
        StartCoroutine(PlusStamina(namaplayer, level));
        if (PhotonNetwork.IsMasterClient)StartCoroutine(EatGift(namaplayer,level));
    }

    IEnumerator EatGift(string namaplayer, string level)
    {
        GameObject item = PhotonNetwork.Instantiate(System.IO.Path.Combine("Model/Item/Prefab", "cake"), GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").Find("AreaPegang").transform.position, GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").rotation);
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").GetComponent<PhotonView>().RPC("addBale", RpcTarget.All, "Player (" + namaplayer + ")", item.name, level);
        yield return new WaitForSeconds(5f);
        PhotonNetwork.Destroy(item);
    }
    IEnumerator PlusStamina(string namaplayer, string level)
    {
        GameObject.Find("Clicked").transform.Find("Heart").gameObject.SetActive(true);
        GameObject.Find("Clicked").transform.Find("Heart").transform.position = GameObject.Find("PlayerSpawn").transform.Find("Player (" + namaplayer + ")").transform.position;
        yield return new WaitForSeconds(2f);
        GameObject.Find("Clicked").transform.Find("Heart").gameObject.SetActive(false);
    }

    void makeAnswerPas(GameObject button1)
    {
        if(button1.GetComponent<Text>().preferredWidth > 150)
        button1.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(button1.GetComponent<Text>().preferredWidth + 5f, button1.transform.parent.GetComponent<RectTransform>().sizeDelta.y);
        else button1.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, button1.transform.parent.GetComponent<RectTransform>().sizeDelta.y);
    }
}

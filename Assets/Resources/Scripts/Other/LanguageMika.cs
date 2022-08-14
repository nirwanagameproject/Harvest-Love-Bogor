using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageMika : MonoBehaviour
{
    public static LanguageMika instance = null;
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
        bahasaID.Add(", apa kebunmu baik-baik saja ?"); //1
        bahasaID.Add("Syukurlah aku ikut senang... hehe"); //2
        bahasaID.Add("Jangan menyerah, kamu pasti bisa!"); //3
        bahasaID.Add("Perlahan-lahan saja pasti bisa kok"); //4
        bahasaID.Add("kenalin yaaa. Nama aku Mika :)"); //5
        bahasaID.Add("Aku disini punya tanah yang dibeli oleh orang tua kamu. Tetapi orang tua kamu hanya sanggup mencicilnya."); //6
        bahasaID.Add("Sekarang aku kasih kesempatan ke kamu untuk membayar sebagian hutang orang tua kamu dan membuat lahan ini menjadi terawat."); //7
        bahasaID.Add("Jangan sungkan untuk bersosialisasi kepada orang di desa sini, karena mereka dapat membantumu untuk memenuhi kebutuhan lahan."); //8
        bahasaID.Add("Nah sekarang apakah kamu ingin melihat tutorial?"); //9
        bahasaID.Add("Ok, semangat mengembangkan lahan ini ya. Di luar ada Ayu yang akan membeli produk kamu sehari-hari dan menjalankan beberapa misi."); //10
        bahasaID.Add("Ini adalah 3 tombol untuk melompat, memilih perkakas, dan tombol tangan untuk melakukan aksi jika ada tanda kotak \"?\" berbentuk kubus"); //11
        bahasaID.Add("Ini adalah tombol misi untuk mendapatkan hadiah atau pencapaian story"); //12
        bahasaID.Add("Tombol pengaturan untuk mengatur besar/kecil volume dan musik, grafik, ruangan publik atau hanya teman, dan lain-lain"); //13
        bahasaID.Add("Tombol tas untuk melihat perkakas dan barang yang ada didalam tas"); //14
        bahasaID.Add("Tombol peta untuk melihat lokasi anda dan teman anda berada pada peta di desa"); //15
        bahasaID.Add("Jika kamu dalam mode online, ini adalah mata uang kelereng untuk berbelanja barang spesial dan ekslusif"); //16
        bahasaID.Add("Mata uang koin dapat diperoleh dalam menyelesaikan misi atau menjual produk, bisa ditukar dengan berbagai barang kebutuhan lahan"); //17
        bahasaID.Add("Bentuk hati yaitu stamina dalam melakukan pekerjaan melalui perkakas, dapat diperoleh dari beristirahat"); //18
        bahasaID.Add("Tanggal dan waktu serta musim saat ini"); //19
        bahasaID.Add("Ok, sekarang kamu paham kan"); //20
        bahasaID.Add(", apa keadaanmu baik-baik saja ? jangan terlalu berlebihan ya dalam mengelola lahan."); //21
        bahasaID.Add(", bagaimana keadaan kebunmu ? Jangan terlalu cape ya."); //22
        bahasaID.Add(", aku harap kebunmu berkembang dengan pesat. Apa kebunmu baik-baik saja ?"); //23
        bahasaID.Add(", semangat ya menjalankan kewajiban kamu teman :)"); //24
        bahasaID.Add("Karena kamu sangat baik. Ini ada kue spesial untukmu, dapat menjaga stamina dengan baik"); //25
        bahasaID.Add("Sepertinya kamu sangat suka sekali bertani dan berternak yahh.. Semangat!"); //26
        bahasaID.Add("Jangan terlalu dipaksakan.. Semangat!"); //27
        bahasaID.Add("Suatu saat kamu akan terbiasa.. Semangat!"); //8
        bahasaID.Add("Aku baik-baik saja kok"); //29
        bahasaID.Add("Tidak cape kok"); //30
        bahasaID.Add("Kebunku sudah membaik"); //31
        bahasaID.Add("Kebunku biasa saja"); //32

        //Translate Bahasa Inggris
        bahasaUS = new List<string>();
        bahasaUS.Add("Hello "); //0
        bahasaUS.Add(", How is your farm ?"); //1
        bahasaUS.Add("I'm gladly to hear that.. hehe"); //2
        bahasaUS.Add("Don't give up, you can do it!"); //3
        bahasaUS.Add("Just do it slowly but surely"); //4
        bahasaUS.Add("Let me introduce myself. I'm Mika :)"); //5
        bahasaUS.Add("I own the farm land before your parents. Unfortunately your parents didn't pay enough for the price i give."); //6
        bahasaUS.Add("Now I give you the opportunity to pay some of your parent's debts and make this farm land fruitful."); //7
        bahasaUS.Add("Don't hesitate to socialize with people in this village, because they can help you meet your land needs."); //8
        bahasaUS.Add("So now do you want to see a tutorial?"); //9
        bahasaUS.Add("Ok, keep your spirit for developing this land. At Outside there is people called Ayu who will buy your daily products and carry out several quests."); //10
        bahasaUS.Add("These are 3 buttons for jumping, selecting tools and hand buttons for performing an action if there is a square \"?\" in the shape of a cube"); //11
        bahasaUS.Add("This is the mission button to get rewards or progress story"); //12
        bahasaUS.Add("Settings buttons to adjust volume and music, graphics, public rooms or just friends etc"); //13
        bahasaUS.Add("Bag button to see tools and items in the bag"); //14
        bahasaUS.Add("Map button to see where you and your friends are on the map in the village"); //15
        bahasaUS.Add("If you are in online mode, this is the currency marbles for buying any special and exclusive items"); //16
        bahasaUS.Add("Coin currency can be obtained in completing missions or selling products, can be exchanged for various land necessities"); //17
        bahasaUS.Add("Heart shape is stamina in doing work through tools, can be obtained from resting"); //18
        bahasaUS.Add("Current date and time and season"); //19
        bahasaUS.Add("Ok, now you understand right"); //20
        bahasaUS.Add(", are you okay ? Don't be too excessive in managing the farm."); //21
        bahasaUS.Add(", how is your farm ? Don't be excessive."); //22
        bahasaUS.Add(", I hope your farm so well my friend. How is your farm now ?"); //23
        bahasaUS.Add(", keep your hardwork of carrying out your obligations friend :)"); //24
        bahasaUS.Add("Because you are so kind. Here is a special cake for you, this item maintain stamina well"); //25
        bahasaUS.Add("Looks like you really like farming and raising livestock.. Cheer up!"); //26
        bahasaUS.Add("Don't be too over.. Cheer up!"); //27
        bahasaUS.Add("Someday you will love it.. Cheer up!"); //28
        bahasaUS.Add("I'm okay"); //29
        bahasaUS.Add("I'm not tired actually"); //30
        bahasaUS.Add("My farm going well"); //31
        bahasaUS.Add("My farm is ok"); //32

        //Translate Bahasa Jepang
        bahasaJP = new List<string>();
        bahasaJP.Add("こんにちは "); //0
        bahasaJP.Add("あなたの農場はどうですか ?"); //1
        bahasaJP.Add("それを聞いてうれしいです.."); //2
        bahasaJP.Add("あきらめないでください、あなたはそれをすることができます!"); //3
        bahasaJP.Add("ゆっくりですが確実にやってください"); //4
        bahasaJP.Add("自己紹介します。ミカです"); //5
        bahasaJP.Add("私はあなたの両親の前に農地を所有しています。残念ながら、あなたの両親は私が与える価格に対して十分に支払っていませんでした。"); //6
        bahasaJP.Add("今、私はあなたにあなたの親の借金の一部を支払い、この農地を実りあるものにする機会を与えます。"); //7
        bahasaJP.Add("彼らはあなたの土地のニーズを満たすのを助けることができるので、この村の人々と交流することを躊躇しないでください。"); //8
        bahasaJP.Add("では、チュートリアルを見たいですか？"); //9
        bahasaJP.Add("さて、この土地を開発するためのあなたの精神を保ちます。アウトサイドには、あなたの日用品を購入し、いくつかのクエストを実行する「アユ」と呼ばれる人々がいます。"); //10
        bahasaJP.Add("これらは、ジャンプするための3つのボタン、ツールを選択するためのボタン、および立方体の形をした正方形の「？」がある場合にアクションを実行するためのハンドボタンです。"); //11
        bahasaJP.Add("これは、報酬や進捗ストーリーを取得するためのミッションボタンです。"); //12
        bahasaJP.Add("音量や音楽、グラフィック、パブリックルーム、または友達などを調整するための設定ボタン。"); //13
        bahasaJP.Add("バッグ内のツールやアイテムを表示するためのバッグボタン。"); //14
        bahasaJP.Add("あなたとあなたの友人が村の地図上のどこにいるかを確認するための地図ボタン。"); //15
        bahasaJP.Add("オンラインモードの場合、これは特別で排他的なアイテムを購入するための通貨ビー玉です。"); //16
        bahasaJP.Add("コイン通貨は、ミッションの完了や製品の販売で取得でき、さまざまな土地の必需品と交換できます。"); //17
        bahasaJP.Add("ハートの形は道具を使って仕事をする際のスタミナであり、休息から得ることができます。"); //18
        bahasaJP.Add("現在の日時と季節。"); //19
        bahasaJP.Add("わかりました、今あなたは正しく理解しています。"); //20
        bahasaJP.Add("、私の友達は大丈夫ですか？農場の管理に過度になりすぎないでください"); //21
        bahasaJP.Add("、あなたの農場は私の友達はどうですか？過度にしないでください。"); //22
        bahasaJP.Add("、あなたの農場が繁栄することを願っています。あなたの農場は今どうですか？"); //23
        bahasaJP.Add("、あなたの義務を遂行するためのあなたの努力を続けてください友人 :)"); //24
        bahasaJP.Add("あなたはとても親切だからです。これがあなたのための特別なケーキです、このアイテムはスタミナをよく維持します"); //25
        bahasaJP.Add("家畜の飼育や飼育が本当に好きなようですね。元気を出して！"); //26
        bahasaJP.Add("終わりすぎないでください..元気を出してください！"); //27
        bahasaJP.Add("いつかあなたはそれを気に入るはずです..元気を出してください！"); //28
        bahasaJP.Add("私は大丈夫ですよ"); //29
        bahasaJP.Add("私は実際に疲れていません"); //30
        bahasaJP.Add("私の農場はうまくいっています"); //31
        bahasaJP.Add("私の農場はうまくいっています"); //32
        bahasaJP.Add("私の農場は大丈夫です"); //33

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
        
        //TUTORIAL EVENT
        if (!PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString()=="tutorial")
        {
            yield return new WaitUntil(() => Gamesetupcontroller.instance != null);
            lagiNanya();
            GetComponent<NPC>().level = "MasukRumah";
            GetComponent<NPC>().sedangditanya = true;
            transform.position = new Vector3(4.5f, 0, 2.86f);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
                ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ", " + ChangeLanguage.instance.GetLanguageNPC(5, name), true);
        }

        yield return new WaitUntil(() => PhotonNetwork.IsMasterClient);
        if((int)PhotonNetwork.CurrentRoom.CustomProperties["tanggal"] == 1 && ((int)PhotonNetwork.CurrentRoom.CustomProperties["tahun"] == 1) && int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["jam"].ToString())==6 && int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString()) == 0)
        {
            yield return new WaitUntil(() => sinkronJam.instance != null);
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add("Mika", "tutorial");
            setTgl.Add("Mikalevel", "MasukRumah");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);

            //SET BUTTON
            GameObject button1 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button1").Find("Text").gameObject;
            GameObject button2 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button2").Find("Text").gameObject;
            GameObject button3 = GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").Find("Text").gameObject;

            sinkronJam.instance.CancelInvoke("jalanDetik");
            PlayerPrefs.SetString("buttonNPC", "Mika");
            GetComponent<NPC>().level = "MasukRumah";
            GetComponent<NPC>().sedangditanya = true;
            transform.position = new Vector3(4.5f,0, 2.86f);
            yield return new WaitUntil(() => Gamesetupcontroller.instance!=null);
            lagiNanya();
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            GetComponent<PhotonView>().RPC("talkSamaanHaiDulu", RpcTarget.All,0,5);
            yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
            GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 6);
            yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
            GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 7);
            yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
            GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 8);
            yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
            GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 9);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("ButtonTurnOff").gameObject.SetActive(false);
            button1.GetComponent<Text>().text = button1.GetComponent<ChangeLanguage>().GetLanguage(16);
            makeAnswerPas(button1);
            button2.GetComponent<Text>().text = button2.GetComponent<ChangeLanguage>().GetLanguage(40);
            makeAnswerPas(button2);
            button3.GetComponent<Text>().text = button3.GetComponent<ChangeLanguage>().GetLanguage(107);
            makeAnswerPas(button3);
            yield return new WaitUntil(() => answer!="");
            if (answer == "yes")
            {
                answer = "";
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                GetComponent<PhotonView>().RPC("setWidthTextDialog", RpcTarget.All, 623f);
                GetComponent<PhotonView>().RPC("setActiveGameobject", RpcTarget.All, "Arrow",true);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 11);
                GetComponent<PhotonView>().RPC("setActiveGameobject", RpcTarget.All, "ButtonBwhKanan", true);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobject", RpcTarget.All, "UIkanan", true);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow2", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 12);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow2", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow3", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 13);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow3", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow4", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 14);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow4", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow5", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 15);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow5", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow6", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 16);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow6", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow7", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 17);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow7", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow8", true);
                GetComponent<PhotonView>().RPC("setActiveGameobject", RpcTarget.All, "UIKiri", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 18);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow8", false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow9", true);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 19);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobjectChild", RpcTarget.All, "Arrow", "redarrow9", false);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 20);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setActiveGameobject", RpcTarget.All, "Arrow", false);
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 10);
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                GetComponent<PhotonView>().RPC("setWidthTextDialog", RpcTarget.All, 840.6f);
                sinkronJam.instance.InvokeRepeating("jalanDetik", 5f, 5f);
                GetComponent<PhotonView>().RPC("endPercakapanSemua", RpcTarget.All);
                ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                setProperti.Add(name, "jalan1");
                PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);

                GetComponent<NPC>().pos = GameObject.Find("Barang").transform.Find("door").position;
                yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "jalan1");
                yield return new WaitForSeconds(1f);
                yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "");
                GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "KeluarRumah");
                yield return new WaitUntil(() => int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString()) >= 6 && int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString()) >= 0);
                transform.position = new Vector3(47.9f, 0, 58.25f);
                StartCoroutine(randomJalanDepanFarm());
            }
            else if (answer == "no")
            {
                answer = "";
                GetComponent<PhotonView>().RPC("talkSamaan", RpcTarget.All, 10);
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").Find("Button3").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
                yield return new WaitUntil(() => GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().percakapanaktif == false);
                sinkronJam.instance.InvokeRepeating("jalanDetik", 5f, 5f);
                GetComponent<PhotonView>().RPC("endPercakapanSemua", RpcTarget.All);
                ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
                setProperti.Add(name, "jalan1");
                PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);

                GetComponent<NPC>().pos = GameObject.Find("Barang").transform.Find("door").position;
                yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "jalan1");
                yield return new WaitForSeconds(1f);
                yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "");
                GetComponent<PhotonView>().RPC("gantiLevel", RpcTarget.All, "KeluarRumah");
                yield return new WaitUntil(() => int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString())>=6 && int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["detik"].ToString())>=0);
                transform.position = new Vector3(47.9f, 0, 58.25f); 
                StartCoroutine(randomJalanDepanFarm());
                
            }
            
        }
        //DAILY EVENT
        else
        if ((int)PhotonNetwork.CurrentRoom.CustomProperties["tanggal"] > 1)
        {
            ExitGames.Client.Photon.Hashtable setTgl = new ExitGames.Client.Photon.Hashtable();
            setTgl.Add("Mika", "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setTgl);
            GetComponent<NPC>().pos.x = 60;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 59;
            Debug.Log("JALAN1");
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "jalan1");
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "");
            ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
            setProperti.Add(name, "jalan1");
            PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
            GetComponent<NPC>().pos.x = 40;
            GetComponent<NPC>().pos.y = 0;
            GetComponent<NPC>().pos.z = 50;
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "jalan1");
            yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "");
            StartCoroutine(randomJalanDepanFarm());
        }
    }

    IEnumerator randomJalanDepanFarm()
    {
        System.Random rnd = new System.Random();
        int val = rnd.Next(20, 50); // range 0.0 to 1.0
        GetComponent<NPC>().pos.x = val;
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 50;

        ExitGames.Client.Photon.Hashtable setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "");
        GetComponent<NPC>().pos.y = 0;
        GetComponent<NPC>().pos.z = 49;

        setProperti = new ExitGames.Client.Photon.Hashtable();
        setProperti.Add(name, "jalan1");
        PhotonNetwork.CurrentRoom.SetCustomProperties(setProperti);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "jalan1");
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.CustomProperties["Mika"].ToString() == "");
        yield return new WaitForSeconds(5f);
        StartCoroutine(randomJalanDepanFarm());
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
        if (PlayerPrefs.GetInt("MikaGift") == 1 && PlayerPrefs.GetInt("MikaFriendship") > 39)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName +", "+ ChangeLanguage.instance.GetLanguageNPC(25, name), false);
            PlayerPrefs.SetInt("MikaGift", 0);
            PlayerPrefs.SetInt("maxstamina", PlayerPrefs.GetInt("maxstamina")+15);
            PlayerPrefs.SetInt("stamina", PlayerPrefs.GetInt("stamina") +15);
            GameObject.Find("Canvas").transform.Find("UIKiri").Find("TextStamina").GetComponent<Text>().text = PlayerPrefs.GetInt("stamina").ToString();
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            GetComponent<PhotonView>().RPC("EatGiftRpc", RpcTarget.All, PhotonNetwork.NickName, PlayerPrefs.GetString("level"));
        }else
        if (PlayerPrefs.GetInt("MikaFriendship") < 20)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(1, name), false);
            button1.GetComponent<Text>().text = ChangeLanguage.instance.GetLanguageNPC(32, name);
            makeAnswerPas(button1);
            yield return new WaitUntil(() => answer!="");
            if (answer == "yes") myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(2, name), false);
            else if (answer == "no") 
            {
                System.Random rnd = new System.Random();
                int randomInt = rnd.Next(3, 5);
                myDialogBag.PercakapanBaru(ChangeLanguage.instance.GetLanguageNPC(randomInt, name), false);
            }
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + name + "1");
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
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
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + name + "3");
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
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + name + "3");
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
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + name + "3");
            GameObject.Find(name).GetComponent<PhotonView>().RPC("refreshTiemout", RpcTarget.MasterClient, 5f, name, true);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
        else if (PlayerPrefs.GetInt(name + "Friendship") <= 100)
        {
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/" + name + "3");
            GameObject.Find("Canvas").transform.Find("DialogBG").GetComponent<MyDialogBag>().PercakapanBaru(
            ChangeLanguage.instance.GetLanguageNPC(0, name) + PhotonNetwork.NickName + ChangeLanguage.instance.GetLanguageNPC(24, name), false);
            GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("TempatButton").gameObject.SetActive(false);
            answer = "";
        }
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
        GameObject.Find("Canvas").transform.Find("DialogBG").Find("DialogName").Find("Avatar").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Avatar/"+name+"3");
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

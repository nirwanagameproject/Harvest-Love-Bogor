using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language instance = null;
    public List<string> bahasaID;
    public List<string> bahasaUS;
    public List<string> bahasaJP;
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
        bahasaID.Add("Tap untuk melanjutkan");
        bahasaID.Add("Bermain Sendiri");
        bahasaID.Add("Bermain Bersama");
        bahasaID.Add("Tentang kami");
        bahasaID.Add("Bahasa");
        bahasaID.Add("Permainan Baru");
        bahasaID.Add("Memuat Permainan"); // 6
        bahasaID.Add("Kembali"); // 7
        bahasaID.Add("Tuan Rumah");
        bahasaID.Add("Bergabung");
        bahasaID.Add("Memuat Tuan Rumah");
        bahasaID.Add("Mulai Baru");
        bahasaID.Add("Join ke Ruangan Publik");
        bahasaID.Add("Terima Kasih Khusus Kepada : \n " +
            "\n3D Modeling : \n" +
            "1.Free3D \n" +
            " - Hernando Mora\n" +
            " - printable_models\n" +
            " - Artist Free3D Lainnya\n" +
            "2.pixiv \n" +
            "3.Blender \n" +
            "4,The GIMP Team \n" +
            "\nGame Engine : \n" +
            "1.Unity Technologies \n" +
            "\n Nirwana Game Project\n" +
            "1.Fandy M F\n" +
            " - (Pemimpin Proyek)\n" +
            " - Pemimpin Programmer\n" +
            "2.Adam A P\n" +
            " - (Manager Produk)\n" +
            " - Desain Permainan\n" +
            " - Programmer\n" +
            "3.M Daniel N\n" +
            " - Konsep Artist\n" +
            " - Manager Artist\n" +
            "4.Fajar M F\n" +
            " - Programmer");
        bahasaID.Add("Tap untuk melanjutkan..");
        bahasaID.Add("Siapa nama kamu?");
        bahasaID.Add("Ya"); // 16
        bahasaID.Add("Kapan tanggal ulang tahun kamu?");
        bahasaID.Add("Spring adalah musim semi");
        bahasaID.Add("Summer adalah musim panas");
        bahasaID.Add("Fall adalah musim gugur");
        bahasaID.Add("Winter adalah musim dingin");
        bahasaID.Add("Nama");
        bahasaID.Add("Selamat datang di Kota Bogor :)");
        bahasaID.Add("Ga ada save-an bro"); //24
        bahasaID.Add("Kamu adalah seorang anak tunggal dari petani yang ditinggalkan oleh orang tua kamu.");
        bahasaID.Add("Di Kota Bogor kamu akan berjuang dengan sisa warisan dari orang tua berupa lahan pertanian dan peternakan.");
        bahasaID.Add("Pertama, silahkan masukkan nama kamu...");
        bahasaID.Add("Hai ");
        bahasaID.Add(", kapan ulang tahun kamu?");
        bahasaID.Add("Tgl 1-30");
        bahasaID.Add("Apa nama kebunmu?");
        bahasaID.Add("Apa nama kucing kamu?");
        bahasaID.Add("Pilih gender kamu...");
        bahasaID.Add("Nama kebun");
        bahasaID.Add("Nama kucing");
        bahasaID.Add("Laki-laki");
        bahasaID.Add("Perempuan");
        bahasaID.Add("Ulang Tahun");
        bahasaID.Add("Apa ini sesuai ?");
        bahasaID.Add("Tidak"); //40
        bahasaID.Add("Rambut");
        bahasaID.Add("Warna"); //42
        bahasaID.Add("Hitam"); //43
        bahasaID.Add("Putih");
        bahasaID.Add("Biru");
        bahasaID.Add("Merah");
        bahasaID.Add("Kuning");
        bahasaID.Add("Hijau");
        bahasaID.Add("Abu-abu");
        bahasaID.Add("Baju");//50
        bahasaID.Add("Rambut1"); //51
        bahasaID.Add("Celana"); // 52
        bahasaID.Add("Celana1"); //53
        bahasaID.Add("Baju1");//54
        bahasaID.Add("Kulit");//55
        bahasaID.Add("Putih Cokelat");//56
        bahasaID.Add("Cokelat");//57
        bahasaID.Add("Cokelat Gelap");//58
        bahasaID.Add("Lanjut");//59
        bahasaID.Add("Apa kamu yakin?"); //60
        bahasaID.Add("Pengaturan"); //61
        bahasaID.Add("Nama tidak boleh kosong"); //62
        bahasaID.Add("Nama kucing tidak boleh kosong"); //63
        bahasaID.Add("Batal"); //64
        bahasaID.Add("Ulang tahun tidak boleh kosong"); //65
        bahasaID.Add("Nama kebun tidak boleh kosong"); //66
        bahasaID.Add("Kamu yakin ingin tidur?" +
        "\nSimpan permainan atau tidak? "); //67
        bahasaID.Add("Ya, disimpan"); //68
        bahasaID.Add("Ya, tidak disimpan"); //69
        bahasaID.Add("Kamu yakin ingin tidur?"); //70
        bahasaID.Add("Simpan Permainan"); //71
        bahasaID.Add("Yakin save disini ?"); //72
        bahasaID.Add("Menunggu pemain lain untuk tidur"); // 73
        bahasaID.Add("Pengaturan"); // 74
        bahasaID.Add("Keluar Permainan"); // 75
        bahasaID.Add("Kualitas"+
        "\nVideo"); // 76
        bahasaID.Add("Layar"); // 77
        bahasaID.Add("Kamu yakin ingin keluar?"); // 78
        bahasaID.Add("Peralatan"); // 79
        bahasaID.Add("Tas"); // 80
        bahasaID.Add("Sedang dipakai"); // 81
        bahasaID.Add("Host keluar atau"+
        "\nkoneksi kamu bermasalah"); //82
        bahasaID.Add("Keluar"); // 83
        bahasaID.Add("Peta"); // 84
        bahasaID.Add("Misi"); // 85
        bahasaID.Add("Barang Inventaris"); // 86
        bahasaID.Add("Inventaris"); // 87
        bahasaID.Add("Teman"); // 88
        bahasaID.Add("Belanja"); // 89
        bahasaID.Add("Uang"); // 90
        bahasaID.Add("Barang"); // 91
        bahasaID.Add("Mohon tunggu..."); // 92
        bahasaID.Add("Mantap, pembelian berhasil !!"); // 93
        bahasaID.Add("Menyambungkan ke server..."); // 94
        bahasaID.Add("Tidak ada save dislot ini"); // 95

        //Translate Bahasa Inggris
        bahasaUS = new List<string>();
        bahasaUS.Add("Tap for continue");
        bahasaUS.Add("Single Player");
        bahasaUS.Add("Multiplayer");
        bahasaUS.Add("Credits");
        bahasaUS.Add("Language");
        bahasaUS.Add("New Game");
        bahasaUS.Add("Load Game");
        bahasaUS.Add("Back");
        bahasaUS.Add("Host");
        bahasaUS.Add("Join");
        bahasaUS.Add("Load Game for Host");
        bahasaUS.Add("New Game");
        bahasaUS.Add("Join to Public Room");
        bahasaUS.Add("Special Thanks To : \n " +
            "\n3D Modeling : \n" +
            "1.Free3D \n" +
            " - Hernando Mora\n" +
            " - printable_models\n" +
            " - Other Artist Free3D\n" +
            "2.pixiv \n" +
            "3.Blender \n" +
            "4,The GIMP Team \n" +
            "\nGame Engine : \n" +
            "1.Unity Technologies \n" +
            "\n Nirwana Game Project\n" +
            "1.Fandy M F\n" +
            " - (Lead Project)\n" +
            " - Lead Programmer\n" +
            "2.Adam A P\n" +
            " - (Project Manager)\n" +
            " - Game Designer\n" +
            " - Programmer\n" +
            "3.M Daniel N\n" +
            " - Concept Artist\n" +
            " - Artist Management\n" +
            "4.Fajar M F\n" +
            " - Programmer");
        bahasaUS.Add("Tap for continue..");
        bahasaUS.Add("Who is your name?");
        bahasaUS.Add("Ok"); // 16
        bahasaUS.Add("When is your birthday?");
        bahasaUS.Add("Spring is season after winter");
        bahasaUS.Add("Summer is season after spring");
        bahasaUS.Add("Fall is season after summer");
        bahasaUS.Add("Winter is season after fall");
        bahasaUS.Add("Name");
        bahasaUS.Add("Welcome to Bogor City :)");
        bahasaUS.Add("Nothing save file here"); //24
        bahasaUS.Add("You're an only child from a farmer who was abandoned by your parents.");
        bahasaUS.Add("In Bogor City, you will struggle with the remaining inheritance from your parents in the form of agricultural land and livestock.");
        bahasaUS.Add("First, please enter your name...");
        bahasaUS.Add("Hello ");
        bahasaUS.Add(", when is your birthday?");
        bahasaUS.Add("Num 1-30");
        bahasaUS.Add("What is name of your farm?");
        bahasaUS.Add("what is your cat's name?");
        bahasaUS.Add("Choose your gender...");
        bahasaUS.Add("Farm name");
        bahasaUS.Add("Cat name");
        bahasaUS.Add("Boy");
        bahasaUS.Add("Girl");
        bahasaUS.Add("Bithday");
        bahasaUS.Add("Is this appropriate?");
        bahasaUS.Add("No");
        bahasaUS.Add("Hair");
        bahasaUS.Add("Color");
        bahasaUS.Add("Black"); //43
        bahasaUS.Add("White"); //44
        bahasaUS.Add("Blue"); //45
        bahasaUS.Add("Red"); //46
        bahasaUS.Add("Yellow"); //47
        bahasaUS.Add("Green"); //48
        bahasaUS.Add("Grey"); //49
        bahasaUS.Add("Clothes");  //50
        bahasaUS.Add("Hair1");  //51
        bahasaUS.Add("Pants"); //52
        bahasaUS.Add("Pants1"); //53
        bahasaUS.Add("Clothes1");//54
        bahasaUS.Add("Skin");//55
        bahasaUS.Add("Bright Chocolate");//56
        bahasaUS.Add("Chocolate");//57
        bahasaUS.Add("Dark Chocolate");//58
        bahasaUS.Add("Continue");//59
        bahasaUS.Add("Are you sure?"); //60
        bahasaUS.Add("Settings"); //61
        bahasaUS.Add("Name cannot be empty"); //62
        bahasaUS.Add("Cat's name cannot be empty"); //63
        bahasaUS.Add("Cancel"); //64
        bahasaUS.Add("Birthday cannot be empty"); //65
        bahasaUS.Add("Farm's name cannot be empty"); //66
        bahasaUS.Add("Are you sure you want to sleep?" +
        "\nSave game or not?"); //67
        bahasaUS.Add("Yes, saved"); //68
        bahasaUS.Add("Yes, not saved"); //69
        bahasaUS.Add("Are you sure you want to sleep?"); //70
        bahasaUS.Add("Save Game"); //71
        bahasaUS.Add("Are you sure you save here?"); //72
        bahasaUS.Add("Waiting for other players to sleep"); // 73
        bahasaUS.Add("Settings"); // 74
        bahasaUS.Add("Quit Game"); // 75
        bahasaUS.Add("Quality" +
            "\nVideo"); // 76
        bahasaUS.Add("Display"); // 77
        bahasaUS.Add("Are you sure you want to leave?"); // 78
        bahasaUS.Add("Tools"); // 79
        bahasaUS.Add("Bag"); // 80
        bahasaUS.Add("In use"); // 81
        bahasaUS.Add("Outgoing host or" +
         "\nyour connection has a problem"); //82
        bahasaUS.Add("Quit"); // 83
        bahasaUS.Add("Map"); // 84
        bahasaUS.Add("Quest"); // 85
        bahasaUS.Add("Inventory"); // 86
        bahasaUS.Add("Inventory"); // 87
        bahasaUS.Add("Friends"); // 88
        bahasaUS.Add("Shop"); // 89
        bahasaUS.Add("Money"); // 90
        bahasaUS.Add("Items"); // 91
        bahasaUS.Add("Please Wait..."); // 92
        bahasaUS.Add("Cool, you got new stuff !!"); // 93
        bahasaUS.Add("Connecting to the server..."); // 94
        bahasaUS.Add("No save file here"); // 95

        //Translate Bahasa Jepang
        bahasaJP = new List<string>();
        bahasaJP.Add("Tap to continue..");
        bahasaJP.Add("シングルプレーヤー");
        bahasaJP.Add("マルチプレーヤー");
        bahasaJP.Add("ひとこと");
        bahasaJP.Add("言語");
        bahasaJP.Add("はじめから");
        bahasaJP.Add("続く");
        bahasaJP.Add("戻る");
        bahasaJP.Add("ホスト");
        bahasaJP.Add("入る");
        bahasaJP.Add("ホストロード中");
        bahasaJP.Add("初めから");
        bahasaJP.Add("パブリックロビーに入る");
        bahasaJP.Add("スペシャル・サンクス : \n " +
            "\n3D Modeling : \n" +
            "1.Free3D \n" +
            " - Hernando Mora\n" +
            " - printable_models\n" +
            " - Other Artist Free3D\n" +
            "2.pixiv \n" +
            "3.Blender \n" +
            "4,The GIMP Team \n" +
            "\nGame Engine : \n" +
            "1.Unity Technologies \n" +
            "\n Nirwana Game Project\n" +
            "1.Fandy M F\n" +
            " - (Lead Project)\n" +
            " - Lead Programmer\n" +
            "2.Adam A P\n" +
            " - (Project Manager)\n" +
            " - Game Designer\n" +
            " - Programmer\n" +
            "3.M Daniel N\n" +
            " - Concept Artist\n" +
            " - Artist Management\n" +
            "4.Fajar M F\n" +
            " - Programmer");
        bahasaJP.Add("杉のページ");
        bahasaJP.Add("お名前は？");
        bahasaJP.Add("はい");
        bahasaJP.Add("お誕生日は？");
        bahasaJP.Add("Springは春");
        bahasaJP.Add("Summerは夏");
        bahasaJP.Add("Fallは秋");
        bahasaJP.Add("Winterは冬");
        bahasaJP.Add("名前");
        bahasaJP.Add("ボゴールへようこそ！　:)");
        bahasaJP.Add("ここにストレージはありません");
        bahasaJP.Add("君は一人っ子。ご両親はもういなくなった。");
        bahasaJP.Add("この街にご両親からの遺産で生きている。");
        bahasaJP.Add("まずは、君の名は？");
        bahasaJP.Add("こんにちは ");
        bahasaJP.Add(", お誕生日は？");
        bahasaJP.Add("1‐30日");
        bahasaJP.Add("農場の名前は？?");
        bahasaJP.Add("猫の名前は？");
        bahasaJP.Add("性別は？");
        bahasaJP.Add("農場の名");
        bahasaJP.Add("ねこの名");
        bahasaJP.Add("男");
        bahasaJP.Add("女");
        bahasaJP.Add("誕生日");
        bahasaJP.Add("これでいい？");
        bahasaJP.Add("いいえ");
        bahasaJP.Add("髪型");
        bahasaJP.Add("色");
        bahasaJP.Add("黒");
        bahasaJP.Add("白");
        bahasaJP.Add("青");
        bahasaJP.Add("赤");
        bahasaJP.Add("金色");
        bahasaJP.Add("緑");
        bahasaJP.Add("グレー");
        bahasaJP.Add("服"); //50
        bahasaJP.Add("髪型1"); //51
        bahasaJP.Add("ボトムズ"); //51
        bahasaJP.Add("ボトムズ1"); //53
        bahasaJP.Add("トップス1");//54
        bahasaJP.Add("肌");//55
        bahasaJP.Add("薄茶色");//56
        bahasaJP.Add("茶色");//57
        bahasaJP.Add("暗褐色");//58
        bahasaJP.Add("続く");//59
        bahasaJP.Add("これでいい？"); //60
        bahasaJP.Add("設定"); //61
        bahasaJP.Add("名前を入れてください"); //62
        bahasaJP.Add("猫の名前を入れてください"); //63
        bahasaJP.Add("戻る"); //64
        bahasaJP.Add("誕生日を入れてください"); //65
        bahasaJP.Add("農場の名前を入れてください"); //66
        bahasaJP.Add("寝る?" +
        "\nセーブする?"); //67
        bahasaJP.Add("はい、セーブ"); //68
        bahasaJP.Add("いいえ"); //69
        bahasaJP.Add("寝る?"); //70
        bahasaJP.Add("セーブする"); //71
        bahasaJP.Add("ここにセーブする?"); //72
        bahasaJP.Add("他のプレイヤーが寝るのを待っている"); // 73
        bahasaJP.Add("設定"); // 74
        bahasaJP.Add("終了"); // 75
        bahasaJP.Add("クオリティ" +
            "\nビデオ"); // 76
        bahasaJP.Add("スクリーン"); // 77
        bahasaJP.Add("本当に終了したいの?"); // 78
        bahasaJP.Add("道具"); // 79
        bahasaJP.Add("鞄"); // 80
        bahasaJP.Add("使ってる"); // 81
        bahasaJP.Add("ホストまたは" +
        "\n接続に問題がある"); //82
        bahasaJP.Add("終了"); // 83
        bahasaJP.Add("地図"); // 84
        bahasaJP.Add("クエスト"); // 85
        bahasaJP.Add("在庫"); // 86
        bahasaJP.Add("在庫"); // 87
        bahasaJP.Add("友達"); // 88
        bahasaJP.Add("店"); // 89
        bahasaJP.Add("お金"); // 90
        bahasaJP.Add("品"); // 91
        bahasaJP.Add("お待ちください..."); // 92
        bahasaJP.Add("素晴らしい、成功した購入！"); // 93
        bahasaJP.Add("サーバーへの接続..."); // 94
        bahasaJP.Add("ここに保存ファイルはありません"); // 95

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

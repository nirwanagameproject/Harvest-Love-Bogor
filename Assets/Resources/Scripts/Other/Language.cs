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


        //Translate Bahasa Indonesia
        bahasaID = new List<string>();
        bahasaID.Add("Tap untuk melanjutkan");
        bahasaID.Add("Bermain Sendiri");
        bahasaID.Add("Bermain Bersama");
        bahasaID.Add("Tentang kami");
        bahasaID.Add("Bahasa");
        bahasaID.Add("Permainan Baru");
        bahasaID.Add("Memuat Permainan");
        bahasaID.Add("Kembali");
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
        bahasaID.Add("Ya");
        bahasaID.Add("Kapan tanggal ulang tahun kamu?");
        bahasaID.Add("Spring adalah musim semi");
        bahasaID.Add("Summer adalah musim panas");
        bahasaID.Add("Fall adalah musim gugur");
        bahasaID.Add("Winter adalah musim dingin");
        bahasaID.Add("Nama");
        bahasaID.Add("Selamat datang di Kota Bogor :)");
        bahasaID.Add("");
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
        bahasaID.Add("Tidak");
        bahasaID.Add("Rambut");
        bahasaID.Add("Warna");
        bahasaID.Add("Hitam");
        bahasaID.Add("Putih");
        bahasaID.Add("Biru");
        bahasaID.Add("Merah");
        bahasaID.Add("Kuning");
        bahasaID.Add("Hijau");
        bahasaID.Add("Abu-abu");

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
        bahasaUS.Add("OK");
        bahasaUS.Add("When is your birthday?");
        bahasaUS.Add("Spring is season after winter");
        bahasaUS.Add("Summer is season after spring");
        bahasaUS.Add("Fall is season after summer");
        bahasaUS.Add("Winter is season after fall");
        bahasaUS.Add("Name");
        bahasaUS.Add("Welcome to Bogor City :)");
        bahasaUS.Add("");
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
        bahasaUS.Add("Black");
        bahasaUS.Add("White");
        bahasaUS.Add("Blue");
        bahasaUS.Add("Red");
        bahasaUS.Add("Yellow");
        bahasaUS.Add("Green");
        bahasaUS.Add("Grey");

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
        bahasaJP.Add("");
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

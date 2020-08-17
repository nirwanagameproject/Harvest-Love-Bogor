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
        bahasaJP.Add("Tap untuk melanjutkan");
        bahasaJP.Add("Bermain Sendiri");
        bahasaJP.Add("Bermain Bersama");
        bahasaJP.Add("Tentang kami");
        bahasaJP.Add("Bahasa");
        bahasaJP.Add("Permainan Baru");
        bahasaJP.Add("Memuat Permainan");
        bahasaJP.Add("Kembali");
        bahasaJP.Add("Tuan Rumah");
        bahasaJP.Add("Bergabung");
        bahasaJP.Add("Memuat untuk Tuan Rumah");
        bahasaJP.Add("Mulai Baru");
        bahasaJP.Add("Join ke Ruangan Publik");
        bahasaJP.Add("Special Thanks To : \n " +
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
        bahasaJP.Add("Tap untuk melanjutkan..");
        bahasaJP.Add("Siapa nama kamu?");
        bahasaJP.Add("Ya");
        bahasaJP.Add("Kapan tanggal ulang tahun kamu?");
        bahasaJP.Add("Spring adalah musim semi");
        bahasaJP.Add("Summer adalah musim panas");
        bahasaJP.Add("Fall adalah musim gugur");
        bahasaJP.Add("Winter adalah musim dingin");
        bahasaJP.Add("Nama");
        bahasaJP.Add("Selamat datang di Kota Bogor :)");
        bahasaJP.Add("");
        bahasaJP.Add("Kamu adalah seorang anak tunggal dari petani yang ditinggalkan oleh orang tua kamu.");
        bahasaJP.Add("Di Kota Bogor kamu akan berjuang dengan sisa warisan dari orang tua berupa lahan pertanian dan peternakan.");
        bahasaJP.Add("Pertama, silahkan masukkan nama kamu...");
        bahasaJP.Add("Hai ");
        bahasaJP.Add(", kapan ulang tahun kamu?");
        bahasaJP.Add("Tgl 1-30");
        bahasaJP.Add("Apa nama kebunmu?");
        bahasaJP.Add("Apa nama kucing kamu?");
        bahasaJP.Add("Pilih gender kamu...");
        bahasaJP.Add("Nama kebun");
        bahasaJP.Add("Nama kucing");
        bahasaJP.Add("Laki-laki");
        bahasaJP.Add("Perempuan");
        bahasaJP.Add("Ulang Tahun");
        bahasaJP.Add("Apa ini sesuai ?");
        bahasaJP.Add("Tidak");
        bahasaJP.Add("Rambut");
        bahasaJP.Add("Warna");
        bahasaJP.Add("Hitam");
        bahasaJP.Add("Putih");
        bahasaJP.Add("Biru");
        bahasaJP.Add("Merah");
        bahasaJP.Add("Kuning");
        bahasaJP.Add("Hijau");
        bahasaJP.Add("Abu-abu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

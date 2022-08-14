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
        bahasaID.Add("Penghujan adalah musim semi yang sering terjadi hujan");
        bahasaID.Add("Pancaroba-1 adalah musim peralihan dari musim hujan ke musim kemarau");
        bahasaID.Add("Kemarau adalah musim gugur dimana daun-daun pada berguguran");
        bahasaID.Add("Pancaroba-2 adalah musim peralihan dari musim kemarau ke musim hujan");
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
        bahasaID.Add("Tambah"); // 96
        bahasaID.Add("Daftar Pertemanan"); // 97
        bahasaID.Add("Kamu yakin ingin menghapus"); // 98
        bahasaID.Add("Permintaan"); // 99
        bahasaID.Add("Username tidak boleh kosong"); // 100
        bahasaID.Add("Username tidak ditemukan"); // 101
        bahasaID.Add("Username tidak boleh diri sendiri"); // 102
        bahasaID.Add("Permintaan pertemanan terkirim kepada"); // 103
        bahasaID.Add("Tulis username teman kamu\n(huruf kapital berpengaruh)"); // 104
        bahasaID.Add("Pilih karakter kamu"); // 105
        bahasaID.Add("Catatan: Kamu harus bermain single player terlebih dahulu dan save karakter dihari ke-2"); // 106
        bahasaID.Add("Tidak apa-apa"); // 107
        bahasaID.Add("Senin"); // 108
        bahasaID.Add("Selasa"); // 109
        bahasaID.Add("Rabu"); // 110
        bahasaID.Add("Kamis"); // 111
        bahasaID.Add("Jumat"); // 112
        bahasaID.Add("Sabtu"); // 113
        bahasaID.Add("Minggu"); // 114
        bahasaID.Add("Kotak Penyimpanan"); // 115
        bahasaID.Add("Apa isi dalam kotak peralatan ?"); // 116
        bahasaID.Add("Pilih barang atau peralatan untuk dipindahkan"); // 117
        bahasaID.Add("Pacul - Alat untuk menggali tanah, gunakan ini untuk membuat lahan penanaman bibit dan mencangkul lahan pertambangan."); // 118
        bahasaID.Add("Kapak - Alat untuk membelah kayu, dapat digunakan untuk mendapatkan kayu dalam membangun rumah."); // 119
        bahasaID.Add("Palu - Alat untuk menghancurkan batu."); // 120
        bahasaID.Add("Sabit - Alat untuk memotong rumput."); // 121
        bahasaID.Add("Penyiram - Alat untuk menyiram tanaman/bibit, isi penyiram dengan mendekati sumber air terdekat."); // 122
        bahasaID.Add("Bibit Tomat - Tanam diwaktu spring, buah tomat segar dijual dengan harga 600 Koin per satuan."); // 123
        bahasaID.Add("Apel - Buah yang diproduksi dari pohon buah apel. Buah apel biasanya berwarna merah kulitnya jika masak dan (siap dimakan)"); // 124
        bahasaID.Add("Tomat - Buah kaya serat dan memiliki sejumlah vitamin serta zat antioksidan penting bagi tubuh"); // 125
        bahasaID.Add("Pilih saluran yang ingin ditonton."); // 126
        bahasaID.Add("Berikutnya"); // 127
        bahasaID.Add("Sebelumnya"); // 128
        bahasaID.Add("Ramalan cuaca untuk besok hari"); // 129
        bahasaID.Add("Makanan Ayam - Makanan untuk ayam, bebek dan unggas peliharaan lainnya. Berikan 1 untuk satu hari."); // 130
        bahasaID.Add("Status Profil"); // 131
        bahasaID.Add("Kebun"); // 132
        bahasaID.Add("Tetangga"); // 133
        bahasaID.Add("Unggas"); // 134
        bahasaID.Add("Lumbung"); // 135
        bahasaID.Add("Daftar Pemain"); // 136
        bahasaID.Add("Stamina"); // 137
        bahasaID.Add("Peternakan"); // 138
        bahasaID.Add("Desa"); // 139
        bahasaID.Add("Pasar"); // 140
        bahasaID.Add("Toko Peternakan"); // 141
        bahasaID.Add("Sapi"); // 142
        bahasaID.Add("Kambing"); // 143
        bahasaID.Add("Bahan"); // 144
        bahasaID.Add("Total Harga : "); // 145
        bahasaID.Add("Beli"); // 146
        bahasaID.Add("Sehat"); // 147
        bahasaID.Add("Kurang Sehat"); // 148
        bahasaID.Add("Sakit"); // 149
        bahasaID.Add("Pintar, baik hati tetapi agak jutek orangnya. Lahir pada tanggal 22 Summer. Menyukai bunga matahari dan buah anggur."); // 150
        bahasaID.Add("Cantik dan agak tomboy. Sangat gaul juga. Lahir pada tanggal 28 Winter. Menyukai es kelapa dan pizza."); // 151
        bahasaID.Add("Sudah umur kepala 3 tapi masih terlihat muda. Lahir pada tanggal 5 Fall. Menyukai telor, susu dan buah tomat."); // 152
        bahasaID.Add("Uang kamu tidak cukup"); // 153
        bahasaID.Add("Kandang kamu sudah full / tidak muat"); // 154
        bahasaID.Add("Beri nama hewan ini ?"); // 155
        bahasaID.Add("DESA\nSUKAHUJAN"); // 156
        bahasaID.Add("Gunung 1"); // 157
        bahasaID.Add("Gunung 2"); // 158
        bahasaID.Add("Hutan Barat"); // 159
        bahasaID.Add("Hutan Barat daya"); // 160
        bahasaID.Add("Hutan Selatan"); // 161
        bahasaID.Add("Persimpangan Jalan"); // 162
        bahasaID.Add("PASAR\n24 Jam"); // 163
        bahasaID.Add("Lapangan"); // 164
        bahasaID.Add("Toko Produk Lahan"); // 165
        bahasaID.Add("Bibit"); // 166
        bahasaID.Add("Produk"); // 167
        bahasaID.Add("Tomat"); // 168
        bahasaID.Add("Jagung"); // 169
        bahasaID.Add("Susu Sapi Mini"); // 170
        bahasaID.Add("Susu Kambing Mini"); // 171
        bahasaID.Add("Telur Ayam"); // 172
        bahasaID.Add("Telur Bebek"); // 173
        bahasaID.Add("Pilih Semua"); // 174
        bahasaID.Add("Jual"); // 175
        bahasaID.Add("Jagung - Salah satu tanaman pangan penghasil karbohidrat yang terpenting di dunia, selain gandum dan padi"); // 176
        bahasaID.Add("Susu Sapi Mini - Sumber protein dan kalsium yang baik, serta nutrisi termasuk vitamin B12, magnesium dan yodium"); // 177
        bahasaID.Add("Susu Sapi Medium - Sumber protein dan kalsium yang baik, serta nutrisi termasuk vitamin B12, magnesium dan yodium"); // 178
        bahasaID.Add("Susu Sapi Besar - Sumber protein dan kalsium yang baik, serta nutrisi termasuk vitamin B12, magnesium dan yodium"); // 179
        bahasaID.Add("Susu Kambing Mini - Memiliki manfaat yang potensial dalam menjaga serta menguatkan tulang dan gigi dan menjaga sistem pencernaan"); // 180
        bahasaID.Add("Susu Kambing Medium - Memiliki manfaat yang potensial dalam menjaga serta menguatkan tulang dan gigi dan menjaga sistem pencernaan"); // 181
        bahasaID.Add("Susu Kambing Besar - Memiliki manfaat yang potensial dalam menjaga serta menguatkan tulang dan gigi dan menjaga sistem pencernaan"); // 182
        bahasaID.Add("Telur Ayam - Nutrisi yang terkandung di dalam sebuah telur cukup lengkap, mulai dari asam amino, lemak, vitamin, mineral hingga lutein"); // 183
        bahasaID.Add("Telur Bebek - Selain mengandung protein, lemak, dan karbohidrat, telur bebek juga mengandung multivitamin dan mineral"); // 184
        bahasaID.Add("Tas kamu sudah full / tidak muat"); // 185
        bahasaID.Add("Kucing gemas dan lucu punya "); // 186
        bahasaID.Add("Ayam gemas dan lucu punya "); // 187
        bahasaID.Add("Bebek gemas dan lucu punya "); // 188
        bahasaID.Add("Toko Unggas"); // 189
        bahasaID.Add("Ayam"); // 190
        bahasaID.Add("Bebek"); // 191
        bahasaID.Add("Makanan Ayam"); // 192
        bahasaID.Add("Yakin ingin menjual ?"); // 193

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
        bahasaUS.Add("Rainy is Spring Season it often rains");
        bahasaUS.Add("Pancaroba-1 is transition season from Rainy Season to Autumn");
        bahasaUS.Add("Autumn is season when leaves fall from trees");
        bahasaUS.Add("Pancaroba-2 is transition season from Autumn to Rainy Season");
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
        bahasaUS.Add("Add"); // 96
        bahasaUS.Add("Friendlist"); // 97
        bahasaUS.Add("Are you sure want to remove"); // 98
        bahasaUS.Add("Request"); // 99
        bahasaUS.Add("Username can't be empty"); // 100
        bahasaUS.Add("Username is not found"); // 101
        bahasaUS.Add("Can't add yourself"); // 102
        bahasaUS.Add("Request have been sent to"); // 103
        bahasaUS.Add("Username of your friend\n(Upper/Lowercase affected)"); // 104
        bahasaUS.Add("Choose your character"); // 105
        bahasaUS.Add("Note: You have to play in single player mode and save your character in day 2"); // 106
        bahasaUS.Add("Nevermind"); // 107
        bahasaUS.Add("Monday"); // 108
        bahasaUS.Add("Tuesday"); // 109
        bahasaUS.Add("Wednesday"); // 110
        bahasaUS.Add("Thursday"); // 111
        bahasaUS.Add("Friday"); // 112
        bahasaUS.Add("Saturday"); // 113
        bahasaUS.Add("Sunday"); // 114
        bahasaUS.Add("Safebox"); // 115
        bahasaUS.Add("What's in the safebox?"); // 116
        bahasaUS.Add("Choose your tool or item to move"); // 117
        bahasaUS.Add("Hoe - A tool for digging soil, use this to make a planting area for seedlings and hoe mining land."); // 118
        bahasaUS.Add("Axe - Tool for splitting wood, can be used to get wood in building houses."); // 119
        bahasaUS.Add("Hammer - Tool for crushing stones."); // 120
        bahasaUS.Add("Sickle - Tool for cutting grass."); // 121
        bahasaUS.Add("Watering Can - A tool for watering plants/seeds, fill the watering can by approaching the nearest water source."); // 122
        bahasaUS.Add("Tomato Seeds - Planted in spring, fresh tomatoes are sold at a price of 8000 Coin per unit."); // 123
        bahasaUS.Add("Apple - The fruit produced from the apple fruit tree. Apples are usually red in color when ripe and (ready to eat)"); // 124
        bahasaUS.Add("Tomato - Fruit rich in fiber and has a number of vitamins and antioxidants that are important for the body"); // 125
        bahasaUS.Add("Choose channel which want to watch."); // 126
        bahasaUS.Add("Next"); // 127
        bahasaUS.Add("Previous"); // 128
        bahasaUS.Add("Weather forecast for tomorrow"); // 129
        bahasaUS.Add("Chicken Feed - Food for chickens, ducks and other domesticated poultry. Give 1 for one day."); // 130
        bahasaUS.Add("Profile Status"); // 131
        bahasaUS.Add("Farm"); // 132
        bahasaUS.Add("Neighbor"); // 133
        bahasaUS.Add("Poultry"); // 134
        bahasaUS.Add("Barn"); // 135
        bahasaUS.Add("Player List"); // 136
        bahasaUS.Add("Stamina"); // 137
        bahasaUS.Add("Livestock"); // 138
        bahasaUS.Add("Village"); // 139
        bahasaUS.Add("Market"); // 140
        bahasaUS.Add("Livestock Shop"); // 141
        bahasaUS.Add("Cow"); // 142
        bahasaUS.Add("Goat"); // 143
        bahasaUS.Add("Item"); // 144
        bahasaUS.Add("Total Price : "); // 145
        bahasaUS.Add("Buy"); // 146
        bahasaUS.Add("Healthy"); // 147
        bahasaUS.Add("Not fine"); // 148
        bahasaUS.Add("Sick"); // 149
        bahasaUS.Add("Smart, kind, but have a bit rude face. Born on the 22nd summer. Loved sunflowers and grapes."); // 150
        bahasaUS.Add("Beautiful and a bit manly. Very slang too. Born on the 28th of Winter. Liked the coconut water and pizza."); // 151
        bahasaUS.Add("He's old in age but still looks young. Born on the 5th of Fall. Likes eggs, milk and tomatoes."); // 152
        bahasaUS.Add("Not enough money"); // 153
        bahasaUS.Add("Your place is full / doesn't fit"); // 154
        bahasaUS.Add("Give the name of this animal ?"); // 155
        bahasaUS.Add("SUKAHUJAN VILLAGE"); // 156
        bahasaUS.Add("Mountain 1"); // 157
        bahasaUS.Add("Mountain 2"); // 158
        bahasaUS.Add("West Forest"); // 159
        bahasaUS.Add("SouthWest Forest"); // 160
        bahasaUS.Add("South Forest"); // 161
        bahasaUS.Add("Junction"); // 162
        bahasaUS.Add("24 Hours\nMarket"); // 163
        bahasaUS.Add("Field"); // 164
        bahasaUS.Add("Seed & Farm Products Shop"); // 165
        bahasaUS.Add("Seed"); // 166
        bahasaUS.Add("Products"); // 167
        bahasaUS.Add("Tomato"); // 168
        bahasaUS.Add("Corn"); // 169
        bahasaUS.Add("Small Cow Milk"); // 170
        bahasaUS.Add("Small Goat Milk"); // 171
        bahasaUS.Add("Chicken Egg"); // 172
        bahasaUS.Add("Duck Egg"); // 173
        bahasaUS.Add("Select All"); // 174
        bahasaUS.Add("Sell"); // 175
        bahasaUS.Add("Corn - One of the most important carbohydrate-producing food crops in the world, besides wheat and rice"); // 176
        bahasaUS.Add("Small Cow Milk - Good source of protein and calcium, as well as nutrients including vitamin B12, magnesium and iodine"); // 177
        bahasaUS.Add("Medium Cow Milk - Good source of protein and calcium, as well as nutrients including vitamin B12, magnesium and iodine"); // 178
        bahasaUS.Add("Large Cow Milk - Good source of protein and calcium, as well as nutrients including vitamin B12, magnesium and iodine"); // 179
        bahasaUS.Add("Small Goat Milk - Has potential benefits in maintaining and strengthening bones and teeth and maintaining the digestive system"); // 180
        bahasaUS.Add("Medium Goat Milk - Has potential benefits in maintaining and strengthening bones and teeth and maintaining the digestive system"); // 181
        bahasaUS.Add("Large Goat Milk - Has potential benefits in maintaining and strengthening bones and teeth and maintaining the digestive system"); // 182
        bahasaUS.Add("Chicken Eggs - The nutrients contained in an egg are quite complete, ranging from amino acids, fats, vitamins, minerals to lutein"); // 183
        bahasaUS.Add("Duck Eggs - In addition to containing protein, fat, and carbohydrates, duck eggs also contain multivitamins and minerals"); // 184
        bahasaUS.Add("Your bag is full / doesn't fit"); // 185
        bahasaUS.Add("Little cute Cat owned by "); // 186
        bahasaUS.Add("Little cute Chicken owned by "); // 187
        bahasaUS.Add("Little cute Duck owned by "); // 188
        bahasaUS.Add("Poultry Shop"); // 189
        bahasaUS.Add("Chicken"); // 190
        bahasaUS.Add("Duck"); // 191
        bahasaUS.Add("Chicken Feed"); // 192
        bahasaUS.Add("Are you sure want to sell?"); // 193

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
        bahasaJP.Add("はい"); //16
        bahasaJP.Add("お誕生日は？");
        bahasaJP.Add("梅雨は春の季節で、よく雨が降ります");
        bahasaJP.Add("Pancaroba-1 は梅雨から秋への移行シーズンです");
        bahasaJP.Add("秋は木の葉が落ちる季節");
        bahasaJP.Add("Pancaroba-2 は秋から梅雨への移行シーズンです");
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
        bahasaJP.Add("追加"); // 96
        bahasaJP.Add("友達リスト"); // 97
        bahasaJP.Add("本当に削除したいですか"); // 98
        bahasaJP.Add("リクエスト"); // 99
        bahasaJP.Add("ユーザー名を空にすることはできません"); // 100
        bahasaJP.Add("ユーザー名が見つかりません"); // 101
        bahasaJP.Add("自分を追加することはできません"); // 102
        bahasaJP.Add("友達リクエストが送信されました"); // 103
        bahasaJP.Add("友達のユーザー名を書く\n（大文字の影響力）"); // 104
        bahasaJP.Add("あなたのキャラクターを選択してください"); // 105
        bahasaJP.Add("注：最初にシングルプレイヤーをプレイし、2日目にキャラクターを保存する必要があります"); // 106
        bahasaJP.Add("気にしない"); // 107
        bahasaJP.Add("月曜日"); // 108
        bahasaJP.Add("火曜日"); // 109
        bahasaJP.Add("水曜日"); // 110
        bahasaJP.Add("木曜日"); // 111
        bahasaJP.Add("金曜日"); // 112
        bahasaJP.Add("土曜日"); // 113
        bahasaJP.Add("日曜日"); // 114
        bahasaJP.Add("セーフボックス"); // 115
        bahasaJP.Add("ツールボックスには何が入っていますか？"); // 116
        bahasaJP.Add("移動するツールまたはアイテムを選択します"); // 117
        bahasaJP.Add("鍬 - 土を掘るための道具で、これを使って苗木や鍬採掘場の植栽地を作ります。"); // 118
        bahasaJP.Add("斧 - 木を分割するためのツールで、家を建てるときに木を手に入れるために使用できます。"); // 119
        bahasaJP.Add("ハンマー - 石を粉砕するためのツール。"); // 120
        bahasaJP.Add("鎌 - 草を刈るための道具。"); // 121
        bahasaJP.Add("じょうろ - 植物/種子に水をまくためのツールで、最寄りの水源に近づいてじょうろを満たします。"); // 122
        bahasaJP.Add("トマトの種 - 春に植えられたフレッシュトマトは、1ユニットあたり8000コインの価格で販売されています。"); // 123
        bahasaJP.Add("りんご - リンゴの果樹から作られる果実。リンゴは通常、熟したとき（すぐに食べられる状態）は赤色になります"); // 124
        bahasaJP.Add("トマト - トマトは食物繊維が豊富な果物で、体に重要なビタミンや抗酸化物質がたくさん含まれています"); // 125
        bahasaJP.Add("見たいチャンネルを選択"); // 126
        bahasaJP.Add("次"); // 127
        bahasaJP.Add("前"); // 128
        bahasaJP.Add("明日の天気予報"); // 129
        bahasaJP.Add("鶏の餌-鶏、アヒル、その他の家禽用の餌。 1日1を与えます。"); // 130
        bahasaJP.Add("プロファイルステータス"); // 131
        bahasaJP.Add("農場"); // 132
        bahasaJP.Add("近所の人"); // 133
        bahasaJP.Add("家禽"); // 134
        bahasaJP.Add("納屋"); // 135
        bahasaJP.Add("プレイヤーリスト"); // 136
        bahasaJP.Add("元気"); // 137
        bahasaJP.Add("家畜"); // 138
        bahasaJP.Add("村"); // 139
        bahasaJP.Add("市場"); // 140
        bahasaJP.Add("畜産店"); // 141
        bahasaJP.Add("牛"); // 142
        bahasaJP.Add("ヤギ"); // 143
        bahasaJP.Add("アイテム"); // 144
        bahasaJP.Add("合計金額 ："); // 145
        bahasaJP.Add("買う"); // 146
        bahasaJP.Add("健康"); // 147
        bahasaJP.Add("うまくない"); // 148
        bahasaJP.Add("病気"); // 149
        bahasaJP.Add("スマートで親切ですが、少し失礼な顔をしています。 22日夏生まれ。ひまわりとぶどうが大好きです。"); // 150
        bahasaJP.Add("美しく、少し男らしい。俗語も非常に。冬の28日に生まれました。ココナッツウォーターとピザが好きだった。"); // 151
        bahasaJP.Add("彼は年をとっていますが、まだ若く見えます。秋の5日に生まれました。卵、ミルク、トマトが好きです。"); // 152
        bahasaJP.Add("お金が足りない"); // 153
        bahasaJP.Add("ケージがいっぱいです/収まりません"); // 154
        bahasaJP.Add("この動物の名前を教えてください？"); // 155
        bahasaJP.Add("SUKAHUJAN 村"); // 156
        bahasaJP.Add("山 1"); // 157
        bahasaJP.Add("山 2"); // 158
        bahasaJP.Add("西の森"); // 159
        bahasaJP.Add("南西の森"); // 160
        bahasaJP.Add("南の森"); // 161
        bahasaJP.Add("ジャンクション"); // 162
        bahasaJP.Add("24時間\n市場"); // 163
        bahasaJP.Add("分野"); // 164
        bahasaJP.Add("種子・農産物販売店"); // 165
        bahasaJP.Add("シード"); // 166
        bahasaJP.Add("製品"); // 167
        bahasaJP.Add("トマト"); // 168
        bahasaJP.Add("コーン"); // 169
        bahasaJP.Add("小さな牛乳"); // 170
        bahasaJP.Add("小さな山羊乳"); // 171
        bahasaJP.Add("鶏卵"); // 172
        bahasaJP.Add("アヒルの卵"); // 173
        bahasaJP.Add("すべて選択"); // 174
        bahasaJP.Add("売る"); // 175
        bahasaJP.Add("トウモロコシ - 小麦や米に加えて、世界で最も重要な炭水化物生産食用作物の1つ"); // 176
        bahasaJP.Add("小さな牛乳 - たんぱく質とカルシウム、そしてビタミンB12、マグネシウム、ヨウ素などの栄養素の優れた供給源"); // 177
        bahasaJP.Add("ミディアムカウミルク - たんぱく質とカルシウム、そしてビタミンB12、マグネシウム、ヨウ素などの栄養素の優れた供給源"); // 178
        bahasaJP.Add("大きな牛乳 - タンパク質とカルシウムのほか、ビタミン B12、マグネシウム、ヨウ素などの栄養素の優れた供給源"); // 179
        bahasaJP.Add("小さなヤギのミルク - 骨と歯の維持と強化、および消化器系の維持に潜在的な利点があります"); // 180
        bahasaJP.Add("ミディアム ゴート ミルク - 骨と歯の維持と強化、および消化器系の維持に潜在的な利点があります"); // 181
        bahasaJP.Add("ラージ ゴート ミルク - 骨と歯の維持と強化、および消化器系の維持に潜在的な利点があります"); // 182
        bahasaJP.Add("鶏卵 - 卵に含まれる栄養素は、アミノ酸、脂肪、ビタミン、ミネラルからルテインに至るまで、非常に完全です"); // 183
        bahasaJP.Add("アヒルの卵 - アヒルの卵には、タンパク質、脂肪、炭水化物が含まれているだけでなく、マルチビタミンとミネラルも含まれています"); // 184
        bahasaJP.Add("バッグがいっぱいです/収まりません"); // 185
        bahasaJP.Add("所有する小さなかわいい猫 "); // 186
        bahasaJP.Add("所有する小さなかわいい鶏 "); // 187
        bahasaJP.Add("所有する小さなかわいいアヒル "); // 188
        bahasaJP.Add("鶏肉屋"); // 189
        bahasaJP.Add("チキン"); // 190
        bahasaJP.Add("アヒル"); // 191
        bahasaJP.Add("鶏の飼料"); // 192
        bahasaJP.Add("本当に売りたいですか？"); // 193

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

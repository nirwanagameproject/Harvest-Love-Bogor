# Harvest Love Bogor
Permainan simulasi **multiplayer** perkebunan Indonesia yang dibuat tahun 2020.Permainan ini terinspirasi dari *Harvest Moon*,
*Story of Seasons* dan *Stardew Valley*.

## Gameplay
Player akan bermain sebagai anak muda yang mendapatkan kesempatan mengikuti program pemuda masuk desa* untuk mengelola sebuah lahan pertanian kosong yang harus diolah menjadi lahan produktif. Desa tersebut juga terancam oleh pengalihan fungsi desa oleh developer korup yang mempengaruhi penduduk desa, player akan mengatur antara mengelola lahan pertanian, mengeksplor desa dan menjalankan main / optional quest  untuk mencegah objek desa diambil oleh developer tersebut atau berinterkasi dengan NPC.

## Fitur yang sudah ada
1. Menanam
2. **Multiplayer**

## Dokumentasi
[Lihat Wiki disini](https://github.com/nirwanagameproject/Harvest-Love-Bogor-Wiki/wiki)
### Cara membuat lahan baru (scene)
1. membuat **Terrain** 
    1. buka *tab inspector* pada *layer* rubah menjadi **Ground**
    2. cari **Terrain** pada *tab* **Paint Terrain** ,lalu pilih **Add Layer** tambahkan (**Grass** , **Dirt**)
    3. klik *icon* **Paint Terrain**,pilih **Brushes** dengan *size* / ukuran sesuai jalan yang akan dibuat
    4. klik **Terrain Setting**, ubah *width* / lebar dan *height* / tinggi 
2. mencopy **Sun**,**EventSystem** dan **Gamesetup** ke dalam **scene**
3. membuat nama **Spawn** dari tempat yang sebelumnya dengan format
    1. `Spawn`+Nama **Scane** sebelumnya yang mengarah ke **Scene** ini.Controh `SpawnPersimpangan`
4. membuat **door** pada tempat yang sebelumnya dengan menyalin **door** ke **Scene** yang dibuat tersebut lalu beri nama `door`+Nama Scene yang dituju.Contoh `doorPersimpangan`.Cari **Door(Script)** lalu isi parameter dibawahnya 
    1. *level* = (Nama **Scene**).Contoh : `PersimpanganJalan`
    2. *respawn* = (**GameObject Spawn** yang dibuat).Contoh : `SpawnPersimpangan`
    3. pintu = (apakah pintu atau gerbang).Contoh : checklist `pintu`
5. membuat **Cube** pembatas (agar tidak jatuh dari terrain)
6. membuat object sesual peta dengan *mesh collider* (untuk tabrakan).
7. klik **File - Build Settings** - *drag scane* ke *scène in build*
8. membuat occlution culling agar menghemat memory dengan merender objek yg terlihat kamera saja.Objek yang diblok objek lain yang terlihat tidak dapat ditampilkan.
    1. pilih **GameObject** atau Objek 3D yang ada didalam **Scene** yang bergerak statis
    2. klik tanda *dropdown* disamping tulisan *static* dibagian kanan.
    3. pilih *occluder static* lalu , *Yes change children*.
    4. pilih *occludee static* lalu , *Yes change children*.
    5. pilih *batching static* lalu , *Yes change children*.
    6. pilih *navigation static* lalu , *Yes change children*.
    7. ulangi langkat 1 sampai 6 pada objek yang bergerak statis sampai semuanya terpenuhi
    8. klik **Windows - Rendering - Occlution Culling**
    9. pilih *tab* **Bake** lalu klik tombol **Bake** dibawahnya
9. Perbaiki *lighting* beda setiap **scene** baru dengan mengikuti step berikut : 
    1. klik **Windows - Rendering - Lighting**
    2. *checklist* **Generate Lightning**
10. ulangi langkah 8 dan 9 jika menambahkan objek baru lagi (tambah mesh collider juga).

### Cara membuat text dengan Terjemahan baru :
1. membuat *component* **UI** *text*
2. buka *script* **Language.cs**
    1. tambahkan `bahasaID.Add(“Terjemahan Indonesia”);`
    2. tambahkan `bahasaUS.Add(“Terjemahan Inggris”);`
    3. tambahkan `bahasaJP.Add(“Terjemahan Jepang”);`
4. buka tambahkan script **ChangeLanguage.cs** dengan **indexText** dari *script* **Language.cs**
5. ubah *tag* di *inspector* menjadi **Language**

### Cara install Cocoapod untuk build IOS
1. buka terminal
2. ketikan `sudo gem update --system`
3. ketikan `sudo gem install cocoapods`
4. ketikan `pod setup`

### Cara build IOS di Xcode (Butuh instalasi Cocoapod)
1. Buka Project dengan extensi .xcworkspace
2. Buka Tab Signing & Capabilities ,rubah Team sesuai Akun Developer Apple kamu.
3. Buka Tab Build Settings , pada kolom pencarian cari `enable modules` lalu rubah menjadi `Yes`

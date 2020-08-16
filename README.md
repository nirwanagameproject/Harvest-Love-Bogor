# Harvest Love Bogor
Permainan simulasi **multiplayer** perkebunan Indonesia yang dibuat tahun 2020.Permainan ini terinspirasi dari *Harvest Moon*,
*Story of Seasons* dan *Stardew Valley*.

## Gameplay
Permainan ini tentang para mahasiswa/mahasiswi yang ingin membuat tugas akhir meneliti tentang pertanian di Indonesia.
Mereka diberi tugas oleh kepala desa untuk mengurus perkebunan yang sudah tidak terawat.Tujuan utamanya agar dapat mempertahankan perkebunan
agar tidak jatuh ke orang yang salah.Pemain bisa memutuskan untuk membuat kebun seperti apa selanjutnya,seperti membersihkan ladang,
menanam dan memanen, menjual hasil panen, berbagi hasil panen antar pemain,mengikuti perlombaan di desa dan membangun hubungan baik dengan warga.

## Fitur yang sudah ada
1. Menanam
2. **Multiplayer**

## Dokumentasi
### Cara membuat lahan baru (scene)
1. membuat **Terrain** 
    1. type **Ground**
    2. pilih **Add Layer** tambahkan (**Grass** , **Dirt**)
    3. klik icon **Paint Terrain**,pilih **Brushes** dengan *size* / ukuran sesuai jalan yang akan dibuat
    4. klik **Terrain Setting**, ubah *width* / lebar dan *height* / tinggi 
2. mencopy **Sun**,**EventSystem** dan **Gamesetup** ke dalam **scene**
3. membuat nama **Spawn** dari tempat yang sebelumnya
4. membuat **door** pada tempat yang sebelumnya
    1. setting *level* (Nama **Scene**) , *respawn* (**GameObject Spawn** yang dibuat) , pintu (apakah pintu atau gerbang)
5. Perbaiki *lighting* beda setiap **scene** baru dengan mengikuti step berikut : 
    1. klik **Windows - Rendering - Lighting**
    2. *checklist* **Auto Generate**
6. membuat **Cube** pembatas (agar tidak jatuh dari terrain)
7. membuat object sesual peta dengan *mesh collider* (untuk tabrakan).
8. klik **File - Build Settings** - *drag scane* ke *scène in build*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialogBag : MonoBehaviour
{
    RectTransform sr;
    double worldScreenHeight = Screen.height;
    double worldScreenWidth = Screen.width;
    public int buka;
    public Text isitext;
    public GameObject taptocontinue;
    public string isidialog;
    public bool percakapanaktif;
    public bool lanjutGa;
    int i;

    public static MyDialogBag instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        sr = GetComponent<RectTransform>();
        //StartCoroutine("intro1");
    }

    IEnumerator intro1()
    {
        PercakapanBaru("Pilih barang atau peralatan untuk dipindahkan", false);
        while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (sr.rect.height < 150 && buka==1)
            sr.sizeDelta = new Vector2(sr.rect.width, sr.rect.height+20f);
        else if(sr.rect.height >= 150 && buka == 1)
        {
            buka = 2;
            InvokeRepeating("jalaninText", 0f, 0.025f);
        }

        if (sr.rect.height > 0 && buka==0)
            sr.sizeDelta = new Vector2(sr.rect.width, sr.rect.height - 20f);

        if (sr.rect.height > 0 && buka == 2)
        {
            if (isitext.text.Length >= isidialog.Length) buka = 3;
        }
            
    }

    public void PercakapanBaru(string isi, bool lanjut)
    {
        percakapanaktif = true;
        isitext.gameObject.SetActive(true);
        isitext.text = "";
        buka = 1;
        isidialog = isi;
        i = 0;
        lanjutGa = lanjut;
    }

    public void jalaninText()
    {
        AudioSource audio = GameObject.Find("TextDialogue").GetComponent<AudioSource>();
        if(!audio.isPlaying)audio.Play();
        isitext.text = isitext.text + isidialog[i].ToString();
        i++;
        if (i == isidialog.Length) CancelInvoke("jalaninText");
    }

    public void fulltext()
    {
        isitext.text = isidialog;
    }

    public void exitpercakapan()
    {
        if (buka == 2)
        {
            fulltext();
            CancelInvoke("jalaninText");
        }
        else if (buka == 3 && !lanjutGa)
        {
            buka = 0;
            isitext.gameObject.SetActive(false);
            percakapanaktif = false;
        }
        else if (buka == 3 && lanjutGa)
        {
            percakapanaktif = false;
        }

    }

    public void percakapanDeskripsi(string namaperalatan)
    {
        if(namaperalatan=="hoe")PercakapanBaru("Pacul - Alat untuk menggali tanah, gunakan ini untuk membuat lahan penanaman bibit dan mencangkul lahan pertambangan.",false);
        else if(namaperalatan=="axe")PercakapanBaru("Kapak - Alat untuk membelah kayu, dapat digunakan untuk mendapatkan kayu dalam membangun rumah.",false);
        else if(namaperalatan=="hammer")PercakapanBaru("Palu - Alat untuk menghancurkan batu.",false);
        else if(namaperalatan=="sickle")PercakapanBaru("Sabit - Alat untuk memotong rumput.",false);
        else if(namaperalatan=="watering")PercakapanBaru("Penyiram - Alat untuk menyiram tanaman/bibit, isi penyiram dengan mendekati sumber air terdekat.",false);
        else if(namaperalatan=="peralatanbibit1")PercakapanBaru("Bibit Tomat - Tanam diwaktu spring, buah tomat segar dijual dengan harga Rp 8000 per satuan",false);
        else if (namaperalatan == "bale") PercakapanBaru("Bibit Tomat - Tanam diwaktu spring, buah tomat segar dijual dengan harga Rp 8000 per satuan", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialog : MonoBehaviour
{
    RectTransform sr;
    double worldScreenHeight = Screen.height;
    double worldScreenWidth = Screen.width;
    public int buka;
    public Text isitext;
    public GameObject taptocontinue;
    public GameObject textDialog;
    public string isidialog;
    public bool percakapanaktif;
    public bool lanjutGa;
    int i;

    public GameObject namakamu;
    public GameObject namafarm;
    public GameObject namakucing;
    public GameObject ulantahun;
    public GameObject konfirmasi;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("gender");
        sr = GetComponent<RectTransform>();
        StartCoroutine("intro1");
    }

    IEnumerator intro1()
    {
        isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(23);
        PercakapanBaru(isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate, true);
        while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);
        {
            isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(25);
            PercakapanBaru(isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate, true);
        }
        while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);
        {
            isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(26);
            PercakapanBaru(isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate, true);
        } while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);
        {
            StartCoroutine("intro2");
        }
    }

        IEnumerator intro2()
    {
        //Masukin Nama
        isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(27);
        PercakapanBaru(isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate, false);
        while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);
        namakamu.SetActive(true);
        PlayerPrefs.DeleteKey("myname");
        while (PlayerPrefs.HasKey("myname") == false) yield return new WaitUntil(() => PlayerPrefs.HasKey("myname") == true);
        namakamu.SetActive(false);

        //Ultang tahun
        isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(28);
        string dialog1 = isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate;
        isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(29);
        string dialog2 = isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate;
        PercakapanBaru(dialog1+ PlayerPrefs.GetString("myname")+dialog2, false);
        while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);
        ulantahun.SetActive(true);
        PlayerPrefs.DeleteKey("mytanggallahir");
        PlayerPrefs.DeleteKey("mymusimlahir");
        while (PlayerPrefs.HasKey("mytanggallahir") == false) yield return new WaitUntil(() => PlayerPrefs.HasKey("mytanggallahir") == true);
        ulantahun.SetActive(false);

        //Nama Kebun
        isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(31);
        PercakapanBaru(isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate, false);
        while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);
        namafarm.SetActive(true);
        PlayerPrefs.DeleteKey("mykebun");
        while (PlayerPrefs.HasKey("mykebun") == false) yield return new WaitUntil(() => PlayerPrefs.HasKey("mykebun") == true);
        namafarm.SetActive(false);

        //Nama Kebun
        isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(32);
        PercakapanBaru(isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate, false);
        while (percakapanaktif == true) yield return new WaitUntil(() => percakapanaktif == false);
        namakucing.SetActive(true);
        PlayerPrefs.DeleteKey("mykucing");
        while (PlayerPrefs.HasKey("mykucing") == false) yield return new WaitUntil(() => PlayerPrefs.HasKey("mykucing") == true);
        namakucing.SetActive(false);

        //Konfirmasi
        konfirmasi.SetActive(true);
        PlayerPrefs.DeleteKey("lanjutpilihgender");
        while (PlayerPrefs.HasKey("lanjutpilihgender") == false) yield return new WaitUntil(() => PlayerPrefs.HasKey("lanjutpilihgender") == true);
        if(PlayerPrefs.GetString("lanjutpilihgender") == "no")
        {
            konfirmasi.SetActive(false);
            StartCoroutine("intro2");
        }
        else if (PlayerPrefs.GetString("lanjutpilihgender") == "yes")
        {
            //PILIH GENDER
            konfirmasi.SetActive(false);
            isitext.gameObject.GetComponent<ChangeLanguage>().GetLanguage(33);
            PercakapanBaru(isitext.gameObject.GetComponent<ChangeLanguage>().textTranslate, false);
            PlayerPrefs.DeleteKey("gender");
            while (PlayerPrefs.HasKey("gender") == false) yield return new WaitUntil(() => PlayerPrefs.HasKey("gender") == true);
            exitpercakapan();

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.HasKey("gender"))
        {
            Vector3 pos = new Vector3();
            pos.x = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).transform.position.x;
            pos.z = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).transform.position.z - 2f;
            pos.y = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).transform.position.y + 1f;
            Vector3 velocity = Vector3.zero;
            Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, pos, ref velocity, 0.3f);
            Camera.main.transform.LookAt(new Vector3(pos.x, pos.y, pos.z + 2f));
        }
        

        if (Input.touchCount == 1 && PlayerPrefs.HasKey("gender"))
        {
            float rotateSpeed = 0.09f;
            Touch touchZero = Input.GetTouch(0);

            //Rotate the model based on offset
            Vector3 localAngle = GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).transform.localEulerAngles;
            localAngle.y -= rotateSpeed * touchZero.deltaPosition.x;
            GameObject.Find("TerrainLoadingMenu").transform.Find(PlayerPrefs.GetString("gender")).transform.localEulerAngles = localAngle;
        }

        if (sr.rect.height < 430 && buka==1)
            sr.sizeDelta = new Vector2(sr.rect.width, sr.rect.height+20f);
        else if(sr.rect.height >= 430 && buka == 1)
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
}

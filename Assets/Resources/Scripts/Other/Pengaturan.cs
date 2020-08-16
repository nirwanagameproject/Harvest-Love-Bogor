using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Pengaturan : MonoBehaviour
{
    public AudioMixer mixer;

    void Start()
    {
        //AUTO AMBIL SETTINGAN
        if (PlayerPrefs.HasKey("Music"))
        {
            GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("SliderBGM").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music");
        }
        if (PlayerPrefs.HasKey("Sound"))
        {
            GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("SliderSFX").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Sound");
        }

        if (PlayerPrefs.HasKey("GraphicQuality"))
        {
            if (PlayerPrefs.GetInt("GraphicQuality") != GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("QualityVideo").GetComponent<Dropdown>().value)
            {
                //QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicQuality"), true);
                GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("QualityVideo").GetComponent<Dropdown>().value = PlayerPrefs.GetInt("GraphicQuality");
            }
        }
    }

    public void OnChangeQuality() // change team
    {
        int dropdownval = GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("QualityVideo").GetComponent<Dropdown>().value;

        QualitySettings.SetQualityLevel(dropdownval, true);

        PlayerPrefs.SetInt("GraphicQuality", dropdownval);
    }

    public void OnChangeResolution() // change team
    {
        int x = 0, y = 0;
        int dropdownval = GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("DisplayVideo").GetComponent<Dropdown>().value;
        if (dropdownval == 0) { x = 1280; y = 768; }
        else if (dropdownval == 1) { x = 1366; y = 768; }
        else if (dropdownval == 2) { x = 1920; y = 1080; }
        PlayerPrefs.SetInt("GraphicResolution", dropdownval);

        Screen.SetResolution(x, y, true);
        //GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<ScaleFullCanvas>().refreshReso();
    }

    public void SetLevelBGM()
    {
        float sliderValue = GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("SliderBGM").GetComponent<Slider>().value;
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("PersenBGM").GetComponent<Text>().text = (int)(sliderValue*100)+"/100";
        PlayerPrefs.SetFloat("Music", sliderValue);
    }

    public void SetLevelSFX()
    {
        float sliderValue = GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("SliderSFX").GetComponent<Slider>().value;
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
        GameObject.Find("Canvas").transform.Find("Pengaturan").Find("BGAtas").Find("PersenSFX").GetComponent<Text>().text = (int)(sliderValue * 100) + "/100";
        PlayerPrefs.SetFloat("Sound", sliderValue);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToMenu : MonoBehaviour
{
    public GameObject tapmelanjutkan;
    public GameObject mainmenuOBJ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void ClickThis()
    {
        AudioSource audio = GameObject.Find("Clicked").GetComponent<AudioSource>();
        audio.Play();

        tapmelanjutkan.SetActive(false);
        mainmenuOBJ.SetActive(true);
        tapmelanjutkan.GetComponent<TextBerkdedip>().CancelInvoke();
        gameObject.SetActive(false);
    }
}

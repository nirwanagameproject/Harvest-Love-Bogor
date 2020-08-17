using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBerkdedip : MonoBehaviour
{
    RectTransform sr;
    double worldScreenHeight = Screen.height;
    double worldScreenWidth = Screen.width;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<RectTransform>();
        InvokeRepeating("berkedip",0,1f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void berkedip()
    {
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}

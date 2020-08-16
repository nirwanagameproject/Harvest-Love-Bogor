using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadertoBottom : MonoBehaviour
{
    RectTransform sr;
    double worldScreenHeight = Screen.height;
    double worldScreenWidth = Screen.width;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sr.localPosition.y> ((worldScreenHeight) * 0.25f))
        sr.localPosition = new Vector3((float)(sr.localPosition.x), ((float)(sr.localPosition.y-2.5f)), 0);
    }
}

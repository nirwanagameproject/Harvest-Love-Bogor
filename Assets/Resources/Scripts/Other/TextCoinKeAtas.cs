using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCoinKeAtas : MonoBehaviour
{
    RectTransform sr;
    double worldScreenHeight = Screen.height;
    double worldScreenWidth = Screen.width;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<RectTransform>();
        
    }

    public bool geraksetting;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Text>().text.Contains("+"))
        {
            if (transform.localPosition.y > -30 && geraksetting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 52f, transform.position.z);
                if (transform.localPosition.y <= -30)
                {
                    geraksetting = false;
                    GetComponent<Text>().text = "";
                }
            }
            else if (transform.localPosition.y < 0 && !geraksetting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                if (transform.localPosition.y >= 0) geraksetting = true;
            }
        }
        else if (GetComponent<Text>().text.Contains("-"))
        {
            if (transform.localPosition.y > -30 && geraksetting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                if (transform.localPosition.y <= -30)
                {
                    geraksetting = false;
                    GetComponent<Text>().text = "";
                }
            }
            else if (transform.localPosition.y < 0 && !geraksetting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 52f, transform.position.z);
                if (transform.localPosition.y >= 0) geraksetting = true;
            }
        }
        
    }
}

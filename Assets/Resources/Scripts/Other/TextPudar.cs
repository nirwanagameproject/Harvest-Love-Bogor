using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPudar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("pudar", 0, 0.5f);
    }

    // Update is called once per frame
    void pudar()
    {
        GetComponent<Text>().color = new Color(0,0,0, GetComponent<Text>().color.a-0.1f);
        if (GetComponent<Text>().color.a <= 0.1f)
        {
            GetComponent<Text>().color = new Color(0, 0, 0, 1);
            gameObject.SetActive(false);
        }
    }
}

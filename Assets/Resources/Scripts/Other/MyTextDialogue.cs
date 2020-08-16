using System;
using System.Collections;
using UnityEngine;

public class MyTextDialogue : MonoBehaviour
{


    private static MyTextDialogue instance = null;
    public static MyTextDialogue Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
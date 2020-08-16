using System;
using System.Collections;
using UnityEngine;

public class MyCanvas : MonoBehaviour
{


    private static MyCanvas instance = null;
    public static MyCanvas Instance
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
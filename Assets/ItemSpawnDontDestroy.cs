using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnDontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private static ItemSpawnDontDestroy instance = null;
    public static ItemSpawnDontDestroy Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

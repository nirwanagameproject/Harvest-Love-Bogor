using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnDontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private static PlayerSpawnDontDestroy instance = null;
    public static PlayerSpawnDontDestroy Instance
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

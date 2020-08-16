using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class river : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("animasiriver",0f,0.1f);
    }

    public void animasiriver()
    {
        if(GetComponent<MeshRenderer>().material.mainTextureScale.y<0.3f)
            GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(GetComponent<MeshRenderer>().material.mainTextureScale.x, Random.Range(0.3f,0.6f));
        else GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(GetComponent<MeshRenderer>().material.mainTextureScale.x, GetComponent<MeshRenderer>().material.mainTextureScale.y-0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

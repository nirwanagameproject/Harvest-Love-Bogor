using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customgrid : MonoBehaviour
{
    public GameObject target;
    public GameObject structure;
    public GameObject structure2;
    public Vector3 truepos;
    public float gridSize;

    // Update is called once per frame
    void Start()
    {
        //gridding();
    }

    public void gridding()
    {
        truepos.x = Mathf.Round(target.transform.position.x / gridSize) * gridSize;
        truepos.y = 0.011f + (Mathf.Round(target.transform.position.y / gridSize) * gridSize);
        truepos.z = Mathf.Round(target.transform.position.z / gridSize) * gridSize;

        structure.transform.position = truepos;
        structure2.transform.position = truepos;
    }
}

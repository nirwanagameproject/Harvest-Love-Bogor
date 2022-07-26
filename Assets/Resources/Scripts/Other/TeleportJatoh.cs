using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportJatoh : MonoBehaviour
{
    public int minjatoh = 1;
    public int maxjatoh = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player") || collision.collider.tag.Equals("NPChewan") || collision.collider.tag.Equals("Buah"))
        {
            if (collision.collider.GetComponent<PhotonView>() != null && PhotonNetwork.IsConnected)
            {
                if (!collision.collider.GetComponent<PhotonView>().IsMine || collision.collider.tag.Equals("NPChewan") || collision.collider.tag.Equals("Buah"))
                {
                    if (collision.collider.tag.Equals("NPChewan") || collision.collider.tag.Equals("Buah"))
                    {
                        System.Random rnd = new System.Random();
                        collision.transform.position = new Vector3((float)rnd.Next(minjatoh, maxjatoh), 1f, (float)rnd.Next(minjatoh, maxjatoh));
                        Debug.Log("teleport jatoh " + collision.collider.name);
                    }
                    return;
                }
                else
                {
                    collision.transform.position = new Vector3(collision.transform.position.x, 1f, collision.transform.position.z);
                }
            }
            

        }
    }
}

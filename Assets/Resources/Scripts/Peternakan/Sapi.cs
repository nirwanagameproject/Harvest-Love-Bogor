using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapi : MonoBehaviour
{
    private Animator anim;
    private float speed;
    private List<Vector3> posisi = new List<Vector3>();
    private int i;
    public bool aktif;
    public int onlineinmap;
    // Start is called before the first frame update
    void Start()
    {
        onlineinmap = 0;
        anim = GetComponent<Animator>();
        speed = 0.5f;
        i = 0;
        
        Vector3 pos = new Vector3();

        pos.x = Random.Range(2f, 6.9f);
        pos.y = 0.14f;
        pos.z = Random.Range(13.58f, 16.47f);

        posisi.Add(pos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onlineinmap>0)
        {
            if (Vector3.Distance(posisi[0], transform.position) <= 0.1)
            {
                anim.SetBool("isWalking", false);
                Vector3 pos = new Vector3();

                pos.x = Random.Range(2f, 6.9f);
                pos.y = 0.14f;
                pos.z = Random.Range(13.58f, 16.47f);

                posisi[0] = pos;
            }else
            {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, posisi[0], step);
                Vector3 direction = posisi[0] - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 3f);
                anim.SetBool("isWalking", true);
            }
        }
        
    }

    [PunRPC]
    void cowaktif(bool aktifin)
    {
        aktif = aktifin;
        if (aktif)
            onlineinmap++;
        else onlineinmap--;
    }
}

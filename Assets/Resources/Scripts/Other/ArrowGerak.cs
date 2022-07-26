using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowGerak : MonoBehaviour
{
    RectTransform sr;
    public bool geraksetting;
    public bool gerakquest;
    public bool gerakkanankirimin;
    public bool gerakstamina;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (name == "redarrow")
            if (transform.localPosition.x > 200 && gerakkanankirimin)
        {
            transform.position = new Vector3(transform.position.x-1f,transform.position.y,transform.position.z);
            if (transform.localPosition.x <= 200) gerakkanankirimin = false;
        }
        else if (transform.localPosition.x < 250 && !gerakkanankirimin)
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            if (transform.localPosition.x >= 250) gerakkanankirimin = true;
        }

        if(name=="redarrow2")
        if (transform.localPosition.x > 350 && gerakquest)
        {
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            if (transform.localPosition.x <= 350) gerakquest = false;
        }
        else if (transform.localPosition.x < 400 && !gerakquest)
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            if (transform.localPosition.x >= 400) gerakquest = true;
        }

        if (name == "redarrow3" || name == "redarrow4" || name == "redarrow5" || name == "redarrow6" || name == "redarrow7")
            if (transform.localPosition.y > 150 && geraksetting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                if (transform.localPosition.y <= 150) geraksetting = false;
            }
            else if (transform.localPosition.y < 200 && !geraksetting)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                if (transform.localPosition.y >= 200) geraksetting = true;
            }

        if (name == "redarrow8" || name == "redarrow9")
            if (transform.localPosition.x > -255 && gerakstamina)
            {
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                if (transform.localPosition.x <= -255) gerakstamina = false;
            }
            else if (transform.localPosition.x < -200 && !gerakstamina)
            {
                transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                if (transform.localPosition.x >= -200) gerakstamina = true;
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //Input
    public Player1 Player;
    public Joystick joystick;

    public static Controller instance;

    public bool pacul;
    public bool jump;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Player = gameObject.GetComponent<Player1>();
        joystick = GameObject.Find("Canvas").transform.Find("Fixed Joystick").GetComponent<Joystick>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Player.Inputs.JoystickX = joystick.Horizontal;
        Player.Inputs.JoystickZ = joystick.Vertical;

        if (pacul)
        {
            Player.Inputs.attacking = pacul;
            pacul = false;
        }

        if (jump)
        {
            Player.Inputs.Jump = jump;
            jump = false;
        }

    }

}

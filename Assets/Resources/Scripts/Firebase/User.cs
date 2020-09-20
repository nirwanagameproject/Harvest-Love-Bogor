
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

[Serializable]
public class User
{
    public string id;
    public LinkedAcc linkedacc;

    public User(string id, LinkedAcc linkedAcc)
    {
        this.id = id;
        this.linkedacc = linkedAcc;
    }
}

[Serializable]
public class LinkedAcc
{
    public string tipeacc;
    public string email;
    public string name;
    public string id;
    public LinkedAcc(string tipeacc, string email, string name, string id)
    {
        this.tipeacc = tipeacc;
        this.email = email;
        this.name = name;
        this.id = id;
    }
}


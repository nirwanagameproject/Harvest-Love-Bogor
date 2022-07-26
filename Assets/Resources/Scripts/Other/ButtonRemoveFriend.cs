using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRemoveFriend : MonoBehaviour
{
    public void RemoveFriend()
    {
        if(!transform.parent.name.Contains("tools"))
        firedatabase.instance.removeFriend(transform.parent.name);
    }

    public void AcceptFriendReq()
    {
        if (!transform.parent.name.Contains("tools"))
            firedatabase.instance.AcceptFriendReq(transform.parent.name);
    }
    public void DenyFriendReq()
    {
        if (!transform.parent.name.Contains("tools"))
            firedatabase.instance.DenyFriendReq(transform.parent.name);
    }
}

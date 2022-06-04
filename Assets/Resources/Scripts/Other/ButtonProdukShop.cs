using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonProdukShop : MonoBehaviour
{
    public void BeliProduk()
    {
        if(!name.Contains("tools"))
        IAPManager.instance.BuyKelereng(name);
    }
}

using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ChangeGear : MonoBehaviour
{
    private Equipment equipmentScript;
    public List<string> topi;
    private int topiIndex;

    public List<string> top;
    private int topIndex;

    private void Start()
    {
        topi = new List<string>();
        topiIndex = 0;
        top = new List<string>();
        topIndex = 0;
        equipmentScript = GetComponent<Equipment>();
        //create equipment list
        equipmentScript.InitializeEquipptedItemsList();
        //equip stuff
        topi.Add("conical_hat");
        topi.Add("pie_hat");

        top.Add("t_shirt_top");
        top.Add("sweeter_top");


        EquipItem("Body", topi[topiIndex]);
        EquipItem("Hair", "japan_hair");
        EquipItem("Top", top[topIndex]);
        EquipItem("Bottom", "long_pants_bottom");
        if (GetComponent<PhotonView>().IsMine)
            Gamesetupcontroller.instance.LoadSkinMine(this.gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            UnequipItem("Body", topi[topiIndex]);
            topiIndex++;
            if (topiIndex == 2)
            {
                topiIndex = 0;
            }
            EquipItem("Body", topi[topiIndex]);
            
        }
        else if (Input.GetKeyDown(KeyCode.C))
        { 
            UnequipItem("Top", top[topIndex]);
            topIndex++;
            if (topIndex == 2)
            {
                topIndex = 0;
            }
            EquipItem("Top", top[topIndex]);

        }
    }

    public void EquipItem(string itemType, string itemSlug)
    {
        for (int i = 0; i < equipmentScript.equippedItems.Count; i++)
        {
            if (equipmentScript.equippedItems[i].ItemType == itemType)
            {
                equipmentScript.equippedItems[i] = ItemDatabase.instance.FetchItemBySlug(itemSlug);
                equipmentScript.AddEquipment(equipmentScript.equippedItems[i]);
                break;
            }
        }
    }

    public void UnequipItem(string itemType, string itemSlug)
    {
        for (int i = 0; i < equipmentScript.equippedItems.Count; i++)
        {
            if (equipmentScript.equippedItems[i].ItemType == itemType)
            {
                equipmentScript.RemoveEquipment(equipmentScript.equippedItems[i]);
                break;
            }
        }
    }
}
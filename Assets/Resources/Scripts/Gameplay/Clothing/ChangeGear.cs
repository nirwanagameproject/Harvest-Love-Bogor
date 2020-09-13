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
    }

    public void LoadGear() {
        topi = new List<string>();
        topiIndex = 0;
        top = new List<string>();
        topIndex = 0;
        equipmentScript = GetComponent<Equipment>();
        //create equipment list
        //equip stuff

        if (GetComponent<PhotonView>().IsMine)
        {
            equipmentScript.InitializeEquipptedItemsList();

            topi.Add("conical_hat");
            topi.Add("pie_hat");

            top.Add("t_shirt_top");
            top.Add("sweeter_top");


            EquipItem("Body", topi[topiIndex]);

            if (PlayerPrefs.GetString("gender") == "cowok")
            {
                EquipItem("Hair", "japan_hair");
                EquipItem("Top", top[topIndex]);
                EquipItem("Bottom", "long_pants_bottom");
            }
            else
            {
                EquipItem("Hair", "famale_long_hair");
                if (topIndex == 0 || topIndex == 2)
                {
                    EquipItem("Top", "famale_t_shirt_top");
                }
                else
                {
                    EquipItem("Top", top[topIndex]);
                }
                EquipItem("Bottom", "famale_long_pants_bottom");
            }
        }
        else
        {
            topi.Add("conical_hat");
            topi.Add("pie_hat");

            top.Add("t_shirt_top");
            top.Add("sweeter_top");

            EquipItem("Body", topi[topiIndex]);

            if (GetComponent<PhotonView>().Owner.CustomProperties["gender"] == "cowok")
            {
                EquipItem("Hair", "japan_hair");
                EquipItem("Top", top[topIndex]);
                EquipItem("Bottom", "long_pants_bottom");
            }
            else
            {
                EquipItem("Hair", "famale_long_hair");
                if (topIndex == 0 || topIndex == 2)
                {
                    EquipItem("Top", "famale_t_shirt_top");
                }
                else
                {
                    EquipItem("Top", top[topIndex]);
                }
                EquipItem("Bottom", "famale_long_pants_bottom");
            }
        }
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
            if (GetComponent<PhotonView>().IsMine)
            {
                if (PlayerPrefs.GetString("gender") == "cewek")
                {
                    EquipItem("Top", "famale_" + top[topIndex]);
                }
                else
                {
                    EquipItem("Top", top[topIndex]);
                }
            }
            else
            {
                if (GetComponent<PhotonView>().Owner.CustomProperties["gender"] == "cewek")
                {
                    EquipItem("Top", "famale_" + top[topIndex]);
                }
                else
                {
                    EquipItem("Top", top[topIndex]);
                }
            }
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
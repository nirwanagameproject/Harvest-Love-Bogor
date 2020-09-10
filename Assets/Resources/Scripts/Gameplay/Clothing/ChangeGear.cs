using System.Collections.Generic;
using UnityEngine;

public class ChangeGear : MonoBehaviour
{
    private Equipment equipmentScript;
    public List<string> topi;
    private int topiIndex;

    private void Start()
    {
        topi = new List<string>();
        topiIndex = 0;
        equipmentScript = GetComponent<Equipment>();
        //create equipment list
        equipmentScript.InitializeEquipptedItemsList();
        //equip stuff
        topi.Add("conical_hat");
        topi.Add("pie_hat");

        EquipItem("Body", topi[topiIndex]); 
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
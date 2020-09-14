using UnityEngine;
using System.Collections.Generic;

public class Equipment : MonoBehaviour
{
    #region Fields
    //gameObjects
    public GameObject avatar;

    public GameObject wornLegs;
    public GameObject wornChest;
    public GameObject wornHair;
    public GameObject wornBeard;
    public GameObject wornMustache;
    public GameObject wornShoes;
    public GameObject wornChestArmor;
    public GameObject wornHat;

    //lists
    public List<Item> equippedItems = new List<Item>(); 
    //scripts
    private Stitcher stitcher;
    //ints
    private int totalEquipmentSlots; 
    #endregion

    #region Monobehaviour
    public void Awake()
    {
        stitcher = new Stitcher();
    }
    
    public void InitializeEquipptedItemsList()
    {
        totalEquipmentSlots = 8;

        for (int i = 0; i < totalEquipmentSlots; i++)
        {
            equippedItems.Add(new Item());
        }

        AddEquipmentToList(0); //Hat
        AddEquipmentToList(1); //Legs
        AddEquipmentToList(2); //Hair
        AddEquipmentToList(3); //Bottom
        AddEquipmentToList(4); //Shoes
        AddEquipmentToList(5); //Beard
        AddEquipmentToList(6); //Mustache
        AddEquipmentToList(7); //Armor
    }

    public void AddEquipmentToList(int id)
    {
        for(int i = 0; i < equippedItems.Count; i++)
        {
            if(equippedItems[id].ItemID == -1)
            {
                equippedItems[id] = ItemDatabase.instance.FetchItemByID(id);
                break; 
            }
        }
    }

    public void AddEquipment(Item equipmentToAdd)
    {
        if (equipmentToAdd.ItemType == "Bottom")
            wornLegs = AddEquipmentHelper(wornLegs, equipmentToAdd);
        else if (equipmentToAdd.ItemType == "Top")
            wornChest = AddEquipmentHelper(wornChest, equipmentToAdd);
        else if (equipmentToAdd.ItemType == "Hair")
            wornHair = AddEquipmentHelper(wornHair, equipmentToAdd);
        else if (equipmentToAdd.ItemType == "Beard")
            wornBeard = AddEquipmentHelper(wornBeard, equipmentToAdd);
        else if (equipmentToAdd.ItemType == "Mustache")
            wornMustache = AddEquipmentHelper(wornMustache, equipmentToAdd);
        else if (equipmentToAdd.ItemType == "Shoes")
            wornShoes = AddEquipmentHelper(wornShoes, equipmentToAdd);
        else if (equipmentToAdd.ItemType == "ChestArmor")
            wornChestArmor = AddEquipmentHelper(wornChestArmor, equipmentToAdd);
        else if (equipmentToAdd.ItemType == "Body")
            wornHat = AddEquipmentHelper(wornHat, equipmentToAdd);
    }

    public GameObject AddEquipmentHelper(GameObject wornItem, Item itemToAddToWornItem)
    {
        wornItem = Wear(itemToAddToWornItem.ItemPrefab, wornItem);
        if (itemToAddToWornItem.Slug.Contains("hair"))
        {
            wornItem.name = "Hair001";
        }
        else if (itemToAddToWornItem.Slug.Contains("top"))
        {
            wornItem.name = "Top";
        }
        else if (itemToAddToWornItem.Slug.Contains("bottom"))
        {
            wornItem.name = "Bottom";
        }
        else
        {
            wornItem.name = itemToAddToWornItem.Slug;
        }
        return wornItem; 
    }

    public void RemoveEquipment(Item equipmentToAdd)
    {
        if (equipmentToAdd.ItemType == "Bottom")
            wornLegs = RemoveEquipmentHelper(wornLegs, 3);
        else if (equipmentToAdd.ItemType == "Top")
            wornChest = RemoveEquipmentHelper(wornChest, 1);
        else if (equipmentToAdd.ItemType == "Hair")
            wornHair = RemoveEquipmentHelper(wornHair, 2);
        else if (equipmentToAdd.ItemType == "Beard")
            wornBeard = RemoveEquipmentHelper(wornBeard, 5);
        else if (equipmentToAdd.ItemType == "Mustache")
            wornMustache = RemoveEquipmentHelper(wornMustache, 6);
        else if (equipmentToAdd.ItemType == "Shoes")
            wornShoes = RemoveEquipmentHelper(wornShoes, 4);
        else if (equipmentToAdd.ItemType == "ChestArmor")
            wornChestArmor = RemoveEquipmentHelper(wornChestArmor, 7);
        else if (equipmentToAdd.ItemType == "Body")
            wornHat = RemoveEquipmentHelper(wornHat, 0);
    }

    public GameObject RemoveEquipmentHelper(GameObject wornItem, int nakedItemIndex)
    {
        wornItem = RemoveWorn(wornItem);
        equippedItems[nakedItemIndex] = ItemDatabase.instance.FetchItemByID(nakedItemIndex);
        return wornItem; 
    }

    #endregion

    private GameObject RemoveWorn(GameObject wornClothing)
    {
        Debug.Log("Hapus Memakai");
        if (wornClothing == null)
            return null;
        GameObject.Destroy(wornClothing);
        return null; 
    }

    private GameObject Wear(GameObject clothing, GameObject wornClothing)
    {
        if (clothing == null)
            return null;
        clothing = (GameObject)GameObject.Instantiate(clothing);
        if (clothing.name.Contains("hair"))
        {
            clothing.name = "Hair001";
        }
        else if (clothing.name.Contains("top"))
        {
            clothing.name = "Top";
        }
        else if (clothing.name.Contains("bottom"))
        {
            clothing.name = "Bottom";
        }
        wornClothing = stitcher.Stitch(clothing, avatar);
        GameObject.Destroy(clothing);
        return wornClothing;
    }
}

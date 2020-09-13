using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();
    public static ItemDatabase instance; 
    private void Awake()
    {
        //create singlton
        instance = this; 

        //naked
        /*itemList.Add(new Item(0, "", "", "naked_legs", "Legs"));
        itemList.Add(new Item(1, "", "", "naked_chest", "Chest"));
        itemList.Add(new Item(2, "", "", "bald_head", "Hair"));
        itemList.Add(new Item(3, "", "", "no_beard", "Beard"));
        itemList.Add(new Item(4, "", "", "no_mustache", "Mustache"));
        itemList.Add(new Item(5, "", "", "empty_hand_r", "HandRight"));
        itemList.Add(new Item(6, "", "", "no_armor", "ChestArmor"));
        itemList.Add(new Item(7, "", "", "naked_slug", "Feet"));*/
        itemList.Add(new Item(0, "", "", "conical_hat", "Body", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Hat/conical_hat")));
        itemList.Add(new Item(1, "", "", "t_shirt_top", "Top", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Top/t_shirt_top")));
        itemList.Add(new Item(2, "", "", "japan_hair", "Hair", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Hair/japan_hair")));
        itemList.Add(new Item(3, "", "", "long_pants_bottom", "Bottom", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Bottom/long_pants_bottom")));
        itemList.Add(new Item(11, "", "", "pie_hat", "Body", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Hat/pie_hat")));
        itemList.Add(new Item(21, "", "", "sweeter_top", "Top", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Top/sweeter_top")));
        itemList.Add(new Item(22, "", "", "famale_t_shirt_top", "Top", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Top/famale_t_shirt_top")));
        itemList.Add(new Item(23, "", "", "famale_sweeter_top", "Top", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Top/famale_sweeter_top")));
        itemList.Add(new Item(31, "", "", "famale_long_hair", "Hair", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Hair/famale_long_hair")));
        itemList.Add(new Item(41, "", "", "famale_long_pants_bottom", "Bottom", (GameObject)Resources.Load("Model/MainMenu/3D/Clothing/Bottom/famale_long_pants_bottom")));

        DontDestroyOnLoad(this.gameObject);
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].ItemID == id)
            {
                return itemList[i];
            }
        }
        return null;
    }

    public Item FetchItemBySlug(string slugName)
    {
        for (int i = 0; i < itemList.Count; i++)
        {

            if (itemList[i].Slug == slugName)
            {
                return itemList[i];
            }
        }
        return null;
    }


}

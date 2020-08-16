using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Isi dengan credits
        string credits = "Special Thanks To : \n " +
            "\n3D Modeling : \n" +
            "1.Free3D \n" +
            " - Hernando Mora\n" +
            " - printable_models\n" +
            " - Other Artist Free3D\n" +
            "2.pixiv \n" +
            "3.Blender \n" +
            "4,The GIMP Team \n" +
            "\nGame Engine : \n" +
            "1.Unity Technologies \n" +
            "\n Nirwana Game Project\n" +
            "1.Fandy M F\n" +
            " - (Lead Project)\n" +
            " - Lead Programmer\n" +
            "2.Adam A P\n" +
            " - (Project Manager)\n" +
            " - Game Designer\n" +
            " - Programmer\n" +
            "3.M Daniel N\n" +
            " - Concept Artist\n" +
            " - Artist Management\n" +
            "4.Fajar M F\n" +
            " - Programmer";
        GetComponent<Text>().text = credits;
        int numLines = GetComponent<Text>().text.Split('\n').Length;
        float jumlahBaris = numLines;
        
        float x = transform.GetComponent<RectTransform>().localPosition.x;
        float y = transform.GetComponent<RectTransform>().localPosition.y;

        float lebar = (90f * (jumlahBaris));
        float panjang = transform.GetComponent<RectTransform>().rect.width;

        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(panjang, lebar);
        transform.GetComponent<RectTransform>().localPosition = new Vector2(x, y - (90f * (jumlahBaris - 1)) / 2);

        x = transform.parent.GetComponent<RectTransform>().localPosition.x;
        y = transform.parent.GetComponent<RectTransform>().localPosition.y;

        lebar = 90f * jumlahBaris;
        panjang = transform.parent.GetComponent<RectTransform>().rect.width;

        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(panjang, lebar);
        transform.parent.GetComponent<RectTransform>().localPosition = new Vector2(x, y - (90f * (jumlahBaris - 1)) / 2);


        GetComponent<Text>().text = credits;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

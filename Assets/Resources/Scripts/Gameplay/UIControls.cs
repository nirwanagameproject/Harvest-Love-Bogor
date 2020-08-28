//Attatch this script to a Button GameObject
using UnityEngine;
using UnityEngine.EventSystems;

public class UIControls : MonoBehaviour, IPointerDownHandler, IPointerUpHandler ,IDeselectHandler
{
    public void OnDeselect(BaseEventData eventData)
    {
        if (GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")") != null)
            GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Player1>().RotateAroundPlayer = true;
    }

    //Detect if a click occurs
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Player1>().RotateAroundPlayer = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")")!=null)
        GameObject.Find("PlayerSpawn").transform.Find("Player (" + PlayerPrefs.GetString("myname") + ")").GetComponent<Player1>().RotateAroundPlayer = true;
    }
}
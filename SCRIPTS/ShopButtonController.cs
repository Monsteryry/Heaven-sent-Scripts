using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopButtonController : MonoBehaviour, IPointerClickHandler
{
    public Image displayImage;
    public Item item;
    public string slotType;
    public void Use()
    {
        if (item)
        {
            Debug.Log("You clicked: " + item.itemName);
            //stick to cursor
            //save to selected
            //UpdateInfo();
        }
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Add buying system, if clicked decrease money and add item (random of the chosen type with level of character, rarity same like in drop sys)
        //or in Use() func
        //Use this to tell when the user right-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Right Clicked!");
        }

        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(name + " Game Object Left Clicked!");
        }
    }
}

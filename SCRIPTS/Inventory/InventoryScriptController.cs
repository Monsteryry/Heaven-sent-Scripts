using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryScriptController : MonoBehaviour
{/*
    public Image displayImage;
    public Item item;

    public GameObject icon;
    
    public void UpdateInfo()
    {
        displayImage.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
        if (item)
        {
            displayImage.sprite = item.icon;
            displayImage.color = Color.white;
        }
        else
        {
            displayImage.sprite = null;
            displayImage.color = Color.clear;
        }
    }
    public void UpdateInfo2()
    {
        displayImage.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
        if (ItemsHandler.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            icon.GetComponent<Image>().sprite = ItemsHandler.instance.list[transform.GetSiblingIndex()].icon;
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
    }
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
    // Start is called before the first frame update
    void Start()
    {
        UpdateInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        Item droppedItem = ItemsHandler.instance.itemList[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()];
        if (eventData.pointerDrag.transform.parent.name == gameObject.name)
        {
            return;
        }
        if (ItemsHandler.instance.itemList[transform.GetSiblingIndex()] == null)
        {
            ItemsHandler.instance.itemList[transform.GetSiblingIndex()] = droppedItem;
            ItemsHandler.instance.itemList[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = null;
            ItemsHandler.instance.UpdatePanelSlots();
        }
        else
        {
            Item tempItem = ItemsHandler.instance.itemList[transform.GetSiblingIndex()];
            ItemsHandler.instance.itemList[transform.GetSiblingIndex()] = droppedItem;
            ItemsHandler.instance.itemList[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = tempItem;
            ItemsHandler.instance.UpdatePanelSlots();

        }
    }*/
}

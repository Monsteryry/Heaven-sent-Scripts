using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject itemDescriptionPanel;
    public Image displayImage;
    public Item item;
    public string slotType;
    public void UpdateInfo()
    {
        displayImage.GetComponent<RectTransform>().sizeDelta = 0.9f * GetComponent<RectTransform>().sizeDelta;
        if (InventoryController.instance.itemList[transform.GetSiblingIndex()] != null)
        {
            displayImage.sprite = InventoryController.instance.itemList[transform.GetSiblingIndex()].icon;
            displayImage.gameObject.SetActive(true);
        }
        else
        {
            displayImage.gameObject.SetActive(false);
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
        itemDescriptionPanel = Inventory.instance.itemDescriptionPanel;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseOver()
    {
        if (item)
        {
            //show desc
        }
    }
    //add check if type of item equals type of slot
    public void OnDrop(PointerEventData eventData)
    {
        Item droppedItem = InventoryController.instance.itemList[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()];
        if (eventData.pointerDrag.transform.parent.name == gameObject.name)
        {
            return;
        }
        if (!IsNotSameTypes(eventData))
        {
            if (InventoryController.instance.itemList[transform.GetSiblingIndex()] == null)
            {
                InventoryController.instance.itemList[transform.GetSiblingIndex()] = droppedItem;
                InventoryController.instance.itemList[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = null;
                InventoryController.instance.UpdatePanelSlots();
            }
            else
            {
                Item tempItem = InventoryController.instance.itemList[transform.GetSiblingIndex()];
                InventoryController.instance.itemList[transform.GetSiblingIndex()] = droppedItem;
                InventoryController.instance.itemList[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = tempItem;
                InventoryController.instance.UpdatePanelSlots();

            }
        }
    }
    public void EquipItem(PointerEventData eventData)
    {/*
        Item clickedItem = InventoryController.instance.itemList[eventData.lastPress.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()];
        if (eventData.button == PointerEventData.InputButton.Right)
            foreach (var item in InventoryController.instance.itemList)
                if (item.itemType == clickedItem.itemType)
        */

    }
    public bool IsNotSameTypes(PointerEventData eventData)
    {
        if (slotType != "")
            return InventoryController.instance.inventorySlots[transform.GetSiblingIndex()].slotType !=
                InventoryController.instance.itemList[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()].itemType;
        else
            return false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item)
        {
            itemDescriptionPanel.GetComponent<ItemDescription>().item = item;
            itemDescriptionPanel.SetActive(true);
            foreach (var stat in item.StatsSwitcher("PrimaryStats"))
            {
                Debug.Log(stat.Key + "\t" + stat.Value);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item)
        {
            itemDescriptionPanel.GetComponent<ItemDescription>().item = null;
            itemDescriptionPanel.SetActive(false);
        }
    }
}

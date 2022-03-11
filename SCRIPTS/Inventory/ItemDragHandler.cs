using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    //dlaczego podwojnie widac item ale jest tylko w jednym slocie

    //dwie opcje albo tak samo, ale musi też przenosić item lub, że tylko zamienia item co powinno działać chyba xd


    //script swap images not items, need to change
    private Transform originalParent;
    private bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (InventoryController.instance.itemList[transform.parent.GetSiblingIndex()] != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                isDragging = true;
                originalParent = transform.parent;
                transform.SetParent(transform.parent.parent);
                GetComponent<CanvasGroup>().blocksRaycasts = false;
                //add canvas group to images?
            }
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                originalParent = transform.parent;
                transform.SetParent(transform.parent.parent);
                GetComponent<CanvasGroup>().blocksRaycasts = false;
                //add canvas group to images?
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (InventoryController.instance.itemList[originalParent.transform.GetSiblingIndex()] != null && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
    
    /*
    //script swap images not items, need to change
    private Transform originalParent;
    private bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ItemsHandler.instance.list[transform.parent.GetSiblingIndex()] != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                isDragging = true;
                originalParent = transform.parent;
                transform.SetParent(transform.parent.parent);
                GetComponent<CanvasGroup>().blocksRaycasts = false;
                //add canvas group to images?
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (ItemsHandler.instance.list[originalParent.transform.GetSiblingIndex()] != null && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour//, ISerializationCallbackReceiver
{
    //add eq by merging eq & inv in hierarchy, then make one itemlist and iterate through siblings
    //add slot type, basic or 1 of 8 eq slots
    public ItemDatabase database;
    public static InventoryController instance;
    public Item[] itemList = new Item[40];//+8? or eqlist
    public SlotController[] inventorySlots = new SlotController[40];
    public ShopButtonController[] shopButtons = new ShopButtonController[8];
    /*
    public Item[] equipmentList = new Item[8];
    public SlotController[] equipmentSlots = new SlotController[8];
    */


    public void /*bool*/ Add(Item item, int amount)
    {
        /*
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = item;
                UpdatePanelSlots();
                return true;
            }
        }
        return false;*/
        for (int i = 8; i < itemList.Length; i++)
        {
            if (itemList[i] == item)
            {
                //itemList[i].AddAmount(amount);
                return;
            }
            else if (itemList[i] == null)
            {
                itemList[i] = item;
                return;
            }
        }
        UpdatePanelSlots();
    }
    public void UpdateSlots()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].UpdateInfo();
        }/*
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].UpdateInfo();
        }*/
    }
    /*public void AddItem(Item item, int amount)
    {
        bool hasAdded = Add(item, amount);

        if (hasAdded)
        {
            UpdatePanelSlots();
        }
    }*/
    public void Remove(Item item)
    {
        //list.Remove(item);
        //UpdatePanelSlots();
    }
    public void UpdatePanelSlots()
    {
        int index = 0;
        foreach (var child in inventorySlots)
        {
            SlotController slot = child.GetComponent<SlotController>();
            if (index < itemList.Length)
            {
                slot.item = itemList[index];
            }
            else
            {
                slot.item = null;
            }
            slot.UpdateInfo();
            index++;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        //UpdateSlots();
    }
    // Update is called once per frame
    void Update()
    {

    }

    /*public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            itemList[i] = database.getItem[itemList[i].ID];
        }
    }*/
}

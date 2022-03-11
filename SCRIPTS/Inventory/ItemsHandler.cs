using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsHandler : MonoBehaviour
{/*
    //add the script to Items in inv in GUICanvas
    public GameObject player;
    public GameObject slots;
    //public InventoryScriptController[] slotControllers;

    public static ItemsHandler instance;
    public Item selectedItem;

    public List<Item> list = new List<Item>();



    public Item[] itemList = new Item[32];
    public List<InventoryScriptController> invSlots = new List<InventoryScriptController>();
    public InventoryScriptController[] inventorySlots = new InventoryScriptController[32];//założenie, że w isc nie ma pola item


    private bool Add(Item item)//call when picked up an item
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = item;
                //invSlots2[i].item = item;
                return true;
            }
        }
        return false;
        /*
        if (list.Count < 32)
        {
            list.Add(item);
        }
        UpdatePanelSlots();
    }
    public void UpdateSlots()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].UpdateInfo();
        }
    }
    public void AddItem(Item item)
    {
        bool hasAdded = Add(item);

        if (hasAdded)
        {
            UpdateSlots();
        }
    }
    public void Remove(Item item)
    {
        //list.Remove(item);
        //UpdatePanelSlots();
    }
    public void UpdatePanelSlots()
    {
        int index = 0;
        foreach (Transform child in slots.transform)
        {
            //Update slot[index]'s name and icon
            InventoryScriptController slot = child.GetComponent<InventoryScriptController>();

            if (index < itemList.Lengthlist.Count)
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
    void SelectItem(Item item)
    {
        selectedItem = item;
    }
    void Awake()
    {
        // niekoniecznie, bo inv ładowany przez skrypt
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
        instance = this;
        //invSlots2 = FindObjectsOfType<InventoryScriptController>();
        UpdatePanelSlots();
    }
    // Update is called once per frame
    void Update()
    {
        
    }*/
}

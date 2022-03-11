using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Items/Database")]
public class ItemDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public Item[] items; //all existing items
    public Dictionary<Item, int> getId = new Dictionary<Item, int>();
    public Dictionary<int, Item> getItem = new Dictionary<int, Item>();

    public void OnAfterDeserialize()
    {
        getId = new Dictionary<Item, int>();
        getItem = new Dictionary<int, Item>();
        for (int i = 0; i < items.Length; i++)
        {
            getId.Add(items[i], i);
            getItem.Add(i, items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}

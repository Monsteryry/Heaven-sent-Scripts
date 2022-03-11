using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickup : MonoBehaviour
{
    public DropSystem dropSystem;
    public Item item;
    void OnTriggerEnter(Collider other)
    {
        //if (other == GameObject.Find("pc"))
        //{
            Debug.Log("Picking up " + item.name);
        if (item)
        {
            InventoryController.instance.Add(item, 1);   // Add to inventory
        }
            Destroy(gameObject);
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        //item = dropSystem.LosujPrzedmiot();
        //dropSystem.DropItem(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

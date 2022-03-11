using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    public GameObject leftSlot;
    public GameObject rightSlot;
    public GameObject resultSlot;

    void CreateItem()
    {
        if (rightSlot.GetComponent<Item>().ID == leftSlot.GetComponent<Item>().ID)
        {
            //konsumuje 2 przedmioty by stworzyć jeden o wzmocniony o 20% do max 100%
            IncreaseStats(1, 5);
        }
    }

    private void IncreaseStats(int currentUpgradeLevel, int maxUpgradeLevel)
    {
        if (currentUpgradeLevel < maxUpgradeLevel)
        {
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

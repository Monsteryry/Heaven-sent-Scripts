using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarButton : MonoBehaviour
{
    public Text textField;
    public SpecialAttack specialAttack;
    public ActionBar actionBar;
    public int slotIndex;

    // Start is called before the first frame update
    void Start()
    {
        SpecialAttack[] attacks = GameObject.FindGameObjectWithTag("Player").GetComponents<SpecialAttack>();
        // specialAttack=attacks[specialAttack.clipId]
        foreach(var attack in attacks)
        {
            if (attack.clipId == slotIndex)
            {
                specialAttack = attack;
                break;
            }
        }

        textField.text =actionBar.actionButtons[specialAttack.clipId].GetComponent<ActionBarButton>().specialAttack.key.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //Debug.Log(gameObject.name);
    }
}

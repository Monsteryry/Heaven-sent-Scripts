using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonStarter : MonoBehaviour
{
    public bool isWindowOpened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (!isWindowOpened)
        {
            isWindowOpened = true;
            ShowDungeonStarterWindow();
        }
    }

    private void ShowDungeonStarterWindow()
    {
        throw new NotImplementedException();
    }
}

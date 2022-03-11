using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour
{
    public static DungeonController instance;
    public bool isDungeonPanelOpened;
    public GameObject dungeonPanel;
    // Start is called before the first frame update
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
    void Start()
    {
        CreateDungeonPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDungeonPanelOpened)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                dungeonPanel.SetActive(true);
                isDungeonPanelOpened = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                dungeonPanel.SetActive(false);
                isDungeonPanelOpened = false;
            }
        }
    }
    public void CreateDungeonPanel()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("DungeonCanvas"));
        dungeonPanel = go;
        isDungeonPanelOpened = false;
        dungeonPanel.SetActive(false);
    }
}

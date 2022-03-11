using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{/*
    [SerializeField]
    protected */
    public Toggle[] toggles = new Toggle[50];
    public Toggle selectedToggle;
    public Button startButton;
    public GameObject toggleGrouper;

    private void Awake()
    {
        FillLevelToggles();
        toggleGrouper = GameObject.Find("ToggleGrouper");
        for (int i = 0; i < toggles.Length; i++)
        {
            //toggles[i].onValueChanged.AddListener((t) => OnToggleValueChanged(toggles[i], t));
            toggles[i].group = toggleGrouper.GetComponent<ToggleGroup>();
        }
    }
    void Update()
    {
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn)
                selectedToggle = toggle;
        }
        UnlockButtonAndPlay();
    }
    public void UnlockButtonAndPlay()
    {
        if (selectedToggle != null)
        {
            startButton.interactable = true;
        }    
    }

    private void OnToggleValueChanged(Toggle toggle, bool newValue)
    {
        if (newValue)
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i] != toggle)
                    toggles[i].isOn = false;
            }
        }
    }
    public void FillLevelToggles()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject t = new GameObject();
            t = (GameObject)Instantiate(Resources.Load("LevelToggle"));
            t.name = "Level " + i;
            t.transform.SetAsLastSibling();
            RectTransform rt = t.GetComponent<RectTransform>();
            Text txt = t.GetComponentInChildren<Text>();
            t.transform.parent = gameObject.transform;
            txt.text = "Level " + (i + 1);
            rt.offsetMax = new Vector2(0, 0 - (i * 50));
            rt.offsetMin = new Vector2(0, 2450 - (i * 50));
            toggles[i] = t.GetComponent<Toggle>();
            //t.GetComponent<Toggle>().onValueChanged.AddListener(value => AccessToStart.instance.ToggleUpdater());
        }
    }
}

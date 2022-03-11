using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AccessToStart : MonoBehaviour
{
    public static AccessToStart instance;
    public Button button;
    public Toggle toggle;
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
    }

    // Update is called once per frame
    void Update()
    {
        UnlockButton();
    }
    // Update is called once per frame
    public void ToggleUpdater()
    {
        toggle = null;
        var toggleChecker = FindObjectsOfType<Toggle>();
        foreach (Toggle t in toggleChecker)
            if (t.isOn)
                toggle = t;
    }
    public void UnlockButton()
    {
        if (toggle != null)
            if (toggle.isOn == true)
                button.interactable = true;
    }
}


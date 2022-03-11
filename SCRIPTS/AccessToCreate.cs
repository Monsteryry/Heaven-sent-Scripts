using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessToCreate : MonoBehaviour
{
    public Button button;
    public InputField inputField;
    public Toggle toggle;
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
    private bool NameChecker()
    {
        //if given name is not used, has at least 3 characters
        if (inputField.text.Length >= 3)
            return true;
        else
            return false;
    }

    public void UnlockButton()
    {
        if (toggle != null)
            if (toggle.isOn == true && NameChecker())
                button.interactable = true;
    }
}

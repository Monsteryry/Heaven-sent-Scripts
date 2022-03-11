using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    public List<Toggle> togglesOn;
    public List<Toggle> togglesOff;
    public List<Toggle> toggles;
    public Text charName;
    public string[] avaibleClasses = { "Taurus", "Sagittarius", "Libra" };
    public string chosenClass;
    public string characterName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetToggle();
    }

    private void DefineClass()
    {
        foreach (Toggle t in toggles)
            if (t.isOn == true)
                chosenClass = t.name;
    }
    private void FillCharName()
    {
        characterName = charName.text;
    }
    public void SaveCharInfo()
    {
        DefineClass();
        FillCharName();
        //PlayerPrefs.SetString("CharacterName", characterName);
        //PlayerPrefs.SetString("CharacterClass", chosenClass);
        Debug.Log(characterName + " - " + chosenClass);
        SceneManager.LoadScene("Testing");
    }
    /*
    private void OneToggleChecked()
    {
        int i = 0;
        foreach (Toggle t in toggles)
        {
            if (t.isOn == true)
                i++;
            if (i > 1)
                foreach (Toggle t2 in toggles)
                    if (t2.isOn == true)
                    {
                        t2.isOn = false;
                        break;
                    }
        }
                
    }*/
    private void SetToggle()
    {
        foreach (Toggle t in togglesOff)
        {
            if (t.isOn == true && !togglesOn.Contains(t))
                togglesOn.Add(t);
            if (togglesOn.Count > 1)
            {
                togglesOn[0].isOn = false;
                togglesOn.RemoveAt(0);
            }
        }
    }
}

public enum ClassName
{
    Taurus,
    Sagittarius,
    Libra
}

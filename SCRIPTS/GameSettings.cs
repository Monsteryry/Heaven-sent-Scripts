using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public const string PLAYER_SPAWN_POINT = "PLAYER_SPAWN_POINT";
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SaveCharacterData()
    {
        GameObject pc = GameObject.Find("pc");

        PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

        //PlayerPrefs.DeleteAll();

        PlayerPrefs.SetString("Player Name", pcClass.Name);
        //Have to save level modifiers for all the stuff also
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            PlayerPrefs.SetInt(((AttributeName)i).ToString() + " - Base Value", pcClass.GetPrimaryAttribute(i).BaseValue);
            PlayerPrefs.SetInt(((AttributeName)i).ToString() + " - Exp To Level", pcClass.GetPrimaryAttribute(i).ExpToLevel);
        }
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Base Value", pcClass.GetVital(i).BaseValue);
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Exp To Level", pcClass.GetVital(i).ExpToLevel);
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Cur Value", pcClass.GetVital(i).CurValue);

            //PlayerPrefs.SetString(((VitalName)i).ToString() + " - Mods", pcClass.GetVital(i).GetModifyingAttributesString());

            //pcClass.GetVital(i).GetModifyingAttributesString();
        }
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            PlayerPrefs.SetInt(((SkillName)i).ToString() + " - Base Value", pcClass.GetSkill(i).BaseValue);
            PlayerPrefs.SetInt(((SkillName)i).ToString() + " - Exp To Level", pcClass.GetSkill(i).ExpToLevel);

            //PlayerPrefs.SetString(((SkillName)i).ToString() + " - Mods", pcClass.GetSkill(i).GetModifyingAttributesString());
            
            //pcClass.GetSkill(i).GetModifyingAttributesString();
        }
    }
    public void LoadCharacterData()
    {
        GameObject pc = GameObject.Find("pc");

        PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

        pcClass.Name = PlayerPrefs.GetString("Player Name", "Noname");

        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            pcClass.GetPrimaryAttribute(i).BaseValue = PlayerPrefs.GetInt(((AttributeName)i).ToString() + " - Base Value", 0);
            pcClass.GetPrimaryAttribute(i).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)i).ToString() + " - Exp To Level", Attribute.STARTING_EXP_COST);
        }
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            pcClass.GetVital(i).BaseValue = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Base Value", 0);
            pcClass.GetVital(i).ExpToLevel = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Exp To Level", 0);

            pcClass.GetVital(i).Update();

            pcClass.GetVital(i).CurValue = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Cur Value", 1);

            /*
            string myMods = PlayerPrefs.GetString(((VitalName)i).ToString() + " - Mods", "");

            string[] mods = myMods.Split('|');

            foreach (string s in mods)
            {
                string[] modStats = s.Split('_');

                int attributeIndex = 0;
                for (int j = 0; j < Enum.GetValues(typeof(AttributeName)).Length; j++)
                {
                    if (modStats[0] == ((AttributeName)j).ToString())
                    {
                        attributeIndex = j;
                        break;
                    }
                }
                pcClass.GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(pcClass.GetPrimaryAttribute(attributeIndex), modStats[1]));
            }
            */
            //pcClass.GetVital(i).CurValue = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Cur Value", 20);

            //PlayerPrefs.SetString(((VitalName)i).ToString() + " - Mods", pcClass.GetVital(i).GetModifyingAttributesString());

            //pcClass.GetVital(i).GetModifyingAttributesString();
        }
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            Debug.Log(((VitalName)i).ToString() + ": " + pcClass.GetVital(i).CurValue);
        }

        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            pcClass.GetSkill(i).BaseValue = PlayerPrefs.GetInt(((SkillName)i).ToString() + " - Base Value", 0);
            pcClass.GetSkill(i).ExpToLevel = PlayerPrefs.GetInt(((SkillName)i).ToString() + " - Exp To Level", 0);

        }
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            Debug.Log(((SkillName)i).ToString() + ": " + pcClass.GetSkill(i).BaseValue + " - " + pcClass.GetSkill(i).ExpToLevel);
        }
    }
}

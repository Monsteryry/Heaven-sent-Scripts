using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCharacter : MonoBehaviour
{
    private string _name;
    private int _level;
    private uint _freeExp;

    private Attribute[] _primaryAttribute;
    private Vital[] _vital;
    private Skill[] _skill;

    public void Awake()
    {
        _name = string.Empty;
        _level = 0;
        _freeExp = 0;

        _primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        _vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        _skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

        SetupPrimaryAttributes();
        SetupVitals();
        SetupSkills();
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    public uint FreeExp
    {
        get { return _freeExp; }
        set { _freeExp = value; }
    }

    public void AddExp(uint exp)
    {
        _freeExp += exp;

        CalculateLevel();
    }
    //Take avg of all player skills and assign that as the player level
    public void CalculateLevel()
    {

    }

    private void SetupPrimaryAttributes()
    {
        for (int i = 0; i < _primaryAttribute.Length; i++)
        {
            _primaryAttribute[i] = new Attribute();
            _primaryAttribute[i].Name = ((AttributeName)i).ToString();
        }
    }
    private void SetupVitals()
    {
        for (int i = 0; i < _vital.Length; i++)
        {
            _vital[i] = new Vital();
        }

        SetupVitalModifiers();
    }
    private void SetupSkills()
    {
        for (int i = 0; i < _skill.Length; i++)
        {
            _skill[i] = new Skill();
        }
        SetupSkillModifiers();
    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return _primaryAttribute[index];
    }
    public Vital GetVital(int index)
    {
        return _vital[index];
    }
    public Skill GetSkill(int index)
    {
        return _skill[index];
    }

    private void SetupVitalModifiers()
    {
        //health
        //ModifyingAttribute health = new ModifyingAttribute();
        //health.attribute = GetPrimaryAttribute((int)AttributeName.Vitality);
        //health.ratio = .5f;

        //GetVital((int)VitalName.Health).AddModifier(health);
        //or
        /*
        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute
        {
            attribute = GetPrimaryAttribute((int)AttributeName.Vitality),
            ratio = .5f
        });
        */
        //energy
        //ModifyingAttribute energy = new ModifyingAttribute();
        //energy.attribute = GetPrimaryAttribute((int)AttributeName.Energy);
        //energy.ratio = .5f;

        //GetVital((int)VitalName.Energy).AddModifier(energy);

        //Better

        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Vitality), .5f));
        GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Power), .5f));
    }
    private void SetupSkillModifiers()
    {
        /*
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Force), .1f));
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Armor), .1f));

        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Force), .1f));
        GetSkill((int)SkillName.Ranged_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Armor), .1f));

        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Force), .1f));
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Armor), .1f));
        */

    }

    public void StatUpdate()
    {
        for (int i = 0; i < _vital.Length; i++)
            _vital[i].Update();
        for (int i = 0; i < _skill.Length; i++)
            _skill[i].Update();
    }
}

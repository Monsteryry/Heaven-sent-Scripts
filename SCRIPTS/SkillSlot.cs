using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot
{
    public SpecialAttack skill;
    public Rect position;
    public KeyCode key;
    
    public void setKey(KeyCode keyCode)
    {
        if(skill != null)
        {
            skill.key = keyCode;
        }
    }
}

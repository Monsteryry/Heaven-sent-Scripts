using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : ModifiedStat
{
    private int _curValue;

    public Stat()
    {
        _curValue = 0;
        ExpToLevel = 50;
        LevelModifier = 1.1f;
    }
    public int CurValue
    {
        get
        {
            if (_curValue > AdjustedBaseValue)
                _curValue = AdjustedBaseValue;
            return _curValue;
        }
        set { _curValue = value; }
    }

}

public enum StatName
{
    //Force
    Damage, //
    //Swiftness
    AttackSpeed,
    MovementSpeed,
    CoolDownReduction,
    //Criticality
    CriticalStrikeChance,   //
    CriticalStrikeDamage,   //*10
    //defensive
    Armor,
    ElementsResistance,
    AerasResistance,
    DarcResistance,
    HydrasResistance,
    LuxResistance,
    PyrasResistance,
    TerasResistance,
    //sources
    Vitality,
    Power,
    HealthRegeneration,
    EnergyRegeneration,
    //other
}

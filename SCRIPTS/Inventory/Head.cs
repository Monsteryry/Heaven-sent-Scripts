using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Head", menuName = "Items/Head")]
public class Head : Item
{
    public float minDamage = 0;                //0-20%
    public float maxDamage = 0;                //0-20%
    public float minAttackSpeed = 0;           //0-20%
    public float maxAttackSpeed = 0;           //0-20%
    public float minMovementSpeed = 0;         //0-20%
    public float maxMovementSpeed = 0;         //0-20%
    public float minCoolDownReduction = 0;     //0-10%
    public float maxCoolDownReduction = 0;     //0-10%
    public float minCriticalStrikeChance = 0;  //0-10%
    public float maxCriticalStrikeChance = 0;  //0-10%
    public float minCriticalStrikeDamage = 0;  //0-100%
    public float maxCriticalStrikeDamage = 0;  //0-100%

    public float minElementsResistance = 0;    //0-10%
    public float maxElementsResistance = 0;    //0-10%
    public float minAerasResistance = 0;       //0-10%
    public float maxAerasResistance = 0;       //0-10%
    public float minDarcResistance = 0;        //0-10%
    public float maxDarcResistance = 0;        //0-10%
    public float minHydrasResistance = 0;      //0-10%
    public float maxHydrasResistance = 0;      //0-10%
    public float minLuxResistance = 0;         //0-10%
    public float maxLuxResistance = 0;         //0-10%
    public float minPyrasResistance = 0;       //0-10%
    public float maxPyrasResistance = 0;       //0-10%
    public float minTerasResistance = 0;       //0-10%
    public float maxTerasResistance = 0;       //0-10%

    public float minArmor = 0;                 //int
    public float maxArmor = 0;                 //int
    public float minVitality = 0;              //int
    public float maxVitality = 0;              //int
    public float minPower = 0;                 //0-20%
    public float maxPower = 0;                 //0-20%
    public float minHealthRegeneration = 0;    //base 1% per sec so max is 10%? 0-1,5% or it will multiply base
    public float maxHealthRegeneration = 0;    //base 1% per sec so max is 10%? 0-1,5% or it will multiply base
    public float minEnergyRegeneration = 0;    //base 5% per sec so max is 
    public float maxEnergyRegeneration = 0;    //base 5% per sec so max is 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

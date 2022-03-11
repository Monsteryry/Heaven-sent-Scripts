using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public Dictionary<string, float> WeaponStats = new Dictionary<string, float>()
    {
        { "MinDamage", 5 },
        { "MaxDamage", 7 },
        { "AttackSpeed", 1 }
    };
    public Dictionary<string, float> PrimaryStats = new Dictionary<string, float>()
    {
        { "Primary", 0 },
        { "Vitality", 0 },
        { "Power", 0 }
    };
    public Dictionary<string, float> DamageStats = new Dictionary<string, float>()
    {
        { "IncreasedDamage", 0 },
        { "IncreasedAttackSpeed", 0 },
        { "CoolDownReduction", 0 },
        { "CriticalStrikeChance", 0 },
        { "CriticalStrikeDamage", 0 }
    };
    public Dictionary<string, float> OtherStats = new Dictionary<string, float>()
    {
        { "HealthRegeneration", 0 },
        { "EnergyRegeneration", 0 },
        { "Lifesteal", 0 },
        { "Energysteal", 0 },
        { "MovementSpeed", 0 }
    };
    /*
    public float minDamage = 0;                //int
    public float maxDamage = 0;                //int
    public float attackSpeed = 0;              //depending on weapon
    //Primary
    public float primary = 0;                  //int
    public float vitality = 0;                 //int
    public float power = 0;                    //int
    //Damage
    public float increasedDamage = 0;           //0-100%
    public float increasedAttackSpeed = 0;      //0-25%
    public float coolDownReduction = 0;         //0-10%
    public float criticalStrikeChance = 0;      //0-10%
    public float criticalStrikeDamage = 0;      //0-100%
    //Other
    public float healthRegeneration = 0;    //base 1% per sec so max is 10%? 0-1,5% or it will multiply base
    public float energyRegeneration = 0;    //base 5% per sec so max is 
    public float lifesteal = 0;
    public float energysteal = 0;
    public float movementSpeed = 0;         //0-20%
    */
    public override void SetStats(List<Statistics.Statistic> statistics)
    {
        System.Random generator = new System.Random();
        foreach (var stat in statistics)
        {
            StatsSwitcher(nameof(statistics))[stat.statName] = generator.Next(stat.minValue, stat.maxValue);
            //Debug.Log(stat.statName + stat.minValue + stat.maxValue + generator.Next(stat.minValue, stat.maxValue) + StatsSwitcher(nameof(statistics))[stat.statName]);
        }
    }
    public override Dictionary<string, float> StatsSwitcher(string name)
    {
        switch (name)
        {
            case "WeaponStats":
                return WeaponStats;
            case "PrimaryStats":
                return PrimaryStats;
            case "DamageStats":
                return DamageStats;
            case "OtherStats":
                return OtherStats;
            default:
                return new Dictionary<string, float>();
        }
    }
    /*public void Awake()
    {
        itemType = ItemType.Weapon;
    }*/
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Armor", menuName = "Items/Armor")]
public class Armor : Item
{
    //w sumie to chyba może zostać item i armor jako klasy
    public Dictionary<string, float> ArmorStats = new Dictionary<string, float>()
    {
        { "Armor", 0 }
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
    public Dictionary<string, float> ResistanceStats = new Dictionary<string, float>()
    {
        { "ElementsResistance", 0 },
        { "AerasResistance", 0 },
        { "DarcResistance", 0 },
        { "HydrasResistance", 0 },
        { "LuxResistance", 0 },
        { "PyrasResistance", 0 },
        { "TerasResistance", 0 }
    };
    public Dictionary<string, float> OtherStats = new Dictionary<string, float>()
    {
        { "HealthRegeneration", 0 },
        { "EnergyRegeneration", 0 },
        { "Lifesteal", 0 },
        { "Energysteal", 0 },
        { "MovementSpeed", 0 }
    };
    public override void SetStats(List<Statistics.Statistic> statistics)
    {
        System.Random generator = new System.Random();
        foreach (var stat in statistics)
        {
            StatsSwitcher(nameof(statistics))[stat.statName] = generator.Next(stat.minValue, stat.maxValue);
            //Debug.Log(stat.statName + stat.minValue + stat.maxValue + generator.Next(stat.minValue, stat.maxValue) + StatsSwitcher(nameof(statistics))[stat.statName]);
        }
    }
    //statsswitcher jako viruala metoda w item, override w armor i weapon i deklaracje metod 
    public override Dictionary<string, float> StatsSwitcher(string name)
    {
        switch (name)
        {
            case "ArmorStats":
                return ArmorStats;
            case "PrimaryStats":
                return PrimaryStats;
            case "DamageStats":
                return DamageStats;
            case "ResistanceStats":
                return ResistanceStats;
            case "OtherStats":
                return OtherStats;
            default:
                return null;
        }
    }
    /*
    public Statistics.Statistic[] stats = Statistics.chestStats;
    public Tuple<float, float> dmgRatio = new Tuple<float, float>(0, 20);
    public float dmg = 0;

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
    public override void Use()
    {
        //można tu dać by na prawy przycisk dodało do eq a z tego slota remove
        //GameObject player = ItemsHandler.instance.player;
        //PlayerStatistics ps = player.GetComponent<PlayerStatistics>();
    }
    /*public void Awake()
    {
        itemType = ItemType.Armor;
    }*/
    // Start is called before the first frame update
    /*
    void Start()
    {
        dmg = UnityEngine.Random.Range(dmgRatio.Item1, dmgRatio.Item2);
        Debug.Log(dmg);
        //Damage = new Statistic("Damage", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}

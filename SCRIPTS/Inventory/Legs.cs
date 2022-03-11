using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Legs", menuName = "Items/Legs")]
public class Legs : Item
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
    /*
    public struct Damage
    {
        public float increasedDamage;       //0-20%
        public float increasedAttackSpeed;  //0-10%
        public float coolDownReduction;     //0-10%
        public float criticalStrikeChance;  //0-10%
        public float criticalStrikeDamage;  //0-100%
    }
    public struct Resistance
    {
        public float elementsResistance;    //0-10%
        public float aerasResistance;       //0-10%
        public float darcResistance;        //0-10%
        public float hydrasResistance;      //0-10%
        public float luxResistance;         //0-10%
        public float pyrasResistance;       //0-10%
        public float terasResistance;       //0-10%
    }
    public struct Other
    {
        public float healthRegeneration; //base 1% per sec so max is 10%? 0-1,5% or it will multiply base
        public float energyRegeneration; //base 5% per sec so max is 
        public float lifesteal;
        public float energysteal;
        public float movementSpeed;         //0-20%
    }
            //int
    //Primary
    //Damage
    //Resistance
    //Other*/
    public override void SetStats(List<Statistics.Statistic> statistics)
    {
        System.Random generator = new System.Random();
        foreach (var stat in statistics)
        {
            //zależnie od stats losujemy wartość z widełek i przypisujemy odpowiedniej statystyce
            //Primary[stat.statName] = generator.Next(stat.minValue, stat.maxValue);
            StatsSwitcher(stat.ToString())[stat.statName] = generator.Next(stat.minValue, stat.maxValue);
        }
    }
    //statsswitcher jako viruala metoda w item, override w armor i weapon i deklaracje metod 
    public Dictionary<string, float> StatsSwitcher(string name)
    {
        switch(name)
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
                return new Dictionary<string, float>();
        }
    }
}

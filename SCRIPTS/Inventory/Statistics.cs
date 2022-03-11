using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Statistics
{
    public class Statistic
    {
        public string statName;
        public int minValue;
        public int maxValue;
        public int curValue;

        public Statistic(string n, int min, int max)
        {
            statName = n;
            minValue = min;
            maxValue = max;
        }
    }
    public static List<Statistic> WeaponStats = new List<Statistic>(){
        new Statistic("MinDamage", 0, 10),
        new Statistic("MaxDamage", 0, 10),
        new Statistic("AttackSpeed", 0, 10)
    };
    public static List<Statistic> ArmorStats = new List<Statistic>(){
        new Statistic("Armor", 0, 10)
    };
    public static List<Statistic> PrimaryStats = new List<Statistic>(){
        new Statistic("Primary", 0, 10),
        new Statistic("Vitality", 0, 10),
        new Statistic("Power", 0, 10)
    };
    public static List<Statistic> DamageStats = new List<Statistic>(){
        new Statistic("IncreasedDamage", 0, 10),
        new Statistic("IncreasedAttackSpeed", 0, 10),
        new Statistic("CoolDownReduction", 0, 10),
        new Statistic("CriticalStrikeChance", 0, 10),
        new Statistic("CriticalStrikeDamage", 0, 10)
    };
    public static List<Statistic> ResistanceStats = new List<Statistic>(){
        new Statistic("ElementsResistance", 0, 10),
        new Statistic("AerasResistance", 0, 10),
        new Statistic("DarcResistance", 0, 10),
        new Statistic("HydrasResistance", 0, 10),
        new Statistic("LuxResistance", 0, 10),
        new Statistic("PyrasResistance", 0, 10),
        new Statistic("TerasResistance", 0, 10)
    };
    public static List<Statistic> OtherStats = new List<Statistic>(){
        new Statistic("HealthRegeneration", 0, 10),
        new Statistic("EnergyRegeneration", 0, 10),
        new Statistic("Lifesteal", 0, 10),
        new Statistic("Energysteal", 0, 10),
        new Statistic("MovementSpeed", 0, 10)
    };
    /*
    public static Statistic[] WeaponStats = {
        new Statistic("MinDamage", 0, 10),
        new Statistic("MaxDamage", 0, 10),
        new Statistic("AttackSpeed", 0, 10),
    };
    public static Statistic[] ArmorStats = {
        new Statistic("Armor", 0, 10)
    };
    public static Statistic[] PrimaryStats = {
        new Statistic("Primary", 0, 10),
        new Statistic("Vitality", 0, 10),
        new Statistic("Power", 0, 10)
    };
    public static Statistic[] DamageStats = {
        new Statistic("IncreasedDamage", 0, 10),
        new Statistic("IncreasedAttackSpeed", 0, 10),
        new Statistic("CoolDownReduction", 0, 10),
        new Statistic("CriticalStrikeChance", 0, 10),
        new Statistic("CriticalStrikeDamage", 0, 10)
    };
    public static Statistic[] ResistanceStats = {
        new Statistic("ElementsResistance", 0, 10),
        new Statistic("AerasResistance", 0, 10),
        new Statistic("DarcResistance", 0, 10),
        new Statistic("HydrasResistance", 0, 10),
        new Statistic("LuxResistance", 0, 10),
        new Statistic("PyrasResistance", 0, 10),
        new Statistic("TerasResistance", 0, 10)
    };
    public static Statistic[] OtherStats = {
        new Statistic("HealthRegeneration", 0, 10),
        new Statistic("EnergyRegeneration", 0, 10),
        new Statistic("Lifesteal", 0, 10),
        new Statistic("Energysteal", 0, 10),
        new Statistic("MovementSpeed", 0, 10)
    };*/


    /*
    #region Weapon
    public static Statistic[] weaponStats = { 
        new Statistic("MinDamage", 0, 10),
        new Statistic("MaxDamage", 0, 10),
        new Statistic("AttackSpeed", 0, 10),
    };
    public static Statistic[] weaponPrimaryStats = {
        new Statistic("Primary", 0, 10),
        new Statistic("Vitality", 0, 10),
        new Statistic("Power", 0, 10)
    };
    public static Statistic[] weaponDamageStats = {
        new Statistic("IncreasedDamage", 0, 10),
        new Statistic("IncreasedAttackSpeed", 0, 10),
        new Statistic("CoolDownReduction", 0, 10),
        new Statistic("CriticalStrikeChance", 0, 10),
        new Statistic("CriticalStrikeDamage", 0, 10)
    };
    public static Statistic[] weaponOtherStats = {
        new Statistic("HealthRegeneration", 0, 10),
        new Statistic("EnergyRegeneration", 0, 10),
        new Statistic("Lifesteal", 0, 10),
        new Statistic("Energysteal", 0, 10),
        new Statistic("MovementSpeed", 0, 10)
    };
    #endregion
    #region Head
    #endregion

    #region Chest
    #endregion

    #region Legs
    #endregion

    #region Hands
    #endregion

    #region Boots
    #endregion

    #region Rune
    #endregion
    public static Statistic[] headStats = {
        new Statistic("Armor", 0, 10)
    };
    public static Statistic[] headPrimaryStats = {
        new Statistic("Primary", 0, 10),
        new Statistic("Vitality", 0, 10),
        new Statistic("Power", 0, 10)
    };
    public static Statistic[] headDamageStats = {
        new Statistic("IncreasedDamage", 0, 10),
        new Statistic("IncreasedAttackSpeed", 0, 10),
        new Statistic("CoolDownReduction", 0, 10),
        new Statistic("CriticalStrikeChance", 0, 10),
        new Statistic("CriticalStrikeDamage", 0, 10)
    };
    public static Statistic[] headResistanceStats = {
        new Statistic("ElementsResistance", 0, 10),
        new Statistic("AerasResistance", 0, 10),
        new Statistic("DarcResistance", 0, 10),
        new Statistic("HydrasResistance", 0, 10),
        new Statistic("LuxResistance", 0, 10),
        new Statistic("PyrasResistance", 0, 10),
        new Statistic("TerasResistance", 0, 10)
    };
    public static Statistic[] headOtherStats = {
        new Statistic("HealthRegeneration", 0, 10),
        new Statistic("EnergyRegeneration", 0, 10),
        new Statistic("Lifesteal", 0, 10),
        new Statistic("Energysteal", 0, 10),
        new Statistic("MovementSpeed", 0, 10)
    };

    public static Statistic[] chestStats = { new Statistic("Damage", 0, 10) };
    public static Statistic[] legsStats;
    public static Statistic[] handsStats;
    public static Statistic[] bootsStats;
    public static Statistic[] runeStats;
    */
    //konieczna metoda robiąca update wartości min i max rosnących proporcjonalnie z lvl
}

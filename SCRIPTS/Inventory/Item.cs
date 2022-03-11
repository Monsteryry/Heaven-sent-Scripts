using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Head,
    Chest,
    Legs,
    Hands,
    Boots,
    Rune
}
public enum RarityType
{
    Common,
    Enhanced,
    Rare,
    Mythic,
    Unique
}
public abstract class Item : ScriptableObject
{
    /*
    public struct Statistic
    {
        public string statName;
        public int minValue;
        public int maxValue;

        public Statistic(string n, int min, int max)
        {
            statName = n;
            minValue = min;
            maxValue = max;
        }
    }*/
    /*
             // get all the meshes in my_fbx.fbx
        Mesh[] meshes = Resources.LoadAll<Mesh>("my_fbx");
        // get all the anim clips
        AnimationClip[] anims = Resources.LoadAll<AnimationClip>("my_fbx");
     */
    public GameObject prefab;
    public int ID;
    public string itemName = "New Item";
    public string/*ItemType*/ itemType;
    [TextArea(15,10)]
    public string itemDescription = "New Description";
    public string rarity = "New Rarity";
    public int minPrice = 0;
    public int maxPrice = 0;
    public int requiredLevel = 0;
    public int curUpgradeLevel = 0;
    public int maxUpgradeLevel = 0;
    public Sprite icon;
    //public enum Type { Default, Weapon, Armor, Rune }
    //public Type type = Type.Default;
    public virtual void SetStats(List<Statistics.Statistic> statistics)
    {

    }
    public virtual Dictionary<string, float> StatsSwitcher(string name)
    {
        return new Dictionary<string, float>();
    }
    public virtual void Use()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

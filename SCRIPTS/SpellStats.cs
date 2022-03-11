using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStats : MonoBehaviour
{
    //I
    public KeyCode key;
    public string spellName;
    public int ID;
    public Texture2D icon;
    public float range;
    public float cooldown;
    public float currentTimer;
    //II
    public bool enemyBased;
    public int projectile;
    public float degrees;
    //III
    //if in action use, set cooldown and is ready if cooldown reset
    public bool isReady;
    public bool inAction;
    public GameObject particleEffect;
    //Buffs
    public Dictionary<string, Dictionary<float, float>> Buffs; //name-value-time
    //Effects
    public Dictionary<string, Dictionary<float, float>> Effects; //name-value-time

    public void FillDictionaries()
    {
        //Buffs["scaleDamage"] = new Dictionary<float, float> = 
        //Buffs = new Dictionary<string, float>();
        //Buffs["PRI"] = 0f;
    }




    //public SpecialAttack specialAttack;
    //public BattleController battleController;

    //public bool isAttack;
    //public bool isBuff;
    //public bool isMobility;
    //public string abilityType;
    //public float tmpCooldown;
    //Buffs
    //W ten sposób? jup
    /*
    public float[] buffTab = new float[11];
    public float primUp;
    public float armorUp;
    public float vitUp;
    public float mgUp;
    public float hprUp;
    public float mprUp;
    public float asUp;
    public float msUp;
    public float cdrUp;
    public float cscUp;
    public float csdUp;
    */
    //Attacks
    public float[] attackTab = new float[8];
    public float scaleDmg;
    public float stunTime;
    public float slowDebuff;
    public float slowTime;
    public float exhaustDebuff;
    public float exhaustTime;
    public float weakenDebuff;
    public float weakenTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

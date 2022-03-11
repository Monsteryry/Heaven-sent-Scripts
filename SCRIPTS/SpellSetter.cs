using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSetter : MonoBehaviour
{
    uint pcLevel;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private uint Level()
    {
        if (pcLevel <= 15)
            return pcLevel / 3;
        else
            return 5;
    }
    
    private void NumberOfSpells()
    {
        for (int i = 0; i <= Level(); i++)
        {
            AddSpell(i);
        }

    }
    private void AddSpell(int i)
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        //I
        ss.key = KeyCode.Mouse0;
        ss.spellName = "BasicAttack";
        ss.range = 2f;
        ss.cooldown = 1;
        //II
        ss.enemyBased = true;
        ss.projectile = 0;
        ss.degrees = 0;
        //III
        ss.inAction = false;
        ss.ID = 0;
        ss.particleEffect = null;
        //Buffs
        //ss.Buffs;
        //Effects
        //ss.Effects;
    }

    private void SpellCaser(int i, SpecialAttack sa)
    {
        switch (i)
        {
            case 0:
                //gameObject.spells[0] = sa;
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }
    }
    public void x()
    {
        SpecialAttack specialAttack0 = gameObject.AddComponent<SpecialAttack>();
        //specialAttack0.specialAttack = specialAttack0;
        specialAttack0.battleController = GetComponent<BattleController>();
        specialAttack0.key = KeyCode.Mouse0;
        specialAttack0.isAttack = true;
        specialAttack0.isBuff = false;
        specialAttack0.isMobility = false;
        //specialAttack0.isAbilityReady = true;
        specialAttack0.abilityName = "Basic Attack";
        specialAttack0.range = PlayerPrefs.GetFloat("AttackRange", 3f);
        specialAttack0.cooldown = PlayerPrefs.GetFloat("AttackDelay", 1f);
        specialAttack0.enemyBased = true;
        specialAttack0.isAbility = false;
        specialAttack0.scaleDmg = PlayerPrefs.GetFloat("DMG", 10f);
        specialAttack0.clipId = 0;
        specialAttack0.degrees = 60f;
        SpecialAttack.isAbilityReady[0] = true;
        //specialAttacks[0] = specialAttack0;
        specialAttack0.icon = Resources.Load<Texture2D>("Ritter/A_R_3");
    }
    /*
     
    public KeyCode key;
    public string spellName;
    public int ID;
    public Texture2D icon;
    public float range;
    public float cooldown;
    //II
    public bool enemyBased;
    public int projectile;
    public float degrees;
    //III
    //if in action use, set cooldown and is ready if cooldown reset
    public bool inReady;
    public bool inAction;
    public GameObject particleEffect;
     */
    public void SpellCreator(KeyCode k, string sn, int i, Texture2D ic, float ran, float cool, float curTim, bool eb, int pro, float deg, GameObject part)
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        //I
        ss.key = k;
        ss.spellName = sn;
        ss.ID = i;
        ss.icon = ic;
        ss.range = ran;
        ss.cooldown = cool;
        ss.currentTimer = curTim;
        //II
        ss.enemyBased = eb;
        ss.projectile = pro;
        ss.degrees = deg;
        //III
        ss.isReady = true;  // always true during creation
        ss.inAction = false;// always false during creation
        ss.particleEffect = part;
    }
    public void BasicAttack()
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        //I
        ss.key = KeyCode.Mouse0;
        ss.spellName = "BasicAttack";
        ss.range = 2f;
        ss.cooldown = 1f;
        //II
        ss.enemyBased = true;
        ss.projectile = 0;
        ss.degrees = 0;
        //III
        ss.inAction = false;
        ss.ID = 0;
        ss.particleEffect = null;
        //ss.icon = Resources.Load<Texture2D>("Ritter/A_R_3");
        //Buffs
        //ss.Buffs;
        //Effects
        //ss.Effects;
    }
    public void EnhancedAttack()
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        //I
        ss.key = KeyCode.Mouse1;
        ss.spellName = "EnhancedAttack";
        ss.range = 2f;
        ss.cooldown = 3f;
        //II
        ss.enemyBased = false;
        ss.projectile = 0;
        ss.degrees = 120;
        //III
        ss.inAction = false;
        ss.ID = 1;
        ss.particleEffect = null;
        //Buffs
        //ss.Buffs;
        //Effects
        //ss.Effects;
    }
    public void Buff()
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        ss.key = KeyCode.Q;
        ss.spellName = "Buff";
        ss.cooldown = 15f;
        ss.inAction = false;
        ss.ID = 3;
        ss.particleEffect = null;
        //Buffs
        //ss.Buffs;
        //Effects
        //ss.Effects;
    }
    public void GreaterAttack()
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        //I
        ss.key = KeyCode.W;
        ss.spellName = "GreaterAttack";
        ss.range = 5f;
        ss.cooldown = 8f;
        //II
        ss.enemyBased = false;
        ss.projectile = 1;
        ss.degrees = 270;
        //III
        ss.inAction = false;
        ss.ID = 3;
        ss.particleEffect = null;
        //Buffs
        //ss.Buffs;
        //Effects
        //ss.Effects;
    }
    public void Mobility()
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        ss.key = KeyCode.E;
        ss.spellName = "Mobility";
        ss.range = 5f;
        ss.cooldown = 5f;
        ss.inAction = false;
        ss.ID = 3;
        ss.particleEffect = null;
        //Buffs
        //ss.Buffs;
        //Effects
        //ss.Effects;
    }
    public void Aura()
    {
        SpellStats ss = gameObject.AddComponent<SpellStats>();
        ss.key = KeyCode.R;
        ss.spellName = "Aura";
        ss.inAction = false;
        ss.ID = 3;
        ss.particleEffect = null;
        //Buffs
        //ss.Buffs;
        //Effects
        //ss.Effects;
    }
    //Spells
    // 6 elements * 6 spells * 3 classes = 108
    #region RMC
    //Ritter
    public void AerasRitter()
    {
        SpellCreator(KeyCode.Mouse0, "1", 0, Resources.Load<Texture2D>("Ritter/A_R_1"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Mouse1, "2", 1, Resources.Load<Texture2D>("Ritter/A_R_2"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Q, "3", 2, Resources.Load<Texture2D>("Ritter/A_R_3"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.W, "4", 3, Resources.Load<Texture2D>("Ritter/A_R_4"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.E, "5", 4, Resources.Load<Texture2D>("Ritter/A_R_5"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.R, "6", 5, Resources.Load<Texture2D>("Ritter/A_R_6"), 5, 1, 1, false, 0, 90, null);
        /*BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();*/
    }
    public void DarcRitter()
    {
        SpellCreator(KeyCode.Mouse0, "1", 0, Resources.Load<Texture2D>("Ritter/D_R_1"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Mouse1, "2", 1, Resources.Load<Texture2D>("Ritter/D_R_2"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Q, "3", 2, Resources.Load<Texture2D>("Ritter/D_R_3"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.W, "4", 3, Resources.Load<Texture2D>("Ritter/D_R_4"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.E, "5", 4, Resources.Load<Texture2D>("Ritter/D_R_5"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.R, "6", 5, Resources.Load<Texture2D>("Ritter/D_R_6"), 5, 1, 1, false, 0, 90, null);
    }
    public void HydrasRitter()
    {
        SpellCreator(KeyCode.Mouse0, "1", 0, Resources.Load<Texture2D>("Ritter/H_R_1"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Mouse1, "2", 1, Resources.Load<Texture2D>("Ritter/H_R_2"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Q, "3", 2, Resources.Load<Texture2D>("Ritter/H_R_3"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.W, "4", 3, Resources.Load<Texture2D>("Ritter/H_R_4"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.E, "5", 4, Resources.Load<Texture2D>("Ritter/H_R_5"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.R, "6", 5, Resources.Load<Texture2D>("Ritter/H_R_6"), 5, 1, 1, false, 0, 90, null);
    }
    public void LuxRitter()
    {
        SpellCreator(KeyCode.Mouse0, "1", 0, Resources.Load<Texture2D>("Ritter/L_R_1"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Mouse1, "2", 1, Resources.Load<Texture2D>("Ritter/L_R_2"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Q, "3", 2, Resources.Load<Texture2D>("Ritter/L_R_3"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.W, "4", 3, Resources.Load<Texture2D>("Ritter/L_R_4"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.E, "5", 4, Resources.Load<Texture2D>("Ritter/L_R_5"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.R, "6", 5, Resources.Load<Texture2D>("Ritter/L_R_6"), 5, 1, 1, false, 0, 90, null);
    }
    public void PyrasRitter()
    {
        SpellCreator(KeyCode.Mouse0, "1", 0, Resources.Load<Texture2D>("Ritter/P_R_1"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Mouse1, "2", 1, Resources.Load<Texture2D>("Ritter/P_R_2"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Q, "3", 2, Resources.Load<Texture2D>("Ritter/P_R_3"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.W, "4", 3, Resources.Load<Texture2D>("Ritter/P_R_4"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.E, "5", 4, Resources.Load<Texture2D>("Ritter/P_R_5"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.R, "6", 5, Resources.Load<Texture2D>("Ritter/P_R_6"), 5, 1, 1, false, 0, 90, null);
    }
    public void TerasRitter()
    {
        SpellCreator(KeyCode.Mouse0, "1", 0, Resources.Load<Texture2D>("Ritter/T_R_1"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Mouse1, "2", 1, Resources.Load<Texture2D>("Ritter/T_R_2"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.Q, "3", 2, Resources.Load<Texture2D>("Ritter/T_R_3"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.W, "4", 3, Resources.Load<Texture2D>("Ritter/T_R_4"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.E, "5", 4, Resources.Load<Texture2D>("Ritter/T_R_5"), 5, 1, 1, false, 0, 90, null);
        SpellCreator(KeyCode.R, "6", 5, Resources.Load<Texture2D>("Ritter/T_R_6"), 5, 1, 1, false, 0, 90, null);
    }
    //Marksman
    public void AerasMarksman()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void DarcMarksman()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void HydrasMarksman()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void LuxMarksman()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void PyrasMarksman()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void TerasMarksman()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    //Conjurer
    public void AerasConjurer()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void DarcConjurer()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void HydrasConjurer()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void LuxConjurer()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void PyrasConjurer()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    public void TerasConjurer()
    {
        BasicAttack();
        EnhancedAttack();
        Buff();
        GreaterAttack();
        Mobility();
        Aura();
    }
    #endregion
}

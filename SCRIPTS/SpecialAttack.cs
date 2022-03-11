using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//add choice of throwing more than 1 projectile
//add range of attack
//add shape of attack
public class SpecialAttack : MonoBehaviour
{
    public SpecialAttack specialAttack;
    public BattleController battleController;
    public KeyCode key;
    public Texture2D icon;

    public bool isAttack;
    public bool isBuff;
    public bool isMobility;
    public string abilityType;

    public string abilityName;
    public float range;
    public float cooldown;
    public float tmpCooldown;
    //Buffs
    //W ten sposób? jup
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

    public GameObject particleEffect;
    public int projectile;

    public bool inAction;
    public bool enemyBased;
    public bool isAbility;
    public float degrees;
    //public bool shape;
    public static bool[] isAbilityReady = new bool[6];
    public int clipId;
    public bool isReady;

    // Start is called before the first frame update
    void Start()
    {
    }
    /*
    void FillAttackParameters()
    {
        specialAttack.key = key;
        specialAttack.isAttack = isAttack;
        specialAttack.isBuff = isBuff;
        specialAttack.isMobility = isMobility;
        specialAttack.abilityName = abilityName;
        specialAttack.range = range;
        specialAttack.cooldown = cooldown;
        specialAttack.tmpCooldown = tmpCooldown;
        specialAttack.buffTab = buffTab;
        specialAttack.attackTab = attackTab;
        specialAttack.particleEffect = particleEffect;
        specialAttack.projectile = projectile;
        specialAttack.inAction = inAction;
        specialAttack.enemyBased = enemyBased;
        specialAttack.aoe = aoe;
        specialAttack.isAbilityReady = isAbilityReady;
        specialAttack.clipId = clipId;
    }
    */
    void FillTabs()
    {
        //
        attackTab[0] = scaleDmg;
        attackTab[1] = stunTime;
        attackTab[2] = slowDebuff;
        attackTab[3] = slowTime;
        attackTab[4] = exhaustDebuff;
        attackTab[5] = exhaustTime;
        attackTab[6] = weakenDebuff;
        attackTab[7] = weakenTime;
        //
        buffTab[0] = primUp;
        buffTab[1] = armorUp;
        buffTab[2] = vitUp;
        buffTab[3] = mgUp;
        buffTab[4] = hprUp;
        buffTab[5] = mprUp;
        buffTab[6] = asUp;
        buffTab[7] = msUp;
        buffTab[8] = cdrUp;
        buffTab[9] = cscUp;
        buffTab[10] = csdUp;
    }
    // Update is called once per frame
    void Update()
    {
        FillTabs(); 
        //FillAttackParameters();
        if (isAbilityReady[clipId])
        {
            if (Input.GetKeyDown(key) && !battleController.isSpecialAttack)
            {
                Debug.Log("Po wciśnięciu");
                //playerInCombat.ResetAttack();
                battleController.isSpecialAttack = true;
                inAction = true;
                //Invoke/Coroutine
                //StartCoroutine(CountDown(cooldown));
                //GetCooldown(cooldown);
            }
        }
        if (!isAbilityReady[clipId])
        {
            StartCoroutine(CountDown(cooldown));
        }
        /*
        if (inAction)
        {
            Debug.Log("inAction " + inAction);
            if (battleController.Attack(specialAttack))
            {

            }
            else
            {
                inAction = false;
            }
        }*/
    }
    IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        isAbilityReady[clipId] = true;
    }/*
    public void GetCooldown(float time)
    {
        if (time > 0)
        {
            isAbilityReady = false;
            tmpCooldown = cooldown;
            InvokeRepeating("CooldownCountDown", 0f, 1f);
        }
    }
    public void CooldownCountDown()
    {
        tmpCooldown -= 1;
        if (tmpCooldown == 0)
        {
            isAbilityReady = true;
            CancelInvoke("CooldownCountDown");
        }
    }*/
}

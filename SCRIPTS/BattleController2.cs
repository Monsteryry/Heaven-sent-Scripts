using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//skrypt odpowiedzialny za realizacje ataku i określanie przeciwników w zasięgu

[System.Serializable]
public class Enemies
{
    public List<GameObject> list;
    public Enemies()
    {
        list = new List<GameObject>();
    }
}

[System.Serializable]
public class EnemyList
{
    public List<Enemies> list;
    public EnemyList()
    {
        list = new List<Enemies>();
    }
}
public class BattleController2 : MonoBehaviour
{
    public PlayerController player;
    public SpecialAttack[] specialAttacks = new SpecialAttack[5];
    public SpellStats[] spells = new SpellStats[6];
    public bool[] isAbilitiesReady = new bool[6];
    public float[] attackTimers = new float[6];
    //Enemies
    //public List<GameObject> enemiesInRange;
    //public List<GameObject> enemiesInAttackRange;
    //public List<GameObject>[] enemiesInSpecialAttackRanges;
    /*
    public List<GameObject> enemiesInRange0;
    public List<GameObject> enemiesInRange1;
    public List<GameObject> enemiesInRange2;
    public List<GameObject> enemiesInRange3;
    public List<GameObject> enemiesInRange4;
    public List<GameObject> enemiesInRange5;
    public List<GameObject> enemiesInAttackRange0;
    public List<GameObject> enemiesInAttackRange1;
    public List<GameObject> enemiesInAttackRange2;
    public List<GameObject> enemiesInAttackRange3;
    public List<GameObject> enemiesInAttackRange4;
    public List<GameObject> enemiesInAttackRange5;
    public List<List<GameObject>> enemiesInRanges;
    public List<List<GameObject>> enemiesInAttackRanges;
    */

    public Enemies enemiesInRange0;
    public Enemies enemiesInRange1;
    public Enemies enemiesInRange2;
    public Enemies enemiesInRange3;
    public Enemies enemiesInRange4;
    public Enemies enemiesInRange5;
    public Enemies enemiesInAttackRange0;
    public Enemies enemiesInAttackRange1;
    public Enemies enemiesInAttackRange2;
    public Enemies enemiesInAttackRange3;
    public Enemies enemiesInAttackRange4;
    public Enemies enemiesInAttackRange5;
    public EnemyList enemiesInRanges;
    public EnemyList enemiesInAttackRanges;
    public GameObject selectedEnemy;
    public float chaseRange;
    public float attackRange;
    public float[] attackRanges;
    //Combat
    public bool isReady;
    public bool inAction;
    public bool isImpacted;
    public bool isSpecialAttack;
    public float combatEscapeTime;
    public float countDown;
    public GameObject test;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<PlayerController>();
        DefineListsOfRanges();
        /*BasicAttack();
        EnhancedAttack();
        Aura();
        Mobility();
        GreaterAttack();
        Buff();*/
        specialAttacks = GetComponents<SpecialAttack>();

        /*
        SetAbilitiesReady();
        isReady = true;
        */
    }

    // Update is called once per frame
    void Update()
    {
        spells = GetComponents<SpellStats>();
        //Debug.Log("specialAttacks[2].isAbilityReady " + specialAttacks[2].isAbilityReady);
        //Debug.Log("SpecialAttack.isAbilityReady[2]" + SpecialAttack.isAbilityReady[2]);
        //test2();
        //Debug.Log(frontAttack(test.transform));
        //frontAttack(test.transform);
        //Debug.Log(Vector3.Angle(transform.forward, test.transform.position));
        // Debug.Log(transform.forward.x + " " + transform.forward.y + " " + transform.forward.z);
        //Debug.Log("isReady " + isReady);
        //Debug.Log("inAction " + inAction);
        //Debug.Log("isImpacted " + isImpacted);
        //Debug.Log("isSpecialAttack " + isSpecialAttack);
        EnemiesListNormalizer2();
        //if (selectedEnemy == null)
        //    PlayerController.isEnemyClicked = false;
        AttackAction();

    }
    public void SetAbilitiesReady()
    {
        for (int i = 0; i <= 4; i++)
            isAbilitiesReady[i] = true;
    }
    /* comm
    //return true if enemy is in front of player, a half of circle
    public bool IsEnemyInFrontOfPlayer(Transform target)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toTarget = target.position - transform.position;
        float angle = Vector3.Dot(forward, toTarget);
        if (angle > 0f)
        {
            return true;
        }

        return false;
    }
    public void test2()
    {
        //float angle = Mathf.Atan(Mathf.Abs(transform.forward.z - test.transform.position.z) / Mathf.Abs(transform.forward.x - test.transform.position.x));
        //float t = Mathf.Tan(angle);
        //Debug.Log(t);
        Vector3 targetDir = test.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        //Debug.Log(angle);
    }
    */
    //Best angle definer
    public bool IsEnemyInRangeOfShapeOfAttack(float deg, GameObject enemy)
    {
        Vector3 targetDir = enemy.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        //Debug.Log(angle + " " + deg);
        if (angle <= deg)
            return true;
        return false;
    }

    #region Comments
    /*
    public void FillAbilities()
    {
        for (int i = 1; i <= 4; i++)
        {
            SpecialAttack specialAttack = gameObject.AddComponent<SpecialAttack>();
            specialAttack{ i}.key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Key1", "Q"));
            specialAttack1.abilityName = PlayerPrefs.GetString($"Name{i}", "Q");
            specialAttack1.abilityType = PlayerPrefs.GetString("Type1", "Q");
            specialAttack1.range = PlayerPrefs.GetFloat("Range1", 5f);
            specialAttack1.cooldown = PlayerPrefs.GetFloat("Cooldown1", 5f);
            //specialAttack1.buffTab = buffTab;
            //specialAttack1.attackTab = attackTab;
            specialAttack1.primUp = PlayerPrefs.GetFloat("PrimUp1", 5f);
            specialAttack1.armorUp = PlayerPrefs.GetFloat("ArmorUp1", 5f);
            specialAttack1.vitUp = PlayerPrefs.GetFloat("VitUp1", 5f);
            specialAttack1.mgUp = PlayerPrefs.GetFloat("MgUp1", 5f);
            specialAttack1.hprUp = PlayerPrefs.GetFloat("HprUp1", 5f);
            specialAttack1.mprUp = PlayerPrefs.GetFloat("MprUp1", 5f);
            specialAttack1.asUp = PlayerPrefs.GetFloat("AsUp1", 5f);
            specialAttack1.msUp = PlayerPrefs.GetFloat("MsUp1", 5f);
            specialAttack1.cdrUp = PlayerPrefs.GetFloat("CdrUp1", 5f);
            specialAttack1.cscUp = PlayerPrefs.GetFloat("CscUp1", 5f);
            specialAttack1.csdUp = PlayerPrefs.GetFloat("CsdUp1", 5f);
            specialAttack1.scaleDmg = PlayerPrefs.GetFloat("ScaleDmg1", 5f);
            specialAttack1.stunTime = PlayerPrefs.GetFloat("StunTime1", 5f);
            specialAttack1.slowDebuff = PlayerPrefs.GetFloat("SlowDebuff1", 5f);
            specialAttack1.slowTime = PlayerPrefs.GetFloat("SlowTime1", 5f);
            specialAttack1.exhaustDebuff = PlayerPrefs.GetFloat("ExhaustDebuff1", 5f);
            specialAttack1.exhaustTime = PlayerPrefs.GetFloat("ExhaustTime1", 5f);
            specialAttack1.weakenDebuff = PlayerPrefs.GetFloat("WeakenDebuff1", 5f);
            specialAttack1.weakenTime = PlayerPrefs.GetFloat("WeakenTime1", 5f);
            //specialAttack1.particleEffect = particleEffect; Jak?
            specialAttack1.projectile = PlayerPrefs.GetInt("Projectile1");
            specialAttack1.enemyBased = (bool)System.Enum.Parse(typeof(bool), PlayerPrefs.GetString("EnemyBased1"));
            specialAttack1.isAbility = (bool)System.Enum.Parse(typeof(bool), PlayerPrefs.GetString("isAbility1"));
            specialAttack1.clipId = PlayerPrefs.GetInt("ClipId1");
        }
        #region spec
        /*
        SpecialAttack specialAttack1 = gameObject.AddComponent<SpecialAttack>();
        specialAttack1.key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Key1", "Q"));
        specialAttack1.abilityName = PlayerPrefs.GetString("Name1", "Q");
        specialAttack1.abilityType = PlayerPrefs.GetString("Type1", "Q");
        specialAttack1.range = PlayerPrefs.GetFloat("Range1", 5f);
        specialAttack1.cooldown = PlayerPrefs.GetFloat("Cooldown1", 5f);
        //specialAttack1.buffTab = buffTab;
        //specialAttack1.attackTab = attackTab;
        specialAttack1.primUp = PlayerPrefs.GetFloat("PrimUp1", 5f);
        specialAttack1.armorUp = PlayerPrefs.GetFloat("ArmorUp1", 5f);
        specialAttack1.vitUp = PlayerPrefs.GetFloat("VitUp1", 5f);
        specialAttack1.mgUp = PlayerPrefs.GetFloat("MgUp1", 5f);
        specialAttack1.hprUp = PlayerPrefs.GetFloat("HprUp1", 5f);
        specialAttack1.mprUp = PlayerPrefs.GetFloat("MprUp1", 5f);
        specialAttack1.asUp = PlayerPrefs.GetFloat("AsUp1", 5f);
        specialAttack1.msUp = PlayerPrefs.GetFloat("MsUp1", 5f);
        specialAttack1.cdrUp = PlayerPrefs.GetFloat("CdrUp1", 5f);
        specialAttack1.cscUp = PlayerPrefs.GetFloat("CscUp1", 5f);
        specialAttack1.csdUp = PlayerPrefs.GetFloat("CsdUp1", 5f);
        specialAttack1.scaleDmg = PlayerPrefs.GetFloat("ScaleDmg1", 5f);
        specialAttack1.stunTime = PlayerPrefs.GetFloat("StunTime1", 5f);
        specialAttack1.slowDebuff = PlayerPrefs.GetFloat("SlowDebuff1", 5f);
        specialAttack1.slowTime = PlayerPrefs.GetFloat("SlowTime1", 5f);
        specialAttack1.exhaustDebuff = PlayerPrefs.GetFloat("ExhaustDebuff1", 5f);
        specialAttack1.exhaustTime = PlayerPrefs.GetFloat("ExhaustTime1", 5f);
        specialAttack1.weakenDebuff = PlayerPrefs.GetFloat("WeakenDebuff1", 5f);
        specialAttack1.weakenTime = PlayerPrefs.GetFloat("WeakenTime1", 5f);
        specialAttack1.particleEffect = particleEffect;
        specialAttack1.projectile = PlayerPrefs.GetInt("Projectile1");
        specialAttack1.enemyBased = (bool)System.Enum.Parse(typeof(bool), PlayerPrefs.GetString("EnemyBased"));
        specialAttack1.isAbility = (bool)System.Enum.Parse(typeof(bool), PlayerPrefs.GetString("isAbility"));
        specialAttack1.clipId = PlayerPrefs.GetInt("ClipId1");

        SpecialAttack specialAttack1 = gameObject.AddComponent<SpecialAttack>();
        specialAttack1.key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill1","Q"));
        specialAttack1.isAttack = isAttack;
        specialAttack1.isBuff = isBuff;
        specialAttack1.isMobility = isMobility;
        specialAttack1.abilityName = abilityName;
        specialAttack1.range = range;
        specialAttack1.cooldown = cooldown;
        specialAttack1.tmpCooldown = tmpCooldown;
        specialAttack1.buffTab = buffTab;
        specialAttack1.attackTab = attackTab;
        specialAttack1.particleEffect = particleEffect;
        specialAttack1.projectile = projectile;
        specialAttack1.inAction = inAction;
        specialAttack1.enemyBased = enemyBased;
        specialAttack1.isAbility = isAbility;
        specialAttack1.isAbilityReady = isAbilityReady;
        specialAttack1.clipId = clipId;

        SpecialAttack specialAttack2 = gameObject.AddComponent<SpecialAttack>();
        specialAttack2.key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill2", "W"));
        specialAttack2.isAttack = isAttack;
        specialAttack2.isBuff = isBuff;
        specialAttack2.isMobility = isMobility;
        specialAttack2.abilityName = abilityName;
        specialAttack2.range = range;
        specialAttack2.cooldown = cooldown;
        specialAttack2.tmpCooldown = tmpCooldown;
        specialAttack2.buffTab = buffTab;
        specialAttack2.attackTab = attackTab;
        specialAttack2.particleEffect = particleEffect;
        specialAttack2.projectile = projectile;
        specialAttack2.inAction = inAction;
        specialAttack2.enemyBased = enemyBased;
        specialAttack2.isAbility = isAbility;
        specialAttack2.isAbilityReady = isAbilityReady;
        specialAttack2.clipId = clipId;

        SpecialAttack specialAttack3 = gameObject.AddComponent<SpecialAttack>();
        specialAttack3.key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill3", "E"));
        specialAttack3.isAttack = isAttack;
        specialAttack3.isBuff = isBuff;
        specialAttack3.isMobility = isMobility;
        specialAttack3.abilityName = abilityName;
        specialAttack3.range = range;
        specialAttack3.cooldown = cooldown;
        specialAttack3.tmpCooldown = tmpCooldown;
        specialAttack3.buffTab = buffTab;
        specialAttack3.attackTab = attackTab;
        specialAttack3.particleEffect = particleEffect;
        specialAttack3.projectile = projectile;
        specialAttack3.inAction = inAction;
        specialAttack3.enemyBased = enemyBased;
        specialAttack3.isAbility = isAbility;
        specialAttack3.isAbilityReady = isAbilityReady;
        specialAttack3.clipId = clipId;

        SpecialAttack specialAttack4 = gameObject.AddComponent<SpecialAttack>();
        specialAttack4.key = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill4", "R"));
        specialAttack4.isAttack = isAttack;
        specialAttack4.isBuff = isBuff;
        specialAttack4.isMobility = isMobility;
        specialAttack4.abilityName = abilityName;
        specialAttack4.range = range;
        specialAttack4.cooldown = cooldown;
        specialAttack4.tmpCooldown = tmpCooldown;
        specialAttack4.buffTab = buffTab;
        specialAttack4.attackTab = attackTab;
        specialAttack4.particleEffect = particleEffect;
        specialAttack4.projectile = projectile;
        specialAttack4.inAction = inAction;
        specialAttack4.enemyBased = enemyBased;
        specialAttack4.isAbility = isAbility;
        specialAttack4.isAbilityReady = isAbilityReady;
        specialAttack4.clipId = clipId;
        
        #endregion
    }*/
    #endregion

    #region Enemies List

    //new stuff
    public void DefineListsOfRanges()
    {
        for (int i = 0; i <= 5; i++)
            enemiesInRanges.list.Add(new Enemies());
        for (int i = 0; i <= 5; i++)
            enemiesInAttackRanges.list.Add(new Enemies());
    }

    public void EnemiesListNormalizer2()
    {
        //inc
        /*if (enemiesInRanges.list != null || enemiesInAttackRanges != null)
        {
            foreach (Enemies lgo in enemiesInRanges.list)
                SpecifiedListOfEnemiesInSpecifiedRange(lgo, chaseRange, 0f);
            for (int i = 0; i < enemiesInAttackRanges.list.Count; i++)
                SpecifiedListOfEnemiesInSpecifiedRange(enemiesInAttackRanges.list[i], specialAttacks[i].range, specialAttacks[i].degrees);
            //dec
            foreach (Enemies lgo in enemiesInRanges.list)
                RemoveEnemiesOutOfRangeOrDead(lgo, chaseRange, 0f);
            for (int i = 0; i < enemiesInAttackRanges.list.Count; i++)
                RemoveEnemiesOutOfRangeOrDead(enemiesInAttackRanges.list[i], specialAttacks[i].range, specialAttacks[i].degrees);
        }*/
    }
    public void SpecifiedListOfEnemiesInSpecifiedRange(Enemies lgo, float range, float degrees)
    {
        // IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemy)
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in allEnemies)
        {
            if (degrees != 0)
            {
                if (enemy != null && !lgo.list.Contains(enemy) &&
                    Vector3.Distance(enemy.transform.position, transform.position) <= range
                    && IsEnemyInRangeOfShapeOfAttack(degrees, enemy) && enemy.GetComponent<EnemyController>().currentHealth > 0)
                {
                    lgo.list.Add(enemy);
                }
            }
            else
            {
                if (enemy != null && !lgo.list.Contains(enemy) &&
                    Vector3.Distance(enemy.transform.position, transform.position) <= range
                    && enemy.GetComponent<EnemyController>().currentHealth > 0)
                {
                    lgo.list.Add(enemy);
                }
            }

        }
    }
    public void RemoveEnemiesOutOfRangeOrDead(Enemies lgo, float range, float degrees)
    {
        foreach (GameObject enemy in lgo.list)
        {
            if (degrees != 0)
            {
                if (((enemy != null && lgo.list.Contains(enemy)) &&
                (Vector3.Distance(enemy.transform.position, transform.position) > range
                || !IsEnemyInRangeOfShapeOfAttack(degrees, enemy)))
                || IsEnemyDead(enemy))
                {
                    lgo.list.Remove(enemy);
                }
            }
            else
            {
                if (((enemy != null && lgo.list.Contains(enemy)) &&
                (Vector3.Distance(enemy.transform.position, transform.position) > range))
                || IsEnemyDead(enemy))
                {
                    lgo.list.Remove(enemy);
                }
            }
        }
    }
    public void RemoveDeadEnemy(GameObject enemy)
    {
        if (IsEnemyDead(enemy))
        {
            foreach (Enemies lgo in enemiesInRanges.list)
                if (lgo.list.Contains(enemy))
                    lgo.list.Remove(enemy);
            foreach (Enemies lgo in enemiesInAttackRanges.list)
                if (lgo.list.Contains(enemy))
                    lgo.list.Remove(enemy);
        }
    }
    public void DeselectEnemy()
    {
        if (selectedEnemy != null)
        {
            inAction = false;
            isImpacted = false;
            selectedEnemy = null;
            PlayerController.isAttack = false;
            PlayerController.isEnemyClicked = false;
        }
    }
    public bool IsEnemyDead(GameObject enemy)
    {
        if (enemy.GetComponent<EnemyController>().currentHealth <= 0 || enemy == null)
        {
            //enemy = null;
            return true;
        }
        return false;
    }
    /*
    public void FillListsOfEnemiesInRange()
    {
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInRange0, chaseRange);//LMB
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInRange1, chaseRange);//RMB
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInRange2, chaseRange);//Q
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInRange3, chaseRange);//W
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInRange4, chaseRange);//E
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInRange5, chaseRange);//R

        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInAttackRange0, attackRanges[0]);//LMB
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInAttackRange1, attackRanges[1]);//RMB
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInAttackRange2, attackRanges[2]);//Q
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInAttackRange3, attackRanges[3]);//W
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInAttackRange4, attackRanges[4]);//E
        SpecifiedListOfEnemiesInSpecifiedRange(enemiesInAttackRange5, attackRanges[5]);//R
    }
    */
    /*
    public void EnemiesListNormalizer()
    {
        DefineEnemiesInRange();
        RemoveEnemiesOutOfRangeFromList();
        for (int i = 0; i <= 4; i++)
        {
            DefineEnemiesInSpecialAttackRange(i);
        }
        for (int i = 0; i <= 4; i++)
        {
            RemoveEnemiesOutOfSpecialAttackRangeFromList(i);
        }
        //DefineEnemiesInAttackRange();
        //RemoveEnemiesOutOfAttackRangeFromList();
    }
    public void DefineEnemiesInRange()
    {
        GameObject[] tmpEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in tmpEnemies)
        {
            if (enemy != null && Vector3.Distance(enemy.transform.position, transform.position) <= chaseRange &&
                !enemiesInRange.Contains(enemy)
                )
            {
                enemiesInRange.Add(enemy);
                //Debug.Log(enemy.name);
            }
        }
    }
    public void RemoveEnemiesOutOfRangeFromList()
    {
        foreach (GameObject enemyInRange in enemiesInRange)
        {
            if (enemyInRange != null && enemiesInRange.Contains(enemyInRange) && Vector3.Distance(enemyInRange.transform.position, transform.position) > chaseRange)
            {
                enemiesInRange.Remove(enemyInRange);
            }
        }
    }
    public void RemoveEnemyFromLists(GameObject enemy)
    {
        if (IsEnemyDead(enemy) && enemiesInRange.Contains(enemy))
            enemiesInRange.Remove(enemy);
        if (IsEnemyDead(enemy) && enemiesInAttackRange0.Contains(enemy))
            enemiesInAttackRange0.Remove(enemy);
        if (IsEnemyDead(enemy) && enemiesInAttackRange1.Contains(enemy))
            enemiesInAttackRange1.Remove(enemy);
        if (IsEnemyDead(enemy) && enemiesInAttackRange2.Contains(enemy))
            enemiesInAttackRange2.Remove(enemy);
        if (IsEnemyDead(enemy) && enemiesInAttackRange3.Contains(enemy))
            enemiesInAttackRange3.Remove(enemy);
        if (IsEnemyDead(enemy) && enemiesInAttackRange4.Contains(enemy))
            enemiesInAttackRange4.Remove(enemy);
    }

    public void DefineEnemiesInSpecialAttackRange(int i)
    {
        List<GameObject> tmpEnemies = enemiesInRange;
        foreach (GameObject enemy in tmpEnemies)
        {
            switch (i)
            {
                case 0:
                    if (enemy != null
                        && Vector3.Distance(enemy.transform.position, transform.position) <= specialAttacks[i].range
                        && !enemiesInAttackRange0.Contains(enemy)
                        && IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemy)
                        )
                    {
                        enemiesInAttackRange0.Add(enemy);
                    }
                    break;
                case 1:
                    if (enemy != null
                        && Vector3.Distance(enemy.transform.position, transform.position) <= specialAttacks[i].range
                        && !enemiesInAttackRange1.Contains(enemy)
                        && IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemy)
                        )
                    {
                        enemiesInAttackRange1.Add(enemy);
                    }
                    break;
                case 2:
                    if (enemy != null
                        && Vector3.Distance(enemy.transform.position, transform.position) <= specialAttacks[i].range
                        && !enemiesInAttackRange2.Contains(enemy)
                        && IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemy)
                        )
                    {
                        enemiesInAttackRange2.Add(enemy);
                    }
                    break;
                case 3:
                    if (enemy != null
                        && Vector3.Distance(enemy.transform.position, transform.position) <= specialAttacks[i].range
                        && !enemiesInAttackRange3.Contains(enemy)
                        && IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemy)
                        )
                    {
                        enemiesInAttackRange3.Add(enemy);
                    }
                    break;
                case 4:
                    if (enemy != null
                        && Vector3.Distance(enemy.transform.position, transform.position) <= specialAttacks[i].range
                        && !enemiesInAttackRange4.Contains(enemy)
                        && IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemy)
                        )
                    {
                        enemiesInAttackRange4.Add(enemy);
                    }
                    break;
                default:
                    Debug.Log("Wrong ability id: " + specialAttacks[i].clipId);
                    break;
            }
        }
    }
    public void RemoveEnemiesOutOfSpecialAttackRangeFromList(int i)
    {
        switch (i)
        {
            case 0:
                foreach (GameObject enemyInRange in enemiesInAttackRange0)
                {
                    if ((enemyInRange != null
                        && enemiesInAttackRange0.Contains(enemyInRange))
                        && (Vector3.Distance(enemyInRange.transform.position, transform.position) > specialAttacks[i].range
                        || !IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemyInRange)))
                    {
                        enemiesInAttackRange0.Remove(enemyInRange);
                    }
                }
                break;
            case 1:
                foreach (GameObject enemyInRange in enemiesInAttackRange1)
                {
                    if ((enemyInRange != null
                        && enemiesInAttackRange1.Contains(enemyInRange))
                        && (Vector3.Distance(enemyInRange.transform.position, transform.position) > specialAttacks[i].range
                        || !IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemyInRange)))
                    {
                        enemiesInAttackRange1.Remove(enemyInRange);
                    }
                }
                break;
            case 2:
                foreach (GameObject enemyInRange in enemiesInAttackRange2)
                {
                    if ((enemyInRange != null
                        && enemiesInAttackRange2.Contains(enemyInRange))
                        && (Vector3.Distance(enemyInRange.transform.position, transform.position) > specialAttacks[i].range
                        || !IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemyInRange)))
                    {
                        enemiesInAttackRange2.Remove(enemyInRange);
                    }
                }
                break;
            case 3:
                foreach (GameObject enemyInRange in enemiesInAttackRange3)
                {
                    if ((enemyInRange != null
                        && enemiesInAttackRange3.Contains(enemyInRange))
                        && (Vector3.Distance(enemyInRange.transform.position, transform.position) > specialAttacks[i].range
                        || !IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemyInRange)))
                    {
                        enemiesInAttackRange3.Remove(enemyInRange);
                    }
                }
                break;
            case 4:
                foreach (GameObject enemyInRange in enemiesInAttackRange4)
                {
                    if ((enemyInRange != null
                        && enemiesInAttackRange4.Contains(enemyInRange))
                        && (Vector3.Distance(enemyInRange.transform.position, transform.position) > specialAttacks[i].range
                        || !IsEnemyInRangeOfShapeOfAttack(specialAttacks[i].degrees, enemyInRange)))
                    {
                        enemiesInAttackRange4.Remove(enemyInRange);
                    }
                }
                break;
            default:
                Debug.Log("Wrong ability id: " + specialAttacks[i].clipId);
                break;
        }
    }*/
    /*
    //this code is included in DefineEnemiesInSpecialAttackRange(int i)
    //where attackRange == specialAttacks[0].range
    public void DefineEnemiesInAttackRange()
    {
        List<GameObject> tmpEnemies = enemiesInRange;
        foreach (GameObject enemy in tmpEnemies)
        {
            if (enemy != null
                && Vector3.Distance(enemy.transform.position, transform.position) <= attackRange
                && !enemiesInAttackRange.Contains(enemy)
                )
            {
                enemiesInAttackRange.Add(enemy);
                //Debug.Log(enemy.name);
            }
        }
    }
    public void RemoveEnemiesOutOfAttackRangeFromList()
    {
        foreach (GameObject enemyInRange in enemiesInAttackRange)
        {
            if (enemyInRange != null
                && enemiesInAttackRange.Contains(enemyInRange)
                && Vector3.Distance(enemyInRange.transform.position, transform.position) > attackRange)
            {
                enemiesInAttackRange.Remove(enemyInRange);
            }
        }
    }
    */
    #endregion

    #region Abilities

    public void BasicAttack()
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
        specialAttack0.icon = Resources.Load<Texture2D>("Ritter/A_R_1");
    }
    public void EnhancedAttack()
    {
        SpecialAttack specialAttack0 = gameObject.AddComponent<SpecialAttack>();
        //specialAttack0.specialAttack = specialAttack0;
        specialAttack0.battleController = GetComponent<BattleController>();
        specialAttack0.key = KeyCode.Mouse1;
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
        specialAttack0.clipId = 1;
        specialAttack0.degrees = 60f;
        SpecialAttack.isAbilityReady[0] = true;
        //specialAttacks[0] = specialAttack0;
        specialAttack0.icon = Resources.Load<Texture2D>("Ritter/A_R_2");
    }
    public void GreaterAttack()
    {
        SpecialAttack specialAttack1 = gameObject.AddComponent<SpecialAttack>();
        //specialAttack0.specialAttack = specialAttack0;
        specialAttack1.battleController = GetComponent<BattleController>();
        specialAttack1.key = KeyCode.Q;
        specialAttack1.isAttack = true;
        specialAttack1.isBuff = false;
        specialAttack1.isMobility = false;
        //specialAttack1.isAbilityReady = true;
        specialAttack1.abilityName = "Q";
        specialAttack1.range = PlayerPrefs.GetFloat("AttackRange", 5f);
        specialAttack1.cooldown = PlayerPrefs.GetFloat("AttackDelay", 1f);
        specialAttack1.enemyBased = false;
        specialAttack1.isAbility = true;
        specialAttack1.scaleDmg = PlayerPrefs.GetFloat("DMG", 1.2f);
        specialAttack1.clipId = 2;
        specialAttack1.degrees = 90f;
        //isAbilitiesReady[1] = specialAttack1.isAbilityReady;
        SpecialAttack.isAbilityReady[1] = true;
        //specialAttacks[1] = specialAttack1;
        specialAttack1.icon = Resources.Load<Texture2D>("Ritter/A_R_5");
    }
    public void Buff()
    {
        SpecialAttack specialAttack2 = gameObject.AddComponent<SpecialAttack>();
        //specialAttack0.specialAttack = specialAttack0;
        specialAttack2.battleController = GetComponent<BattleController>();
        specialAttack2.key = KeyCode.W;
        specialAttack2.isAttack = true;
        specialAttack2.isBuff = false;
        specialAttack2.isMobility = false;
        //specialAttack2.isAbilityReady = true;
        specialAttack2.abilityName = "W";
        specialAttack2.range = PlayerPrefs.GetFloat("AttackRange", 7f);
        specialAttack2.cooldown = PlayerPrefs.GetFloat("AttackDelay", 7f);
        specialAttack2.enemyBased = false;
        specialAttack2.isAbility = true;
        specialAttack2.scaleDmg = PlayerPrefs.GetFloat("DMG", 1.5f);
        specialAttack2.clipId = 3;
        specialAttack2.degrees = 120f;
        //isAbilitiesReady[2] = specialAttack2.isAbilityReady;
        SpecialAttack.isAbilityReady[2] = true;
        //specialAttacks[2] = specialAttack2;
        specialAttack2.icon = Resources.Load<Texture2D>("Ritter/A_R_6");
    }
    public void Mobility()
    {
        SpecialAttack specialAttack3 = gameObject.AddComponent<SpecialAttack>();
        //specialAttack0.specialAttack = specialAttack0;
        specialAttack3.battleController = GetComponent<BattleController>();
        specialAttack3.key = KeyCode.E;
        specialAttack3.isAttack = true;
        specialAttack3.isBuff = false;
        specialAttack3.isMobility = false;
        //specialAttack3.isAbilityReady = true;
        specialAttack3.abilityName = "E";
        specialAttack3.range = PlayerPrefs.GetFloat("AttackRange", 9f);
        specialAttack3.cooldown = PlayerPrefs.GetFloat("AttackDelay", 3f);
        specialAttack3.enemyBased = false;
        specialAttack3.isAbility = true;
        specialAttack3.scaleDmg = PlayerPrefs.GetFloat("DMG", 1.8f);
        specialAttack3.clipId = 4;
        specialAttack3.degrees = 160f;
        //isAbilitiesReady[3] = specialAttack3.isAbilityReady;
        SpecialAttack.isAbilityReady[3] = true;
        //specialAttacks[3] = specialAttack3;
        specialAttack3.icon = Resources.Load<Texture2D>("Ritter/A_R_4");
    }
    public void Aura()
    {
        SpecialAttack specialAttack4 = gameObject.AddComponent<SpecialAttack>();
        //specialAttack0.specialAttack = specialAttack0;
        specialAttack4.battleController = GetComponent<BattleController>();
        specialAttack4.key = KeyCode.R;
        specialAttack4.isAttack = true;
        specialAttack4.isBuff = false;
        specialAttack4.isMobility = false;
        //specialAttack4.isAbilityReady = true;
        specialAttack4.abilityName = "R";
        specialAttack4.range = PlayerPrefs.GetFloat("AttackRange", 11);
        specialAttack4.cooldown = PlayerPrefs.GetFloat("AttackDelay", 4f);
        specialAttack4.enemyBased = false;
        specialAttack4.isAbility = true;
        specialAttack4.scaleDmg = PlayerPrefs.GetFloat("DMG", 2f);
        specialAttack4.clipId = 5;
        specialAttack4.degrees = 180f;
        //isAbilitiesReady[4] = specialAttack4.isAbilityReady;
        SpecialAttack.isAbilityReady[4] = true;
        //specialAttacks[4] = specialAttack4;
        specialAttack4.icon = Resources.Load<Texture2D>("Ritter/A_R_3");
    }

    #endregion

    #region Combat

    public void AttackTarget(SpellStats specialAttack, float attackTimer)
    {
        /*attackTimer = 0;
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
            attackTimer = 0;
        if (attackTimer == 0)
        {*/
        Attack2(specialAttack);
        //attackTimer = specialAttack.cooldown;
        //}
    }

    public void AttackAction()
    {
        //if (inAction)
        //{
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        /*
            if (Attack(specialAttacks[0]))
            {
            }
            else
            {
                inAction = false;
            }
        */
        //}
        if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerController.isEnemyClicked)
        {
            AttackTarget(spells[0], 0/*, attackTimers[0]*/);//error
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && spells[1].isReady)
        {
            if (Attack(spells[1]))
            {
                spells[1].isReady = false;
                //specialAttacks[1].isAbilityReady = false;
                //StartCoroutine(WaitToResetCooldownOfAbility(specialAttacks[1]));
            }
            else
            {
                inAction = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && spells[2].isReady)
        {
            if (Attack(spells[2]))
            {
                spells[2].isReady = false;
                //specialAttacks[1].isAbilityReady = false;
                //StartCoroutine(WaitToResetCooldownOfAbility(specialAttacks[1]));
            }
            else
            {
                inAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && spells[3].isReady)
        {
            if (Attack(spells[3]))
            {
                spells[3].isReady = false;
                //specialAttacks[2].isAbilityReady = false;
                //StartCoroutine(WaitToResetCooldownOfAbility(specialAttacks[2]));
            }
            else
            {
                inAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && spells[4].isReady)
        {
            if (Attack(spells[4]))
            {
                spells[4].isReady = false;
                //specialAttacks[3].isAbilityReady = false;
                //StartCoroutine(WaitToResetCooldownOfAbility(specialAttacks[3]));
            }
            else
            {
                inAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) && spells[5].isReady)
        {
            if (Attack(spells[5]))
            {
                spells[5].isReady = false;
                //specialAttacks[4].isAbilityReady = false;
                //StartCoroutine(WaitToResetCooldownOfAbility(specialAttacks[4]));
            }
            else
            {
                inAction = false;
            }
        }


        /*
        for (int i = 0; i <= 4; i++)
        {
            if (Attack(specialAttacks[i]))
            {
            }
            else
            {
                inAction = false;
            }
        }
        */
        //}
    }
    public void CooldownScript()
    {
    }
    IEnumerator WaitToResetCooldownOfAbility(SpellStats specialAttack)
    {
        yield return new WaitForSeconds(specialAttack.cooldown);
        isAbilitiesReady[specialAttack.ID] = true;
    }
    public void Attack2(SpellStats specialAttack)
    {/*
        //Player is impacted if is stunned etc.
        if (isImpacted)
        {
            PlayerController.isAttack = false;
            isImpacted = false;
            if (isSpellStats)
                isSpellStats = false;
            return;
        }*/
        //Player is able to attack
        if (Input.GetKeyDown(specialAttack.key) && IsInRangeToBeAbleToAttack(specialAttack.ID))
        {
            Vector3 tmp = PlayerController.cursorPosition;
            if (specialAttack.enemyBased)
                if (selectedEnemy != null)
                    tmp = selectedEnemy.transform.position;
            tmp.y = transform.position.y;
            transform.LookAt(tmp);
            PlayerController.isAttack = true;
        }
        Impact(specialAttack);
    }
    public bool Attack(SpellStats specialAttack)
    {
        //Player is impacted if is stunned etc.
        if (isImpacted)
        {
            PlayerController.isAttack = false;
            isImpacted = false;
            if (isSpecialAttack)
                isSpecialAttack = false;
            return false;
        }
        //Player is able to attack
        if (Input.GetKeyDown(specialAttack.key) && IsInRangeToBeAbleToAttack(specialAttack.ID))
        {
            Vector3 tmp = PlayerController.cursorPosition;
            if (specialAttack.enemyBased)
                if (selectedEnemy != null)
                    tmp = selectedEnemy.transform.position;
            tmp.y = transform.position.y;
            transform.LookAt(tmp);
            PlayerController.isAttack = true;
        }
        Impact(specialAttack);
        return true;
    }
    /*
    public void BuffPlayer(SpellStats specialAttack)
    {
        PlayerPrefs.SetFloat("PRI", PlayerPrefs.GetFloat("PRI") * specialAttack.primUp);
        PlayerPrefs.SetFloat("ARM", PlayerPrefs.GetFloat("ARM") * specialAttack.armorUp);
        PlayerPrefs.SetFloat("VIT", PlayerPrefs.GetFloat("VIT") * specialAttack.vitUp);
        PlayerPrefs.SetFloat("MG", PlayerPrefs.GetFloat("MG") * specialAttack.mgUp);
        PlayerPrefs.SetFloat("HPR", PlayerPrefs.GetFloat("HPR") * specialAttack.hprUp);
        PlayerPrefs.SetFloat("MPR", PlayerPrefs.GetFloat("MPR") * specialAttack.mprUp);
        PlayerPrefs.SetFloat("AS", PlayerPrefs.GetFloat("AS") * specialAttack.asUp);
        PlayerPrefs.SetFloat("MS", PlayerPrefs.GetFloat("MS") * specialAttack.msUp);
        PlayerPrefs.SetFloat("CDR", PlayerPrefs.GetFloat("CDR") * specialAttack.cdrUp);
        PlayerPrefs.SetFloat("CSC", PlayerPrefs.GetFloat("CSC") * specialAttack.cscUp);
        PlayerPrefs.SetFloat("CSD", PlayerPrefs.GetFloat("CSD") * specialAttack.csdUp);

    }
    IEnumerator WaitToResetBuff(SpellStats specialAttack)
    {
        yield return new WaitForSeconds(specialAttack.cooldown);
        PlayerPrefs.SetFloat("PRI", PlayerPrefs.GetFloat("PRI") * (1f / specialAttack.primUp));
        PlayerPrefs.SetFloat("ARM", PlayerPrefs.GetFloat("ARM") * (1f / specialAttack.armorUp));
        PlayerPrefs.SetFloat("VIT", PlayerPrefs.GetFloat("VIT") * (1f / specialAttack.vitUp));
        PlayerPrefs.SetFloat("MG", PlayerPrefs.GetFloat("MG") * (1f / specialAttack.mgUp));
        PlayerPrefs.SetFloat("HPR", PlayerPrefs.GetFloat("HPR") * (1f / specialAttack.hprUp));
        PlayerPrefs.SetFloat("MPR", PlayerPrefs.GetFloat("MPR") * (1f / specialAttack.mprUp));
        PlayerPrefs.SetFloat("AS", PlayerPrefs.GetFloat("AS") * (1f / specialAttack.asUp));
        PlayerPrefs.SetFloat("MS", PlayerPrefs.GetFloat("MS") * (1f / specialAttack.msUp));
        PlayerPrefs.SetFloat("CDR", PlayerPrefs.GetFloat("CDR") * (1f / specialAttack.cdrUp));
        PlayerPrefs.SetFloat("CSC", PlayerPrefs.GetFloat("CSC") * (1f / specialAttack.cscUp));
        PlayerPrefs.SetFloat("CSD", PlayerPrefs.GetFloat("CSD") * (1f / specialAttack.csdUp));

    }*/
    public void Impact(SpellStats specialAttack)
    {
        //Debug.Log("Ability used");
        //if ((!specialAttack.enemyBased || selectedEnemy != null)/* && !isImpacted*/)
        //{
        //if (isReady)
        //{
        //Debug.Log("xd");
        //if (/*IsImpacted() && IsNotReadyToRun()*/isImpacted)
        //{
        //countDown = combatEscapeTime;
        //CancelInvoke("combatEscapeCountDown");
        //InvokeRepeating("combatEscapeCountDown", 0, 1);
        if (specialAttack.enemyBased && specialAttack.degrees == 0/* && !specialAttack.isAbility*/)
        {
            selectedEnemy.GetComponent<EnemyController>().GetHit((int)specialAttack.attackTab[0]);
            selectedEnemy.GetComponent<EnemyController>().GetStunned(specialAttack.attackTab[1]);
            selectedEnemy.GetComponent<EnemyController>().GetSlowed(specialAttack.attackTab[2], specialAttack.attackTab[3]);
            selectedEnemy.GetComponent<EnemyController>().GetExhausted(specialAttack.attackTab[4], specialAttack.attackTab[5]);
            selectedEnemy.GetComponent<EnemyController>().GetWeakend(specialAttack.attackTab[6], specialAttack.attackTab[7]);
        }
        else
        {
            AttackEnemiesInRange2(specialAttack, specialAttack.attackTab);
        }
        /*
        if (specialAttack.isAbility)
        {
            //Debug.Log("xdd");
            AttackEnemiesInRange(specialAttack.clipId,specialAttack.attackTab);
        }
        else if (specialAttack.isBuff)
        {

        }
        else if (specialAttack.isMobility)
        {

        }*/

        /*FilterEnemiesInShapeOfAttack(*/
        //enemiesInSpecialAttackRanges[specialAttack.clipId],
        /*specialAttack.rightAngle,
        specialAttack.leftAngle
        ), */


        /*
        Quaternion rot = transform.rotation;
        rot.x = 0f;
        rot.z = 0f;

        if (specialAttack.projectile == 1)
        {
            Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), rot);//transform.position
        }

        ShowParticles(specialAttack.particleEffect, specialAttack.isAbility);
        */
        /*
        isImpacted = false;
        specialAttack.inAction = false;
        isReady = false;
        inAction = false;*/
        //StartCoroutine(GettingReadyToAttack(specialAttack.clipId));
        //}
        //}
    }
    IEnumerator GettingReadyToAttack(int i)
    {
        yield return new WaitForSeconds(1f/*specialAttacks[i].cooldown*/);
        isReady = true;
        /*if (PlayerController.isAbilityUsed)
            PlayerController.isAbilityUsed = false;
        if (PlayerController.isAbilityEnded)
            PlayerController.isAbilityEnded = false;*/
    }
    /*
    public void ShowParticles(GameObject particleEffect, bool isAbility)
    {
        if (particleEffect != null)
        {
            if (!isAbility)
            {
                Instantiate(particleEffect/*Resources.Load("")*//*,
                    new Vector3(
                        selectedEnemy.transform.position.x,
                        selectedEnemy.transform.position.y + 1.5f,
                        selectedEnemy.transform.position.z),
                    Quaternion.identity);

            }
            else
            {
                foreach (GameObject enemy in enemiesInRange)
                {
                    Instantiate(particleEffect/*Resources.Load("")*//*,
                        new Vector3(
                            enemy.transform.position.x,
                            enemy.transform.position.y + 1.5f,
                            enemy.transform.position.z),
                        Quaternion.identity);
                }
            }
        }
    }
    */
    public void AttackEnemiesInRange2(SpellStats sa, float[] attackTab)
    {
        switch (sa.key)
        {
            case KeyCode.Mouse0:
                foreach (GameObject enemy in enemiesInAttackRanges.list.ElementAt(0).list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 10) * attackTab[0]));
                    enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case KeyCode.Mouse1:
                foreach (GameObject enemy in enemiesInAttackRanges.list.ElementAt(1).list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 10) * attackTab[0]));
                    enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case KeyCode.Q:
                foreach (GameObject enemy in enemiesInAttackRanges.list.ElementAt(2).list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 10) * attackTab[0]));
                    enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case KeyCode.W:
                foreach (GameObject enemy in enemiesInAttackRanges.list.ElementAt(3).list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 10) * attackTab[0]));
                    enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case KeyCode.E:
                foreach (GameObject enemy in enemiesInAttackRanges.list.ElementAt(4).list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 10) * attackTab[0]));
                    enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case KeyCode.R:
                foreach (GameObject enemy in enemiesInAttackRanges.list.ElementAt(5).list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 20) * attackTab[0]));
                    enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            default:
                Debug.Log("Wrong ability key: " + sa.key);
                break;
        }
    }
    public void MoveCharacter()
    {/*
        float t = 0f;
        Vector3 v = gameObject.transform.position;
        float z = gameObject.transform.position.z;
        t += Time.deltaTime;
        if (t > 1)
        {
            v.z += t;
            if (v.z - z > 5)
                t = 0;
        }
        //
        Vector3 value = new Vector3(0, 0, 0.1f);
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position += value * Time.deltaTime;
        }*/
    }

    public void AttackEnemiesInRange(int i, float[] attackTab)
    {
        switch (i)
        {
            case 0:
                foreach (GameObject enemy in enemiesInAttackRange0.list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 20) * attackTab[0]));
                    //enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    //enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    //enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    //enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case 1:
                foreach (GameObject enemy in enemiesInAttackRange1.list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 20) * attackTab[0]));
                    //enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    //enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    //enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    //enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case 2:
                foreach (GameObject enemy in enemiesInAttackRange2.list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 20) * attackTab[0]));
                    //enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    //enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    //enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    //enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case 3:
                foreach (GameObject enemy in enemiesInAttackRange3.list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 20) * attackTab[0]));
                    //enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    //enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    //enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    //enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            case 4:
                foreach (GameObject enemy in enemiesInAttackRange4.list)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(PlayerPrefs.GetFloat("DMG", 20) * attackTab[0]));
                    //enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    //enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    //enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    //enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                break;
            default:
                Debug.Log("Wrong ability id: " + i);
                break;
        }
    }
    /*
    public List<GameObject> FilterEnemiesInShapeOfAttack(List<GameObject> enemies, float r, float l)
    {
        List<GameObject> tmpEnemies = enemies;
        foreach (GameObject enemy in tmpEnemies)
        {
            if (enemy != null
                && !(Vector3.Angle(transform.forward, enemy.transform.position) < r)
                && !(Vector3.Angle(enemy.transform.position, transform.forward) > l)
                )
            {
                tmpEnemies.Remove(enemy);
            }
        }
        foreach (GameObject enemy in tmpEnemies)
        {
            Debug.Log(enemy.name);
        }
        return tmpEnemies;
        /*
        if (enemy != null
                && !(Vector3.Angle(enemy.transform.position, transform.forward) < r)
                && !(Vector3.Angle(enemy.transform.position, transform.forward) > l)
                ) 
        */
    //}*/
    public bool IsInRangeToBeAbleToAttack(int i)
    {
        if (selectedEnemy != null)
            return (Vector3.Distance(selectedEnemy.transform.position, transform.position) <= specialAttacks[i].range);
        else
            return false;
    }
    /*
    public bool DefineShapeOfAttack(float r, float l)
    {
        if (Vector3.Angle(selectedEnemy.transform.position, transform.forward) < r
            && Vector3.Angle(selectedEnemy.transform.position, transform.forward) > l)
            return true;
        return false;
    }
    */
    public void InstantiateProjectiles(int amount, Quaternion rot)
    {
        switch (amount)
        {
            case 1:
                break;
            case 2:
                Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z)/*transform.position*/, rot);
                Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z)/*transform.position*/, rot);
                break;
            case 3:
                break;
            case 4:
                break;




        }
    }

    #endregion

}

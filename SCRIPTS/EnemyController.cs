using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int mobType;
    public DropSystem dropSystem;
    public BattleController battleController;
    public float movementSpeed;
    public float attackSpeed;
    public float attackRange;
    public float chaseRange;
    public CharacterController characterController;
    public Transform playerTransform;
    public AnimationClip[] animationClips;
    public Animation animation;
    public Animator animator;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public float impactTime = 0.5f;
    private bool isImpacted;
    //public PlayerInCombat enemy;
    public GameObject player;
    //public ExperienceSystem experienceSystem;
    public int exp;
    //Combat effects
    public bool isStunned; //stun
    public float stunTime;

    public bool isSlowed; //ms is decreased
    private float slowDebuffValue;
    public float slowTime;
    public float tmpMovementSpeed;

    public bool isExhausted; //as is decreased
    private float exhaustDebuffValue;
    public float exhaustTime;
    public float tmpAttackSpeed;

    public bool isWeakend; //dmg is decreased
    private float weakenDebuffValue;
    public float weakenTime;
    public int tmpDamage;

    public float attackTimer;
    public float coolDown;
    public float dieTimer;
    //GUI
    public Texture2D frame;
    public Rect framePosition;
    public Texture2D healthBar;
    public Rect healthBarPosition;
    public float healthPercentage;
    public void DrawFrame()
    {
        framePosition.x = (Screen.width - framePosition.width) / 2;
        framePosition.y = (Screen.height - framePosition.height) / 40;
        framePosition.width = Screen.width * 0.25f;
        framePosition.height = Screen.height * 0.05f;
        GUI.DrawTexture(framePosition, frame);
    }
    public void DrawHealthBar()
    {
        healthBarPosition.Set
        (
            framePosition.x,
            framePosition.y,
            framePosition.width * healthPercentage,
            framePosition.height
        );
        GUI.DrawTexture(healthBarPosition, healthBar);
    }
    public void OnGUI()
    {
        if (battleController.selectedEnemy != null && battleController.selectedEnemy == gameObject)
        {
            DrawFrame();
            DrawHealthBar();
        }
    }
    public void UpdateHealthStatus()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthPercentage = (float)currentHealth / (float)maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        dropSystem = GameObject.Find("DropSystem").GetComponent<DropSystem>();
        mobType = 3;
        attackTimer = 0;
        coolDown = attackSpeed;
        dieTimer = 1.5f;

        animation = gameObject.GetComponent<Animation>();
        animator = gameObject.GetComponent<Animator>();
        maxHealth = 100;//PlayerPrefs.GetInt("CurrentLevel") * 100;
        currentHealth = 100;//PlayerPrefs.GetInt("CurrentLevel") * 100;
        //enemy = playerTransform.GetComponent<PlayerInCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tmpPC = GameObject.Find("pc");
        player = tmpPC;
        playerTransform = tmpPC.transform;
        battleController = tmpPC.GetComponent<BattleController>();
        characterController = GetComponent<CharacterController>();
        UpdateHealthStatus();
        ChasePlayer();
    }
    public void Attack()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
            attackTimer = 0;
        if (attackTimer == 0)
        {
            player.GetComponent<PlayerHealth>().GetHit(damage);
            attackTimer = coolDown;
        }

        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0));
        //if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > impactTime * animator.GetCurrentAnimatorStateInfo(0).length && !isImpacted && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.9 * animator.GetCurrentAnimatorStateInfo(0).length)
        //if (animation[animationClips[2].name].time >
        //    impactTime * animation[animationClips[2].name].length &&
        //    !isImpacted &&
        //    animation[animationClips[2].name].time < 0.9 * animation[animationClips[2].name].length)
        //{
        //player.GetComponent<PlayerHealth>().GetHit(damage);
        //isImpacted = true;
        //Invoke("NotImpacted", attackSpeed);
        //}

    }
    public void NotImpacted()
    {
        isImpacted = false;
    }
    public void GetHit(int dmg)
    {
        Debug.Log(gameObject.name + " - " + currentHealth);
        currentHealth -= dmg;
        if (currentHealth < 0)
            currentHealth = 0;
    }
    public void ToDie()
    {
        animator.SetTrigger("die");
        battleController.DeselectEnemy();
        battleController.RemoveDeadEnemy(gameObject);
        if (dieTimer > 0)
            dieTimer -= Time.deltaTime;
        if (dieTimer < 0)
            dieTimer = 0;
        if (dieTimer == 0)
        {
            dropSystem.DropItem(mobType, transform);
            Destroy(gameObject);
        }
        //animation.Play(animationClips[2].name);
        //if (animation[animationClips[2].name].time > 0.9 * animation[animationClips[2].name].length)
        //{
        //experienceSystem.GainExp(exp);
        //battleController.DeselectEnemy();
        //battleController.RemoveEnemyFromLists(gameObject);
        //}
    }
    public bool IsDead()
    {
        return (currentHealth <= 0);
    }
    public bool IsInRangeToAttack()
    {
        return (Vector3.Distance(transform.position, playerTransform.position) < attackRange);
    }
    public bool IsInRangeToChase()
    {
        return (Vector3.Distance(transform.position, playerTransform.position) < chaseRange);
    }
    public bool IsUnderAnyEffects()
    {
        return (isStunned || isSlowed || isExhausted || isWeakend);
    }
    public void GetWeakend2(float debuff, float time)
    {
        weakenTime = time;
        if (!isWeakend && weakenTime > 0)
        {
            isWeakend = true;
            weakenDebuffValue = debuff;
            tmpDamage = damage;
            damage = (int)(damage - (damage * weakenDebuffValue));
        }
        if (weakenTime > 0)
            weakenTime -= Time.deltaTime;
        if (weakenTime< 0)
            weakenTime = 0;
        if (weakenTime == 0)
        {
            isWeakend = false;
            damage = tmpDamage;
        }
    }
    public void GetExhausted2(float debuff, float time)
    {
        exhaustTime = time;
        if (!isExhausted && exhaustTime > 0)
        {
            isExhausted = true;
            exhaustDebuffValue = debuff;
            tmpAttackSpeed = attackSpeed;
            attackSpeed = (attackSpeed - (attackSpeed * exhaustDebuffValue));
        }
        if (exhaustTime > 0)
            exhaustTime -= Time.deltaTime;
        if (exhaustTime < 0)
            exhaustTime = 0;
        if (exhaustTime == 0)
        {
            isExhausted = false;
            attackSpeed = tmpAttackSpeed;
        }
    }
    public void GetSlowed2(float debuff, float time)
    {
        slowTime = time;
        if (!isSlowed && slowTime > 0)
        {
            isSlowed = true;
            slowDebuffValue = debuff;
            tmpMovementSpeed = movementSpeed;
            movementSpeed = (movementSpeed - (movementSpeed * slowDebuffValue));
        }
        if (slowTime > 0)
            slowTime -= Time.deltaTime;
        if (slowTime < 0)
            slowTime = 0;
        if (slowTime == 0)
        {
            isSlowed = false;
            movementSpeed = tmpMovementSpeed;
        }
    }
    public void GetStun2(float debuff, float time)
    {
        stunTime = time;
        if (!isStunned && stunTime > 0)
        {
            isStunned = true;
        }
        if (stunTime > 0)
            stunTime -= Time.deltaTime;
        if (stunTime < 0)
            stunTime = 0;
        if (stunTime == 0)
        {
            isStunned = false;
        }
    }
    public void GetWeakend(float debuff, float time)
    {
        CancelInvoke("WeakenCountDown");
        if (time > 0)
        {
            isWeakend = true;
            weakenDebuffValue = debuff;
            tmpDamage = damage;
            damage = (int)(damage - (damage * weakenDebuffValue));
            weakenTime = time;
            InvokeRepeating("WeakenCountDown", 0f, 1f);
        }
    }
    public void WeakenCountDown()
    {
        weakenTime -= 1;
        if (weakenTime == 0)
        {
            isWeakend = false;
            damage = (int)(tmpDamage + (tmpDamage * weakenDebuffValue));
            CancelInvoke("WeakenCountDown");
        }
    }
    public void GetExhausted(float debuff, float time)
    {
        CancelInvoke("ExhaustCountDown");
        if (time > 0)
        {
            isExhausted = true;
            exhaustDebuffValue = debuff;
            attackSpeed -= exhaustDebuffValue;
            exhaustTime = time;
            InvokeRepeating("ExhaustCountDown", 0f, 1f);
        }
    }
    public void ExhaustCountDown()
    {
        exhaustTime -= 1;
        if (exhaustTime == 0)
        {
            isExhausted = false;
            attackSpeed += exhaustDebuffValue;
            CancelInvoke("ExhaustCountDown");
        }
    }
    public void GetSlowed(float debuff, float time)
    {
        CancelInvoke("SlowCountDown");
        if (time > 0)
        {
            isSlowed = true;
            slowDebuffValue = debuff;
            movementSpeed -= slowDebuffValue;
            slowTime = time;
            InvokeRepeating("SlowCountDown", 0f, 1f);
        }
    }
    public void SlowCountDown()
    {
        slowTime -= 1;
        if (slowTime == 0)
        {
            isSlowed = false;
            movementSpeed += slowDebuffValue;
            CancelInvoke("SlowCountDown");
        }
    }
    public void GetStunned(float time)
    {
        CancelInvoke("StunCountDown");
        if (time > 0)
        {
            isStunned = true;
            stunTime = time;
            InvokeRepeating("StunCountDown", 0f, 1f);
        }
    }
    public void StunCountDown()
    {
        stunTime -= 1;
        if (stunTime == 0)
        {
            isStunned = false;
            CancelInvoke("StunCountDown");
        }
    }
    public void ChasePlayer()
    {
        if (!IsDead())
        {
            //if (!isStunned)
            //{
            if (IsInRangeToChase() && !IsInRangeToAttack() && !animator.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack"))
            {
               // movementSpeed = 3;
                //animation.GetClip("Z_Run");
                Vector3 tmp = playerTransform.position;
                    tmp.y = transform.position.y;
                    transform.LookAt(tmp);
                    characterController.SimpleMove(transform.forward * movementSpeed);
                //animator.CrossFade("Z_Walk", 0.5f);

                GetComponent<Animator>().SetTrigger("run");
                //animation.Play("Z_Run");
            }
                else if (IsInRangeToAttack())
            {
                //movementSpeed = 0;
                //animator.CrossFade("Z_Walk", 0.5f);
                GetComponent<Animator>().SetTrigger("attack");
                //animation.Play("Z_Attack");
                //animation.CrossFade(animationClips[2].name);
                Attack();
                //if (animation[animationClips[2].name].time > 0.9 * animation[animationClips[2].name].length)
                isImpacted = false;
            }
            else
            {
                //animator.CrossFade("Z_Walk", 0.5f);
                GetComponent<Animator>().SetTrigger("idle");
            }
            //animation.Play("Z_Idle");
            //}

        }
        else
            ToDie();

    }
    public void OnMouseOver()
    {
        //PlayerInCombat.enemy = gameObject;
        if (Input.GetMouseButton(0))
        {
            battleController.selectedEnemy = gameObject;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInCombat : MonoBehaviour
{
    public BattleController battleController;
    public static GameObject enemy;
    public List<GameObject> enemiesInRange;
    public PlayerController playerController;
    public int damage;
    public float impactTime;
    public bool isImpacted;
    public float range;
    //public PlayerHealth playerHealth;
    public float combatEscapeTime;
    public float countDown;

    public bool specialAttack;
    public bool inAction;
    public static float Range;

    public static float attackRange;
    public static float chaseRange;
    public float aRange;
    public float cRange;

    public float rightAngle;
    public float leftAngle;
    // Start is called before the first frame update
    void Start()
    {
        //enemiesInRange = new List<GameObject>();
        //attackRange = aRange;
        //chaseRange = cRange;
    }

    // Update is called once per frame
    void Update()
    {
        //Range = range;
        WindowsHandler();
        //DefineEnemiesInRange(rightAngle, leftAngle);
        //RemoveEnemiesOutOfRangeFromList();
        //ChaseEnemyAndAttack();
        //foreach (GameObject enemyInRange in enemiesInRange)
        //{
        //    Debug.Log(enemyInRange.name);
        //}
        //Debug.Log(attackRange);
        //Debug.Log(chaseRange);

    }
    /*
    public void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, Screen.width / 2 / (playerHealth.maxHealth / playerHealth.currentHealth), 20), playerHealth.currentHealth + "/" + playerHealth.maxHealth);
        enemy.GetComponent<EnemyController>().DrawFrame();
        enemy.GetComponent<EnemyController>().DrawHealthBar();
    }
    */
    /*
    public void combatEscapeCountDown()
    {
        countDown = countDown - 1;
        if (countDown == 0)
            CancelInvoke("combatEscapeCountDown");
    }*/
    private void WindowsHandler()
    {



        //if (Input.GetKeyDown(KeyCode.Space) && !specialAttack)
        //    inAction = true;

        if (inAction)
        {
            float[] tab = { 1, 0, 0, 0, 0, 0, 0, 0 };
            if (Attack(5, 0, tab, null, KeyCode.Mouse0, null, 0, true, false))
            {

            }
            else
            {
                inAction = false;
            }

        }
        //playerController.GetComponent<PlayerHealth>().ToDie();
    }
    public void ResetRange(float r)
    {
        if (r != 5)
            range = 5;
    }
    public bool Attack(
        float ran, float cooldown,
        float[] attackTab, float[] buffTab,
        KeyCode key, GameObject particleEffect,
        int projectile, bool enemyBased, bool aoe
        )
    {
        range = ran;

        if (enemyBased)
        {
            if (Input.GetKeyDown(key) && IsInRangeToBeAbleToAttack())
            {
                //playerController.animation.Play(playerController.animationClips[2].name);
                PlayerController.isAttack = true;
                if (enemy != null)
                {
                    Vector3 tmp = enemy.transform.position;
                    tmp.y = transform.position.y;
                    transform.LookAt(tmp);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                //playerController.animation.Play(playerController.animationClips[2].name);
                PlayerController.isAttack = true;
                transform.LookAt(PlayerController.cursorPosition);
            }
        }

        if (isImpacted)//IsReadyToRun())
        {
            PlayerController.isAttack = false;
            isImpacted = false;
            if (specialAttack)
                specialAttack = false;
            return false;
        }
        Impact(
            ran, cooldown,
            attackTab, buffTab,
            particleEffect, projectile, enemyBased, aoe
        );
        return true;
    }
    public void AttackAction()
    {
        //attack
    }
    public void BuffAction()
    {
        //increase statistics
    }
    public void MobilityAction()
    {
        //attack
        //move functionality
        //2 types: 
        //first
        //teleport to cursor position if in range of use 
        //if not tp to max range of use on the line between cursor and player
        //second
        //move forward in the face direction
    }
    /*
    public void ResetAttack()
    {
        PlayerController.isAttack = false;
        isImpacted = false;
        //playerController.animation.Stop(playerController.animationClips[2].name);
    }
    public bool IsReadyToRun()
    {
        return playerController.animation[playerController.animationClips[2].name].time >
            0.9 * playerController.animation[playerController.animationClips[2].name].length;
        //!playerController.animation.IsPlaying(playerController.animationClips[3].name)
    }
    public bool IsNotReadyToRun()
    {
        return playerController.animation[playerController.animationClips[2].name].time <
            0.9 * playerController.animation[playerController.animationClips[2].name].length;
        //!playerController.animation.IsPlaying(playerController.animationClips[3].name)
    }
    public bool IsImpacted()
    {
        return playerController.animation[playerController.animationClips[2].name].time >
            playerController.animation[playerController.animationClips[2].name].length * impactTime;
    }*/
    /*
    private bool ReadyToRun()
    {
        if (IsReadyToRun())
        {
            PlayerController.isAttack = false;
            isImpacted = false;
            if (specialAttack)
                specialAttack = false;
            return false;
        }
    }*/
    public void Impact(
        float ran, float cooldown,
        float[] attackTab, float[] buffTab,
        GameObject particleEffect,
        int projectile, bool enemyBased, bool aoe
        )
    {
        if ((!enemyBased || enemy != null) &&
            //playerController.animation.IsPlaying(playerController.animationClips[2].name) &&
            !isImpacted)
        {
            if (/*IsImpacted() && IsNotReadyToRun()*/isImpacted)
            {
                countDown = combatEscapeTime;
                CancelInvoke("combatEscapeCountDown");
                InvokeRepeating("combatEscapeCountDown", 0, 1);
                //uzależniony invoke od prędkości ataku
                if (enemyBased && !aoe)
                {
                    enemy.GetComponent<EnemyController>().GetHit((int)(damage * attackTab[0]));
                    //enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
                    //enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
                    //enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
                    //enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
                }
                if (aoe)
                {
                    AttackEnemiesInRange(attackTab);
                }

                Quaternion rot = transform.rotation;
                rot.x = 0f;
                rot.z = 0f;

                if (projectile == 1)
                {
                    Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z)/*transform.position*/, rot);
                }

                ShowParticles(particleEffect, aoe);

                isImpacted = true;
            }
        }
        //ResetRange(ran);
    }
    public void ShowParticles(GameObject particleEffect, bool aoe)
    {
        if (particleEffect != null)
        {
            if (!aoe)
            {
                Instantiate(particleEffect/*Resources.Load("")*/,
                    new Vector3(
                        enemy.transform.position.x,
                        enemy.transform.position.y + 1.5f,
                        enemy.transform.position.z),
                    Quaternion.identity);

            }
            else
            {
                foreach (GameObject enemy in enemiesInRange)
                {
                    Instantiate(particleEffect/*Resources.Load("")*/,
                        new Vector3(
                            enemy.transform.position.x,
                            enemy.transform.position.y + 1.5f,
                            enemy.transform.position.z),
                        Quaternion.identity);
                }
            }
        }
    }
    public void AttackEnemiesInRange(float[] attackTab)
    {
        foreach (GameObject enemy in enemiesInRange)
        {
            enemy.GetComponent<EnemyController>().GetHit((int)(damage * attackTab[0]));
            //enemy.GetComponent<EnemyController>().GetStunned(attackTab[1]);
            //enemy.GetComponent<EnemyController>().GetSlowed(attackTab[2], attackTab[3]);
            //enemy.GetComponent<EnemyController>().GetExhausted(attackTab[4], attackTab[5]);
            //enemy.GetComponent<EnemyController>().GetWeakend(attackTab[6], attackTab[7]);
        }
    }
    public bool DefineShapeOfAttack(float r, float l)
    {
        if (Vector3.Angle(enemy.transform.position, transform.forward) < r
            && Vector3.Angle(enemy.transform.position, transform.forward) > l)
            return true;
        return false;
    }
    /*ToCheck
    bool frontAttack(Transform target)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toTarget = target.position - transform.position;
        float angle = Vector3.Dot(forward, toTarget);

        if (angle > 0.5f && angle < 1.5f)
        {
            return true;
        }

        return false;
    }
    */
    /*
    public void DefineEnemiesInRange(float r, float l)
    {
        GameObject[] tmpEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in tmpEnemies)
        {
            if (Vector3.Distance(enemy.GetComponent<EnemyController>().transform.position, transform.position) <= range &&
                !enemiesInRange.Contains(enemy) //&& DefineShapeOfAttack(r, l)
                )
            {
                enemiesInRange.Add(enemy);
            }
        }
    }*/

    public void RemoveEnemiesOutOfRangeFromList()
    {
        foreach (GameObject enemyInRange in enemiesInRange)
        {
            if (Vector3.Distance(enemyInRange.GetComponent<EnemyController>().transform.position, transform.position) > range &&
                enemiesInRange.Contains(enemy))
            {
                //Debug.Log(enemyInRange.name);
                enemiesInRange.Remove(enemyInRange);
            }
        }
    }
    public bool IsInRangeToBeAbleToAttack()
    {
        return (Vector3.Distance(battleController.selectedEnemy.transform.position, transform.position) <= range);
    }
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
    public bool IsEnemyClicked()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit, 1000))
        {
            if (raycastHit.collider.tag == "Enemy")
            {
                return true;
            }
        }
        return false;
    }
    public bool IsInRangeToAttack()
    {
        return (Vector3.Distance(transform.position, enemy.transform.position) < attackRange);
    }
    public bool IsInRangeToChase()
    {
        return (Vector3.Distance(transform.position, enemy.transform.position) < chaseRange);
    }
    public void ChaseEnemyAndAttack()
    {
        if (Input.GetMouseButtonDown(0) && IsEnemyClicked())
        {
            if (IsInRangeToChase() && !IsInRangeToAttack())
            {
                Vector3 tmp = enemy.transform.position;
                tmp.y = transform.position.y;
                transform.LookAt(tmp);
                playerController.characterController.SimpleMove(transform.forward * playerController.movementSpeed);
                //animation.CrossFade(animationClips[1].name);
            }
            else if (IsInRangeToAttack())
            {
                inAction = true;

                if (inAction)
                {
                    float[] tab = { 1, 0, 0, 0, 0, 0, 0, 0 };
                    if (Attack(5, 0, tab, null, KeyCode.Mouse0, null, 0, true, false))
                    {

                    }
                    else
                    {
                        inAction = false;
                    }

                }
                //animation.CrossFade(animationClips[2].name);
                //Attack();
                //if (animation[animationClips[2].name].time > 0.9 * animation[animationClips[2].name].length)
                //    isImpacted = false;
            }
        }
    }
}

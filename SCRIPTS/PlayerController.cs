using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Button button;
    public BattleController battleController;
    public CharacterController characterController;
    public float movementSpeed;
    public Vector3 position;
    public static bool isAttack;
    public static bool isDead;
    public static bool isEnemyClicked;
    public static bool isPlayerClicked;
    public static bool isTerrainClicked;
    public static bool isGUIClicked;
    public static bool isAbilityUsed;
    //public static bool isAbilityEnded;
    public float triggerTimer;
    public float abilityTimer;

    public static Vector3 cursorPosition;
    
    public Vector3 increaseValues = new Vector3(0.1f, 0.1f, 0);
    public Vector3 targetPosition = new Vector3(0, 0, 0.35f);





    public Vector3 moveDirection;

    public const float maxDashTime = 2.0f;
    public float dashDistance = 30;
    public float dashStoppingSpeed = 0.05f;
    float currentDashTime = maxDashTime;
    float dashSpeed = 1;
    bool dash;


    List<KeyCode> keyCodes;
    public bool[] abilityReadiness;
    public float[] abilityTimers;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            InventoryController.instance.Add(item, 1);
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        //characterController = FindObjectOfType<PlayerController>().GetComponent<CharacterController>();
        position = transform.position;
        //isAbilityEnded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.G))
        //{
        //if (Vector3.Distance(targetPosition, gameObject.transform.position) > 0.2f)
        //Vector3 v= gameObject.transform.forward;
        //v.y += 0.5f * Time.deltaTime;
        //gameObject.transform.forward = v;
        //characterController.SimpleMove(transform.forward * movementSpeed * 5);


        //



        //Debug.Log(isEnemyClicked + " " + isPlayerClicked + " " + isTerrainClicked);
        ActionRecognizer();
        WindowsHandler();
        //CurrentSpeedMeter();
        AbilityUsing();
        //Debug.Log(isAbilityUsed);

        if (Input.GetKeyDown(KeyCode.W)) //Right mouse button
            {
                currentDashTime = 0;
                dash = true;
            }
            if (currentDashTime < maxDashTime)
            {
                moveDirection = transform.forward * dashDistance;
                currentDashTime += dashStoppingSpeed;
            }
            else
            {
                moveDirection = Vector3.zero;
            }
            if (dash)
                characterController.Move(moveDirection * Time.deltaTime * dashSpeed);





        //

        //}

    }
    public void CurrentSpeedMeter()
    {
        //Debug.Log(characterController.velocity);
    }
    public void ResetAttack()
    {
        if (!isEnemyClicked)
        {
            triggerTimer = GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length;
            if (triggerTimer > 0)
                triggerTimer -= Time.deltaTime;
            if (triggerTimer < 0)
                triggerTimer = 0;
            if (triggerTimer == 0)
            {
                GetComponentInChildren<Animator>().ResetTrigger("SpellTrigger");
            }
        }
    }

    private void ActionRecognizer()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !isGUIClicked)
        {
            if (Physics.Raycast(ray, out raycastHit, 1000))
            {
                if (raycastHit.collider.tag == "Enemy")
                {
                    isTerrainClicked = false;
                    isPlayerClicked = false;
                    isEnemyClicked = true;
                    isGUIClicked = false;
                }
                else if (raycastHit.collider.tag == "Player")
                {
                    isTerrainClicked = false;
                    isPlayerClicked = true;
                    isEnemyClicked = false;
                    isGUIClicked = false;
                    battleController.DeselectEnemy();
                }
                else if (raycastHit.collider.tag == "Terrain")
                {
                    isTerrainClicked = true;
                    isPlayerClicked = false;
                    isEnemyClicked = false;
                    isGUIClicked = false;
                    battleController.DeselectEnemy();
                }
                else if (raycastHit.collider.tag == "GUI")
                {
                    isTerrainClicked = false;
                    isPlayerClicked = false;
                    isEnemyClicked = false;
                    isGUIClicked = true;
                    battleController.DeselectEnemy();
                }
            }
        }
    }
    private void ActionFinalizer()
    {
        //Reaching the cursor point makes the bool false
    }

    private void WindowsHandler()
    {
        //
        //UJEDNOLICIĆ WINDOWSHANDLERA ITD.
        //
        //Debug.Log(Input.GetKey(KeyCode.LeftShift) + " Input.GetKeyDown(KeyCode.LeftShift)");
        LocateCursor();
        if (!Input.GetKey(KeyCode.LeftShift) && !isGUIClicked)
        {
            if (isTerrainClicked && !isDead && !isGUIClicked && !isAbilityUsed)//add boolen
                ClickToMove();
            else if (isEnemyClicked && !isDead && !isGUIClicked && !isAbilityUsed)
                FollowAndAttack();
            if (IsSpellButtonClicked())
                AbilitiesUsing();
        }
        else
            StayAndAttack();
        //if (battleController.selectedEnemy == null)
        //    isEnemyClicked = false;

    }
    public bool IsInRangeToAttack()
    {
        if (battleController.selectedEnemy != null)
            return (Vector3.Distance(transform.position, battleController.selectedEnemy.transform.position) < battleController.attackRange);
        return false;
    }
    public bool IsInRangeToChase()
    {
        if (battleController.selectedEnemy != null)
            return (Vector3.Distance(transform.position, battleController.selectedEnemy.transform.position) < battleController.chaseRange);
        return false;
    }
    public void FollowAndAttack()
    {
        if (IsInRangeToChase() && !IsInRangeToAttack())
        {
            Vector3 tmp = battleController.selectedEnemy.transform.position;
            tmp.y = transform.position.y;
            transform.LookAt(tmp);
            characterController.SimpleMove(transform.forward * movementSpeed);
            //GetComponentInChildren<Animator>().SetFloat("speedPercent", 1f);
            GetComponentInChildren<Animator>().SetBool("Moving", true);
        }
        else if (IsInRangeToAttack())
        {
            GetComponentInChildren<Animator>().SetBool("Moving", false);
            GetComponentInChildren<Animator>().SetInteger("SpellIndex", 1);
            GetComponentInChildren<Animator>().SetTrigger("SpellTrigger");
            Vector3 tmp = battleController.selectedEnemy.transform.position;
            tmp.y = transform.position.y;
            transform.LookAt(tmp);
            //GetComponentInChildren<Animator>().SetFloat("speedPercent", 0f);
            battleController.inAction = true; 
            //AbilityUsing();
            ResetAttack();
        }
    }
    public void StayAndAttack()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isGUIClicked)
        {
            if (GetComponentInChildren<Animator>().GetBool("Moving"))
                GetComponentInChildren<Animator>().SetBool("Moving", false);
            /*if (GetComponentInChildren<Animator>().GetFloat("speedPercent") == 1f)
                GetComponentInChildren<Animator>().SetFloat("speedPercent", 0f);*/
            if (Input.GetMouseButtonDown(0))
            {
                GetComponentInChildren<Animator>().SetInteger("SpellIndex", 1);
                GetComponentInChildren<Animator>().SetTrigger("SpellTrigger");
                Vector3 tmp = cursorPosition;
                tmp.y = transform.position.y;
                transform.LookAt(tmp);
                battleController.inAction = true; 
                //AbilityUsing();
                ResetAttack();
            }
        }
    }
    public List<KeyCode> AbilitiesKeyCodesUpdater(List<KeyCode> kc)
    {
        foreach(KeyCode k in kc)
        {
            if (Input.GetKeyDown(k))
            {
                var tmp = k;
                kc.Remove(k);
                //AbilityUsing2(3f, true);
                kc.Add(tmp);
                //start timer
                //add again when stopped
            }
        }
        return kc;
    }
    public void AbilityUsing2(float timer, bool readiness)
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if (timer < 0)
            timer = 0;
        if (timer == 0)
        {
            readiness = true;
            return;
        }
    }
    public void AbilitiesUsing()//chyba lepiej dać  if (Input.GetKeyDown(kc) && timery[kc.index] is ready)  
    {
        
        //if (battleController.isReady)
        //{
            /*if (GetComponentInChildren<Animator>().GetFloat("speedPercent") == 1f)
                GetComponentInChildren<Animator>().SetFloat("speedPercent", 0f);*/
        keyCodes = new List<KeyCode>{ /*KeyCode.Mouse0,*/ KeyCode.Mouse1, KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R };
        foreach (KeyCode kc in keyCodes)
            if (Input.GetKeyDown(kc)/* && abilityReadiness[0]*/) //error 
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    isAbilityUsed = true;
                    abilityTimer = 0.9f;

                    SwitchAnimOfSpells(kc);
                    Vector3 tmp = cursorPosition;
                    tmp.y = transform.position.y;
                    transform.LookAt(tmp);

                    //isAbilityUsed = true;
                    //isAbilityEnded = false;
                    battleController.inAction = true;

                    /*abilityReadiness[0] = false;
                    AbilityUsing2(abilityTimers[0], abilityReadiness[0]);*/

                    ResetAttack();
                }
        //}
    }
    public void AbilityUsing()
    {
        if (isAbilityUsed)
        {
            //Debug.Log("in");
            if (abilityTimer > 0)
                abilityTimer -= Time.deltaTime;
            if (abilityTimer < 0)
                abilityTimer = 0;
            if (abilityTimer == 0)
            {
                //Debug.Log("isAbilityUsed => false");
                isAbilityUsed = false;
                dash = false;
            }
        }
    }
    public void SwitchAnimOfSpells(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Mouse1:
                GetComponentInChildren<Animator>().SetInteger("SpellIndex", 2);
                break;
            case KeyCode.Q:
                GetComponentInChildren<Animator>().SetInteger("SpellIndex", 3);
                break;
            case KeyCode.W:
                GetComponentInChildren<Animator>().SetInteger("SpellIndex", 4);
                break;
            case KeyCode.E:
                GetComponentInChildren<Animator>().SetInteger("SpellIndex", 5);
                break;
            case KeyCode.R:
                GetComponentInChildren<Animator>().SetInteger("SpellIndex", 6);
                break;
            default:
                break;
        }
        GetComponentInChildren<Animator>().SetTrigger("SpellTrigger");
    }
    /*
    public void BasicAttack(float r, float l)
    {
        isAttack = true;
        if (PlayerInCombat.enemy != null)
        {
            Vector3 tmp = PlayerInCombat.enemy.transform.position;
            tmp.y = transform.position.y;
            transform.LookAt(tmp);
        }
    }
    */
    public void ClickToMove()
    {
        if (!isAttack && !isGUIClicked)
        {
            if (Input.GetMouseButton(0))
                if (!EventSystem.current.IsPointerOverGameObject())
                    LocatePosition();
            MoveToPositionOnMouseClick();
        }
    }
    public bool IsSpellButtonClicked()
    {
        return Input.GetKeyDown(KeyCode.Mouse1) 
            || Input.GetKeyDown(KeyCode.Q) 
            || Input.GetKeyDown(KeyCode.W) 
            || Input.GetKeyDown(KeyCode.E) 
            || Input.GetKeyDown(KeyCode.R);
    }
    public void MoveToPositionOnMouseClick()
    {
        //Debug.Log(GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run2"));
        if (Vector3.Distance(transform.position, position) > 0.65 && !IsSpellButtonClicked())
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);   
            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            characterController.SimpleMove(transform.forward * movementSpeed);
            //GetComponentInChildren<Animator>().SetFloat("speedPercent", 1f);
            GetComponentInChildren<Animator>().SetBool("Moving", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Moving", false);
            //GetComponentInChildren<Animator>().Play("Idle");
            //GetComponentInChildren<Animator>().SetFloat("speedPercent", 0f);
            isTerrainClicked = false;
        }

    }
    public void LocatePosition()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit, 1000))
        {
            if (raycastHit.collider.tag != "Player" && raycastHit.collider.tag != "Enemy")
            {
                position = new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);
            }
        }
    }
    public void LocateCursor()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit, 1000))
        {
            cursorPosition = raycastHit.point;
        }
    }
    public void InteractWithObjectOnMouseClick()
    {
        //soon
    }
}

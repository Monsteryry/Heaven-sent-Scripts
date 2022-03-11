using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpells : MonoBehaviour
{
    //problem z usuwaniem umiejętności po wyjęciu ze slotu runy
    public GameObject[] spellContainers;
    public InventoryController inventoryController;
    public SpellStats[] spells;
    public bool cooldownReset;
    public float[] timer;
    public SpellSetter spellSetter;
    public int savedID;

    //cooldown i osobno timer do pokazywania
    bool SpellIsReady;
    public void UseAbility(SpellStats spell)
    {
        if (spell.isReady)
        {
            spell.isReady = false;
            SpellTimerUpdater(spell);
            StartCoroutine(Wait(spell));
        }
    }
    public IEnumerator Wait(SpellStats spell)
    {
        yield return new WaitForSeconds(spell.cooldown);
        spell.isReady = true;
    }
    public void SpellTimerUpdater(SpellStats s)
    {
        s.currentTimer = s.cooldown;
        if (s.currentTimer > 0)
            s.currentTimer -= Time.deltaTime;
        if (s.currentTimer < 0)
            s.currentTimer = 0;
        if (s.currentTimer == 0)
        {
            return;
        }
    }
    //cooldown

    void Start()
    {
        savedID = -1;
        inventoryController = GameObject.Find("InventoryHandler").GetComponent<InventoryController>();
        spellContainers = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            spellContainers[i] = GameObject.Find("Spell " + (i + 1));
            spellContainers[i].GetComponent<Image>().sprite = Sprite.Create(Resources.Load<Texture2D>("Mini_background"), new Rect(0, 0, Resources.Load<Texture2D>("Mini_background").width, Resources.Load<Texture2D>("Mini_background").height), new Vector2(0.5f, 0.5f));
        }
        //spellSetter.DarcRitter();
        spells = new SpellStats[6];
    }
    void Update()
    {
        RitterSpellsGiver();
        SpellIconsUpdater();
        //SpellTimerUpdater();
        /*
        SpellCooldownStarter();
        SpellCooldownUpdater();
        */
    }
    public void SpellCooldownStarter()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) StartCounting(spells[0]);
        else if (Input.GetKeyDown(KeyCode.Mouse1)) StartCounting(spells[1]);
        else if (Input.GetKeyDown(KeyCode.Q)) StartCounting(spells[2]);
        else if (Input.GetKeyDown(KeyCode.W)) StartCounting(spells[3]);
        else if (Input.GetKeyDown(KeyCode.E)) StartCounting(spells[4]);
        else if (Input.GetKeyDown(KeyCode.R)) StartCounting(spells[5]);
    }
    public void SpellCooldownUpdater()
    {
        for (int i = 0; i < 6; i++)
        {
            if (spells[i] != null)
            {
                if (spells[i].currentTimer != 0)
                    spellContainers[i].GetComponentInChildren<Text>().text = spells[i].currentTimer.ToString();
                else
                    spellContainers[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }
    public void StartCounting(SpellStats s)
    {
        s.currentTimer = s.cooldown;
        if (s.currentTimer > 0)
            s.currentTimer -= Time.deltaTime;
        if (s.currentTimer < 0)
            s.currentTimer = 0;
        if (s.currentTimer == 0)
        {
            return;
        }
    }
    public void SpellIconsUpdater()
    {
        for (int i = 0; i < 6; i++)
        {
            if (spells[i] != null)
                spellContainers[i].GetComponent<Image>().sprite = Sprite.Create(spells[i].icon, new Rect(0, 0, spells[i].icon.width, spells[i].icon.height), new Vector2(0.5f, 0.5f));
        }
    }
    public void RitterSpellsGiver()
    {
        if (inventoryController.itemList[6])
        {
            if (inventoryController.itemList[6].ID == savedID)
                return;
            else
            {
                //if (GetComponent<SpellStats>())
                //{
                    spells = new SpellStats[6];
                    for (int i = 0; i < 6; i++)
                    {
                        Destroy(GetComponent<SpellStats>());
                        Debug.Log("removed spellstats");
                    }
                //}
            }
            if (!GetComponent<SpellStats>())
            {
                switch (inventoryController.itemList[6].ID)
                {
                    case 30:
                        //przed każdym usuń wszystkie SpellStats komponenty
                        spellSetter.AerasRitter();
                        savedID = 30;
                        break;
                    case 31:
                        spellSetter.DarcRitter();
                        savedID = 31;
                        break;
                    case 32:
                        spellSetter.HydrasRitter();
                        savedID = 32;
                        break;
                    case 33:
                        spellSetter.LuxRitter();
                        savedID = 33;
                        break;
                    case 34:
                        spellSetter.PyrasRitter();
                        savedID = 34;
                        break;
                    case 35:
                        spellSetter.TerasRitter();
                        savedID = 35;
                        break;
                    default:
                        Debug.Log("Wrong rune id.");
                        break;
                }
                spells = GetComponents<SpellStats>();
            }
        }
        else
        {
            if (GetComponent<SpellStats>())
            {
                savedID = -1;
                spells = new SpellStats[6];
                for (int i = 0; i < 6; i++)
                {
                    Destroy(GetComponent<SpellStats>());
                    Debug.Log("removed spellstats");
                    spellContainers[i].GetComponent<Image>().sprite = Sprite.Create(Resources.Load<Texture2D>("Mini_background"), new Rect(0, 0, Resources.Load<Texture2D>("Mini_background").width, Resources.Load<Texture2D>("Mini_background").height), new Vector2(0.5f, 0.5f));
                }
            }
        }
    }
}

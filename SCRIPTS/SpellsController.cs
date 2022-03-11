using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsController : MonoBehaviour
{
    public Animator animator;
    public int[] spellIDs;
    //GUI
    public Texture2D[] frames;
    public Rect[] framesPosition;
    public Texture2D[] spellIcons;
    public Rect[] spellIconsPosition;
    public float cooldownPercentage;
    public float currentCooldown;
    public float cooldown;
    void Start()
    {

    }
    void Update()
    {
        UpdateSpellsStatus();
        //SpellsHandler();
    }
    
    public void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, Screen.width / 2 / (playerHealth.maxHealth / playerHealth.currentHealth), 20), playerHealth.currentHealth + "/" + playerHealth.maxHealth);
        drawFrames();
        drawSpellIcons();
    }
    private void drawFrames()
    {
        float tmp = 0.2f;
        for (int i = 0; i < 4; i++)
        {
            framesPosition[i].x = (Screen.width - framesPosition[i].width) * (0.4f + (tmp / 3 * i));
            framesPosition[i].y = (Screen.height - framesPosition[i].height) * 38 / 40;
            framesPosition[i].width = Screen.width * 0.05f;
            framesPosition[i].height = Screen.width * 0.05f;
            GUI.DrawTexture(framesPosition[i], frames[i]);
        }
    }
    private void drawSpellIcons()
    {
        for (int i = 0; i < 4; i++)
        {
            spellIconsPosition[i].Set
            (
                framesPosition[i].x,
                framesPosition[i].y,
                framesPosition[i].width,
                framesPosition[i].height
            );
            GUI.DrawTexture(spellIconsPosition[i], spellIcons[i]);

        }
    }
    public void UpdateSpellsStatus()
    {
        if (currentCooldown > cooldown)
            currentCooldown = cooldown;
        cooldownPercentage = (float)currentCooldown / (float)cooldown;
    }


    public void UseSpellOnClick(int index)
    {
        animator.SetInteger("spellID", index);
        animator.SetTrigger("spell");
    }

    public void SpellsHandler()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            UseSpellOnClick(0);
        if (Input.GetKeyDown(KeyCode.W))
            UseSpellOnClick(1);
        if (Input.GetKeyDown(KeyCode.E))
            UseSpellOnClick(2);
        if (Input.GetKeyDown(KeyCode.R))
            UseSpellOnClick(3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject healthPotion;
    public int maxHealth;
    public int currentHealth;
    public bool isStartedDying;
    public bool isEndedDying;
    public float healthPercentage;
    public Sprite[] healthPotions;
    public GameObject healthPercentageText;
    /*
    //GUI
    public Texture2D frame;
    public Rect framePosition;
    public Texture2D healthBar;
    public Rect healthBarPosition;
    */
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        healthPotion = GameObject.Find("HealthBottle");
        healthPercentageText = GameObject.Find("HealthText");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthStatus();
        UpdateHealthTexture();
    }
    public void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, Screen.width / 2 / (playerHealth.maxHealth / playerHealth.currentHealth), 20), playerHealth.currentHealth + "/" + playerHealth.maxHealth);
        //DrawFrame();
        //DrawHealthBar();
    }
    /*private void DrawFrame()
    {
        //framePosition.x = (Screen.width - framePosition.width) / 40;
        //framePosition.y = (Screen.height - framePosition.height) * 39 / 40;
        //framePosition.width = Screen.width * 0.25f;
        //framePosition.height = Screen.height * 0.05f;
        framePosition.x = (Screen.width - framePosition.width) * 11.75f / 40;
        framePosition.y = (Screen.height - framePosition.height) * 39.6f / 40;
        framePosition.width = Screen.width * 0.08f;
        framePosition.height = Screen.width * 0.08f;
        GUI.DrawTexture(framePosition, frame);
    }
    private void DrawHealthBar()
    {
        healthBarPosition.Set
        (
            framePosition.x,
            framePosition.y,
            framePosition.width,
            framePosition.height
        );
        GUI.DrawTexture(healthBarPosition, healthBar);
    }*/
    public void UpdateHealthStatus()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthPercentage = (float)currentHealth / (float)maxHealth;
        healthPercentageText.GetComponent<Text>().text = healthPercentage * 100f + "";
    }
    public void UpdateHealthTexture()
    {
        if (healthPercentage == 1f)
            healthPotion.GetComponent<Image>().sprite = healthPotions[0];
        else if (healthPercentage < 1f && healthPercentage > 0.75f)
            healthPotion.GetComponent<Image>().sprite = healthPotions[1];
        else if (healthPercentage <= 0.75f && healthPercentage > 0.5f)
            healthPotion.GetComponent<Image>().sprite = healthPotions[2];
        else if (healthPercentage <= 0.5f && healthPercentage > 0.25f)
            healthPotion.GetComponent<Image>().sprite = healthPotions[3];
        else if (healthPercentage <= 0.25f && healthPercentage > 0f)
            healthPotion.GetComponent<Image>().sprite = healthPotions[4];
        else if (healthPercentage == 0)
            healthPotion.GetComponent<Image>().sprite = healthPotions[5];
    }
    public void RestoreHealth(int hp)
    {
        currentHealth += hp;
        UpdateHealthStatus();
    }
    public void GetHit(int damage)
    {
        Debug.Log("Got hit");
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
    }
    public bool IsDead()
    {
        return (currentHealth == 0);
    }
    public void ToDie()
    {
        if (IsDead() && !isEndedDying)
        {
            if (!isStartedDying)
            {
                PlayerController.isDead = true;
                //playerController.animation.Play(playerController.animationClips[2].name);
                isStartedDying = true;
            }
            if (isStartedDying) //&& playerController.animation.IsPlaying(playerController.animationClips[2].name))
            {
                Debug.Log("You have died!");
                isEndedDying = true;
                playerController.GetComponent<PlayerHealth>().Revive();
                //revive at last checkpoint;
                PlayerController.isDead = false;
            }
        }
        //show defeat panel
    }
    public void Revive()
    {
        currentHealth = maxHealth;
        //reloading player character
    }
}

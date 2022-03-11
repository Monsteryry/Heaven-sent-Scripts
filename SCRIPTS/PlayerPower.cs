using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject powerPotion;
    public int maxPower;
    public int currentPower;
    public float powerPercentage;
    public Sprite[] powerPotions;
    public GameObject powerPercentageText;
    //GUI
    /*
    public Texture2D frame;
    public Rect framePosition;
    public Texture2D powerBar;
    public Rect powerBarPosition;*/
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        powerPotion = GameObject.Find("PowerBottle");
        powerPercentageText = GameObject.Find("PowerText");
    }
    void Update()
    {
        UpdatePowerStatus();
        UpdatePowerTexture();
    }
    public void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, Screen.width / 2 / (playerHealth.maxHealth / playerHealth.currentHealth), 20), playerHealth.currentHealth + "/" + playerHealth.maxHealth);
        //DrawFrame();
        //DrawPowerBar();
    }
    /*private void DrawFrame()
    {
        //framePosition.x = (Screen.width - framePosition.width) * 39 / 40;
        //framePosition.y = (Screen.height - framePosition.height) * 39 / 40;
        //framePosition.width = Screen.width * 0.25f;
        //framePosition.height = Screen.height * 0.05f;
        framePosition.x = (Screen.width - framePosition.width) * 28.25f / 40;
        framePosition.y = (Screen.height - framePosition.height) * 39.6f / 40;
        framePosition.width = Screen.width * 0.08f;
        framePosition.height = Screen.width * 0.08f;
        GUI.DrawTexture(framePosition, frame);
    }
    private void DrawPowerBar()
    {
        powerBarPosition.Set
        (
            framePosition.x,
            framePosition.y,
            framePosition.width,
            framePosition.height
        );
        GUI.DrawTexture(powerBarPosition, powerBar);
    }*/
    public void UpdatePowerStatus()
    {
        if (currentPower > maxPower)
            currentPower = maxPower;
        powerPercentage = (float)currentPower / (float)maxPower;
        powerPercentageText.GetComponent<Text>().text = powerPercentage * 100f + "";
    }
    public void UpdatePowerTexture()
    {
        if (powerPercentage == 1f)
            powerPotion.GetComponent<Image>().sprite = powerPotions[0];
        else if (powerPercentage < 1f && powerPercentage > 0.75f)
            powerPotion.GetComponent<Image>().sprite = powerPotions[1];
        else if (powerPercentage <= 0.75f && powerPercentage > 0.5f)
            powerPotion.GetComponent<Image>().sprite = powerPotions[2];
        else if (powerPercentage <= 0.5f && powerPercentage > 0.25f)
            powerPotion.GetComponent<Image>().sprite = powerPotions[3];
        else if (powerPercentage <= 0.25f && powerPercentage > 0f)
            powerPotion.GetComponent<Image>().sprite = powerPotions[4];
        else if (powerPercentage == 0)
            powerPotion.GetComponent<Image>().sprite = powerPotions[5];
    }
    public void RestorePower(int pp)
    {
        currentPower += pp;
        UpdatePowerStatus();
    }
    public void UsePower(int pp)
    {
        if (pp < currentPower)
            currentPower -= pp;
        else
            NotEnoughPower();
    }
    public void CastSpell(string spell)
    {
        //playerController.animation.Play(spell);
    }
    public void NotEnoughPower()
    {
        //show message "Not enough power"
    }
    public void Revive()
    {
        currentPower = maxPower;
        //reloading player character
    }
}

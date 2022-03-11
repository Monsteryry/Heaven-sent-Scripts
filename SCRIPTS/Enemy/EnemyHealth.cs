using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;

    public float healthBarLength;
    // Start is called before the first frame update
    void Start()
    {
        healthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        //GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHealth / curHealth), 20), curHealth + "/" + maxHealth);
        GUI.Box(new Rect(Screen.width / 2, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
    }
    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;
        if (curHealth < 0)
            curHealth = 0;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (maxHealth < 1)
            maxHealth = 1;
        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
}

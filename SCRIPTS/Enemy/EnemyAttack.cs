﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject target;
    public float attackTimer;
    public float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        attackTimer = 0;
        coolDown = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
            attackTimer = 0;
        if (attackTimer == 0)
        {
            Attack();
            attackTimer = coolDown;
        }
    }
    private void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Vector3 dir = (target.transform.position - transform.position).normalized;

        float direction = Vector3.Dot(dir, transform.forward);

        if (distance < 2.5f)
        {
            if (direction > 0)
            {
                PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");
                //eh.AddjustCurrentHealth(-10);
            }
        }
    }
}

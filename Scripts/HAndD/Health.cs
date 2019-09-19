using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 1;
    [SerializeField]
    private bool isPlayer = false;
    private bool isAlive = true;
    public event Action DiesP;
    public event Action<int> PHit;



    public void DealDamage(int damage)
    {
        health = health - damage;
        if (isPlayer)
        {
            PHit(health);
        }
        

        if (health <= 0)
        {            
            Die();
        }

    }

    private void Die()
    {
        if (isPlayer)
        {
            DiesP();
            isAlive = false;
        }

        Destroy(gameObject);
    }
}

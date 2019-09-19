using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    float shottimer = 0;
    private Transform shotpoint;
    [SerializeField] private GameObject bullet;
    private bool isInRange = false;
    private void Start()
    {
        var moveToTarget = GetComponent<MoveToTarget>();
        moveToTarget.RangeChange += BlockFire;
        shotpoint = transform.GetChild(0);
    }

    void Update()
    {
        Shoot();
        shottimer += 1 * Time.deltaTime;    
    }

    void Shoot()
    {
        if (Canfire(0.7f))
        {
            if (isInRange)
            {
                Instantiate(bullet, shotpoint.position, shotpoint.rotation);
            }            
        }
    }

    bool Canfire(float timer)
    {
        if (shottimer >= timer)
        {
            shottimer = 0;
            return true;

        }
        else
        {
            return false;
        }
    }

    private void BlockFire(bool range)
    {
        if (range)
        {
            isInRange = true;
        }
        else
        {
            isInRange = false;
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    float hittimer = 0;
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
        Hit();
        hittimer += 1 * Time.deltaTime;
    }

    void Hit()
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
        if (hittimer >= timer)
        {
            hittimer = 0;
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

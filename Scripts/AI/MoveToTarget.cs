using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private string tag;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private bool isMelee = false;
    private bool isAtTarget = false;
    private bool targetAlive = true;
    private GameObject target;

    public event Action<bool> RangeChange;

    void Start()//sets tag
    {
        target = GameObject.FindGameObjectWithTag(tag);
        var hasTarget = GameObject.Find("Player").GetComponent<Health>();
        hasTarget.DiesP += RemoveTarget;
    }

    void Update()
    {
        if (targetAlive)
        {
            GoToTarget(target);
        }
    }

    private void GoToTarget(GameObject targ)//makes it look towards the target and move towards there
    {
        RotateTowards(targ);
        float step = speed * Time.deltaTime;
        Vector3 pos = new Vector2(targ.transform.position.x, targ.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, pos, step);
    }

    private void RotateTowards(GameObject view)//calculates the rotation to look at
    {
        Vector3 diff = view.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void OnTriggerStay2D(Collider2D col)//stops in target area
    {
        if (!isMelee && col.tag == "TargetArea")
        {
            speed = 0;
            isAtTarget = true;
            RangeChange(isAtTarget);
        }
        else if (isMelee && col.tag == "TargetAreaM")
        {
            speed = 0;
            isAtTarget = true;
            RangeChange(isAtTarget);
        }

    }   

    private void OnTriggerExit2D(Collider2D col)//continues outside of target area
    {
        if (!isMelee && col.tag == "TargetArea")
        {
            speed = 1;
            isAtTarget = false;
            RangeChange(isAtTarget);
        }
        else if (isMelee && col.tag == "TargetAreaM")
        {
            speed = 1;
            isAtTarget = false;
            RangeChange(isAtTarget);
        }
    }

    private void RemoveTarget()
    {
            targetAlive = false;
    }
}

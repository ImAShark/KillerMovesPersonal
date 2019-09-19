using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : MonoBehaviour
{
    [SerializeField] private string objTag;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == objTag)
        {
            col.gameObject.SendMessage("DealDamage", 1);
            Destroy(gameObject);
        }
    }
}

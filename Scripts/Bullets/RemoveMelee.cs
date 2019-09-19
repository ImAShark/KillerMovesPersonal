using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMelee : MonoBehaviour
{
    private float timer;
    [SerializeField] private float reset = 0.3f;

    void Update()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            timer = timer - Time.deltaTime; 
        }
    }
}

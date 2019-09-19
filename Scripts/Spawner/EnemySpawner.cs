using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyS, EnemyM, EnemyD;
    [SerializeField] private float reset = 1;
    private float timer;
    private float dChance = 1;

    void Update()
    {
        if (timer <= 0)
        {
            CalculateChance();
            timer = reset;
        }
        timer = timer - Time.deltaTime;
        
    }

    private void SpawnEnemy()
    {
        float t = Mathf.Floor(Random.Range(0,2));
        if (t == 0)
        {
            Debug.Log("Shooter Spawned");
            Instantiate(EnemyS,transform.position,Quaternion.identity);
        }
        else if (t == 1)
        {
            Debug.Log("Melee Spawned");
            Instantiate(EnemyM, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Big oof");
        }
    }

    private void CalculateChance()
    {
        float d = Mathf.Floor(Random.Range(dChance, 20));
        if (dChance == 20 || d == 20)
        {
            Instantiate(EnemyD, transform.position, Quaternion.identity);
            dChance = 1;
        }
        else if (dChance <= 19)
        {
            dChance += 1;
            SpawnEnemy();
        }
    }
}

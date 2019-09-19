using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private GameObject Hp1, Hp2, Hp3, Hp4, Hp5;
    private int health;

    void Start()
    {
        var hp = GameObject.Find("Player").GetComponent<Health>();
        hp.PHit += UpdateHealth;
    }

    private void UpdateHealth(int health)
    {
        switch (health)
        {
            case 0:
                Hp1.SetActive(false);
                break;
            case 1:
                Hp2.SetActive(false);
                break;
            case 2:
                Hp3.SetActive(false);
                break;
            case 3:
                Hp4.SetActive(false);
                break;
            case 4:
                Hp5.SetActive(false);
                break;


            default:
                break;
        }
    }
}

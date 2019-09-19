using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]private Text text;
    void Start()
    {
        text.text = "Score: " + PlayerPrefs.GetInt("Score");
    }

}

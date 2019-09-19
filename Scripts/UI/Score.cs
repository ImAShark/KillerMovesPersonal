using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private float value,scoreTotal;
    private bool pLives = true;


    void Start()
    {
        var isAlive = GameObject.Find("Player").GetComponent<Health>();
        isAlive.DiesP += StopScore;
    }

    void Update()
    {
        if (pLives)
        {
            scoreTotal += Mathf.Ceil(value * Time.deltaTime);
            score.text = "score: " + scoreTotal;
        }
        else if(!pLives)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            SaveScore();
            gameObject.SetActive(false);
        }
        
    }

    private void StopScore()
    {
        pLives = false;
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", Mathf.RoundToInt(scoreTotal));
        if (PlayerPrefs.GetInt("HighScore") < scoreTotal)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(scoreTotal));
        }
        
    }

}

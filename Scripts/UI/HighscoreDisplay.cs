using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{
    public Text HighScoreText;

    void Start()
    {
        HighScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
    }

}

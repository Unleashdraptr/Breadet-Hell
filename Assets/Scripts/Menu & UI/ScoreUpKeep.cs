using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpKeep : MonoBehaviour
{
    public int Score;
    public int ConScore;

    public Text ScoreText;
    public Text ConScoreText;
    void Update()
    {
        //Updates the score everytime an enemy is killed
        ScoreText.text = Score.ToString("000000");
        ConScoreText.text = ConScore.ToString("000000");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpKeep : MonoBehaviour
{
    public int Score;
    public int ConScore;
    void Update()
    {
        //Updates the score everytime an enemy is killed
        transform.GetChild(2).GetChild(2).GetComponent<Text>().text = Score.ToString("000000");
        transform.GetChild(2).GetChild(3).GetComponent<Text>().text = ConScore.ToString("000000");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpKeep : MonoBehaviour
{
    public int Score;
    void Update()
    {
        //Updates the score everytime an enemy is killed
        transform.GetComponent<Text>().text = (Score.ToString("000000"));
    }
}

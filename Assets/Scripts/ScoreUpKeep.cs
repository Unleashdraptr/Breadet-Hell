using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpKeep : MonoBehaviour
{
    public int Score;
    void Update()
    {
        //Updates the score everytime an enemy is killed
        transform.GetComponent<TextMeshProUGUI>().text = ("Score: " + Score);
    }
}
